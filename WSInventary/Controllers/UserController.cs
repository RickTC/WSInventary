using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSInventary.Model;
using WSInventary.Model.Response;
using WSInventary.Model.ViewModels;
namespace WSInventary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get() 
        {
            Response oResponse = new Response();
            try
            {
                using(inventaryContext db = new inventaryContext())
                {
                    var listUser = db.Usuario.ToList();
                    oResponse.Success = 1;
                    oResponse.Data = listUser;
                }
            }
            catch(Exception ex)
            {
                oResponse.Message = ex.Message;
            }
            
            return Ok(oResponse);
        }

        [HttpPost]
        public IActionResult Add(UserViewModel model)
        {
            Response oReponse = new Response();

            try
            {
                using (inventaryContext db = new inventaryContext()) {

                    Usuario oUser = new Usuario {
                        CompletName = model.CompletName,
                        UserName = model.UserName,
                        Password = model.Password,
                        IdProfile = model.IdProfile,
                        IdStatus = model.IdStatus,
                        RegisterDate = DateTime.Now
                    };

                    db.Add(oUser);
                    db.SaveChanges();
                    oReponse.Success = 1;
                }
            }
            catch(Exception ex)
            {
                oReponse.Message = ex.Message;
            }

            return Ok(oReponse);
        }

        [HttpPut]
        public IActionResult Update(UserViewModel model)
        {
            Response oReponse = new Response();

            try
            {
                using (inventaryContext db = new inventaryContext())
                {


                    Usuario oUser = db.Usuario.Find(model.Id);
                    oUser.CompletName = model.CompletName;
                    oUser.UserName = model.UserName;
                    oUser.Password = model.Password;
                    oUser.IdProfile = model.IdProfile;
                    oUser.IdStatus = model.IdStatus;
                        

                    db.Entry(oUser).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();
                    oReponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oReponse.Message = ex.Message;
            }

            return Ok(oReponse);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Response oReponse = new Response();

            try
            {
                using (inventaryContext db = new inventaryContext())
                {


                    Usuario oUser = db.Usuario.Find(id);
                    db.Remove(oUser);
                    db.SaveChanges();
                    oReponse.Success = 1;
                }
            }
            catch (Exception ex)
            {
                oReponse.Message = ex.Message;
            }

            return Ok(oReponse);
        }
    }
}