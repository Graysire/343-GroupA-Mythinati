using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int actionsRemaining;
    public Group centralGroup;
    public List<Card> specialCards = new List<Card>();
    WinCondition goal;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartTurn()
    {
        centralGroup.StartTurn();
        actionsRemaining = 2;
    }

    public void EndTurn()
    {
        //CheckWinCondition
    }

    public bool CheckWinCondition()
    {
        switch (goal)
        {
            case WinCondition.Bavarian:
                if (centralGroup.GetTotalPower() >= 35)
                {
                    return true;
                }  
                break;
            case WinCondition.Bermuda:
                if (centralGroup.GetTotalAlignments().Count >= 10)
                {
                    return true;
                }
                break;
            case WinCondition.Discordian:
                if (centralGroup.GetTotalAlignments(Alignment.Weird) >= 5)
                {
                    return true;
                }
                break;
            case WinCondition.Gnomes:
                if (centralGroup.GetTotalTreasury() >= 150)
                {
                    return true;
                }
                break;
            case WinCondition.Network:
                if (centralGroup.GetTotalTransferablePower() >= 25)
                {
                    return true;
                }
                break;
            case WinCondition.Servants:
                if (centralGroup.GetTotalGroupsDestroyed() > 8)
                {
                    return true;
                }
                break;
            case WinCondition.Assassins:
                if (centralGroup.GetTotalAlignments(Alignment.Violent) >= 6)
                {
                    return true;
                }
                break;
        }
        return false;
    }

    public enum WinCondition
    {
        Bavarian,Bermuda,Discordian,Gnomes,Network,Servants,Assassins
    }
}

