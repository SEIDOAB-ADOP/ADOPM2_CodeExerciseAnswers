
System.Console.WriteLine("Hello World");


(PearlColor Color, PearlShape Shape, PearlType Type) pearl1 = (PearlColor.Black, PearlShape.Round, PearlType.SaltWater);
System.Console.WriteLine(pearl1);
System.Console.WriteLine(pearl1.Type);

(PearlColor, PearlShape, PearlType) pearl2 =  (PearlColor.Pink, PearlShape.Round, PearlType.SaltWater);
System.Console.WriteLine(pearl2);

(PearlColor, PearlShape, PearlType) pearl4 = (PearlColor.Black, PearlShape.Round, PearlType.SaltWater);

if (pearl1 == pearl4) 
{
   System.Console.WriteLine("Pearls are equal");
}

if (pearl2 == (PearlColor.Pink, PearlShape.Round, PearlType.SaltWater))
{
   System.Console.WriteLine("pearl2 is pink");
}


var pearl3 = pearl1;
pearl1.Shape = PearlShape.DropShaped;
System.Console.WriteLine(pearl3.Shape);
System.Console.WriteLine(pearl1.Shape);

(PearlColor Color, PearlShape Shape, PearlType Type) = pearl3;
System.Console.WriteLine(Color);
System.Console.WriteLine(Shape);
System.Console.WriteLine(Type);



List <(PlayingCardSuit, PlayingCardValue)> deckOfCards = new List <(PlayingCardSuit, PlayingCardValue)>();

/*
for (PlayingCardSuit s = PlayingCardSuit.Clubs; s <= PlayingCardSuit.Spades; s++)
{
   for (PlayingCardValue v = PlayingCardValue.Two; v <= PlayingCardValue.Ace; v++)
   {
      deckOfCards.Add((s,v));

   }
}
*/

Type myType = typeof(PlayingCardSuit);

foreach (PlayingCardSuit s in typeof(PlayingCardSuit).GetEnumValues())
{
   foreach (PlayingCardValue v in typeof(PlayingCardValue).GetEnumValues())
   {
         deckOfCards.Add((s,v));
   }
}



System.Console.WriteLine("\nDeck of Cards");
foreach (var item in deckOfCards)
{
   System.Console.WriteLine($"{item.Item1} {item.Item2}" );
}



public enum PearlColor { Black, White, Pink }
public enum PearlShape { Round, DropShaped }
public enum PearlType { FreshWater, SaltWater }


public enum PlayingCardSuit {Clubs, Diamonds, Hearts, Spades}
public enum PlayingCardValue { Two = 2, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Knight, Queen, King, Ace}

/* Exercises
1. Create a tuple pearl1 which is Black, Round, Saltwater
2. Create a tuple pearl2 which is White, DropShaped, Freashwater
3. test if pearl1 is equal to pearl2
3.a Use tuple syntax to test if pearl2 is a Pink, Round, Saltwater

4. Modify pearl1 and pearl2 tuple creatation so the tuple items are no longer calles Item1, Item2, Item3 but
   Color, Shape and Type

5. Use tuple syntax to create pearl3 that is a copy of pearl1
6. Use tuple syntax to create three variables PearlColor Color, PearlShape Shape and PearlType Type from pearl2

7. Create a list of tuples List <(PlayingCardSuit, PlayingCardValue)> and fill it with 52 cards lika a deck of card
8. Write the deck of card to the console 

*/

