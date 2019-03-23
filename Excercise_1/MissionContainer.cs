using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excercise_1
{
    public delegate double FunctionDelegate(double num);
    
    //a container for functions F:R->R, key is string
    public class FunctionsContainer
    {
        private Dictionary<String, FunctionDelegate> dict;
        //constructor
        public FunctionsContainer()
        {
            dict = new Dictionary<string, FunctionDelegate>();
        }
   
        //the indexer
        public FunctionDelegate this[String key]
        {
            get
            {
                //if the key exist return the right function
                if (dict.ContainsKey(key))
                {
                    return dict[key];
                }
                //else, add and return the self function
                else
                {
                    dict.Add(key, x => x);
                    return x => x;
                }
            }
            set
                //if exist change and if not, create.
            {
                if (dict.ContainsKey(key))
                {
                    dict[key] = value;
                }
                else
                {
                    dict.Add(key, value);
                }
            }
        }
        //return a list of all the functions names
        public List<String> GetAllMissions()
        {
            return new List<string>(this.dict.Keys);
        }
    }
}
