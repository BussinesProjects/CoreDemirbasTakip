using DemirbasTakipSistemi.Models;
using DemirbasTakipSistemi.Models.DataModel;
using System.Collections.Generic;
using System.Linq;

namespace DemirbasTakipSistemi.Repositories
{
    public class AccountRepository : Repository<Login>
    {
        Context context = new Context();
        public Login getUser(string username,string password)
        {
          return context.Set<Login>().Where(x=> x.Username==username && x.Password==password && x.isEnabled ).FirstOrDefault();
        }
        public List<Login> getNotAdmin()
        {
            return context.Set<Login>().ToList();
        }
        
    }
}
