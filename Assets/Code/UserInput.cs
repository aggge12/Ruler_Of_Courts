using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput
{
    public List<KeyCode> ActiveCodes {get; private set;}
    public InputEvent BufferedInput {get;set;}
    
    public UserInput(){
        ActiveCodes = new List<KeyCode>();

        ActiveCodes.Add(KeyCode.W);
        ActiveCodes.Add(KeyCode.A);
        ActiveCodes.Add(KeyCode.S);
        ActiveCodes.Add(KeyCode.D);

        BufferedInput = new InputEvent(){
            InputKey = KeyCode.None,
        };
    }

}
