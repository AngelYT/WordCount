using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp16
{
    public interface Num
    {
        int GetAsc(string text);
        int GetWords(string text);
        Dictionary<string, int> GetTop(string text);
        Dictionary<string, int> SortDictionary_Desc(Dictionary<string, int> dic);
        string openfile();
        int GetLines(string text);
        void Output();
    }
}
