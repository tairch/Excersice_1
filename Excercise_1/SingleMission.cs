using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class SingleMission : IMission
    {
        //public delegate double FunctionDelegate(double num);
        //SingleMission sqrtMission = new SingleMission(funcList["Sqrt"], "SqrtMission");
        // An Event of when a mission is activated
        public event EventHandler<double> OnCalculate;
        readonly FunctionDelegate func;
        readonly string name;
        //constructor
        public SingleMission(FunctionDelegate function, string str)
        {
            func = function;
            name = str;
        }
        public String Name {
            get
            {
                return name;
            }
        }
        public String Type
        {
            get
            {
                return "Single";
            }
        }

        public double Calculate(double value)
        {
            //calculate
            double ret = func(value);
            //raise the event
            OnCalculate?.Invoke(this, ret);
            return ret;
        }
    }
}
