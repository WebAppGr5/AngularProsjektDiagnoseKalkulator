﻿
using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Model.entities;
using System.Xml;
using DiagnoseKalkulatorAngular.Data;
using symptkalk.model;
using symptkalk.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace DiagnoseKalkulatorAngular.data
{

    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;
            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

            db.symptom.ToList().ForEach((x) => db.Remove(x));
            db.diagnose.ToList().ForEach((x) => db.Remove(x));
            db.diagnoseGruppe.ToList().ForEach((x) => db.Remove(x));
            db.symptomSymptomBilde.ToList().ForEach((x) => db.Remove(x));
            db.symptomGruppe.ToList().ForEach((x) => db.Remove(x));
            db.symptomBilde.ToList().ForEach((x) => db.Remove(x));
            db.brukerInfo.ToList().ForEach((x) => db.Remove(x));
            db.brukerLogin.ToList().ForEach((x) => db.Remove(x));

            db.SaveChanges();

            db.Database.OpenConnection();

            List<Diagnose> diagnoser;
            List<DiagnoseGruppe> diagnoseGrupper;
            List<Symptom> symptomer;
            List<SymptomGruppe> symptomGrupper;
            List<SymptomBilde> symptomBilder;
            List<SymptomSymptomBilde> symptomSymptomBilder;
            List<BrukerInfo> brukerInfo;
            List<BrukerLogIn> brukerLogIn;

            

            brukerInfo = new List<BrukerInfo>
            {
                new BrukerInfo
                {
                    etternavn = "per",
                    Fornavn = "jola",
                    ID = 1
                },
                new BrukerInfo
                {
                    etternavn = "ter",
                    Fornavn = "saga",
                    ID = 2
                }
            };
            brukerInfo.ForEach((x) => db.brukerInfo.Add(x));
            db.SaveChanges();


            brukerLogIn = new List<BrukerLogIn>
            {
                new BrukerLogIn
                {
                    brukernavn = "tora",
                    ID=1,
                    passord="123456"
                },
                new BrukerLogIn
                {
                    brukernavn = "tarfo",
                    ID=2,
                    passord="test1234"
                }
            };
            brukerLogIn.ForEach((x) => db.brukerLogin.Add(x));
            db.SaveChanges();

            diagnoseGrupper = new List<DiagnoseGruppe>
            {
                new DiagnoseGruppe
                {
                    diagnoseGruppeId=1,
                    beskrivelse="Hjerte problem",
                    navn="hjerte",
                    dypForklaring = "123"
                },
                new DiagnoseGruppe
                {
                    diagnoseGruppeId=2,
                    beskrivelse="Lunge problem",
                    navn="lunge",
                    dypForklaring = "123"
                },
                new DiagnoseGruppe
                {
                    diagnoseGruppeId=3,
                    beskrivelse="mage problem",
                    navn="mage",
                    dypForklaring = "123"
                },
                new DiagnoseGruppe
                {
                    diagnoseGruppeId=4,
                    beskrivelse="hud problem",
                    navn="hud",
                    dypForklaring = "123"
                }
            };
            diagnoseGrupper.ForEach((x) => db.diagnoseGruppe.Add(x));
            db.SaveChanges();

            symptomGrupper = new List<SymptomGruppe>
            {
                new SymptomGruppe
                {
                    symptomGruppeId=1,
                    beskrivelse="Hjerte problem",
                    navn="hjerte",
                    dypForklaring = "123"
                },
                new SymptomGruppe
                {
                    symptomGruppeId=2,
                    beskrivelse="Lunge problem",
                    navn="lunge",
                    dypForklaring = "123"
                },
                new SymptomGruppe
                {
                    symptomGruppeId=3,
                    beskrivelse="mage problem",
                    navn="mage",
                    dypForklaring = "123"
                }
                ,
                new SymptomGruppe
                {
                    symptomGruppeId=4,
                    beskrivelse="andre problem",
                    navn="annet",
                    dypForklaring = "123"
                }
            };
            symptomGrupper.ForEach((x) => db.symptomGruppe.Add(x));
            db.SaveChanges();


            diagnoser = new List<Diagnose>()
            {

                new Diagnose
                {
                    diagnoseId = 1,
                    beskrivelse = "vondt i venstre-del av hjerte",
                    diagnoseGruppeId = 1,
                    navn = "venstre-del hjerte sykdommen",
                    dypForklaring = "123"
                },
                      new Diagnose
                {
                  diagnoseId = 2,
                    beskrivelse = "vondt i høyre-del av hjerte",
                    diagnoseGruppeId = 1,
                    navn = "høyre-del hjerte sykdommen",
                    dypForklaring = "123"
                },
                            new Diagnose
                {
                    diagnoseId = 3,
                    beskrivelse = "vondt i venstre lunge",
                    diagnoseGruppeId = 2,
                    navn = "venstre lunge sykdom",
                    dypForklaring = "123"
                },      new Diagnose
                {
                    diagnoseId = 4,
                    beskrivelse = "vondt i høyre lunge",
                    diagnoseGruppeId = 2,
                    navn = "høyre lunge sykdom",
                    dypForklaring = "123"
                },      new Diagnose
                {
                    diagnoseId = 5,
                    beskrivelse = "vondt i tarm",
                    diagnoseGruppeId = 3,
                    navn = "tarm sykdommen",
                    dypForklaring = "123"
                },      new Diagnose
                {
                    diagnoseId = 6,
                    beskrivelse = "vondt i makesekk",
                    diagnoseGruppeId = 3,
                    navn = "magesekk sykdommen",
                    dypForklaring = "123"
                }
            };
            diagnoser.ForEach((x) => db.diagnose.Add(x));
            db.SaveChanges();

            symptomer = new List<Symptom>()
            {
                new Symptom
                {
                    beskrivelse = "problemet med syre",
                    navn = "syre problem i magesekk",
                    symptomId = 1,

                    symptomGruppeId =3,
                    dypForklaring = "123"
                },
                   new Symptom
                {
                    beskrivelse = "vondt i lunge",
                    navn = "vondt i lunge",
                    symptomId = 2,

                    symptomGruppeId= 2,
                    dypForklaring = "123"
                },   new Symptom
                {
                    beskrivelse = "vondt i mage",
                    navn = "vondt i mage",
                    symptomId = 3,

                    symptomGruppeId =3,
                    dypForklaring = "123"
                },   new Symptom
                {
                    beskrivelse = "vondt i hjerte",
                    navn = "vondt i hjerte",
                    symptomId = 4,
                   symptomGruppeId=1,
                   dypForklaring = "123"
                },   new Symptom
                {
                    beskrivelse = "har hodepine",
                    navn = "hodepine",
                    symptomId = 5,

                   symptomGruppeId=4,
                   dypForklaring = "123"
                },   new Symptom
                {
                    beskrivelse = "er kvalm",
                    navn = "opplever kvalme",
                    symptomId = 6,
                   symptomGruppeId=4,
                   dypForklaring = "123"
                }
            };
            symptomer.ForEach((x) => db.symptom.Add(x));
            db.SaveChanges();


            symptomBilder = new List<SymptomBilde>
            {
                new SymptomBilde
                {
                    diagnoseId = 1,
                    symptomBildeId = 1,
                    beskrivelse = "herte problem",
                    navn = "hjerte vansker",
                    dypForklaring = "123"
                },
                   new SymptomBilde
                {
                    diagnoseId = 4,
                    symptomBildeId = 2,
                    beskrivelse = "lunge problem",
                    navn = "lunge vansker",
                    dypForklaring = "123"
                },
                      new SymptomBilde
                {
                    diagnoseId = 1,
                    symptomBildeId = 3,
                    beskrivelse = "herte har fått hull",
                    navn = "hjerte vansker",
                    dypForklaring = "123"
                }, new SymptomBilde
                {
                    diagnoseId = 2,
                    symptomBildeId = 4,
                    beskrivelse = "lunge punktert",
                    navn = "lunge punktert",
                    dypForklaring = "123"
                },
                   new SymptomBilde
                {
                    diagnoseId = 3,
                    symptomBildeId = 5,
                    beskrivelse = "lunge problem",
                    navn = "lunge vansker",
                    dypForklaring = "123"
                },
                      new SymptomBilde
                {
                    diagnoseId = 5,
                    symptomBildeId = 6,
                    beskrivelse = "tarm har fått hull",
                    navn = "tarm vansker",
                    dypForklaring = "123"
                }, new SymptomBilde
                {
                    diagnoseId = 5,
                    symptomBildeId = 7,
                    beskrivelse = "tarm har tat fyr",
                    navn = "tarm brann",
                    dypForklaring = "123"
                }


            };
            symptomBilder.ForEach((x) => db.symptomBilde.Add(x));
            db.SaveChanges();

            symptomSymptomBilder = new List<SymptomSymptomBilde>
            {
                new SymptomSymptomBilde
                {
                    symptomBildeId = 7,
                                         varighet = 2,
                    symptomId =1
                },
                new SymptomSymptomBilde
                {
                    symptomBildeId = 6,
                                         varighet = 1,
                    symptomId =3
                },
                    new SymptomSymptomBilde
                {
                    symptomBildeId = 3,
                                         varighet =3,
                    symptomId =4
                },
                    new SymptomSymptomBilde
                {
                    symptomBildeId =5,
                                         varighet = 1,
                    symptomId =2
                },
                new SymptomSymptomBilde
                {
                    symptomBildeId = 1,
                                         varighet = 2,
                    symptomId =4
                },
                new SymptomSymptomBilde
                {
                    symptomBildeId = 6,
                                         varighet = 4,
                    symptomId =1
                }
        };
            symptomSymptomBilder.ForEach((x) => db.symptomSymptomBilde.Add(x));
            db.SaveChanges();

            return app;
        }
    }

}