Console.WriteLine("Enter first number :");
String num1String = Console.ReadLine();
Console.WriteLine("Enter second number :");
String num2String = Console.ReadLine();

double num1 = Convert.ToDouble(num1String);
double num2 = Convert.ToDouble(num2String);

Console.WriteLine("Addition : " + (num1 + num2) + "\n" +
                  "Substraction : " + (num1 - num2) + "\n" +
                  "Multiplication : " + (num1 * num2) + "\n" +
                  "Division : " + (num1 / num2) + "\n" +
                  "Addition : " + (num1 + num2) + "\n" +
                  "Modulo : " + num1 * num2 + "\n");
