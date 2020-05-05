using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages all decks and players within the game
public class BoardManager : MonoBehaviour
{
    public static Deck generalDeck = new Deck("General");
    public static Deck centralDeck = new Deck("Central");
    public static Deck uncontrolledDeck = new Deck("Uncontrolled");
    public static Deck destroyedDeck = new Deck("Destroyed");

    public static List<Player> turnOrder = new List<Player>();
    public static int currentTurn = 0;

    // Start is called before the first frame update
    void Start()
    {
        generalDeck.fillDeck(DeckType.General);
        generalDeck.ShuffleDeck();
        ShuffleTurnOrder();
        //players draw central cards
        turnOrder[0].StartTurn();
    }

    // Update is called once per frame
    void Update()
    {
        //if time to end turn
        //turnOrder[currentTurn].EndTurn();
        //if(currentTurn + 1 == turnOrder.Count)
        //{
        //  currentTurn = 0;
        //}
        //else
        //{
        //  currentTurn++;
        //}
        //turnOrder[currentTurn].StartTurn();
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
