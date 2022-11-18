using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMaxElement
{
    public class LinesArrayClass
    {
        private Line[] _lines;

        public LinesArrayClass(string filePath)
        {
            _lines = GetLinesFromFile(filePath);
        }

        private Line[] GetLinesFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new ArgumentException("The file directory doesn't exist.");
            }
            var stringLines = File.ReadAllLines(filePath, Encoding.UTF8);
            Line[] linesTemp = new Line[stringLines.Length];
            for (int i = 0; i < linesTemp.Length; i++)
            {
                linesTemp[i] = new Line(stringLines[i]);
            }
            return linesTemp;
        }

        public List<int> GetWrongElementsNumber()
        {
            List<int> wrongLinesNumbers = new List<int>();
            for (int i = 0; i < _lines.Length; i++)
            {
                if (_lines[i]._existWrongElements == true)
                {
                    wrongLinesNumbers.Add(i);
                }
            }
            return wrongLinesNumbers;
        }

        private decimal? GetLineSum(Line line)
        {
            decimal? lineSum = null;
            if (!line._existWrongElements)
            {
                lineSum = 0;
                foreach (decimal item in line._lineElements)
                {
                    lineSum += item;
                }
            }
            return lineSum;
        }

        public decimal? GetMaxSum()
        {
            decimal? maxSum = null;
            List<decimal?> linesWithCalculatedSum = new List<decimal?>();
            foreach (var line in _lines)
            {
                if (!line._existWrongElements)
                {
                    linesWithCalculatedSum.Add(GetLineSum(line));
                }                
            }
            if (linesWithCalculatedSum.Count > 0)
            {
                maxSum = linesWithCalculatedSum.Max();
            }            
            return maxSum;
        }
    }
}
