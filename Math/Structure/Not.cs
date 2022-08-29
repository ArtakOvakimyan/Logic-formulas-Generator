namespace Formulas_Generator.Math.Structure
{
    public class Not: CustomStruct
    {
        private CustomStruct v;

        public Not(CustomStruct v)
        {
            this.v = v;
        }
        
        public override int LastIndex
        {
            get => v.LastIndex;
            set{}
        }
        public override int Len
        {
            get => 1 + v.Len;
            set{}
        }

        public override string ToString()
        {
            if (v.GetType() == typeof(Val))
            {
                return @"\neg" + v.ToString() + " ";
            }
            return @"\neg" + "(" + v.ToString() + ")" + " ";
        }
    }
}