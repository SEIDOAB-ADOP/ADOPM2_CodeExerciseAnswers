using System;
using System.Drawing;
using Seido.Utilities.SeedGenerator;

namespace _07_IEquatable_IComparable
{
    public class Necklace : IEquatable<Necklace>
    {
        public List<PearlAsClass> ListOfPearls { get; set; } = new List<PearlAsClass>();
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
                ListOfPearls.Add(new PearlAsClass(rnd));
            }
        }
        public Necklace(string name, PearlAsClass _p1, PearlAsClass _p2)
        {
            Name = name;
            ListOfPearls.Add(_p1);
            ListOfPearls.Add(_p2);
        }

        public Necklace(Necklace org)
        {
            Name = org.Name;
            ListOfPearls = new List<PearlAsClass>();

            for (int i = 0; i < org.ListOfPearls.Count; i++)
            {
                ListOfPearls.Add(new PearlAsClass(org.ListOfPearls[i]));
            }
        }
    }
}

