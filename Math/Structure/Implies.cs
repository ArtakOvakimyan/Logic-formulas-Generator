namespace Formulas_Generator.Math.Structure
{
    public class Implies: CustomStruct
    {
        private CustomStruct v1;
        private CustomStruct v2;
        
        public Implies(CustomStruct v1, CustomStruct v2)
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
            get => Priority.Implies;
            set { }
        }
        
        public override string Operator
        {
            get => @"\rightarrow";
            set{} 
        }

        public override string ToString()
        {
            var v1Str = v1.ToString();
            var v2Str = v2.ToString();

            if (v1.Priority < this.Priority)
            {
                v1Str = "(" + v1Str + ")";
            }
            
            if (v2.Priority < this.Priority)
            {
                v2Str = "(" + v2Str + ")";
            }

            return v1Str + this.Operator + v2Str;
        }
    }
}