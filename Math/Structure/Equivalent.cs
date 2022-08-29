namespace Formulas_Generator.Math.Structure
{
    public class Equivalent: CustomStruct
    {
        private CustomStruct v1;
        private CustomStruct v2;
        
        public Equivalent(CustomStruct v1, CustomStruct v2)
        {
            this.v1 = v1;
            this.v2 = v2;
        }
        
        public override int LastIndex
        {
            get
            {
                return System.Math.Max(v1.LastIndex, v2.LastIndex);
            } 
            set{}
        }
        public override int Len
        {
            get => 1 + v1.Len + v2.Len;
            set{}
        }
        
        public override string ToString()
        {
            return v1.ToString() + @"\leftrightarrow" + v2.ToString();
        }
    }
}