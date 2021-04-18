using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApplicationLayer.Controllers
{
    
    public class ClientInformationController : ApiController
    {
        [HttpPost]
        [Route("api/ClientInformation/AddClientInformation")]
  
        public IHttpActionResult AddClientInformation(DAL.Models.ClientInformation model)
        {

            try
            {
                var service = new DAL.Services.ClientInformationService();

                var clientInformationID = service.AddClientInformation(model);

                    return Ok(clientInformationID);
               
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Route("api/ClientInformation/GetAllClientInformation")]

        public IHttpActionResult GetAllClientInformation()
        {

            try
            {
                var service = new DAL.Services.ClientInformationService();

                var clientInformation = service.GetAllClientInformation();

                return Ok(clientInformation);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("api/ClientInformation/UpdateClientInformation")]

        public IHttpActionResult UpdateClientInformation(DAL.Models.ClientInformation model)
        {

            try
            {
                var service = new DAL.Services.ClientInformationService();

                service.UpdateClientInformation(model);

                return Ok("Success");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        [HttpPost]
        [Route("api/ClientInformation/GetClientInformation")]

        public IHttpActionResult GetClientInformation(DAL.Models.ClientInformation model)
        {

            try
            {
                var service = new DAL.Services.ClientInformationService();

                var clientInformation = service.GetClientInformation(model.ClientInformationID);

                if(clientInformation == null)
                {
                    return NotFound();
                }

                return Ok(clientInformation);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
