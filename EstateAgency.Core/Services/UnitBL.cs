using EstateAgency.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstateAgency.Core.Services
{
    public class UnitBL : IUnitBL
    {
        public async Task<IList<Unit>> GetAllUnitsAsync()
        {
            using var ctx = new EstateAgencyDbContext();
            return await ctx.Units
                .Include(x => x.Owner)
                .OrderBy(x => x.DataIns).ToListAsync();
        }

        public async Task<Unit> GetUnitByIdAsync(int unitId)
        {
            using var ctx = new EstateAgencyDbContext();
            return await ctx.Units.FindAsync(unitId);
        }

        public IList<Unit> GetUnitsByOwnerCode(int ownerCode)
        {
            using var ctx = new EstateAgencyDbContext();
            var query = ctx.Units
                .Where(x => x.OwnerId == ownerCode)
                .OrderBy(x => x.DataIns);
            return query.ToList();
        }

        public async Task<IList<Unit>> GetUnitsByTypeAsync(UnitType type)
        {
            using var ctx = new EstateAgencyDbContext();
            var query = ctx.Units
                .Where(x => x.Tipo == type)
                .OrderBy(x => x.DataIns);
            return await query.ToListAsync();
        }

        public bool InsertUnit(Unit unit, out string err)
        {
            err = null;
            if(unit == null)
            {
                err = "L'unità immobiliare è null";
                return false;
            }
            try
            {
                using var ctx = new EstateAgencyDbContext();
                ctx.Units.Add(unit);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return false;
        }

        public bool UpdateUnit(Unit unit, out string err)
        {
            err = null;
            try
            {
                using var ctx = new EstateAgencyDbContext();
                ctx.Units.Update(unit);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return false;
        }

        public bool UpdateUnitStatus(int unitCode, UnitStatus newStatus, out string err)
        {
            err = null;
            var unit = GetUnitByIdAsync(unitCode).Result;
            if(unit == null)
            {
                err = "Immobile non trovato: " + unitCode;
                return false;
            }
            unit.Status = newStatus;
            return UpdateUnit(unit, out err);
        }
    }
}
