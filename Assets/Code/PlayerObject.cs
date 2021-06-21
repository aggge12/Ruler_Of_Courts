using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject
{
    private GameObject obj;

    public PlayerObject(string tag)
    {
        obj = GameObject.FindGameObjectWithTag(tag);
    }
}
