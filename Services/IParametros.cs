using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IParametros
    {
        public void Create(string connstring);
        public string GetConnString();
    }
}
