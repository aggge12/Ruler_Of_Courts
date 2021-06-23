using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGrid : MonoBehaviour
{
    public List<Card> CardSlots {get;set;}
    public Deck Deck {get;set;}

    void Start()
    {
        transform.position = new Vector2(1, 1);
        CardSlots = new List<Card>();
        Draw();
        
        
    }

    void Update()
    {   
        // test
        CardSlots[0].gameObject.transform.position = new Vector2(CardSlots[0].gameObject.transform.position.x - 0.1f, CardSlots[0].gameObject.transform.position.y);
    }


    private void Draw(){
        GameObject obj = Resources.Load("Prefabs/Cards/RoC_Testcard") as GameObject;
        var gameObject = Object.Instantiate(obj, new Vector2(1,1), Quaternion.identity);
        CardSlots.Add(gameObject.GetComponent<Card>());
    }


}
