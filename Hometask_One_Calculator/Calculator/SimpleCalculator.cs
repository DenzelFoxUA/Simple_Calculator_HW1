using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace Hometask_One_Calculator
{

    public static class SimpleCalculator
    {
        internal class CalculatorMemoryContainer
        {
            private static int _indexCounter;
            private Dictionary<int, Operation> _operationsHistory;
            private static CalculatorMemoryContainer _instanse = null;

            private CalculatorMemoryContainer()
            {
                _operationsHistory = new Dictionary<int, Operation>();
                _indexCounter = 0;
            }

            public static CalculatorMemoryContainer Instance
            {
                get
                {
                    if (_instanse is null)
                    {
                        _instanse = new CalculatorMemoryContainer();
                        return _instanse;
                    }
                    else
                    {
                        return _instanse;
                    }
                }
            }

            public void recordOperation(double leftOperand, string _operator, double result, double ?rightOperand = null)
            {
                if (_operator is not null && _operator != string.Empty)
                {
                    if (rightOperand is null)
                        _operationsHistory.Add(++_indexCounter, (new Operation(leftOperand, _operator, result)));
                    else
                        _operationsHistory.Add(++_indexCounter, (new Operation(leftOperand, _operator, result, rightOperand)));
                }
                else
                {
                    throw new NullReferenceException("Empty or null string for assigning operator");
                }
            }

            public double ?GetResultByIndex(int indexOfOperation)
            {

                string errorOnFindingMessage = "No such index registered in a memory.\n";

                double ?result = null;

                try
                {
                    result = _operationsHistory.ElementAt(indexOfOperation).Value.Result;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine(errorOnFindingMessage + "\n" + ex.Message);
                    Console.ReadLine();
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine(errorOnFindingMessage + "\n" + ex.Message);
                    Console.ReadLine();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
                finally
                {
                    Console.WriteLine($"\nResult on index {indexOfOperation} is " + result);
                    Console.ReadLine();
                    
                }
                return result;
                
            }

            public void PrintAllOperationsFromMemory()
            {
                if(_operationsHistory.Count != 0)
                {
                    foreach (var operation in _operationsHistory)
                    {
                        Console.WriteLine($"{operation.Key}. " + operation.Value);
                    }
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine($"Memory is empty at the moment.");
                    Console.ReadLine();
                }
                
            }

            public void ClearMemory()
            {
                _operationsHistory.Clear();
                _indexCounter = 0;
                Console.WriteLine("Memory cleared.");
                Console.ReadLine();
            }
        }

        //сет статичних методів для обчислень

        public static double Plus(this double leftOperand, double rightOperand) => leftOperand + rightOperand;

        public static double Minus(this double leftOperand, double rightOperand) => leftOperand - rightOperand;

        public static double Multiply(this double leftOperand, double rightOperand) => leftOperand * rightOperand;

        public static double Divide(this double leftOperand, double rightOperand)
        {
            if (rightOperand != 0)
            {
                return leftOperand / rightOperand;
            }
            else
            {
                throw new DivideByZeroException();
            }
        }

        public static double Power(this double leftOperand, double rightOperand)
        {
            if (rightOperand >= 0)
            {
                return Math.Pow(leftOperand, rightOperand);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Power number must be >= 0");
            }

        }

        public static double Factorial(this int operand)
        {

            if (operand > 0)
            {
                int counter = operand;
                double result = 1;
                for (int i = 2; i <= counter; i++)
                {
                    result *= i;
                }
                return result;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Value must be greater than 0");
            }

        }

        public static double SquareRoot(this double operand)
        {
            return Math.Sqrt(operand);
        }

    }
}
