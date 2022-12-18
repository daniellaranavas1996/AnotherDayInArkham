using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Prefab;
    public List<Card> CardsInHand;
    //public Transform Slot1;
    //public Transform Slot2;
    //public Transform Slot3;
    //public Transform Slot4;
    //public Transform Slot5;
    //public Transform Slot6;

    public Transform[] Slots;
    private List<GameObject> gSaveObjects;
    public TurnManagerController tmanager ; 
    void Awake()
    {
        Character character1 = SelectionData.CharacterSelected1;
        Character character2 = SelectionData.CharacterSelected2;

        character1.Deck = new List<Card>(character1.FixedDeck);
        character2.Deck = new List<Card>(character2.FixedDeck);

        character1.ShufleDeck();
        character2.ShufleDeck();

        //DrawTurn(character1, character2);

    }

    public void DrawTurn(Character character1, Character character2)
    {
        character1.AlreadyInHand = new List<Card>();
        character2.AlreadyInHand = new List<Card>();
        CardsInHand.Clear();

        if (character1.Deck.Count < 3)
        {
            character1.Deck.AddRange(character1.DiscardDeck);
            character1.DiscardDeck.Clear();
        }
        if (character2.Deck.Count < 3)
        {
            character2.Deck.AddRange(character2.DiscardDeck);
            character2.DiscardDeck.Clear();
        }

        character1.AlreadyInHand.Add(character1.Deck[0]);
        character1.AlreadyInHand.Add(character1.Deck[1]);
        character1.AlreadyInHand.Add(character1.Deck[2]);


        character2.AlreadyInHand.Add(character2.Deck[0]);
        character2.AlreadyInHand.Add(character2.Deck[1]);
        character2.AlreadyInHand.Add(character2.Deck[2]);

        character1.DiscardDeck.Add(character1.Deck[0]);
        character1.DiscardDeck.Add(character1.Deck[1]);
        character1.DiscardDeck.Add(character1.Deck[2]);
        character2.DiscardDeck.Add(character2.Deck[0]);
        character2.DiscardDeck.Add(character2.Deck[1]);
        character2.DiscardDeck.Add(character2.Deck[2]);

        CardsInHand.AddRange(character1.AlreadyInHand);

        CardsInHand.AddRange(character2.AlreadyInHand);

        character1.Deck.RemoveRange(0, 3);
        character2.Deck.RemoveRange(0, 3);


        DrawCardsInHand();
    }

    internal void ClearHands()
    {
        for (int i = 0; i < Slots.Length; i++)
        {
            try
            {
                if (Slots[i].GetChild(0).gameObject != null)
                {
                    Destroy(Slots[i].GetChild(0).gameObject);
                }
            }
            catch (Exception)
            {
            }



         
        }
    }

    public void DrawCardsInHand()
    {
        int i = 1;
        foreach (Card c in CardsInHand)
        {




            GameObject newObject = Instantiate(Prefab, Slots[i-1]);
            newObject.GetComponent<CardDisplay>().card = c;
            newObject.GetComponent<CardDisplay>().LoadFromAsset();
            newObject.GetComponent<DraggableTestWithActions>().tmanager = tmanager;
            
            

            i++;


        }






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
