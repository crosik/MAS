using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TradingCardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Card xd = new Card(CardRarity.COMMON, "Stronk", 10, 10, 10, "Mocna karta", "Podpalenie", 2);
            Card xp = new Card(CardRarity.RARE, "Stornker", 20, 20, 20, "Mocniejsza karta", "Stun", 2);
            Card xz = new Card(CardRarity.EPIC, "Stronkiests", 30, 30, 30, "Najmocniejsza karta jk", "Taunt", 2);
            Card xc = new Card(CardRarity.COMMON, "Cos", 10, 10, 10, "Jakis opis", "Silence", 2);
            Card xa = new Card(CardRarity.COMMON, "Tutaj", 10, 10, 10, "watever", "Deathrattle", 2);
            Card xw = new Card(CardRarity.COMMON, "Nie Gra", 10, 10, 10, "xdxp", "Random", 2);
            //Card.Save(Card.Extent);
            //Card.Load();
            Deck stronk = new Deck("stronk");
            stronk.AddCard(xd);
            stronk.AddCard(xp);
            stronk.AddCard(xz);
            stronk.AddCard(xc);
            stronk.AddCard(xa);
            stronk.AddCard(xw);
            foreach(var Card in stronk.AllCardsInDeck)
            {
                Console.WriteLine(Card.ToString());
            }
            Account test = new Account(1, "test", "test");
            test.AddDeck(stronk);
            test.RemoveDeck(stronk);
            //Card.ShowAllCards();
            Thread.Sleep(500000);
        }
    }
}
