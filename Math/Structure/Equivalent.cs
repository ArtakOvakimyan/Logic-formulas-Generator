namespace Formulas_Generator.Math.Structure
{
    public class Equivalent: CustomStruct
    {
   
        
        public Equivalent(CustomStruct v1, CustomStruct v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        
        public override int LastIndex
        {
            get => System.Math.Max(v1.LastIndex, v2.LastIndex);
            set{}
        }
        
        public override int Len
        {
            get => 1 + v1.Len + v2.Len;
            set{}
        }
        
        public override Priority Priority {
            get => Priority.Equivalent;
            set { }
        }
        
        public override string Operator
        {
            get => @"\leftrightarrow ";
            set{} 
        }
        
        public override string ToString()
        {
            var v1Str = v1.ToString().Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
            var v2Str = v2.ToString().Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
            var res = "";

            foreach (var p1 in v1Str)
            {
                foreach (var p2 in v2Str)
                {
                    if (v1.Priority < this.Priority)
                    {
                        res += "(" + p1 + ")" + this.Operator + p2 + '\n';
                    }

                    if (v2.Priority < this.Priority)
                    {
                        res += p1 + this.Operator + "(" + p2 + ")" + '\n';
                    }

                    if (v1.Priority < this.Priority && v2.Priority < this.Priority)
                    {
                        res += "(" + p1 + ")" + this.Operator + "(" + p2 + ")" + '\n';
                    }
                    res += p1 + this.Operator + p2 + '\n';
                }
            }
            return res;
        }
    }
}