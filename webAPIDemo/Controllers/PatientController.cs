using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAPIDemo.Models;

namespace webAPIDemo.Controllers
{
    public class PatientController : ApiController
    {

        List<PatientModel> patients = new List<PatientModel>() { new PatientModel() { ID = 5, Name = "Amr" } };

        /// <summary>
        /// This method returns Hello world
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<PatientModel> GetAllPatients()
        {
            return patients;

        }

        [HttpGet]
        public IHttpActionResult GetPatient(int id)
        {
            var patient = patients.Where(x => x.ID == id).FirstOrDefault();

            if (patient is null)
            {
                return NotFound();
            }
            else
            {
                return Ok<PatientModel>(patient);
            }
        }

        [HttpPost]
        public IHttpActionResult PostPatient([FromBody] PatientModel patient)
        {
            if (ModelState.IsValid)
            {
                if (patients.Any(x => x.ID == patient.ID))
                {
                    return Conflict();
                }
                else
                {
                    return Ok(patient);
                }
            }
            return BadRequest("not valid");
        }
    }
}
