using System;
using Seido.Utilities.SeedGenerator;

namespace _03a_Necklace.Models
{
    public enum PearlColor { Black, White, Pink }
    public enum PearlShape { Round, DropShaped }
    public enum PearlType { FreshWater, SaltWater }

    #region Pearl as a class
    public class Pearl
    {
        public int Size { get; init; }
        public PearlColor Color { get; init; }
        public PearlShape Shape { get; init; }
        public PearlType Type { get; init; }

        public override string ToString() => $"{Size}mm {Color} {Shape} {Type} pearl.";

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

    #region Pearl as a record
    public record rePearl(int Size, PearlColor Color, PearlShape Shape, PearlType Type)
    {
        public override string ToString() => $"{Size}mm {Color} {Shape} {Type} pearl.";

        //Your own constructor, must call this(record properties...)
        public rePearl(SeedGenerator _seeder) : this(

            _seeder.Next(5, 25),
            _seeder.FromEnum<PearlColor>(),
            _seeder.FromEnum<PearlShape>(),
            _seeder.FromEnum<PearlType>())
        { }
    }
    #endregion
}

