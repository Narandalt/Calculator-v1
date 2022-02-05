using System;
namespace Test

{ 
  public class CALCULATOR
  { 
    public static double calculator(string x, double value2, double value1)
    {
      double result = 0;
        
      switch (x)
      {
        case "+":
          result = value1 + value2;
          break;
        case "-": 
          result = value1 - value2;
          break;
        case "*":
          result = value1 * value2;
          break;
        case "/":
          result =  (value1 / value2);
          break;
                
        case "^":
          result = Math.Pow(value1, value2); 
          break;
        case "!":
          result = 1;
          for (int i = 1; i <= value2; i++)
          {
            result *= i;
          }
          break;
        case "ln":
          result = Math.Log(value1, value2);
          break;
        case "lg":
          result = Math.Log(value1, value2);
          break;
        case "sin":
          result = Math.Sin((value2 / 180D) * Math.PI);
          break;
        case "cos":
          result = Math.Cos((value2 / 180D) * Math.PI);
          break;
        case "tg":
          result = Math.Tan((value2 / 180D) * Math.PI);
          break;
        case "ctg":
          result = 1 / Math.Tan((value2 / 180D) * Math.PI);
          break;
        case "log":
          result = Math.Log(value2, value1);
          break;
      }
        
      return result;
    }
  }
}