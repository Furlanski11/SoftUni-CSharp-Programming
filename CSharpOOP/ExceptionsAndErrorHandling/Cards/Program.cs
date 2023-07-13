using System;
using System.Collections.Generic;
using System.Net.Cache;


string[] input = Console.ReadLine().Split(", ",
    StringSplitOptions.RemoveEmptyEntries);
List<Card> cards = new List<Card>();

foreach (string tokens in input)
{
    try
    {
        string[] cardInfo = tokens.Split(' ');
        Card card = new(cardInfo[0], cardInfo[1]);
        cards.Add(card);
    }
    catch (ArgumentException ex)
    {

        Console.WriteLine(ex.Message);
    }
}
 Console.WriteLine(string.Join(" ", cards));

public class Card
{
    private string face;
    private string suit;

    public Card(string face, string suit)
    {
        Face = face;
        Suit = suit;
    }

    public string Face
    {
        get => face;
        private set
        {
            switch (value)
            {
                case "2":
                    face = value;
                    break;
                case "3":
                    face = value;
                    break;
                case "4":
                    face = value;
                    break;
                case "5":
                    face = value;
                    break;
                case "6":
                    face = value;
                    break;
                case "7":
                    face = value;
                    break;
                case "8":
                    face = value;
                    break;
                case "9":
                    face = value;
                    break;
                case "10":
                    face = value;
                    break;
                case "J":
                    face = value;
                    break;
                case "Q":
                    face = value;
                    break;
                case "K":
                    face = value;
                    break;
                case "A":
                    face = value;
                    break;
                default:
                    throw new ArgumentException("Invalid card!");
            }
        }
    }
    public string Suit
    {
        get => suit;
        private set
        {
            switch (value)
            {
                case "S":
                    suit = value;
                    break;
                case "H":
                    suit = value;
                    break;
                case "D":
                    suit = value;
                    break;
                case "C":
                    suit = value;
                    break;
                default:
                    throw new ArgumentException("Invalid card!");
            }
        }
    }

    public override string ToString()
    {
        switch (Suit)
        {
            case "S":
                return $"[{Face}\u2660]";
            case "H":
                return $"[{Face}\u2665]";
            case "D":
                return $"[{Face}\u2666]";
            case "C":
                return $"[{Face}\u2663]";
            default:
                return null;
        }
    }
}