using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Formulas_Generator.Math.Structure;
using Formulas_Generator.Menu;

namespace Formulas_Generator.Math
{
    public class Generator
    {
        private int FinLen { get; }
        private int FinFormulaNum { get; }
        private int FinVarNum { get; }
        
        public Generator(int finLen, int finFormulaNum, int finVarNum)
        {
            FinLen = finLen;
            FinFormulaNum = finFormulaNum;
            FinVarNum = finVarNum;
        }

        private List<string> Formulas = new List<string>();
        private static List<Val> Vars = new List<Val>();
        private static List<string> Operations = new List<string>();

        private void setVars()
        {
            for (var i = 0; i < FinVarNum; i++)
            {
                var newVal = new Val("x");
                newVal.LastIndex = i;
                Vars.Add(newVal);
            }
        }

        public static void setOperations(IEnumerable<string> op)
        {
            Operations.AddRange(op);
        }

        public Task<List<string>> getLines()
        {
            var task = new Task<List<string>>(
                () =>
                {
                    setVars();
                    try
                    {
                        getFormulas(Vars[0], Vars.Count > 1 ? Vars[1] : Vars[0]);
                        getFormulas2(Vars[0], Vars.Count > 1 ? Vars[1] : Vars[0]);
                    }
                    catch (Exception e)
                    {
                        return Formulas.Select(x => x.formatString()).ToList();
                    }

                    return Formulas.Select(x => x.formatString()).ToList();
                }
            );
            task.Start();
            return task;
        }

        private void getFormulas(CustomStruct cs, CustomStruct v2)
        {
            if (Formulas.Count >= FinFormulaNum)
                throw new CustomAttributeFormatException("Лист заполнен");
            
            if (Operations.Contains(cs.GetType().Name) || Operations.Contains(v2.GetType().Name))
                return;
            
            if (cs.Len == FinLen)
            {
                foreach (var s in cs.ToString().Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (Formulas.Contains(s)) continue;
                    Formulas.Add(s);
                }
                return;
            }
            
            if (v2.Len == FinLen)
            {

                foreach (var s in v2.ToString().Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (Formulas.Contains(s)) continue;
                    Formulas.Add(s);
                }
                return;
            }
            
            if (cs.Len > FinLen || v2.Len > FinLen)
                return;

            var maxLastInd = System.Math.Max(cs.LastIndex, v2.LastIndex);
            var v3 = Vars[(maxLastInd + 1) % FinVarNum];
            var v4 = Vars[(maxLastInd + 2) % FinVarNum];
            
            getFormulas(cs, new And(v2, v3));
            getFormulas(cs, new Or(v2, v3));
            getFormulas(cs, new Implies(v2, v3));
            getFormulas(cs, new Equivalent(v2, v3));

            getFormulas(new And(cs, v2), new And(v3, v4));
            getFormulas(new And(cs, v2), new Or(v3, v4));
            getFormulas(new And(cs, v2), new Implies(v3, v4));
            getFormulas(new And(cs, v2), new Equivalent(v3, v4));

            getFormulas(new Or(cs, v2), new And(v3, v4));
            getFormulas(new Or(cs, v2), new Or(v3, v4));
            getFormulas(new Or(cs, v2), new Implies(v3, v4));
            getFormulas(new Or(cs, v2), new Equivalent(v3, v4));

            getFormulas(new Implies(cs, v2), new And(v3, v4));
            getFormulas(new Implies(cs, v2), new Or(v3, v4));
            getFormulas(new Implies(cs, v2), new Implies(v3, v4));
            getFormulas(new Implies(cs, v2), new Equivalent(v3, v4));

            getFormulas(new Equivalent(cs, v2), new And(v3, v4));
            getFormulas(new Equivalent(cs, v2), new Or(v3, v4));
            getFormulas(new Equivalent(cs, v2), new Implies(v3, v4));
            getFormulas(new Equivalent(cs, v2), new Equivalent(v3, v4));


            getFormulas( new And(v2, v3), cs);
            getFormulas( new Or(v2, v3), cs);
            getFormulas(new Implies(v2, v3), cs);
            getFormulas(new Equivalent(v2, v3), cs);

            getFormulas(new And(v3, v4), new And(cs, v2));
            getFormulas(new Or(v3, v4), new And(cs, v2));
            getFormulas(new Implies(v3, v4), new And(cs, v2));
            getFormulas(new Equivalent(v3, v4), new And(cs, v2));

            getFormulas(new And(v3, v4),new Or(cs, v2));
            getFormulas(new Or(v3, v4), new Or(cs, v2));
            getFormulas(new Implies(v3, v4),new Or(cs, v2));
            getFormulas(new Equivalent(v3, v4), new Or(cs, v2));

            getFormulas(new And(v3, v4), new Implies(cs, v2));
            getFormulas(new Or(v3, v4), new Implies(cs, v2));
            getFormulas(new Implies(v3, v4), new Implies(cs, v2));
            getFormulas(new Equivalent(v3, v4), new Implies(cs, v2));

            getFormulas(new And(v3, v4), new Equivalent(cs, v2));
            getFormulas(new Or(v3, v4), new Equivalent(cs, v2));
            getFormulas(new Implies(v3, v4),new Equivalent(cs, v2));
            getFormulas(new Equivalent(v3, v4),new Equivalent(cs, v2));

            if (cs.GetType() != typeof(Not))
            {
                getFormulas(new Not(cs), v2);
            }
            
            if (v2.GetType() != typeof(Not))
            {
                getFormulas(cs, new Not(v2));
            }

            if (cs.GetType() != typeof(Not) && v2.GetType() != typeof(Not))
            {
                getFormulas2(new Not(cs), new Not(v2));
            }
        }
        
        private void getFormulas2(CustomStruct cs, CustomStruct v2)
        {
            if (Formulas.Count >= FinFormulaNum)
                throw new CustomAttributeFormatException("Лист заполнен");
            
            if (Operations.Contains(cs.GetType().Name) || Operations.Contains(v2.GetType().Name))
                return;
            
            if (cs.Len == FinLen)
            {
                foreach (var s in cs.ToString().Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (Formulas.Contains(s)) continue;
                    Formulas.Add(s);
                }
                return;
            }
            
            if (v2.Len == FinLen)
            {
                foreach (var s in v2.ToString().Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (Formulas.Contains(s)) continue;
                    Formulas.Add(s);
                }
                return;
            }

            if (cs.Len > FinLen || v2.Len > FinLen)
                return;

            var maxLastInd = System.Math.Max(cs.LastIndex, v2.LastIndex);
            var v3 = Vars[(maxLastInd + 1) % FinVarNum];
            var v4 = Vars[(maxLastInd + 2) % FinVarNum];

            getFormulas2(new And(cs, v2), v3);
            getFormulas2(new Or(cs, v2), v3);
            getFormulas2(new Implies(cs, v2), v3);
            getFormulas2(new Equivalent(cs, v2), v3);


            getFormulas2(v3, new And(cs, v2));
            getFormulas2(v3, new Or(cs, v2));
            getFormulas2(v3, new Implies(cs, v2));
            getFormulas2(v3, new Equivalent(cs, v2));
            
            if (cs.GetType() != typeof(Not) && v2.GetType() != typeof(Not))
            {
                getFormulas2(new Not(cs), new Not(v2));
            }
            
            if (cs.GetType() != typeof(Not))
            {
                getFormulas2(new Not(cs), v2);
            }
            
            if (v2.GetType() != typeof(Not))
            {
                getFormulas2(cs, new Not(v2));
            }
        }
    }
}