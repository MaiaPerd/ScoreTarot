using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Interface;

namespace Model
{
    public class SingletonICalculator
    {
        private ICalculator calculator;

        public ICalculator GetCalculator()
        {
            if (calculator == null)
                calculator = new Calculator();
            return this.calculator;
        }
    }
}
