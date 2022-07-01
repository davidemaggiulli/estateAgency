using EstateAgency.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstateAgency.Core.Services
{
    public interface IUnitBL
    {
        Task<IList<Unit>> GetAllUnitsAsync();

        Task<IList<Unit>> GetUnitsByTypeAsync(UnitType type);

        IList<Unit> GetUnitsByOwnerCode(int ownerCode);

        bool InsertUnit(Unit unit, out string err);

        bool UpdateUnit(Unit unit, out string err); 

        bool UpdateUnitStatus(int unitCode, UnitStatus newStatus, out string err);

        Task<Unit> GetUnitByIdAsync(int unitId);
    }
}
