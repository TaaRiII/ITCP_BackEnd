using ITCPBackend.Data;
using ITCPBackend.DTOs;
using ITCPBackend.Helper;
using ITCPBackend.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Bson;

namespace ITCPBackend.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ITCPBackendContext _dbcontext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ApplicationController(ITCPBackendContext dbcontext, IWebHostEnvironment webHostEnvironment)
        {
            _dbcontext = dbcontext;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateGenCompInfo(GenComInfo comInfo, int ClientId)
        {
            var CompanyInfoExist = await _dbcontext.genComInfos.Where(x => x.Id == comInfo.Id).FirstOrDefaultAsync();
            string message = "";
            if (CompanyInfoExist == null)
            {
                comInfo.CreatedBy = "system";
                comInfo.CreatedDate = DateTime.Now;
                comInfo.ClientId = ClientId;
                _dbcontext.genComInfos.Add(comInfo);
                _dbcontext.SaveChanges();
                message = "User " + Constants.message.AddMessage;
            }
            else
            {
                comInfo.ModifyBy = "system";
                comInfo.ModifyDate = DateTime.Now;
                comInfo.ClientId = ClientId;
                _dbcontext.genComInfos.Update(comInfo);
                _dbcontext.SaveChanges();
                message = "User " + Constants.message.UpdateMessage;
            }
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateShareholder(Shareholder modelObj, int ClientId)
        {
            var objExist = await _dbcontext.shareholders.Where(x => x.Id == modelObj.Id).FirstOrDefaultAsync();
            string message = "";
            if (objExist == null)
            {
                modelObj.CreatedBy = "system";
                modelObj.CreatedDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.shareholders.Add(modelObj);
                _dbcontext.SaveChanges();
                message = "ShareHolder " + Constants.message.AddMessage;
            }
            else
            {
                modelObj.ModifyBy = "system";
                modelObj.ModifyDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.shareholders.Update(modelObj);
                _dbcontext.SaveChanges();
                message = "ShareHolder " + Constants.message.UpdateMessage;
            }
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateCompContactPerson(CompanyContactPerson modelObj, int ClientId)
        {
            var objExist = await _dbcontext.companyContactPeople.Where(x => x.Id == modelObj.Id).FirstOrDefaultAsync();
            string message = "";
            if (objExist == null)
            {
                modelObj.CreatedBy = "system";
                modelObj.CreatedDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.companyContactPeople.Add(modelObj);
                _dbcontext.SaveChanges();
                message = "Company Contact Person " + Constants.message.AddMessage;
            }
            else
            {
                modelObj.ModifyBy = "system";
                modelObj.ModifyDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.companyContactPeople.Update(modelObj);
                _dbcontext.SaveChanges();
                message = "Company Contact Person " + Constants.message.UpdateMessage;
            }
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateBusinessType(BussinessType modelObj, int ClientId)
        {
            var objExist = await _dbcontext.bussinessTypes.Where(x => x.Id == modelObj.Id).FirstOrDefaultAsync();
            string message = "";
            if (objExist == null)
            {
                modelObj.CreatedBy = "system";
                modelObj.CreatedDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.bussinessTypes.Add(modelObj);
                _dbcontext.SaveChanges();
                message = "Company Contact Person " + Constants.message.AddMessage;
            }
            else
            {
                modelObj.ModifyBy = "system";
                modelObj.ModifyDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.bussinessTypes.Update(modelObj);
                _dbcontext.SaveChanges();
                message = "Company Contact Person " + Constants.message.UpdateMessage;
            }
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateEmployees(Employee modelObj, int ClientId)
        {
            var objExist = await _dbcontext.employees.Where(x => x.Id == modelObj.Id).FirstOrDefaultAsync();
            string message = "";
            if (objExist == null)
            {
                modelObj.CreatedBy = "system";
                modelObj.CreatedDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.employees.Add(modelObj);
                _dbcontext.SaveChanges();
                message = "Employee " + Constants.message.AddMessage;
            }
            else
            {
                modelObj.ModifyBy = "system";
                modelObj.ModifyDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.employees.Update(modelObj);
                _dbcontext.SaveChanges();
                message = "Employee " + Constants.message.UpdateMessage;
            }
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateManagement(Management modelObj, int ClientId)
        {
            var objExist = await _dbcontext.managements.Where(x => x.Id == modelObj.Id).FirstOrDefaultAsync();
            string message = "";
            if (objExist == null)
            {
                modelObj.CreatedBy = "system";
                modelObj.CreatedDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.managements.Add(modelObj);
                _dbcontext.SaveChanges();
                message = "Managment Team Member " + Constants.message.AddMessage;
            }
            else
            {
                modelObj.ModifyBy = "system";
                modelObj.ModifyDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.managements.Update(modelObj);
                _dbcontext.SaveChanges();
                message = "Managment Team Member " + Constants.message.UpdateMessage;
            }
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateServiceCategory(ServiceCategory modelObj, int ClientId)
        {
            var objExist = await _dbcontext.serviceCategories.Where(x => x.Id == modelObj.Id).FirstOrDefaultAsync();
            string message = "";
            if (objExist == null)
            {
                modelObj.CreatedBy = "system";
                modelObj.CreatedDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.serviceCategories.Add(modelObj);
                _dbcontext.SaveChanges();
                message = "Service Category " + Constants.message.AddMessage;
            }
            else
            {
                modelObj.ModifyBy = "system";
                modelObj.ModifyDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                _dbcontext.serviceCategories.Update(modelObj);
                _dbcontext.SaveChanges();
                message = "Service Category " + Constants.message.UpdateMessage;
            }
            return Ok(message);
        }
        [HttpPost]
        public async Task<IActionResult> AddUpdateFiles([FromForm] FileUploadModel modelObj, int ClientId)
        {
            var objExist = await _dbcontext.fileUploads.Where(x => x.Id == modelObj.Id).FirstOrDefaultAsync();
            string message = "";
            if (objExist == null)
            {
                FileUpload fileUpload = new FileUpload()
                {
                    BPP = modelObj.BPP != null ? UploadedFile(modelObj.BPP) : "",
                    PENCOM = modelObj.PENCOM != null ? UploadedFile(modelObj.PENCOM) : "",
                    ITF = modelObj.ITF != null ? UploadedFile(modelObj.ITF) : "",
                    NSITF = modelObj.NSITF != null ? UploadedFile(modelObj.NSITF) : "",
                    AUDITED = modelObj.AUDITED != null ? UploadedFile(modelObj.AUDITED) : "",
                    CAC = modelObj.CAC != null ? UploadedFile(modelObj.CAC) : "",
                    PC = modelObj.PC != null ? UploadedFile(modelObj.PC) : "",
                    CV = modelObj.CV != null ? UploadedFile(modelObj.CV) : "",
                    ClientId = ClientId
                };
                //modelObj.CreatedBy = "system";
                //modelObj.CreatedDate = DateTime.Now;
                modelObj.ClientId = ClientId;
                //modelObj.BPP = UploadedBPPFile(modelObj.BPP);
                _dbcontext.fileUploads.Add(fileUpload);
                _dbcontext.SaveChanges();
                message = "Service Category " + Constants.message.AddMessage;
            }
            else
            {
                //modelObj.ModifyBy = "system";
                //modelObj.ModifyDate = DateTime.Now;
                FileUpload fileUpload = new FileUpload()
                {
                    Id = modelObj.Id,
                    BPP = modelObj.BPP != null ? UploadedFile(modelObj.BPP) : "",
                    PENCOM = modelObj.PENCOM != null ? UploadedFile(modelObj.PENCOM) : "",
                    ITF = modelObj.ITF != null ? UploadedFile(modelObj.ITF) : "",
                    NSITF = modelObj.NSITF != null ? UploadedFile(modelObj.NSITF) : "",
                    AUDITED = modelObj.AUDITED != null ? UploadedFile(modelObj.AUDITED) : "",
                    CAC = modelObj.CAC != null ? UploadedFile(modelObj.CAC) : "",
                    PC = modelObj.PC != null ? UploadedFile(modelObj.PC) : "",
                    CV = modelObj.CV != null ? UploadedFile(modelObj.CV) : "",
                    ClientId = ClientId
                };
                _dbcontext.fileUploads.Update(fileUpload);
                _dbcontext.SaveChanges();
                message = "Service Category " + Constants.message.UpdateMessage;
            }
            return Ok(message);
        }
        #region Function
        //[NonAction]
        //private string UploadedFile(f model)
        //{
        //    string uniqueFileName = null;

        //    if (model.ImageFile != null)
        //    {
        //        string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ImageFile.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.ImageFile.CopyTo(fileStream);
        //        }
        //    }
        //    return uniqueFileName;
        //}
        private string UploadedFile(IFormFile file)
        {
            string uniqueFileName = null;
            string ext = "";
            if (file != null)
            {
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
                ext = System.IO.Path.GetExtension(file.FileName);
                uniqueFileName = Guid.NewGuid().ToString();
                string filePath = Path.Combine(uploadsFolder, string.Format(uniqueFileName.ToString() + ext));
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return string.Format(uniqueFileName.ToString() + ext);
        }
        #endregion

    }
}
