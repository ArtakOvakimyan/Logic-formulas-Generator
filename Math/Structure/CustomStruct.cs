using System;

namespace Formulas_Generator.Math.Structure
{
    public abstract class CustomStruct
    {
        public CustomStruct v1 { get;  set; }
        public CustomStruct v2 { get;  set; }
        public abstract int LastIndex { get; set; }
        public abstract int Len { get; set; }
        public abstract Priority Priority { get; set; }
        public abstract string Operator { get; set; }
    }
}