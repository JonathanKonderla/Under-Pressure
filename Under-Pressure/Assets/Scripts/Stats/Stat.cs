using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Unity will serialize a custom class
// the fields inside this class will show up in inspector
[System.Serializable]
public class Stat 
{
    [SerializeField] // this makes it editable in the inspector
    private int baseValue; // starting value for given stat

    public int GetValue ()
    {
        return baseValue;
    }
 


}
