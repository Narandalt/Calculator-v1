namespace Test
{
    public class PRIORITY
    {
        public static int priority(string x)
        {
          switch (x)
          {
            case "+":
              return 1;
            case "-":
              return 1;
           
            case "*":
              return 2;
            case "/":
              return 2;
           
            case "^":
              return 3;
            case "!": 
              return 3;
            case "ln": 
              return 3;
            case "lg": 
              return 3;
            case "sin":
              return 3;
            case "cos": 
              return 3;
            case "tg": 
              return 3;
            case "ctg":
              return 3;
            case "log":
              return 3;
            
            case "(": 
              return 0;
            case ")": 
              return 0;
          }
                
          return -1;
        }
    }
}