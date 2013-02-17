using System;
using System.Text;

class CalculateNFacturielwithDigitsInArray
{
    static void Main()
    {
        Console.WriteLine("Insert Number to calculate its facturial:");
        string n = Console.ReadLine();
        //n = MultiplyTwoNumbersByDigits("85", "135");
        string facturiel = CalcFacturiel(n);
        Console.WriteLine(facturiel);
    }

    private static string CalcFacturiel(string n)
    {        
        if (n.Length == 1)
        {
            if (Convert.ToInt32(n) > 1)
            {
                n = MultiplyTwoNumbersByDigits(n, CalcFacturiel(numberMinusOne(n)));
            }
        }
        else
        {
            n = MultiplyTwoNumbersByDigits(n, CalcFacturiel(numberMinusOne(n)));
        }
        return n;
    }
    static string numberMinusOne(string n)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(n);
        int number;
        int i = 1;
        do
        {
            number = Convert.ToInt32(sb[sb.Length - i].ToString());

            if (number != 0)
            {
                sb.Remove(sb.Length - i, 1);
                if (number - 1 != 0 || sb.Length >= i)
                {
                  sb.Insert(sb.Length - i + 1, (number - 1));
                }
            }
            i++;
        }
        while (number == 0);
        i--;
        sb.Replace("0", "9", sb.Length + 1 - i, i -1);

        n = sb.ToString();
        return n;
    }

    static string MultiplyTwoNumbersByDigits(string firstNumber, string secondNumber)
    {
        int[] firstArray = new int[firstNumber.Length];
        int[] secondArray = new int[secondNumber.Length];
        int[] multiArray = new int[Math.Max(firstNumber.Length, secondNumber.Length) * 2];
        int[] multiArrayCurrent = new int[multiArray.Length];
        int[] multiArrayPrevious = new int[multiArray.Length];
        StringBuilder Number = new StringBuilder();
        Number.Append(firstNumber);
        for (int i = 0; i < firstNumber.Length; i++)
        {
            firstArray[i] = Convert.ToInt32(Number[firstNumber.Length - 1 - i].ToString());
        }
        Number.Clear();
        Number.Append(secondNumber);
        for (int i = 0; i < secondNumber.Length; i++)
        {
            secondArray[i] = Convert.ToInt32(Number[secondNumber.Length - 1 - i].ToString());
        }
        Number.Clear();
        for (int j = 0; j < firstNumber.Length; j++)
        {
            for (int i = 0; i <secondNumber.Length + 1; i++)
            {
                if (i == 0)
                {
                    multiArrayCurrent[i + j] = (firstArray[j] * secondArray[i]) % 10;
                }
                else if (i == Math.Max(firstNumber.Length, secondNumber.Length))
                {
                    multiArrayCurrent[i + j] = (firstArray[j] * secondArray[i - 1]) / 10;
                }
                else
                {
                    multiArrayCurrent[i + j] = (firstArray[j] * secondArray[i]) % 10 + (firstArray[j] * secondArray[i - 1]) / 10;
                }
            }
            int naum = 0;
            for (int i = 0; i < multiArray.Length; i++)
            {
                if (i == 0)
                {
                    multiArray[i] = (multiArrayCurrent[i] + multiArrayPrevious[i]) % 10;
                }
                else if (i == multiArray.Length)
                {
                    multiArray[i] = (multiArrayCurrent[i - 1] + multiArrayPrevious[i - 1]) / 10;
                }
                else
                {
                    multiArray[i] = (multiArrayCurrent[i] + multiArrayPrevious[i]) % 10 + (multiArrayCurrent[i - 1] + multiArrayPrevious[i - 1]) / 10 +naum;
                    naum = 0;
                    if (multiArray[i] > 9)
                    {
                        naum = multiArray[i] / 10;
                        multiArray[i] = multiArray[i] % 10;
                    }
                    }
            }

            multiArray.CopyTo(multiArrayPrevious, 0);
            Array.Clear(multiArrayCurrent,0,multiArrayCurrent.Length);


        }
        Array.Reverse(multiArray);
        if (multiArray[0] != 0)
        {
            Number.Append(multiArray[0]);
        }
        bool isZero = false;
        for (int i = 1; i < multiArray.Length; i++)
        {
            if (multiArray[i] != 0 || isZero)
            {
                Number.Append(multiArray[i]);
                isZero = true;
            }
        }
        return Number.ToString();
    }
}
