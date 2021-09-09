using ApiPackExpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPackExpress.IServices
{
    public interface IBranchService
    {
        public List<Branch> getBranchs();
        public Branch getBranchById();

    }
}
