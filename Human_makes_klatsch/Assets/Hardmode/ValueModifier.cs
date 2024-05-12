using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ValueModifier : MonoBehaviour
{
    Hardmode hardmode = new Hardmode();

    public void ModifySpeed()
    {
        if (hardmode.GetMoreSpeed())
        {
            //fallspeed times two
        }
        else if (hardmode.GetLessSpeed())
        {
            //fallspeed duvuded by two
        }
        else if(!hardmode.GetMoreSpeed() && !hardmode.GetLessSpeed())
        {
            //fallspeed remains unchanged
        }
    }

    public void ModifyNestSpawn()
    {
        if(hardmode.GetNoNests())
        {
            //Nests deactivated on Level start
        }
        else
        {
            //Nests activated on Level start
        }
    }

    public void ModifyHealth()
    {
        if(hardmode.GetHalfHealth())
        {
            //Egg health divided by Two
        }
        else if (hardmode.GetDoubleHealth())
        {
            //Egg health doubled
        }
        else if(!hardmode.GetHalfHealth() && !hardmode.GetDoubleHealth())
        {
            //Egg health remains unchained
        }
    }


}
