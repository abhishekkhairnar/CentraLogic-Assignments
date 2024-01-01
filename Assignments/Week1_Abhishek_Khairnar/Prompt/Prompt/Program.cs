Console.WriteLine("Enter first number :");
String num1String = Console.ReadLine();
Console.WriteLine("Enter second number :");
String num2String = Console.ReadLine();
int num1Int = Convert.ToInt32(num1String);
int num2Int = Convert.ToInt32(num2String);
int sum = num1Int + num2Int;
Console.WriteLine("The square of sum of two numbers is : " + sum * sum);