using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using DiagnoseKalkulatorAngular.Data;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class BrukerRepository : IBrukerRepository
    {
        private ApplicationDbContext db;

        public BrukerRepository(ApplicationDbContext db)
        {
            this.db = db;
        }




    }
}