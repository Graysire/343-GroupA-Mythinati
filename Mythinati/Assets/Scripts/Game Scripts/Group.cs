using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a card that represents some power group or
public class Group : Card
{

    //power of the card usable for attacks
    protected int power;
    //power of the card usable for iaidng attacks
    protected int transferablePower;
    //how much is added to the treasury every turn
    protected int income;
    //how much currency this card has stored
    protected int treasury;
    //whether this card is controlled
    protected Player controller;
    //distance from Central Group
    protected int distanceFromCentral;
    //whether this card has attacked this turn
    protected bool hasAttacked;
    //the number of Groups this group has successfully destroyed
    protected int groupsDestroyed;

    //the directions this card can connect to -1 is recieving, 0 is none, 1 is sending
    int[] connectingDirections = new int[4];
    //the groups this card is connected to
    Group[] connectingGroups = new Group[4];
    //the list of alignments this group is
    List<Alignment> alignments;

    public Group(string name, int pow, int transferable, int income, int[] connectDirect, List<Alignment> align) : base(name)
    {
        power = pow;
        transferablePower = transferable;
        this.income = income;
        treasury = 0;
        connectingDirections = connectDirect;
        connectingGroups = new Group[4];
        alignments = align;

        controller = null;
        distanceFromCentral = -1;
        hasAttacked = false;
        groupsDestroyed = 0;
    }

    //the start of turn operations all groups
    public void StartTurn()
    {
        treasury += income;
        hasAttacked = false;
        for(int i = 0; i < 4; i++)
        {
            //start turn for connected groups
            if (connectingGroups[i] != null && connectingDirections[i] == 1)
            {
                connectingGroups[i].StartTurn();
            }
        }
    }

    //attacks another group
    public void Attack(GeneralGroup target, AttackType atk)
    {
        hasAttacked = true;
        //roll 2d6 for determining outcome
        int diceRoll = Random.Range(1, 6) + Random.Range(1, 6);
        //the number to beat with the roll
        int targetNumber = 0;

        //set base target numbers based on attack type
        switch (atk)
        {
            case AttackType.Control:
                targetNumber = power - target.GetResistance();
                //check alignment oppositon and add power
                break;
            case AttackType.Destroy:
                targetNumber = power - target.power;
                //check alignment oppositon and add power
                break;
            case AttackType.Neutralize:
                targetNumber = power - target.GetResistance() + 6;
                break;
            default:
                targetNumber = power - target.GetResistance();
                break;

        }

        //decrease target number based on proximity to Central Group
        if (target.distanceFromCentral == 1)
        {
            targetNumber -= 10;
        }
        else if (target.distanceFromCentral == 2)
        {
            targetNumber -= 5;
        }
        else if (target.distanceFromCentral == 3)
        {
            targetNumber -= 2;
        }

        //prompt source player for Assassination
        //prompt other players for Murphy's Law

        if (diceRoll > 10)
        {
            Debug.Log("Attack Failed");
            return;
        }

        //prompt source and target players to use transferable power
        //prompt source and target players to spend money
        //prompt other players for Interference
        //prompt source player for Privilege

        //determine if attack fails, exit if true
        if (diceRoll > targetNumber)
        {
            Debug.Log("Attack Failed");
            return;
        }

        switch (atk)
        {
            case AttackType.Control:
                //prompt selection of arrow to control target from
                target.treasury /= 2;
                target.controller = this.controller;
                //prompt free transfer
                break;
            case AttackType.Destroy:
                targetNumber = power - target.power;
                target.ResetControl();
                groupsDestroyed++;
                //move target to destroyed pile
                break;
            case AttackType.Neutralize:
               target.ResetControl();
                break;
            default:
                targetNumber = power - target.GetResistance();
                break;

        }

    }

    //resets the control of this and its subordinate groups to false
    void ResetControl()
    {
        controller = null;
        treasury = 0;
        hasAttacked = false;
        distanceFromCentral = -1;
        for (int i = 0; i < 4; i++)
        {
            //checks for groups to reset and removes itself from the parent group
            if (connectingGroups[i] != null && connectingDirections[i] == 1)
            {
                connectingGroups[i].ResetControl();
            }
            else if (connectingGroups != null && connectingDirections[i] == -1)
            {
                connectingGroups[i].RemoveGroup(this);
            }
        }
    }

    //removes a specific group from the connecting groups
    void RemoveGroup(Group other)
    {
        for (int i = 0; i < 4; i++)
        {
            //checks for the group to remove
            if (connectingGroups[i] == other)
            {
                connectingGroups[i] = null;
            }
        }
    }

    //gets the total power of all groups in the hierarchy
    public int GetTotalPower()
    {
        int sum = power;
        //for each subgroup, add its power
        for (int i = 0; i < 4; i++)
        {
            if (connectingGroups[i] != null && connectingDirections[i] == 1)
            {
                sum += connectingGroups[i].GetTotalPower();
            }
        }
        return sum;
    }

    //gets the list of all alignments in the hierarchy
    public List<Alignment> GetTotalAlignments()
    {
        List<Alignment> align = new List<Alignment>();
        //add all alignments except for None
        foreach (Alignment a in alignments)
        {
            if (a != Alignment.None)
            {
                align.Add(a);
            }
        }
        //for each subgroup add its alignments
        for (int i = 0; i < 4; i++)
        {
            if (connectingGroups[i] != null && connectingDirections[i] == 1)
            {
                List<Alignment> connectAlign = connectingGroups[i].GetTotalAlignments();
                foreach (Alignment a in connectAlign)
                {
                    if (!align.Contains(a) && a != Alignment.None)
                    {
                        align.Add(a);
                    }
                }
            }
        }

        return align;
    }

    //gets the total number of groups in the hierarchy with a specified alignment
    public int GetTotalAlignments(Alignment alignment)
    {
        int sum = 0;
        if (alignments.Contains(alignment))
        {
            sum++;
        }

        //for each subgroup, check whether it contains the alignment
        for (int i = 0; i < 4; i++)
        {
            if (connectingGroups[i] != null && connectingDirections[i] == 1)
            {
                sum += connectingGroups[i].GetTotalAlignments(alignment);
            }
        }

        return sum;
    }

    //gets the total transferable power of all groups in the hierarchy
    public int GetTotalTransferablePower()
    {
        int sum = transferablePower;
        //for each subgroup, add its power
        for (int i = 0; i < 4; i++)
        {
            if (connectingGroups[i] != null && connectingDirections[i] == 1)
            {
                sum += connectingGroups[i].GetTotalTransferablePower();
            }
        }
        return sum;
    }

    //gets the total currency of all groups in the hierarchy
    public int GetTotalTreasury()
    {
        int sum = treasury;
        //for each subgroup, add its power
        for (int i = 0; i < 4; i++)
        {
            if (connectingGroups[i] != null && connectingDirections[i] == 1)
            {
                sum += connectingGroups[i].GetTotalTreasury();
            }
        }
        return sum;
    }

    //gets the total number of groups destroyed in the hierarchy
    public int GetTotalGroupsDestroyed()
    {
        int sum = groupsDestroyed;
        //for each subgroup, add its power
        for (int i = 0; i < 4; i++)
        {
            if (connectingGroups[i] != null && connectingDirections[i] == 1)
            {
                sum += connectingGroups[i].GetTotalGroupsDestroyed();
            }
        }
        return sum;
    }


    public bool GetAlignmentOpposition(Alignment first, Alignment second)
    {
        switch (first)
        {
            case Alignment.Government:
                if (second == Alignment.Communist)
                {
                    return true;
                }
                return false;
            case Alignment.Communist:
                if (second == Alignment.Government)
                {
                    return true;
                }
                return false;
            case Alignment.Liberal:
                if (second == Alignment.Conservative)
                {
                    return true;
                }
                return false;
            case Alignment.Conservative:
                if (second == Alignment.Liberal)
                {
                    return true;
                }
                return false;
            case Alignment.Violent:
                if (second == Alignment.Peaceful)
                {
                    return true;
                }
                return false;
            case Alignment.Peaceful:
                if (second == Alignment.Violent)
                {
                    return true;
                }
                return false;
            case Alignment.Weird:
                if (second == Alignment.Straight)
                {
                    return true;
                }
                return false;
            case Alignment.Straight:
                if (second == Alignment.Weird)
                {
                    return true;
                }
                return false;
            case Alignment.Fanatic:
                if (second == Alignment.Fanatic)
                {
                    return true;
                }
                return false;
            default:
                return false;
        }
    }

}

public enum Alignment
{
    Government, Communist, Liberal, Conservative, Peaceful, Violent, Straight, Weird, Criminal, Fanatic, None

    
}

//enums used to determinethe tpye of attack
public enum AttackType { Control, Neutralize, Destroy }