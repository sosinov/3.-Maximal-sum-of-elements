using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumMaxElement
{
    internal class Line
    {
        private static IFormatProvider _formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
        protected internal decimal[] _lineElements;
        protected internal bool _existWrongElements;

        protected internal Line(string line)
        {
            _lineElements = LineToNumberArray(line);
        }

        private decimal[] LineToNumberArray(string inputLine)
        {
            char separator = ',';
            bool existWrongElementsTemp = false;
            var lineNumbersArray = new List<decimal>();
            var numbersInLine = inputLine.Split(separator);
            foreach (string number in numbersInLine)
            {
                bool result = decimal.TryParse(number, NumberStyles.Number, _formatter, out var value);
                if (result)
                {
                    lineNumbersArray.Add(value);
                }
                else
                {
                    existWrongElementsTemp = true;
                    lineNumbersArray.Clear();
                    break;
                }
            }
            _existWrongElements = existWrongElementsTemp;
            return lineNumbersArray.ToArray();
        }
    }
}
