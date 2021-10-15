using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public List<OperationClaim> GetOperationClaims(int userId)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from o in context.OperationClaims
                             join u in context.UserOperationClaims on o.Id equals u.OperationClaimId
                             where u.UserId == userId
                             select new OperationClaim
                             {Id=o.Id,
                             Name=o.Name
                             };
                return result.ToList();
            }
        }
    }
}
