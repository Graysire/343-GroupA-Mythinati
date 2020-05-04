using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int actionsRemaining;
    public Group centralGroup;
    public List<Card> specialCards = new List<Card>();

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
}
