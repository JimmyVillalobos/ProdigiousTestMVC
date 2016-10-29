using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMVC.Models
{
    public interface IReadable
    {

        List<AbstractModel> List();
        AbstractModel Get(int id);


    }
}
