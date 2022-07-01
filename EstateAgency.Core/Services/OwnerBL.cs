using EstateAgency.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace EstateAgency.Core.Services
{
    public class OwnerBL : IOwnerBL
    {
        public IList<Owner> GetAllOwners()
        {
            using var ctx = new EstateAgencyDbContext();
            var query = ctx.Owners.OrderBy(x => x.Cognome).ThenBy(x => x.Nome);
            return query.ToList();
        }

        public Owner GetOwnerById(int ownerId)
        {
            using var ctx = new EstateAgencyDbContext();
            return ctx.Owners.Find(ownerId);
        }

        public bool InsertOwner(Owner owner, out string err)
        {
            err = null;
            try
            {
                using var ctx = new EstateAgencyDbContext();
                ctx.Owners.Add(owner);
                ctx.SaveChanges();
                return true;
            }catch(Exception ex)
            {
                err = ex.Message;
            }
            return false;
        }

        public bool UpdateOwner(Owner owner, out string err)
        {
            err = null;
            try
            {
                using var ctx = new EstateAgencyDbContext();
                ctx.Owners.Update(owner);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                err = ex.Message;
            }
            return false;
        }
    }
}
