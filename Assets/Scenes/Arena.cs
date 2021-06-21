using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public float cellSizeVertical, cellSizeHorizontal;
    public int tickInterval;

    private List<GameObject> gameObjects;
    private PlayGrid playGrid; 
    private float currentTickCounter;
    private int _playerID = 1;
    public int height;
    public int width;
    private float arenaHeight;
    private float arenaWidth;
    private UserInput userInput;


    void Start()
    {
        height = 5;
        width = 6;

        playGrid = new PlayGrid(width, height);

        userInput = new UserInput();
        
        gameObjects = new List<GameObject>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        gameObjects.Add(player);

        currentTickCounter = 0;
        tickInterval = 1;

        arenaHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        arenaWidth = GetComponent<SpriteRenderer>().bounds.size.x;

        cellSizeHorizontal = arenaWidth/width;
        cellSizeVertical = arenaHeight/height;

        Debug.Log(cellSizeHorizontal);
        Debug.Log(cellSizeVertical);

        playGrid.TrySetLocationOfObject(_playerID, 0, 0);

        SaveNewPosition(_playerID, player);
    }

    void Update()
    {
        BufferInput();

        currentTickCounter += Time.deltaTime * 1;

        if (currentTickCounter >= tickInterval){

            currentTickCounter = 0;

            foreach (GameObject character in gameObjects){

                if (userInput.BufferedInput != null){
                    if (userInput.BufferedInput.InputKey == KeyCode.S){
                        playGrid.TryMoveObjectInDirection(_playerID, PlayGrid.Direction.down);
                    }
                    else if (userInput.BufferedInput.InputKey == KeyCode.W){
                        playGrid.TryMoveObjectInDirection(_playerID, PlayGrid.Direction.up);
                    }
                    else if (userInput.BufferedInput.InputKey == KeyCode.A){
                        playGrid.TryMoveObjectInDirection(_playerID, PlayGrid.Direction.left);
                    }
                    else if (userInput.BufferedInput.InputKey == KeyCode.D){ 
                        playGrid.TryMoveObjectInDirection(_playerID, PlayGrid.Direction.right);
                    }
                }

                userInput.BufferedInput.KeyDownEventHasExpired = true;
                
                SaveNewPosition(_playerID, character);
            }
        }
    }

    private void BufferInput(){
        foreach(KeyCode keyCode in userInput.ActiveCodes){
            if (Input.GetKeyDown(keyCode)){
                userInput.BufferedInput = new InputEvent() {InputKey = keyCode, KeyDownEventHasExpired = false};
            }
            else if (userInput.BufferedInput.InputKey == keyCode && !Input.GetKey(keyCode) && userInput.BufferedInput.KeyDownEventHasExpired == true){
                userInput.BufferedInput = new InputEvent() {InputKey = KeyCode.None, KeyDownEventHasExpired = true};
            }
            
        }
    }

    public void SaveNewPosition(int playerID, GameObject o){
        Vector3 position = playGrid.GetWorldPosition(cellSizeHorizontal, cellSizeVertical, arenaHeight / 2, arenaWidth / 2, playerID);

        position.z = -1;
        o.transform.position = position;

        Debug.Log(o.transform.position);
    }

}
