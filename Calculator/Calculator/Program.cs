using System;
using System.Collections.Generic;
using static Test.PRIORITY;
using static Test.CALCULATOR;

  /* Примеры
   * (23 - 15)! + 6 - 89*(5-3)^3 
   * (57 + 8)*2 - 23*3 + 2 * (5+6-1) 
   * sqrt 23 - ln 587 / 2 
   * ln (587 - 275) 
   * sqrt 23 - ln 587 / 2 * sin72 ^ cos13 + 12! 
   * ln(587-500) + sqrt(27 - 2) * sin(97-20)^(cos(53+6)+5)
   * log(2+5)(93)
   * log3(9)
  */

  /* Функционал
   * считает примеры любой длины
   * использовано 14 операций(+, -, *, /, ^, !, srqt, ln, lg, sin, cos, tg, ctg, log)
   * реализована работа со скобками
   * НЕТ защиты от дурака
  */

namespace Test
{
  internal class Program
  {
    public static void Main(string[] args)
    {
      string str = ""; // хранит входную строку с примером
      string command = ""; // хранит в себе операции, которые не укладываются в один символ
      string num_str = ""; // хранит в себе число из строки
      int flag = 0; // 0 - нет скобок, 1 - есть скобки

      Stack<double> number = new Stack<double>(); // стек чисел
      Stack<string> operation = new Stack<string>(); // стек операций

      str = Console.ReadLine();

      for (int i = 0; i < str.Length; i++)
      {
        // парсер чисел
        if (str[i] == ' ')
        {
          continue;
        }
        if ((str[i] >= '0') && (str[i] <= '9'))
        {
          num_str += str[i];
          continue;
        }
        else
        {
          if (num_str != "")
          {
            number.Push(Convert.ToInt32(num_str));
            num_str = "";
          }
        }

        // если использована буква
        if ((str[i] >= 'a') && (str[i] <= 'z'))
        {
          command += str[i];
          continue;
        }

        // работа со скобками
        if (str[i] == '(')
        {
          operation.Push(Convert.ToString(str[i]));
          flag = 1;
          continue;
        }
        else if (str[i] == ')')
        {
          while (operation.Peek() != "(")
          {
            number.Push(calculator(operation.Pop(), number.Pop(), number.Pop()));
          }

          operation.Pop();
          flag = 0;
          continue;
        }

        // проведение операций, записанных в command
        if ((flag == 0) && (command != ""))
        {
          switch (command)
          {
            case "sqrt":
              command = "";
              operation.Push("^");
              number.Push(0.5f);
              break;
            case "ln":
              command = "";
              operation.Push("ln");
              number.Push(Math.Exp(1.0));
              break;
            case "lg":
              command = "";
              operation.Push("lg");
              number.Push(10);
              break;
            case "sin":
              command = "";
              number.Push(calculator("sin", number.Pop(), 0));
              break;
            case "cos":
              command = "";
              number.Push(calculator("cos", number.Pop(), 0));
              break;
            case "tg":
              command = "";
              number.Push(calculator("tg", number.Pop(), 0));
              break;
            case "ctg":
              command = "";
              number.Push(calculator("ctg", number.Pop(), 0));
              break;
            case "log":
              command = "";
              operation.Push("log");
              break;
          }
        }

        // работа с факториалом
        if (str[i] == '!')
        {
          number.Push(calculator("!", number.Pop(), 0));
          continue;
        }

        // реализация операций
        if ((operation.Count > 0) && (priority(operation.Peek()) != 0))
        {
          if ((priority(Convert.ToString(str[i])) <= priority(operation.Peek())) && (priority(Convert.ToString(str[i])) != 0))
          {
            while ((operation.Count > 0) && (operation.Peek() != "(") && (priority(Convert.ToString(str[i])) <= priority(operation.Peek())))
            {
              number.Push(calculator(operation.Pop(), number.Pop(), number.Pop()));
            }
            
            operation.Push(Convert.ToString(str[i]));
          }
          else
            operation.Push(Convert.ToString(str[i]));
        }
        else
          operation.Push(Convert.ToString(str[i]));
        
      }

      // вычисления
      if(num_str != "")
        number.Push(Convert.ToInt32(num_str));
    
      switch (command)
      {
        case "":
          break;
        case "sqrt": 
          operation.Push("^"); 
          number.Push(0.5f); 
          break;
        case "ln":
          operation.Push("ln");
          number.Push(Math.Exp(1.0));
          break;
        case "sin": 
          number.Push(calculator("sin", number.Pop(), 0));
          break;
        case "cos":
          number.Push(calculator("cos", number.Pop(), 0));
          break;
        case "tg": 
          number.Push(calculator("tg", number.Pop(), 0)); 
          break;
        case "ctg":
          number.Push(calculator("ctg", number.Pop(), 0));
          break;
        case "lg": 
          operation.Push("lg");
          number.Push(10);
          break;
        case "log":
          operation.Push("log");
          break;
      }
      
      while (operation.Count > 0)
      {
        number.Push(calculator(operation.Pop(), number.Pop(), number.Pop()));
      }
      
      Console.WriteLine("\nОтвет: " + number.Pop());
      
      Console.ReadKey();
      }
  }
}