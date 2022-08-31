namespace Formulas_Generator.Math.Structure
{
    public class Or: CustomStruct
    {
        private CustomStruct v1;
        private CustomStruct v2;
        
        public Or(CustomStruct v1, CustomStruct v2)
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
            get => Priority.Or;
            set { }
        }
        
        public override string Operator
        {
            get => @"\vee";
            set{} 
        }
        
        public override string ToString()
        {
            /*if (v1.GetType() == typeof(And) && v2.GetType() == typeof(And))
            {
                return "(" + v1.ToString() + ")" + @"\vee" + "(" + v2.ToString() + ")";
            }

            if (v1.GetType() == typeof(And))
            {
                return "(" + v1.ToString() + ")" + @"\vee" + v2.ToString();
            }
            
            if (v2.GetType() == typeof(And))
            {
                return v1.ToString() + @"\vee" + "(" + v2.ToString() + ")";
            }

            return v1.ToString() + @"\vee" + v2.ToString();*/
            
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