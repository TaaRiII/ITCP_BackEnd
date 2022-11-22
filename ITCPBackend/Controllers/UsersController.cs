using ITCPBackend.Data;
using ITCPBackend.DTOs;
using ITCPBackend.Helper;
using ITCPBackend.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using symphony_services.Helpers;
using System.Net.Mail;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using Microsoft.AspNetCore.Hosting;

namespace ITCPBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ITCPBackendContext _dbcontext;
        public UsersController(ITCPBackendContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        [HttpPost]
        public async Task<IActionResult> LoginUser(LoginModel login)
        {
            var loginUser = await _dbcontext.Users.Where(m => m.Username == login.username && m.Password == login.password && m.Status == Constants.Status.Active).FirstOrDefaultAsync();
            if (loginUser == null)
            {
                var message = "Your Username and Password are wrong try again.";
                return Ok(message);
            }
            else
            {
                var message = "You are login Successfully";
                string _token= JWTToken.Generate(loginUser);
                var userObj = new
                {
                    username = loginUser.Username,
                    name = loginUser.Name,
                    email = loginUser.Email,
                    role = int.Parse(loginUser.role) == 1 ? Constants.role.Client : "",
                };

                var responce = new ResponceModel()
                {
                    accesstoken = _token,
                    message = message,
                    user = userObj
                };
                return Ok(responce);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetUser(int id = 0)
        {
            var UsersList = await _dbcontext.Users.Where(m => id != 0 ? m.Id == id : true).ToListAsync();
            return Ok(UsersList);
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateUser(Users user)
        {
            if(user.Id != 0)
            {
                //Users userExist = _dbcontext.Users.Where(m => m.Id == user.Id).ToList();
                user.ModifyBy = "system";
                user.CreatedDate = DateTime.Now;
                _dbcontext.Users.Update(user);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                user.CreatedBy = "System";
                user.CreatedDate = DateTime.Now;
                _dbcontext.Users.Add(user);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateDepartment(Department obj)
        {
            if (obj.Id != 0)
            {
                obj.ModifyBy = "system";
                obj.CreatedDate = DateTime.Now;
                _dbcontext.departments.Update(obj);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                obj.CreatedBy = "System";
                obj.CreatedDate = DateTime.Now;
                _dbcontext.departments.Add(obj);
                await _dbcontext.SaveChangesAsync();
                return Ok();
            }
        }
        #region Client 
        [HttpPost]
        public IActionResult SignUpClient(SignupModel objModel)
        {
            string EncruptedString = objModel.Email + "&&$" + DateTime.Now + "&&$" + objModel.Password + "&&$" + objModel.Role;
            var Encrupted = Crypto.Encrypt(EncruptedString);
            string APIsString = "https://localhost:7231/api/users/verifyclient?emailToken=" + Encrupted;
            EmailSetting setting = new EmailSetting()
            {
                ToEmail = objModel.Email,
                TokenString = APIsString,
            };
            Client client = new Client()
            {
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                Email = objModel.Email,
                Password = objModel.Password,
                Name = objModel.Name,
                PhoneNumber = objModel.PhoneNumber,
                Username = objModel.Username,
                status = Constants.Status.InActive,
                Role = Constants.role.Client,
            };
            _dbcontext.clients.Add(client);
            _dbcontext.SaveChanges();
            SendEmail(setting);
            return Ok(APIsString);
        }
        [HttpPost]
        public IActionResult VerifyClient(string emailToken)
        {
            var encrupted = Crypto.Decrypt(emailToken);
            var TokenSplit = encrupted.Split("&&$");
            string Email = TokenSplit[0];
            DateTime TokenTime = DateTime.Parse(TokenSplit[1]);
            DateTime CurrentDate = DateTime.Now;
            DateTime FifteenMin = DateTime.Now.AddMinutes(15);
            var Message = "";
            if(CurrentDate >= TokenTime && TokenTime <= FifteenMin)
            {
                Message = "Token True";
                var ClientObj = _dbcontext.clients.Where(m => m.Email == Email).FirstOrDefault();
                ClientObj.ModifyBy = "Email Verification";
                ClientObj.ModifyDate = DateTime.Now;
                ClientObj.status = Constants.Status.Active;
                _dbcontext.clients.Update(ClientObj);
                _dbcontext.SaveChanges();
            }
            else
            {
                Message = "Token False";
            }
            return Ok(Message);
        }
        [HttpGet]
        public bool EmailValidation(string Email)
        {
            var CheckingEmail = _dbcontext.clients.Where(m => m.Email == Email).FirstOrDefault();
            if(CheckingEmail == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
        #region Email 
        [NonAction]
        public bool SendEmail(EmailSetting setting)
        {
            string username = "info@cloudhawktech.com";
            string password = "*?mD3NuO(8@8";
            ICredentialsByHost credentials = new NetworkCredential(username, password);

            SmtpClient smtpClient = new SmtpClient()
            {
                Host = "mail.cloudhawktech.com",
                Port = 25,
                EnableSsl = false,
                Credentials = credentials
            };
            StringBuilder sb = new StringBuilder();
            sb.Append("Hello!");
            sb.AppendLine("Thanks for make account on ITCP!");
            sb.AppendLine("If you want verify your account then click on blew link.");
            sb.AppendLine(setting.TokenString);
            sb.AppendLine("Regards");
            sb.AppendLine("ITCP Admin");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(username);
            mail.To.Add(setting.ToEmail);
            mail.Subject = "Verification Email For ITCP";
            mail.Body = sb.ToString();

            smtpClient.Send(mail);
            return true;
        }
        #endregion
    }
}
