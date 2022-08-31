using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Formulas_Generator.Math.Structure;

namespace Formulas_Generator.Math
{
    public class Generator
    {
        private int FinLen { get; set; }
        private int FinFormulaNum { get; set; }
        private int FinVarNum { get; set; }
        
        public Generator(int FinLen, int FinFormulaNum, int FinVarNum)
        {
            this.FinLen = FinLen;
            this.FinFormulaNum = FinFormulaNum;
            this.FinVarNum = FinVarNum;
        }

        private List<string> formulas = new List<string>();

        private static List<Val> vars = new List<Val>();

        private void setVars()
        {
            for (var i = 0; i < FinVarNum; i++)
            {
                var newVal = new Val("x" + i);
                newVal.LastIndex = i;
                vars.Add(newVal);
            }

        }

        public Task<List<string>> getLines()
        {
            var task = new Task<List<string>>(
                () =>
                {
                    setVars();
                    try
                    {
                        getFormulas(vars[0], vars.Count > 1 ? vars[1] : vars[0]);
                    }
                    catch (Exception e)
                    {
                        return formulas;
                    }
                    return formulas;
                }
            );
            task.Start();
            return task;
        }

        private void getFormulas(CustomStruct cs, CustomStruct v2)
        {
            if (formulas.Count >= FinFormulaNum)
            {
                throw new CustomAttributeFormatException("Лист заполнен");
            }

            if (cs.Len == FinLen)
            {
                formulas.Add(cs.ToString());
                return;
            }

            if (v2.Len == FinLen)
            {
                formulas.Add(cs.ToString());
                return;
            }

            if (cs.Len > FinLen)
            {
                return;
            }

            if (v2.Len > FinLen)
            {
                return;
            }

            var maxLastInd = System.Math.Max(cs.LastIndex, v2.LastIndex);
            var v3 = vars[(maxLastInd + 1) % FinVarNum];
            
            getFormulas(new And(cs, v2), v3);
            getFormulas(new Or(cs, v2), v3);
            getFormulas(new Implies(cs, v2), v3);
            getFormulas(new Equivalent(cs, v2), v3);
            
            getFormulas(new And(v2, cs), v3);
            getFormulas(new Or(v2, cs), v3);
            getFormulas(new Implies(v2, cs), v3);
            getFormulas(new Equivalent(v2, cs), v3);
            
            if (cs.GetType() != typeof(Not))
            {
                getFormulas(new Not(cs), v2);
            }
            
            if (v2.GetType() != typeof(Not))
            {
                getFormulas(new Not(v2), cs);
            }
        }
    }
}