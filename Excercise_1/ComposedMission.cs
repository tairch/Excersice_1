using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public class ComposedMission : IMission
    {
        //public delegate double FunctionDelegate(double num);
        List<FunctionDelegate> funcList;
        public event EventHandler<double> OnCalculate;  // An Event of when a mission is activated
        readonly string name;
        //constructor
        public ComposedMission(string str)
        {
            funcList = new List<FunctionDelegate>();
            name = str;
        }
        public String Name
        {
            get
            {
                return name;
            }
        }
        public String Type
        {
            get
            {
                return "Composed";
            }
        }
        //add a function to the list
        public ComposedMission Add(FunctionDelegate func)
        {
            funcList.Add(func);
            return this;
        }
        //calculate the functions result with a value
        public double Calculate(double value)
        {
            double retValue = value;
            foreach (var func in funcList)
            {
                retValue = func(retValue);
            }
            //raise the event
            OnCalculate?.Invoke(this, retValue);
            return retValue;
        }
    }
}
