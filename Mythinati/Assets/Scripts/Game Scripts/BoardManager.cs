using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//manages all decks and players within the game
public class BoardManager : MonoBehaviour
{
    public Deck generalDeck;

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
}
