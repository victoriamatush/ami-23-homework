using RESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTAPI.Services
{
    public interface IGoodService
    {
        IEnumerable<Good> GetAll(string search, string sort_by,
           string sort_type, int offset, int limit);
        Good GetById(int id);
        void Post(Good g);
        void Put(Good g);
        void Delete(int id);
        bool Exist(int id);
        int Count();
    }
}
