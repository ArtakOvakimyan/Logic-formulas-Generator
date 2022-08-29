namespace Formulas_Generator.Math.Structure
{
    public class And: CustomStruct
    {
        private CustomStruct v1;
        private CustomStruct v2;
        
        public And(CustomStruct v1, CustomStruct v2)
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
        
        public override string ToString()
        {
            if (v1.GetType() == typeof(Or) && v2.GetType() == typeof(Or))
            {
                return "(" + v1.ToString() + ")" + @"\wedge" + "(" + v2.ToString() + ")";
            }

            if (v1.GetType() == typeof(Or))
            {
                return "(" + v1.ToString() + ")" + @"\wedge" + v2.ToString();
            }
            
            if (v2.GetType() == typeof(Or))
            {
                return v1.ToString() + @"\wedge" + "(" + v2.ToString() + ")";
            }

            return v1.ToString() + @"\wedge" + v2.ToString();
        }
    }
}