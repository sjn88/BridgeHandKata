using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeKata
{
    public class BridgeCalculator
    {
        private IFileHandler fileHandler;
        public int Points = 0;
        private string fileName;

        public void readHand(string fileName)
        {
            if (!fileHandler.Exists(fileName))
            {
                throw new ArgumentException();
            }

            string[] allLines = fileHandler.ReadAllLines(fileName);
            if (!allLines.Any())
            {
                throw new FileFormatException("The file was empty");
            }

            if (this.fileName == null)
            {
                this.fileName = fileName;
            }
            else
            {
                    throw new ArgumentException();
            }

            KeyValuePair<string,int> jack = new KeyValuePair<string, int>("J", 1);
            KeyValuePair<string, int> queen = new KeyValuePair<string, int>("Q", 2);
            List<KeyValuePair<string, int>> listOfCardsAndPoints = new List<KeyValuePair<string, int>> {jack, queen};
            Points = listOfCardsAndPoints.Sum(card => allLines.Count(s => s.Contains(card.Key)) * card.Value);
        }

        public BridgeCalculator(IFileHandler fileHandler)
        {
            this.fileHandler = fileHandler;
        }
    }
}
