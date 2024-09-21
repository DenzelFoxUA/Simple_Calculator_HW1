using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_One_Calculator
{
    public abstract class ButtonModel
    {
        public abstract string Name { get; protected set; }
        public abstract char Key { get; protected set; }

        public override string ToString()
        {
            return $"{Name}";
        }
    }

    public class Button: ButtonModel
    {
        public override string Name { get; protected set; }
        public override char Key { get; protected set; }

        private Button() 
        { 
            Name = "button";
            Key = '`';
        }

        public Button(string name, char key)
        {
            Name = name;
            Key = key;
        }

        public override string ToString() 
        {
            return $"[{Key}] - {Name}";
        }
    }
}
