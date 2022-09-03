using System;

namespace Formulas_Generator.Math.Structure
{
    public class Not: CustomStruct
    {

        public Not(CustomStruct v)
        {
            this.v1 = v;
        }
        
        public override int LastIndex
        {
            get => v1.LastIndex;
            set{}
        }
        public override int Len
        {
            get => 1 + v1.Len;
            set{}
        }
        
        public override Priority Priority {
            get => Priority.Not;
            set { }
        }
        
        public override string Operator
        {
            get => @"\neg ";
            set{} 
        }

        public override string ToString()
        {
            if (v1.GetType() == typeof(Val))
            {
                return this.Operator + v1.ToString();
            }

            var vstr = v1.ToString().Split(new char[] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            var res = "";

            foreach (var p in vstr)
            {
                res += this.Operator + "(" + p + ")" + '\n';
            }

            return res;
        }
    }
}