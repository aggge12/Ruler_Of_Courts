using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerObject
{
    private GameObject obj;
    // public List<Card> deck;
    // public Lst<Card> hand;
    // public Card currentPlay;

    public PlayerObject(string tag)
    {
        obj = GameObject.FindGameObjectWithTag(tag);
    }

    public void Shuffle(){

    }

    public void Draw(int amount){
        // add to hand
        // remove from deck
    }

    public void Play(){
        // play card
    }
}
