using EstateAgency.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstateAgency.Core.Services
{
    public interface IOwnerBL
    {
        IList<Owner> GetAllOwners();

        bool InsertOwner(Owner owner, out string err);

        bool UpdateOwner(Owner owner, out string err);

        Owner GetOwnerById(int ownerId);
    }
}
