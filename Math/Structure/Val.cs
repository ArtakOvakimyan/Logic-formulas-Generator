namespace Formulas_Generator.Math.Structure
{
    public class Val: CustomStruct
    {
        private string value;
        
        public override int LastIndex { get; set; }

        public override int Len
        {
            get => 1;
            set{}
        }

        public Val(string value)
        {
            this.value = value;
        }
        
        public override string ToString()
        {
            return " " + value + " ";
        }
    }
}