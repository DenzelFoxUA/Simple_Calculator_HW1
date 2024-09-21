using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Hometask_One_Calculator
{
    public class UI_Calculator
    {
        private static UI_Calculator _instance = null;

        private SimpleCalculator.CalculatorMemoryContainer _calculator;

        private UI_Calculator() 
        {
            _calculator = SimpleCalculator.CalculatorMemoryContainer.Instance;
        }

        public static UI_Calculator Instance //проперті яке дозволяє створити єдиний екземпляр об"єкту
        {
            get
            {
                if(_instance is null)
                {
                   _instance = new UI_Calculator();
                    return _instance;
                }
                else
                {
                    return _instance;
                }
            }
        }

        public void RunUI()
        {
            char userSelection;
            var calculator = SimpleCalculator.CalculatorMemoryContainer.Instance;

            do
            {
                Console.Clear();
                Console.WriteLine(BuildMainMenu());

                userSelection = GetUserSelection();

                switch (userSelection)
                {
                    case '1':
                        RunBinaryOperations();
                        break;
                    case '2':
                        RunUnaryOperations();
                        break;
                    case '3':
                        RunMemoryManagementOperations(); break;
                    case 'e': break;
                    default: break;
                }
            }
            while (userSelection != 'e');
                
        }//головний метод

        private void RunBinaryOperations()
        {
            double operand_Left = 0,
                   operand_Right = 0,
                   result = 0;
            string _operator = string.Empty;
            char userSelection;

            do
            {
                Console.Clear();

                Console.WriteLine("\nEnter two numbers to operate");
                operand_Left = GetNumberFromInput();
                operand_Right = GetNumberFromInput();

                Console.WriteLine(BuildBinaryOperationsMenu());
                userSelection = GetUserSelection();

                switch (userSelection)
                {
                    case '1': _operator = "+";

                        result = operand_Left.Plus(operand_Right);
                        _calculator.recordOperation(operand_Left, _operator, operand_Right, result);
                        PrintSequence(operand_Left, _operator, result, operand_Right);
                        break;

                    case '2': _operator = "-";

                        result = operand_Left.Minus(operand_Right);
                        _calculator.recordOperation(operand_Left, _operator, operand_Right, result);
                        PrintSequence(operand_Left, _operator, result, operand_Right);
                        break;

                    case '3': _operator = "*";

                        result = operand_Left.Multiply(operand_Right);
                        _calculator.recordOperation(operand_Left, _operator, operand_Right, result);
                        PrintSequence(operand_Left, _operator, result, operand_Right);
                        break;
                        
                    case '4': _operator = "/";

                        try
                        {
                            result = operand_Left.Divide(operand_Right);
                        }
                        catch(DivideByZeroException ex)
                        {
                            
                            Console.WriteLine("\n"+ex.Message);
                            Console.ReadLine();
                            break;
                        }
                        _calculator.recordOperation(operand_Left, "/", operand_Right, result);
                        PrintSequence(operand_Left, _operator, result, operand_Right);
                        break;

                    case '5': _operator = "^";

                        try
                        {
                            result = operand_Left.Power(operand_Right);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine("\n"+ex.Message);
                            Console.ReadLine();
                            break;
                        }
                        
                        _calculator.recordOperation(operand_Left, _operator, operand_Right, result);
                        PrintSequence(operand_Left, _operator, result, operand_Right);
                        break;

                    case 'b':; break;
                    default: break;

                }
            }
            while (userSelection != 'b');

        }

        private void RunUnaryOperations()
        {

            double operand_Left = 0, result = 0;

            char userSelection;
            string _operator = string.Empty;

            do
            {
                Console.Clear();

                Console.WriteLine("\nEnter number to operate");
                operand_Left = GetNumberFromInput();

                Console.WriteLine(BuildUnaryOperationsMenu());
                userSelection = GetUserSelection();

                switch (userSelection)
                {
                    case '1': _operator = "!";

                        int convertedValue = (int)Math.Floor(operand_Left);
                        try
                        {
                            result = convertedValue.Factorial();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("\n" + ex.Message);
                            Console.ReadLine();
                            break;
                        }

                        _calculator.recordOperation(operand_Left, _operator, result);
                        PrintSequence(operand_Left, _operator, result);
                        break;

                    case '2': _operator = "SQARE_ROOT";

                        result = operand_Left.SquareRoot();
                        _calculator.recordOperation(operand_Left, _operator, result);
                        PrintSequence(operand_Left, _operator, result);
                        break;

                    case 'b':; break;
                    default: break;

                }
            }
            while (userSelection != 'b');

        }

        private void RunMemoryManagementOperations()
        {
            char userSelection;

            do
            {
                Console.Clear();

                Console.WriteLine(BuildMemoryManagementMenu());
                userSelection = GetUserSelection();

                switch (userSelection)
                {
                    case 'r':
                        _calculator.PrintAllOperationsFromMemory();
                        break;

                    case 'i':
                        Console.WriteLine("Before continue enter index number!");
                        int index = (int)GetNumberFromInput();
                        double? retrivedReult = _calculator.GetResultByIndex(index);
                        break;

                    case 'c':
                        _calculator.ClearMemory();
                        break;

                    case 'b':; break;
                    default: break;

                }
            }
            while (userSelection != 'b');
        }

        private void PrintSequence(double leftOperand, string _operator, double result, double? rightOperand = null)
        {
            if(rightOperand is not null)
                Console.WriteLine($"\n{leftOperand} {_operator} {rightOperand} = {result}");
            else
                Console.WriteLine(($"\n{leftOperand}{_operator} = {result}"));

            Console.ReadLine(); 
        }

        private char GetUserSelection()
        {
            Console.Write("Select option: ");
            char userSelection = Console.ReadKey().KeyChar;
            return userSelection;
        }

        private double GetNumberFromInput()
        {
            bool isCorrect = false;
            double number = 0;

            do
            {
                Console.Clear();
                Console.Write("Enter number: ");
                string userEntrie = Console.ReadLine();

                if (userEntrie != string.Empty)
                {
                    isCorrect = double.TryParse(userEntrie, out number);
                    if (isCorrect == false)
                    {
                        Console.WriteLine("\nWrong entrie.Press enter");
                        Console.ReadLine();
                    }
                    
                }
                else
                {
                        Console.WriteLine("Empty string is not acceptable. Try again");
                        Console.ReadLine();
                }
            }
            while (isCorrect == false);
            
            return number;
        }

        //методи створення різних меню
        private MenuModel BuildMainMenu()
        {
            MenuBase.MenuBuilder menuBuilder = new MenuBase.MenuBuilder();
            var menu = menuBuilder
                .SetTitle("\t---------- Calculator -----------")
                .AddButton(new Button("Binary Operations", '1'))
                .AddButton(new Button("Unary Operations", '2'))
                .AddButton(new Button("Memory Management", '3'))
                .AddButton(new Button("Exit", 'e'))
                .Build();
            return menu;
        }

        private MenuModel BuildBinaryOperationsMenu()
        {
            MenuBase.MenuBuilder menuBuilder = new MenuBase.MenuBuilder();
            var menuBin = menuBuilder
                .SetTitle("\t---------- Binary Operations -----------")
                .AddButton(new Button("Adding",'1'))
                .AddButton(new Button("Subtraction", '2'))
                .AddButton(new Button("Multiply", '3'))
                .AddButton(new Button("Divide", '4'))
                .AddButton(new Button("Power", '5'))
                .AddButton(new Button("<-Back", 'b'))
                .Build();
            return menuBin;
        }
        private MenuModel BuildUnaryOperationsMenu() 
        {
            MenuBase.MenuBuilder menuBuilder = new MenuBase.MenuBuilder();

            var menu = menuBuilder
                .SetTitle("\t---------- Unary Operations -----------")
                .AddButton(new Button("Factorial", '1'))
                .AddButton(new Button("SquareRoot", '2'))
                .AddButton(new Button("<-Back", 'b'))
                .Build();
            return menu;

        }

        private MenuModel BuildMemoryManagementMenu()
        {
            MenuBase.MenuBuilder menuBuilder = new MenuBase.MenuBuilder();
            var menu = menuBuilder
                .SetTitle("\t---------- Memory -----------")
                .AddButton(new Button("ReadAllMemory", 'r'))
                .AddButton(new Button("GetResultByIndex", 'i'))
                .AddButton(new Button("ClearMemory", 'i'))
                .AddButton(new Button("<-Back", 'b'))
                .Build();
            return menu;
        }

    }
}
