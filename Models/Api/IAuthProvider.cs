using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Api;

public interface IAuthProvider
{
    IAuth GetAuth();
}
