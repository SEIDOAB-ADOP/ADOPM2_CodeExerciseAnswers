using System;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Seido.Utilities.SeedGenerator;

namespace _08_hashset_factory_switchexpr
{
    public enum PearlColor { Black, White, Pink }
    public enum PearlShape { Round, DropShaped }
    public enum PearlType { FreshWater, SaltWater }

    #region Pearl as a class
    public class Pearl : IEquatable<Pearl>, IComparable<Pearl>
    {
        public int Size { get; init; }
        public PearlColor Color { get; init; }
        public PearlShape Shape { get; init; }
        public PearlType Type { get; init; }

        public override string ToString()
        {
            var sRet = $"{Size}mm {Color} {Shape} {Type} pearl.";
            string s = this.Size switch
            {
                <= 10 => " A small pearl.",
                > 10 and <= 15 => " A midsized pearl.",
                > 15 => " A large pearl."
            };

            return sRet + s;
        }


        #region Implementation of IEquatable<T> interface
        public bool Equals(Pearl other) => (this.Size, this.Color, this.Shape, this.Type) ==
           (other.Size, other.Color, other.Shape, other.Type);

        //Needed to implement as part of IEquatable
        public override bool Equals(object obj) => Equals(obj as Pearl);
        public override int GetHashCode() => (this.Size, this.Color, this.Shape, this.Type).GetHashCode();
        #endregion

        #region operator overloading
        public static bool operator ==(Pearl o1, Pearl o2) => o1.Equals(o2);
        public static bool operator !=(Pearl o1, Pearl o2) => !o1.Equals(o2);
        #endregion

        #region Implementation IComparable<T> interface
        public int CompareTo(Pearl other)
        {
            //Sort on Make -> Model -> Year
            if (this.Size != other.Size)
                return this.Size.CompareTo(other.Size);

            return this.Type.CompareTo(other.Type);
        }
        #endregion

        public Pearl() { }
        public Pearl(SeedGenerator _seeder)
        {
            Size = _seeder.Next(5, 25);
            Color = _seeder.FromEnum<PearlColor>();
            Shape = _seeder.FromEnum<PearlShape>();
            Type = _seeder.FromEnum<PearlType>();
        }
        public Pearl(int _size, PearlColor _color, PearlShape _shape, PearlType _type)
        {
            Size = _size;
            Color = _color;
            Shape = _shape;
            Type = _type;
        }
        public Pearl(Pearl org)
        {
            Size = org.Size;
            Color = org.Color;
            Shape = org.Shape;
            Type = org.Type;
        }
    }
    #endregion
}

