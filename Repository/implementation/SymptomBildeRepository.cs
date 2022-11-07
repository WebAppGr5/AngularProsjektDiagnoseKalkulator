﻿using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;
using System.Linq;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class SymptomBildeRepository : ISymptomBildeRepository
    {
        private ApplicationDbContext db;

        public SymptomBildeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }


        public async  Task<List<SymptomBilde>> hentSymptomBilder(List<SymptomDTO> symptomer)
        {
            List<int> symptomIdEnTrenger = symptomer.ConvertAll((x) => x.id).ToList();

        
            List<SymptomBilde> symptomBilder = db.symptomBilde.ToList();
            List<SymptomBilde> tilRetunering = new List<SymptomBilde>();

            foreach (var symptomBilde in symptomBilder)
            {
                int counter = 0;

                //Med spesifikt symptombilde
                List<int> syptomIder = db.symptomSymptomBilde.Where((x) => x.symptomBildeId == symptomBilde.symptomBildeId).ToList().ConvertAll((x) => x.symptomId);
                foreach (int symptomId in syptomIder)
                {
                    if (symptomIdEnTrenger.Contains(symptomId))
                    {
                        int varighetOppMotSymptomBilde = db.symptomSymptomBilde.Where((x) => x.symptomId == symptomId && x.symptomBildeId == symptomBilde.symptomBildeId).First().varighet;
                        SymptomDTO symptomDTO = symptomer.Where((x) => x.id == symptomId).First();
                        if(varighetOppMotSymptomBilde <= symptomDTO.varighet)
                        {
                            counter++;
                        }
                    }
                     

                    if (counter == symptomIdEnTrenger.Count)
                    {

                        tilRetunering.Add(symptomBilde);
                        break;
                    }
                }
            }

            return tilRetunering;
        }

    }
}
