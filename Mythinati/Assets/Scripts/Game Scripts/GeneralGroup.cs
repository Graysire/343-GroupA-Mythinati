using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralGroup : Group
{


    //how well the group resists control neutralization and destruction
    protected int resistance;

    public GeneralGroup(string name, int pow, int transferable, int resist, int income, int[] connectDirect, List<Alignment> align) : base(name, pow, transferable, income, connectDirect, align)
    {
        resistance = resist;
    }

    //returns the resistance of this group
    public int GetResistance()
    {
        return resistance;
    }

}
