using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVC.Models
{
    public interface IEditable
    {
      bool Insert(AbstractModel data);

      bool Update(int id, AbstractModel data);
    }
}
