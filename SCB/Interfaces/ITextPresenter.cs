using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCB.Interfaces
{
    public interface ITextPresenter<T>
    {
        string Present(T Input);
    }
}
