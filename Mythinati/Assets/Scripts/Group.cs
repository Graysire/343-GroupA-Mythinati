﻿using System.Collections;
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
    protected bool isControlled;
    //distance from Central Group
    protected int distanceFromCentral;
    //whether this card has attacked this turn
    protected bool hasAttacked;

    //the directions this card can connect to -1 is recieving, 0 is none, 1 is sending
    int[] connectingDirections = new int[4];
    //the groups this card is connected to
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

        isControlled = false;
        distanceFromCentral = -1;
        hasAttacked = false;
    }

    //the start of turn operations all groups
    public void StartTurn()
    {
        treasury += income;
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
                //prompt free transfer
                break;
            case AttackType.Destroy:
                targetNumber = power - target.power;
                //target.ResetControl(true)
                break;
            case AttackType.Neutralize:
                //target.ResetControl(false);
                break;
            default:
                targetNumber = power - target.GetResistance();
                break;

        }

    }


}

public enum Alignment
{
    Government, Communist, Liberal, Conservative, Peacful, Violent, Straight, Weird, Criminal, Fanatic, None
}

//enums used to determinethe tpye of attack
public enum AttackType { Control, Neutralize, Destroy }