using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AutoCadConvert.Bussiness
{
    public class Rules
    {
        Hashtable convertRules = new Hashtable();
        

        public void SetRules(string oldNum, string newNum)
        {
            convertRules.Add(oldNum, newNum);
        }

        public Hashtable GetRules()
        {
            return convertRules;
        }
    }
}
