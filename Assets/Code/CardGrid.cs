using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGrid : MonoBehaviour
{

    public List<Card> CardSlots {get;set;}
    public Deck Deck {get;set;}

    private float _gridWidth;
    private float _gridHeight;

    void Start()
    {
        _gridHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        _gridWidth = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        
    }
}
