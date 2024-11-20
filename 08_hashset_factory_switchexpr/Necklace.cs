using System;
using System.Drawing;
using Seido.Utilities.SeedGenerator;

namespace _08_hashset_factory_switchexpr
{
    public class Necklace : IEquatable<Necklace>
    {
        public List<Pearl> ListOfPearls { get; set; } = new List<Pearl>();
        public string Name { get; set; }

        public override string ToString()
        {
            string sRet = $"\n{Name}:";
            foreach (var item in ListOfPearls)
            {
                sRet += $"\n{item.ToString()}";
            }
            return sRet;
        }

        #region Implementation of IEquatable<T> interface
        public bool Equals(Necklace other)
        {
            if (this.Name != other.Name)
                return false;
            if (this.ListOfPearls.Count != other.ListOfPearls.Count)
                return false;

            for (int i = 0; i < ListOfPearls.Count; i++)
            {
                if (this.ListOfPearls[i] != other.ListOfPearls[i])
                    return false;
            }
            return true;
        }


        //Needed to implement as part of IEquatable
        public override bool Equals(object obj) => Equals(obj as Necklace);
        public override int GetHashCode() => (this.Name, this.ListOfPearls.Count, this.ListOfPearls).GetHashCode();
        #endregion

        #region operator overloading
        public static bool operator ==(Necklace o1, Necklace o2) => o1.Equals(o2);
        public static bool operator !=(Necklace o1, Necklace o2) => !o1.Equals(o2);
        #endregion

        public Necklace(string name)
        {
            Name = name;
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

        public Necklace(Necklace org)
        {
            Name = org.Name;
            ListOfPearls = new List<Pearl>();

            for (int i = 0; i < org.ListOfPearls.Count; i++)
            {
                ListOfPearls.Add(new Pearl(org.ListOfPearls[i]));
            }
        }

        #region class factory

        public static class Factory
        {
            public static Necklace CreateSaltWaterUnique()
            {
                var rnd = new SeedGenerator();
                HashSet<Pearl> unique_pearls = new HashSet<Pearl>();

                while (unique_pearls.Count < 10)
                {
                    unique_pearls.Add(new Pearl(rnd) { Type = PearlType.SaltWater });
                }

                return new Necklace("Unique saltwater pearls")
                {
                    ListOfPearls = unique_pearls.ToList()
                };
            }
            public static Necklace CreateXL(int NrOfPearls)
            {
                var rnd = new SeedGenerator();

                var pearls = new List<Pearl>();
                for (int i = 0; i < NrOfPearls; i++)
                {
                    pearls.Add(new Pearl(rnd) { Size = rnd.Next(15, 21) });
                }
                return new Necklace("Necklace XL")
                {
                    ListOfPearls = pearls
                };
            }

        }
        #endregion
    }
}

