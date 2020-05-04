using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages all decks and players within the game
public class BoardManager : MonoBehaviour
{
    public static Deck generalDeck;
    public static Deck centralDeck;
    public static List<Player> turnOrder = new List<Player>();

    // Start is called before the first frame update
    void Start()
    {
        generalDeck.fillDeck(DeckType.General);
        generalDeck.ShuffleDeck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShuffleTurnOrder()
    {
        int length = turnOrder.Count;
        List<Player> newOrder = new List<Player>();
        //for each card in the deck
        for (int i = 0; i < length; i++)
        {
            //randomly select a card and add it to the new deck
            Player temp = turnOrder[Random.Range(0, turnOrder.Count - 1)];
            newOrder.Add(temp);
            turnOrder.Remove(temp);
        }
        //set the deck card list to the new card list
        turnOrder = newOrder;
    }
}
