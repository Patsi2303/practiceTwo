using PracticeTwo.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeTwo.BusinessLogic.Managers
{
    public class PatientManager
    {
        private List<Patient> _patients;

        public PatientManager()
        {
            _patients = new List<Patient>();

            _patients.Add(new Patient("Alejandro", "Uriarte", 123456));
        }

        public void AddPatient(string name, string lastname, int ci)
        {
            _patients.Add(new Patient(name, lastname, ci));
        }

        public void UpdatePatientByCI(int ci, string newName, string newLastname)
        {
            Patient patient = _patients.FirstOrDefault(p => p.CI == ci);
            if (patient != null)
            {
                patient.Name = newName;
                patient.Lastname = newLastname;
            }
            else
            {
                throw new InvalidOperationException("Patient not found");
            }
        }

        public void DeletePatientByCI(int ci)
        {
            Patient patient = _patients.FirstOrDefault(p => p.CI == ci);
            if (patient != null)
            {
                _patients.Remove(patient);
            }
            else
            {
                throw new InvalidOperationException("Patient not found");
            }
        }

        public List<Patient> GetPatients()
        {
            return _patients;
        }

        public Patient GetPatientByCI(int ci)
        {
            return _patients.FirstOrDefault(p => p.CI == ci);
        }
    }
}
