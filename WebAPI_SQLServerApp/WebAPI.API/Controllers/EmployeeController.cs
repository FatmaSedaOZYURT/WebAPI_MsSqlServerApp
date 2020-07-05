using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using WebAPI.API.Attributes;
using WebAPI.API.Security;
using WebAPI.DAL;
using WebAPI.DAL.Model;

namespace WebAPI.API.Controllers
{
    //[ApiExceptionAttribute]
    public class EmployeeController : ApiController
    {
        EntitiesDAL entitiesDAL = new EntitiesDAL();
        //public HttpResponseMessage Get()
        [ResponseType(typeof(IEnumerable<EmployeeModel>))]
        //[NonAction]
        public IHttpActionResult Get()
        {
            //try
            //{
                List<EmployeeModel> employees = entitiesDAL.GetEmployees().ToList();
                //return Request.CreateResponse(HttpStatusCode.OK,employees);
                return Ok(employees);
            //}
            //catch (Exception ex)
            //{
            //    HttpResponseMessage errorResponse = new HttpResponseMessage(HttpStatusCode.BadGateway);
            //    errorResponse.ReasonPhrase = ex.Message;
            //    throw new HttpResponseException(errorResponse); 
            //}
        }
        [ResponseType(typeof(EmployeeModel))]
        [APIAuthorized(Roles ="admin")]
        public IHttpActionResult Get(int id)
        {
            EmployeeModel emp = entitiesDAL.GetEmployeeByID(id);
            if (emp == null)
            {
                //return Request.CreateResponse(HttpStatusCode.NotFound, "Kayıt bulunamamıştır.");
                return NotFound();
            }
            //return Request.CreateResponse(HttpStatusCode.OK, emp);
            return Ok(emp);
        }
        [ResponseType(typeof(Employee))]
        public IHttpActionResult Post(Employee employee)
        {
            try
            {
                Employee emp = entitiesDAL.AddEmployee(employee);
                //return Request.CreateResponse(HttpStatusCode.Created, employee);
                return CreatedAtRoute("DefaultApi", new { id = emp.EmployeeID }, emp);
            }
            catch (Exception ex)
            {
                //return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return BadRequest(ex.Message);
            }
        }
        [ResponseType(typeof(Employee))]
        public IHttpActionResult Put(Employee employee)
        {
            try
            {
                Employee emp = entitiesDAL.UpdateEmployee(employee);
                //return Request.CreateResponse(HttpStatusCode.OK, emp);
                return Ok(emp);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Kayıt bulunamadı.")
                {
                    //return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
                    return NotFound();
                }
                //return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
                return BadRequest(ex.Message);
            }
        }
        public IHttpActionResult Delete(Employee employee)
        {
            try
            {
                Employee emp = entitiesDAL.DeleteEmployee(employee);
                //return Request.CreateResponse(HttpStatusCode.OK, "Veri silindi.");
                //return Ok();
                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                //return Request.CreateResponse(HttpStatusCode.NotFound, ex.Message);
                return NotFound();
            }
        }
        [HttpGet]
        public IHttpActionResult SearchByName(string name)
        {
            return Ok("Name: " + name);
        }


    }
}
