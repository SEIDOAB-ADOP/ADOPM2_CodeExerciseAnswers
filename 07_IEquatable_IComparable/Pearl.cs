using System;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using Seido.Utilities.SeedGenerator;

namespace _07_IEquatable_IComparable
{
    public enum PearlColor { Black, White, Pink }
    public enum PearlShape { Round, DropShaped }
    public enum PearlType { FreshWater, SaltWater }

    #region Pearl as a class
    public class PearlAsClass : IEquatable<PearlAsClass>, IComparable<PearlAsClass>
    {
        public int Size { get; init; }
        public PearlColor Color { get; init; }
        public PearlShape Shape { get; init; }
        public PearlType Type { get; init; }

        public override string ToString() => $"{Size}mm {Color} {Shape} {Type} pearl.";

        #region Implementation of IEquatable<T> interface
        public bool Equals(PearlAsClass other) => (this.Size, this.Color, this.Shape, this.Type) ==
           (other.Size, other.Color, other.Shape, other.Type);

        //Needed to implement as part of IEquatable
        public override bool Equals(object obj) => Equals(obj as PearlAsClass);
        public override int GetHashCode() => (this.Size, this.Color, this.Shape, this.Type).GetHashCode();
        #endregion

        #region operator overloading
        public static bool operator ==(PearlAsClass o1, PearlAsClass o2) => o1.Equals(o2);
        public static bool operator !=(PearlAsClass o1, PearlAsClass o2) => !o1.Equals(o2);
        #endregion

        #region Implementation IComparable<T> interface
        public int CompareTo(PearlAsClass other)
        {
            //Sort on Make -> Model -> Year
            if (this.Size != other.Size)
                return this.Size.CompareTo(other.Size);

            return this.Type.CompareTo(other.Type);
        }
        #endregion

        public PearlAsClass() { }
        public PearlAsClass(SeedGenerator _seeder)
        {
            Size = _seeder.Next(5, 25);
            Color = _seeder.FromEnum<PearlColor>();
            Shape = _seeder.FromEnum<PearlShape>();
            Type = _seeder.FromEnum<PearlType>();
        }
        public PearlAsClass(int _size, PearlColor _color, PearlShape _shape, PearlType _type)
        {
            Size = _size;
            Color = _color;
            Shape = _shape;
            Type = _type;
        }
        public PearlAsClass(PearlAsClass org)
        {
            Size = org.Size;
            Color = org.Color;
            Shape = org.Shape;
            Type = org.Type;
        }
    }
    #endregion
}

