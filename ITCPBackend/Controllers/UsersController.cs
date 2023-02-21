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
                var RRole = "";
                if(loginUser.role == Constants.UserRoleInt.Management)
                {
                    RRole = Constants.UserRoleString.Management;
                }
                else if(loginUser.role == Constants.UserRoleInt.Secretariat)
                {
                    RRole = Constants.UserRoleString.Secretariat;
                }
                else if (loginUser.role == Constants.UserRoleInt.Committee)
                {
                    RRole = Constants.UserRoleString.Committee;
                }
                else
                {
                    RRole = Constants.UserRoleString.System;
                }
                var message = "You are login Successfully";
                string _token= JWTToken.Generate(loginUser);
                var userObj = new
                {
                    username = loginUser.Username,
                    name = loginUser.Name,
                    email = loginUser.Email,
                    role = RRole,
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
        [HttpGet]
        public async Task<IActionResult> GetClient(int id = 0)
        {
            var UsersList = await _dbcontext.clients.Where(m => id != 0 ? m.Id == id : true).ToListAsync();
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
        //[HttpPost]
        //public async Task<IActionResult> AddUpdateDepartment(Department obj)
        //{
        //    if (obj.Id != 0)
        //    {
        //        obj.ModifyBy = "system";
        //        obj.CreatedDate = DateTime.Now;
        //        _dbcontext.departments.Update(obj);
        //        await _dbcontext.SaveChangesAsync();
        //        return Ok();
        //    }
        //    else
        //    {
        //        obj.CreatedBy = "System";
        //        obj.CreatedDate = DateTime.Now;
        //        _dbcontext.departments.Add(obj);
        //        await _dbcontext.SaveChangesAsync();
        //        return Ok();
        //    }
        //}
        #region Client 
        [HttpPost]
        public IActionResult SignUpClient(SignupModel objModel)
        {
            Client client = new Client()
            {
                CreatedBy = "System",
                CreatedDate = DateTime.Now,
                Email = objModel.Email,
                Password = objModel.Password,
                Name = objModel.Name,
                PhoneNumber = objModel.PhoneNumber,
                Username = objModel.Username,
                status = Constants.Status.Active,
                Role = objModel.Role,
                MDAId = objModel.Role == Constants.ClientRoleInt.Entry ? objModel.MDAId : 0,
            };
            _dbcontext.clients.Add(client);
            _dbcontext.SaveChanges();
            //StringBuilder sb = new StringBuilder();
            //sb.AppendLine("Hello!");
            //sb.AppendLine("Dear your account on ITCP are created successfully below your credential!");
            //sb.AppendLine("Username:- " + objModel.Username);
            //sb.AppendLine("Password:- " + objModel.Password);
            //sb.AppendLine("Regards");
            //sb.AppendLine("ITCP Admin");
            //EmailSetting setting = new EmailSetting()
            //{
            //    ToEmail = objModel.Email,
            //    EmailString = sb.ToString(),
            //    EmailBody = "Account Create For ITCP",
            //};
            //SendEmail(setting);
            var msg = "User Added Successfully";
            return Ok(msg);
        }
        //[HttpPost]
        //public IActionResult SignUpClient(SignupModel objModel)
        //{
        //    string EncruptedString = objModel.Email + "&&$" + DateTime.Now + "&&$" + objModel.Password + "&&$" + objModel.Role;
        //    var Encrupted = Crypto.Encrypt(EncruptedString);
        //    string APIsString = "https://localhost:7231/api/users/verifyclient?emailToken=" + Encrupted;
        //    StringBuilder sb = new StringBuilder();
        //    sb.AppendLine("Hello!");
        //    sb.AppendLine("Thanks for make account on ITCP!");
        //    sb.AppendLine("If you want verify your account then click on blew link.");
        //    sb.AppendLine(APIsString);
        //    sb.AppendLine("Regards");
        //    sb.AppendLine("ITCP Admin");
        //    EmailSetting setting = new EmailSetting()
        //    {
        //        ToEmail = objModel.Email,
        //        EmailString = sb.ToString(),
        //        EmailBody = "Verification Email For ITCP",
        //    };
        //    Client client = new Client()
        //    {
        //        CreatedBy = "System",
        //        CreatedDate = DateTime.Now,
        //        Email = objModel.Email,
        //        Password = objModel.Password,
        //        Name = objModel.Name,
        //        PhoneNumber = objModel.PhoneNumber,
        //        Username = objModel.Username,
        //        status = Constants.Status.Active,
        //        Role = objModel.Role,
        //    };
        //    _dbcontext.clients.Add(client);
        //    _dbcontext.SaveChanges();
        //    SendEmail(setting);
        //    return Ok(APIsString);
        //}
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
        [HttpPost]
        public async Task<IActionResult> LoginClient(LoginModel login)
        {
            var loginClients = await _dbcontext.clients.Where(m => m.Username == login.username && m.Password == login.password && m.status == Constants.Status.Active).FirstOrDefaultAsync();
            if (loginClients == null)
            {
                var message = "Your Username and Password are wrong try again.";
                return Ok(message);
            }
            else
            {
                var RRole = "";
                if (loginClients.Role == Constants.ClientRoleInt.Entry)
                {
                    RRole = Constants.ClientRoleString.Entry;
                }
                else
                {
                    RRole = Constants.ClientRoleString.MasterMDA;
                }
                var message = "You are login Successfully";
                string _token = JWTToken.ClientGenerate(loginClients);
                var ClientObj = new
                {
                    username = loginClients.Username,
                    name = loginClients.Name,
                    email = loginClients.Email,
                    role = RRole,
                };

                var responce = new ResponceModel()
                {
                    accesstoken = _token,
                    message = message,
                    user = ClientObj
                };
                return Ok(responce);
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

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(username);
            mail.To.Add(setting.ToEmail);
            mail.Subject = setting.EmailBody;
            mail.Body = setting.EmailString;

            smtpClient.Send(mail);
            return true;
        }
        #endregion
        #region Client Forget Password
        [HttpPost]
        public IActionResult ForgetClient(string? email)
        {
            var UserObj =  _dbcontext.clients.Where(m => m.Email == email).FirstOrDefault();
            var message = "";
            if(UserObj != null)
            {
                string EncruptedString = UserObj.Email + "&&$" + DateTime.Now + "&&$" + UserObj.Id;
                var Encrupted = Crypto.Encrypt(EncruptedString);
                var en = Encrupted.Replace("+", "mdmd");
                string APIsString = "http://localhost:4200/create-password?Token=" + en;
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Dear!");
                sb.AppendLine("Member your forget password request for ITCP!");
                sb.AppendLine("If you want to reset your account then click on blew link.");
                sb.AppendLine(APIsString);
                sb.AppendLine("Regards");
                sb.AppendLine("ITCP Admin");
                EmailSetting setting = new EmailSetting()
                {
                    ToEmail = UserObj.Email,
                    EmailString = sb.ToString(),
                    EmailBody = "Forget Password Request of ITCP."
                };
                SendEmail(setting);
                message = "Email are send successfully.";
            }
            else
            {
                message = "Problem occure while sending email.";
            }
            return Ok(message);
        }
        [HttpPost]
        public IActionResult PasswordChange(PasswordModel login ,string Token)
        {
            var en = Token.Replace("mdmd", "+");
            var encrupted = Crypto.Decrypt(en);
            var TokenSplit = encrupted.Split("&&$");
            string Email = TokenSplit[0];
            int Id = int.Parse(TokenSplit[2]);
            DateTime TokenTime = DateTime.Parse(TokenSplit[1]);
            DateTime CurrentDate = DateTime.Now;
            DateTime FifteenMin = DateTime.Now.AddMinutes(15);
            var Message = "";
            if (CurrentDate >= TokenTime && TokenTime <= FifteenMin)
            {
                var ClientObj = _dbcontext.clients.Where(m => m.Email == Email && m.Id == Id).FirstOrDefault();
                if(ClientObj != null)
                {
                    ClientObj.ModifyBy = "Email Verification";
                    ClientObj.ModifyDate = DateTime.Now;
                    ClientObj.Password = login.password;
                    ClientObj.status = Constants.Status.Active;
                    _dbcontext.clients.Update(ClientObj);
                    _dbcontext.SaveChanges();
                    Message = "Password are change successfully";
                }
                else
                {
                    Message = "Forget Password False";
                }
            }
            else
            {
                Message = "Token False";
            }
            return Ok(Message);
        }
        #endregion


        [HttpGet]
        public string testt() {
            return "Api is ruiing123";
        }
        #region Get MDA LIst
        [HttpGet]
        public async Task<IActionResult> MDAUsersList()
        {
            var EntryList = _dbcontext.clients.Where(m => m.Role == Constants.ClientRoleInt.MasterMDA).ToList();
            return Ok(EntryList);
        }
        #endregion
    }
}
