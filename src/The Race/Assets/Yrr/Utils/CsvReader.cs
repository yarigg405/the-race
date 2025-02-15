using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


namespace Yrr.Utils
{
    public sealed class CsvReader
    {
        public List<string[]> ReadFile(string text, char csvDelimiter, bool ignoreHeadline, bool removeQuoteSign)
        {
            List<string[]> lst = new List<string[]>();
            int currentLineNumner = 0;
            int columnCount = 0;

            var file = text.Split('\n');
            foreach (var line in file)
            {
                currentLineNumner++;
                string[] strAr = line.Split(csvDelimiter);

                for (int i = 0; i < strAr.Length; i++)
                    strAr[i] = strAr[i].Replace("\r", "");

                if (currentLineNumner == 1) columnCount = strAr.Count();

                if (strAr.Count() != columnCount)
                {
                    if (currentLineNumner == file.Count()) continue;
                    throw new Exception(string.Format("CSV Import Exception: Wrong column count in line {0}", currentLineNumner));
                }

                if (removeQuoteSign) strAr = RemoveQouteSign(strAr);
                if ((currentLineNumner != 1) || !ignoreHeadline) lst.Add(strAr);
            }

            return lst;
        }

        public List<string[]> ReadCSVFile(string filePath, char csvDelimiter, bool removeQuoteSign)
        {
            return ReadFile(File.ReadAllText(filePath), csvDelimiter, true, removeQuoteSign);
        }

        public List<string[]> ReadCSVFileFromResources(string filename, char csvDelimiter, bool ignoreHeadline = true, bool removeQuoteSign = true)
        {
            return ReadFile(Resources.Load<TextAsset>(filename).text, csvDelimiter, ignoreHeadline, removeQuoteSign);
        }

        private string[] RemoveQouteSign(string[] ar)
        {
            for (int i = 0; i < ar.Count(); i++)
            {
                if (ar[i].StartsWith("\"") || ar[i].StartsWith("'")) ar[i] = ar[i].Substring(1);
                if (ar[i].EndsWith("\"") || ar[i].EndsWith("'")) ar[i] = ar[i].Substring(0, ar[i].Length - 1);
            }
            return ar;
        }
    }
}
