using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;



namespace ConsoleApp16
{
    class Program
    {
        
        public static void Main(string[] args)
        {
            Num text = new GetNum();
           
            string txt;
            
            txt = text.openfile();
            Dictionary<string, int> frequence = text.GetTop(txt);
            frequence = text.SortDictionary_Desc(frequence);
            int i = 0;
            string[] w = new string[10000];
            int[] f = new int[10000];
            foreach (KeyValuePair<string, int> valuePair in frequence)
            {

                string word = valuePair.Key;
                int fre = valuePair.Value;



                w[i] = word;
                f[i] = fre;
                i++;

            }
           for (i = 0; i < 10; i++)
            {
                Console.WriteLine("单词：{0}   频数：{1}", w[i], f[i]);
            }
            text.Output();

            Console.ReadLine();
            

        }
       
       
    }
}