using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a card that f
public class Group : Card
{
    //power of the card usable for attacks
    int power;
    //power of the card usable for iaidng attacks
    int transferablePower;
    //how much is added to the treasury every turn
    int income;
    //how much currency this card has stored
    int treasury;
    //the directions this card can connect to
    bool[] connectingDirections = new bool[4];
    //the groups this card isconnected to
    Group[] connectingGroups = new Group[4];



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
