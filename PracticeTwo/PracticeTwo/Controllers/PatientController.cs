using Microsoft.AspNetCore.Mvc;
using PracticeTwo.BusinessLogic.Managers;
using PracticeTwo.BusinessLogic.Models;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PracticeTwo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private PatientManager _patientManager;

        public PatientController(PatientManager patientManagerr)
        {
            _patientManager = patientManagerr;
        }

        // GET: api/<PatientController>
        [HttpGet]
        public List<Patient> Get()
        {
            return _patientManager.GetPatients();
        }

        // GET api/<PatientController>/5
        [HttpGet("{CI}")]
        public Patient Get(int CI)
        {
            return _patientManager.GetPatientByCI(CI);
        }

        // POST api/<PatientController>
        [HttpPost]
        public void Post(string name, string lastname, int CI)
        {
            _patientManager.AddPatient(name, lastname, CI);
        }

        // PUT api/<PatientController>/5
        [HttpPut("{CI}")]
        public void Put(int CI, string name, string lastname)
        {
            _patientManager.UpdatePatientByCI(CI, name, lastname);
        }

        // DELETE api/<PatientController>/5
        [HttpDelete("{CI}")]
        public void Delete(int CI)
        {
            _patientManager.DeletePatientByCI(CI);
        }
    }
}
