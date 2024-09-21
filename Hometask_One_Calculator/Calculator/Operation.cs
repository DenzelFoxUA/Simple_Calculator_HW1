using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_One_Calculator
{
    public class Operation
    {

        public Operation(double leftOperand, string _operator, double result, double ?rightOperand = null) 
        { 
            LeftOperand = leftOperand;
            Operator_ = _operator;
            RightOperand = rightOperand;
            Result = result;
        }

        public double LeftOperand {private get; init; }
        public string Operator_ {private get; init; }
        public double ?RightOperand {private get; init; }
        public double Result { get; init; }

        public override string ToString()
        {
            if(RightOperand == null) return $"{LeftOperand} {Operator_} = {Result}";
            else return $"{LeftOperand} {Operator_} {RightOperand} = {Result}";
        }
    }
}
