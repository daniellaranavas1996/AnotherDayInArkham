using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPersonaje", menuName = "Personaje")]
public class Character : ScriptableObject
{
    public string Name;
    ////A implementar posibles atributos; como fuerza, agilidad...
    //public int Strength;
    //public int Agility;
    //public int Wisdom;
    //public int Observation;
    
    public string Text;
    public Sprite CharacterModel;
    public Sprite RipModel;
    public  List<Card> FixedDeck;
    public List<Card> Deck;
    public List<Card> DiscardDeck;
    public List<Card> AlreadyInHand;

    public int Salud;
    public int SaludActual;

    private static System.Random rng = new System.Random(System.Convert.ToInt32(System.DateTime.Now.ToString("ddhhmmss")));

    public Character()
    {
        DiscardDeck = new List<Card>();
        AlreadyInHand = new List<Card>();
    }


    public void ShufleDeck()
    {


        int n = Deck.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            Card value = Deck[k];
            Deck[k] = Deck[n];
            Deck[n] = value;
        }


    }
    
}

