using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a card that represents some power group or
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
    //the directions this card can connect to -1 is recieving, 0 is none, 1 is sending
    int[] connectingDirections = new int[4];
    //the groups this card isconnected to
    Group[] connectingGroups = new Group[4];
    //the list of alignments this group is
    List<Alignment> alignments;

    public Group(string name, int pow, int transferable, int income, int[] connectDirect, Group[] connectGroup, List<Alignment> align) : base(name)
    {
        power = pow;
        transferablePower = transferable;
        this.income = income;
        treasury = 0;
        connectingDirections = connectDirect;
        connectingGroups = connectGroup;
        alignments = align;
    }

    public void startTurn()
    {
        treasury += income;
        foreach (Group g in connectingGroups)
        {
            if (g != null)
            {
                g.startTurn();
            }
        }
    }

}

public enum Alignment
{
    Government, Communist, Liberal, Conservative, Peacful, Violent, Straight, Weird, Criminal, Fanatic, None
}