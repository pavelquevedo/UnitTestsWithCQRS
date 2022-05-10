namespace MyLib
{
    public class Operation
    {
        public List<int> oddNumbersList = new List<int>();
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

        public List<int> GetOddNumbersList(int minInterval, int maxInterval)
        {
            oddNumbersList.Clear();
            for (int i = minInterval; i <= maxInterval; i++)
            {
                if (i % 2 != 0)
                {
                    oddNumbersList.Add(i);
                }                
            }

            return oddNumbersList;
        }
    }
}