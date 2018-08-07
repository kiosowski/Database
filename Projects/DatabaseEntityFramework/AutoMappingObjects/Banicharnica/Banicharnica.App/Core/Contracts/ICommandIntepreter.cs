using System;
using System.Collections.Generic;
using System.Text;

namespace Banicharnica.App.Core.Contracts
{
    public interface ICommandIntepreter
    {
        string Read(string[] input);
    }
}
