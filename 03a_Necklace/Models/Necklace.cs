using System;
using Seido.Utilities.SeedGenerator;

namespace _03a_Necklace.Models
{
    #region Necklace using Pearl as a class
    public class Necklace
	{
        public List<Pearl> ListOfPearls { get; set; } = new List<Pearl>();
        public string Name { get; set; }

        public (Pearl minPearl, Pearl maxPearl) GetMinMaxPearl()
        {
            int maxSize = int.MinValue;
            int minSize = int.MaxValue;
            Pearl maxPearl = null;
            Pearl minPearl = null;

            foreach (var item in ListOfPearls)
            {
                if (item.Size > maxSize)
                {
                    maxSize = item.Size;
                    maxPearl = item;
                }
                if (item.Size < minSize)
                {
                    minSize = item.Size;
                    minPearl = item;
                }
            }
            return (minPearl, maxPearl);
        }
        public override string ToString()
        {
            string sRet = $"\n{Name}:";
            foreach (var item in ListOfPearls)
            {
                sRet += $"\n{item.ToString()}";
            }
            return sRet;
        }

        public Necklace(int nrPearls, string name)
		{
            Name = name;
            var rnd = new SeedGenerator();
            for (int i = 0; i < nrPearls; i++)
            {
                ListOfPearls.Add(new Pearl(rnd));
            }
        }
        public Necklace(string name, Pearl _p1, Pearl _p2)
        {
            Name = name;
            ListOfPearls.Add(_p1);
            ListOfPearls.Add(_p2);
        }
        public Necklace(Necklace org, string name)
        {
            Name = name;
            ListOfPearls = new List<Pearl>();
            foreach (var item in org.ListOfPearls)
            {
                ListOfPearls.Add(new Pearl(item));
            }
        }
    }
    #endregion
}

