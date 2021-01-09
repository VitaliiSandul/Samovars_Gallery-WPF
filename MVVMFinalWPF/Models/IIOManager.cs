using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMFinalWPF.Models
{
    public interface IIOManager<T>
    {
        T Load(string path);
        void Save(T data, string path);
    }
}
