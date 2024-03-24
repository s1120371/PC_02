using System;
namespace PC_02
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            XAXBKernel xaxb = new XAXBKernel();
            xaxb.SetLuckyNumber("123");
            Console.WriteLine("{0} is legal? {1}", "1234", XAXBKernel.IsLegal("1234"));
            Console.WriteLine("{0} is legal? {1}", "123", XAXBKernel.IsLegal("123"));
            Console.WriteLine("{0}: {1}", "566", XAXBKernel.IsLegal("566") ? "legal" : "illegal");
            Console.WriteLine("{0}: {1}", "787", XAXBKernel.IsLegal("787") ? "legal" : "illegal");
            Console.WriteLine("{0}: {1}", "770", XAXBKernel.IsLegal("770") ? "legal" : "illegal");
            Console.WriteLine("{0}: {1}", "079", XAXBKernel.IsLegal("079") ? "legal" : "illegal");
            string result1 = xaxb.GetGuessResult("124");
            Console.WriteLine("{0} {1}: {2}", xaxb.GetLuckyNumber(), "124", result1);
            string result2 = xaxb.GetGuessResult("123");
            Console.WriteLine("{0} {1}: {2}", xaxb.GetLuckyNumber(), "123", result2);
            Console.WriteLine("{0} gameover: {1}", "125", xaxb.IsGameover("125"));
            Console.WriteLine("{0} gameover: {1}", "123", xaxb.IsGameover("123"));
        }
        internal class XAXBKernel
        {
            private string LuckyNumber;
            public XAXBKernel()
            {
                this.LuckyNumber = LuckyNumber;
                Random random = new Random(); // Random 隨機數產生器
                int randomNumber = random.Next();
                if(IsLegal(randomNumber.ToString()))
                {
                    for(int i = 0;LuckyNumber.Length>i;i++)
                    {
                        for(int j = i + 1; LuckyNumber.Length>j; j++)
                        {
                            if (LuckyNumber[i] == LuckyNumber[j] && LuckyNumber.Length == 3)
                            {
                                LuckyNumber = LuckyNumber;
                            }
                        }
                    }
                }
            }
            public bool SetLuckyNumber(string newLuckyNumber)
            {
                if (IsLegal(newLuckyNumber))
                {
                    LuckyNumber = newLuckyNumber;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public string GetLuckyNumber()
            {
                return LuckyNumber;
            }
            public static bool IsLegal(string userNumber)
            {
                for (int i = 0; i < userNumber.Length; i++)
                {
                    for (int j = i + 1; j < userNumber.Length; j++)
                    {
                        if (userNumber[j] == userNumber[i])
                        {
                            return false;
                        }
                    }
                }
                if (userNumber.Length != 3)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public string GetGuessResult(String userNumber)
            {
                int A = 0;
                int B = 0;
                for (int i = 0; i < userNumber.Length; i++)
                {
                    if (userNumber[i] == LuckyNumber[i])
                    {
                        A++;
                    }
                    else 
                    {
                        for(int j = 0; j < LuckyNumber.Length; j++)
                        {
                            if(userNumber[i] == LuckyNumber[i])
                            {
                                B++;
                            }
                        }
                    }
                }
                return $"{A}A{B}B";
            }
            public bool IsGameover(string userNumber)
            {
                if (userNumber == LuckyNumber)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}