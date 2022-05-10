namespace MyLib
{
    public class Operation
    {
        public int Sum(int num1, int num2)
        {
            return num1 + num2;
        }

        public bool IsPairValue(int number)
        {
            return number % 2 == 0;
        }

        public double SumDecimal(double decimal1, double decimal2)
        {
            return decimal1 + decimal2;
        }
    }
}