using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    List<Card> cards = new List<Card>();
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
            Card temp = cards[Random.Range(0, cards.Count - 1)];
            newCards.Add(temp);
            cards.Remove(temp);
        }
        //set the deck card list to the new card list
        cards = newCards;
        Debug.Log("Deck " + deckName + " Shuffled, Contains " + cards.Count + " Cards");
    }

    public void DrawCard(Player drawer)
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
            drawer.specialCards.Add(cards[0]);
            //remove card[0] from the deck
            cards.RemoveAt(0);
        }
    }

    public void fillDeck(DeckType type)
    {
        switch (type)
        {
            case DeckType.General:
                int[] connectDirect = { 0, 1, 0, -1 };
                List<Alignment> alignList = new List<Alignment>();
                alignList.Add(Alignment.None);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("Empty Vee", 3, 0, 3, 4, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                //+5 Control Big Media/Empty Vee
                cards.Add(new GeneralGroup("Madison Avenue", 3, 3, 3, 2, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = 1; connectDirect[2] = 1; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Multinational Oil Companies", 6, 0, 4, 8, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 1; connectDirect[2] = 1; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("The Phone Company", 5, 2, 6, 3, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                //+3 Direct Control Convenience Stores
                cards.Add(new GeneralGroup("Video Games", 2, 0, 3, 7, connectDirect, alignList));

                alignList.Clear();
                alignList.Add(Alignment.Weird);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 1;
                //+4 Direct Control/Neutralize/Destroy Orbital Mind Lasers
                cards.Add(new GeneralGroup("L-4 Society", 1, 0, 2, 0, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Psychiatrists", 0, 0, 6, 2, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Punk Rockers", 0, 0, 4, 1, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                //+2 Control Weird
                cards.Add(new GeneralGroup("Science Fiction Fans", 0, 0, 5, 1, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                //+5 Direct Control Science Fiction Fans, +2 Direct Control of Trekkies
                cards.Add(new GeneralGroup("S.M.O.F.", 1, 0, 1, 0, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Tabloids", 2, 0, 3, 3, connectDirect, alignList));

                alignList.Add(Alignment.Violent);
                cards.Add(new GeneralGroup("American Autoduel Association", 1, 0, 5, 1, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Comic Books", 1, 0, 1, 2, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = 1;
                //+2 Destroy groups
                cards.Add(new GeneralGroup("Cycle Gangs", 0, 0, 4, 0, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                //+4 Control/Neutralize/Destroy Orbital Mind Lasers
                cards.Add(new GeneralGroup("Evil Geniuses for a Better Tomorrow", 0, 2, 6, 3, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Society for Creative Anarchism", 0, 0, 4, 1, connectDirect, alignList));

                alignList.Add(Alignment.Liberal);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Eco-Guerillas", 0, 0, 6, 1, connectDirect, alignList));

                alignList.Clear();
                alignList.Add(Alignment.Liberal);

                connectDirect[0] = 1; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                //+2 Destroy Nuclear Power Companies
                cards.Add(new GeneralGroup("Anti-Nuclear Activists", 2, 0, 5, 1, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("Democrats", 5, 0, 4, 3, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("CFL-AIO", 6, 0, 5, 3, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 1; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Feminists", 2, 0, 2, 1, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Girlie Magazines", 2, 0, 2, 3, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 1; connectDirect[3] = -1;
                //+2 Control Anti-Nuclear Activists
                cards.Add(new GeneralGroup("Health Food Stores", 1, 0, 1, 2, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 1; connectDirect[2] = 1; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Hollywood", 2, 0, 0, 5, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 1;
                //Pay 5 Currency to draw extra card, ont an action
                cards.Add(new GeneralGroup("Recyclers", 2, 0, 2, 3, connectDirect, alignList));

                alignList.Add(Alignment.Peaceful);

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Antiwar Activists", 0, 0, 3, 1, connectDirect, alignList));

                alignList.Remove(Alignment.Peaceful);
                alignList.Add(Alignment.Straight);

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("Big Media", 4, 3, 6, 3, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Triliberal Commission", 5, 0, 6, 3, connectDirect, alignList));

                alignList.Remove(Alignment.Liberal);

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Conveniance Stores", 1, 0, 4, 3, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 1; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Fast Food Chains", 2, 0, 4, 3, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("The United Nations", 1, 0, 3, 3, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Comic Books", 1, 0, 1, 2, connectDirect, alignList));

                alignList.Add(Alignment.Peaceful);

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Boy Sprouts", 0, 0, 3, 1, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Morticians", 0, 0, 4, 1, connectDirect, alignList));

                alignList.Add(Alignment.Conservative);

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Parent/Teacher Agglomeration", 0, 0, 5, 1, connectDirect, alignList));

                alignList.Remove(Alignment.Peaceful);

                connectDirect[0] = 0; connectDirect[1] = 1; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Congressional Wives", 1, 0, 4, 1, connectDirect, alignList));

                alignList.Add(Alignment.Violent);

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Local Police Departments", 0, 0, 4, 1, connectDirect, alignList));

                alignList.Remove(Alignment.Violent);
                alignList.Add(Alignment.Fanatic);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Moral Minority", 2, 0, 1, 2, connectDirect, alignList));

                alignList.Remove(Alignment.Straight);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Nephews of God", 0, 0, 4, 2, connectDirect, alignList));

                alignList.Remove(Alignment.Fanatic);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("Nuclear Power Companies", 4, 0, 4, 3, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("Republicans", 4, 0, 4, 4, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Yuppies", 1, 1, 4, 5, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Fraternal Orders", 3, 0, 5, 2, connectDirect, alignList));

                alignList.Add(Alignment.Weird);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("Flat Earthers", 1, 0, 2, 1, connectDirect, alignList));

                alignList.Remove(Alignment.Weird);
                alignList.Add(Alignment.Violent);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                //Resistance 10 vs Liberal/Communist/Weird
                cards.Add(new GeneralGroup("Gun Lobby", 1, 0, 3, 1, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("KKK", 2, 0, 5, 1, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 1;
                //+6 Destroy Communist
                cards.Add(new GeneralGroup("Militia", 2, 0, 4, 2, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("South American Nazis", 4, 0, 6, 2, connectDirect, alignList));

                alignList.Add(Alignment.Fanatic);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                //+2 Resistance to all owner's groups
                cards.Add(new GeneralGroup("Survivalists", 0, 0, 6, 2, connectDirect, alignList));

                alignList.Remove(Alignment.Fanatic);
                alignList.Add(Alignment.Government);

                connectDirect[0] = 1; connectDirect[1] = 1; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Texas", 6, 0, 6, 4, connectDirect, alignList));

                alignList.Remove(Alignment.Conservative);
                alignList.Add(Alignment.Straight);

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("Pentagon", 6, 0, 6, 2, connectDirect, alignList));

                alignList.Remove(Alignment.Straight);
                alignList.Add(Alignment.Criminal);

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("New York", 7, 0, 8, 3, connectDirect, alignList));

                alignList.Remove(Alignment.Criminal);

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("C.I.A.", 6, 4, 5, 0, connectDirect, alignList));

                alignList.Remove(Alignment.Violent);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Post Office", 4, 3, 3, -1, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = 1; connectDirect[2] = 0; connectDirect[3] = -1;
                //Can transfer money to anywhere
                cards.Add(new GeneralGroup("Federal Reserve", 5, 3, 7, 6, connectDirect, alignList));

                alignList.Add(Alignment.Weird);
                alignList.Add(Alignment.Liberal);

                connectDirect[0] = 1; connectDirect[1] = 0; connectDirect[2] = 1; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("California", 5, 0, 4, 5, connectDirect, alignList));

                alignList.Remove(Alignment.Weird);
                alignList.Remove(Alignment.Liberal);
                alignList.Add(Alignment.Straight);

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("F.B.I.", 4, 2, 6, 0, connectDirect, alignList));

                alignList.Remove(Alignment.Straight);
                alignList.Add(Alignment.Criminal);

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                //Other players pay controlling player 2 Currency from any group
                cards.Add(new GeneralGroup("I.R.S.", 5, 3, 5, 0, connectDirect, alignList));

                alignList.Remove(Alignment.Government);

                connectDirect[0] = 1; connectDirect[1] = 1; connectDirect[2] = 1; connectDirect[3] = -1;
                //+4 Control Punk Rockers, Cycle Gangs, Hollywood
                cards.Add(new GeneralGroup("International Cocaine Smugglers", 3, 0, 5, 5, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                //+4 Control Post Office
                cards.Add(new GeneralGroup("Junk Mail", 1, 0, 3, 2, connectDirect, alignList));

                alignList.Add(Alignment.Liberal);

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                //+3 Control/Neutralize/Destroy Phone Company
                cards.Add(new GeneralGroup("Phone Phreaks", 0, 1, 1, 1, connectDirect, alignList));

                alignList.Remove(Alignment.Liberal);
                alignList.Add(Alignment.Weird);

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("The Men In Black", 0, 2, 6, 1, connectDirect, alignList));

                alignList.Remove(Alignment.Weird);
                alignList.Add(Alignment.Violent);

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                //+3 Direct Control Criminal
                cards.Add(new GeneralGroup("The Mafia", 7, 0, 7, 6, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 1; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Loan Sharks", 5, 0, 5, 6, connectDirect, alignList));

                alignList.Add(Alignment.Communist);

                connectDirect[0] = 0; connectDirect[1] = 1; connectDirect[2] = 1; connectDirect[3] = -1;
                //+3 Destroy Any
                cards.Add(new GeneralGroup("Clone Arrangers", 6, 2, 6, 1, connectDirect, alignList));

                alignList.Add(Alignment.Liberal);
                alignList.Add(Alignment.Weird);

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                //+1 Destroy Any
                cards.Add(new GeneralGroup("Semiconscious Liberation Army", 0, 0, 8, 0, connectDirect, alignList));

                alignList.Remove(Alignment.Liberal);
                alignList.Remove(Alignment.Weird);
                alignList.Remove(Alignment.Criminal);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                //+2 Destroy Any
                cards.Add(new GeneralGroup("KGB", 2, 2, 6, 0, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Robot Sea Monsters", 0, 0, 6, 2, connectDirect, alignList));

                alignList.Remove(Alignment.Violent);

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 0;
                //Act as Government when attempting to control Government
                cards.Add(new GeneralGroup("Chinese Campaign Donors", 3, 0, 2, 3, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                //+3 Control Communist
                cards.Add(new GeneralGroup("International Communist Conspiracy", 7, 0, 8, 6, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = 1; connectDirect[2] = 0; connectDirect[3] = -1;
                //On turn add/Remove/Reverse Alignment of One Group in play
                cards.Add(new GeneralGroup("Orbital Mind Control Laser", 4, 2, 5, 0, connectDirect, alignList));

                alignList.Add(Alignment.Liberal);

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Underground Newspapers", 1, 1, 5, 0, connectDirect, alignList));

                alignList.Remove(Alignment.Liberal);
                alignList.Add(Alignment.Fanatic);

                connectDirect[0] = 1; connectDirect[1] = 1; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Fiendish Fluoridators", 3, 0, 5, 1, connectDirect, alignList));

                alignList.Remove(Alignment.Communist);

                connectDirect[0] = 1; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Libertarians", 1, 0, 4, 1, connectDirect, alignList));

                alignList.Add(Alignment.Straight);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 1; connectDirect[3] = 1;
                //+3 Direct Control Moral Minority
                cards.Add(new GeneralGroup("TV Preachers", 3, 0, 6, 4, connectDirect, alignList));

                alignList.Remove(Alignment.Straight);
                alignList.Add(Alignment.Violent);

                connectDirect[0] = 0; connectDirect[1] = 1; connectDirect[2] = 1; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Professional Sports", 2, 0, 4, 3, connectDirect, alignList));

                alignList.Remove(Alignment.Violent);
                alignList.Add(Alignment.Weird);

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                cards.Add(new GeneralGroup("Trekkies", 0, 0, 4, 3, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 0;
                //+3 Neutralize Any
                cards.Add(new GeneralGroup("Hackers", 1, 1, 4, 2, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Intellectuals", 0, 0, 3, 1, connectDirect, alignList));

                alignList.Remove(Alignment.Weird);
                alignList.Add(Alignment.Peaceful);

                connectDirect[0] = 0; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Goldfish Fanciers", 0, 0, 4, 1, connectDirect, alignList));

                connectDirect[0] = 1; connectDirect[1] = 0; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Moonies", 2, 0, 4, 3, connectDirect, alignList));

                alignList.Remove(Alignment.Fanatic);

                connectDirect[0] = 0; connectDirect[1] = 1; connectDirect[2] = 0; connectDirect[3] = -1;
                cards.Add(new GeneralGroup("Fnord Motor Company", 2, 0, 4, 2, connectDirect, alignList));

                connectDirect[0] = 0; connectDirect[1] = -1; connectDirect[2] = 0; connectDirect[3] = 1;
                cards.Add(new GeneralGroup("Copy Shops", 1, 0, 3, 4, connectDirect, alignList));

                //placeholders for special cards
                cards.Add(new Card("Assassination"));
                cards.Add(new Card("Bribery"));
                cards.Add(new Card("Computer Espionage"));
                cards.Add(new Card("Deep Agent"));
                cards.Add(new Card("Interference"));
                cards.Add(new Card("Interference"));
                cards.Add(new Card("Market Manipulation"));
                cards.Add(new Card("Media Campaign"));
                cards.Add(new Card("Murphy's Law"));
                cards.Add(new Card("Secrets Man Was Not Meant To Know"));
                cards.Add(new Card("Senate Investigating Committee"));
                cards.Add(new Card("Slush Fund"));
                cards.Add(new Card("Swiss Bank Account"));
                cards.Add(new Card("Whispering Campaign"));
                cards.Add(new Card("White Collar Crime"));

                return;
        }
    }
}

public enum DeckType
{
    General, Central
}