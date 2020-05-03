using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    List<Card> cards;
    public string deckName;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShuffleDeck()
    {
        int length = cards.Count;
        List<Card> newCards = new List<Card>();
        //for each card in the deck
        for (int i = 0; i < length; i++)
        {
            //randomly select a card and add it to the new deck
            newCards.Add(cards[Random.Range(0, cards.Count - 1)]);
        }
        //set the deck card list to the new card list
        cards = newCards;
        Debug.Log("Deck " + deckName + " Shuffled");
    }

    public void DrawCard(/*Player drawer */)
    {
        //check the type of card and act accordingly
        if (cards[0].GetType() == typeof(GeneralGroup))
        {
            //put card[0] into the uncontrolled groups
            //remove card[0] from the deck
            cards.RemoveAt(0);
        }
        else //this means the card is one ofthe special cards
        {
            //put card into the drawing player's hand
        }
    }
}
