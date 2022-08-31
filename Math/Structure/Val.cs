namespace Formulas_Generator.Math.Structure
{
    public class Val: CustomStruct
    {
        private string value;
        
        public Val(string value)
        {
            this.value = value;
        }
        
        public override int LastIndex { get; set; }

        public override int Len
        {
            get => 1;
            set{}
        }
        
        public override Priority Priority {
            get => Priority.Val;
            set { }
        }
        
        public override string Operator { get; set; }

        public override string ToString()
        {
            return " " + value + " ";
        }
    }
}