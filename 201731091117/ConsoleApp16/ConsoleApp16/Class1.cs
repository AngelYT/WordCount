using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp16
{
    public class GetNum : Num
    {


        public string openfile()
        {
            string txt;
            txt = File.ReadAllText(@"D:\TEST.txt");

            return txt;

        }
        public int GetAsc(string text)
        {
            text = openfile();
            int asc = 0;
            foreach (char word in text)
            {
                if (32 <= word && word <= 126)
                {
                    asc++;
                }
            }
            Console.WriteLine("字符数为：{0}", asc);
            return asc;
        }
        public int GetWords(string text)
        {
            text = openfile();
            string[] list = text.Split(" ,.\r".ToCharArray());
            int words = 0;
            foreach (string word in list)
            {
                if (word.Length >= 1)
                {
                    words++;
                }
            }
            Console.WriteLine("单词数为：{0}", words);
            return words;


        }



        public Dictionary<string, int> GetTop(string text)
        {
            Dictionary<string, int> keyValuePairs;
            keyValuePairs = new Dictionary<string, int>();
            text = openfile();
            string[] list = text.Split(" ,.\r".ToCharArray());
            foreach (string word in list)
            {
                if (keyValuePairs.ContainsKey(word) && word.Length >= 4)
                {
                    keyValuePairs[word]++;
                }
                else if (word.Length >= 4)
                {
                    keyValuePairs[word] = 1;
                }
            }

            return keyValuePairs;
        }
        public int GetLines(string text)
        {

            text = openfile();
            StreamReader stream = new StreamReader(@"D:\TEST.txt");
            string lines;
            int i = 0;
            while ((lines = stream.ReadLine()) != null)
            {
                i++;
            }
            Console.WriteLine("lines:  {0}",i);
            return i;
        }
        public Dictionary<string, int> SortDictionary_Desc(Dictionary<string, int> dic)

        {

            List<KeyValuePair<string, int>> myList = new List<KeyValuePair<string, int>>(dic);
                        myList.Sort(delegate (KeyValuePair<string, int> s1, KeyValuePair<string, int> s2)

            {

                return s2.Value.CompareTo(s1.Value);

            });

            dic.Clear();

            foreach (KeyValuePair<string, int> pair in myList)

            {

                if (pair.Key != null && pair.Key != ":" && pair.Key != "," && pair.Key != ".")

                    dic.Add(pair.Key, pair.Value);

            }

            return dic;

        }
        public void Output()
        {
            GetNum get = new GetNum();
            string outtext = openfile();
            int outasc = get.GetAsc(outtext);
            int outline = get.GetLines(outtext);
            int outword = get.GetWords(outtext);
            
            
            StreamWriter sw = new StreamWriter(@"D:\output.txt");
            Console.SetOut(sw);
            Console.WriteLine("charactor:  {0}", outasc);
            Console.WriteLine("lines:    {0}", outline);
            Console.WriteLine("words:      {0}", outword);
            Dictionary<string, int> frequence = get.GetTop(outtext);
            frequence = get.SortDictionary_Desc(frequence);
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
            sw.Flush();
            sw.Close();
        }

    }
}
