using System;
namespace _05_Wines_Interfaces
{
    public class WineCellar : IEquatable<WineCellar>
    {
        public string Name { get; set; }
        public List<Wine> Wines = new List<Wine>();

        /*
        public void Add(Wine wine) => _wines.Add(wine);
        public int Count => _wines.Count;
        public Wine this[int idx] => _wines[idx];

        public void Clear() => _wines.Clear();
        */
        public decimal Value
        {
            get
            {
                decimal _sum = 0M;
                foreach (var wine in Wines)
                {
                    _sum += wine.Price;
                }
                return _sum;
            }
        }

        public override string ToString()
        {
            var sRet = "";
            foreach (var wine in Wines)
            {
                sRet += $"{wine}\n";
            }
            return sRet;
        }

        public WineCellar() { }
        public WineCellar(string name)
        {
            Name = name;
        }

        public (Wine hicost, Wine locost) WineHiLoCost()
        {
            if (Wines.Count == 0) return (null, null);

            decimal _hiPrice = decimal.MinValue;
            Wine _hiWine = null;
            decimal _loPrice = decimal.MaxValue;
            Wine _loWine = null;
            foreach (var wine in Wines)
            {
                if (wine.Price > _hiPrice)
                {
                    _hiWine = wine;
                    _hiPrice = wine.Price;
                }
                if (wine.Price < _loPrice)
                {
                    _loWine = wine;
                    _loPrice = wine.Price;
                }
            }
            return (_hiWine, _loWine);
        }

        public bool Equals(WineCellar other)
        {

            if (other == null) return false;
            if (other.Name != Name) return false;
            if (other.Wines.Count != Wines.Count) return false;

            for (int i = 0; i < Wines.Count; i++)
            {
                if (other.Wines[i] != Wines[i]) return false;
            }

            return true;
        }

        public override bool Equals(object obj) => Equals(obj as WineCellar);
        public static bool operator ==(WineCellar left, WineCellar right) => left.Equals(right);
        public static bool operator !=(WineCellar left, WineCellar right) => left.Equals(right);
    }
}

