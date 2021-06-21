using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGrid
{

    public enum Direction {
        up = 0,
        down = 1,
        left = 2,
        right = 3
    }

    List<List<int>> grid;
 
    public PlayGrid(int width, int height){
        grid = new List<List<int>>();

        for (int i = 0; i < width; i++){

            grid.Add(new List<int>());
            
            for (int j = 0; j < height; j++){
                grid[i].Add(0);
            }
        }

    }

    public void Display(float vSize, float hSize){
        //foreach (List<int> row in grid){
            //foreach (int i in row){
                //UtilsClass.CreateWorldText();
            //}
        //}
    }

    public Vector3 GetWorldPosition(float hSize, float vSize, float hOffset, float vOffset, int objectId){
        TryGetObjectIndex(objectId, out int locationX, out int locationY);
        return new Vector3((hSize * locationX) - vOffset + (hSize/2), (vSize * locationY) - hOffset + (vSize/2));
    }

    public bool TrySetLocationOfObject(int id, int locationX, int locationY){
            if (grid[locationX][locationY] == 0) {
                grid[locationX][locationY] = id;

                return true;
            }

        return false; // if we wanna make sad noice when we cannot move
    }

    public bool TryMoveObjectInDirection(int objectId, Direction direction){
        TryGetObjectIndex(objectId, out int locationX, out int locationY);

        int newX = locationX;
        int newY = locationY;
        
        switch(direction){
            case Direction.up:
                newY += 1;
                break;
            case Direction.down:
                newY -= 1;
                break;
            case Direction.left:
                newX -= 1;
                break;
            case Direction.right:
                newX += 1;
                break;
        }
        
        Debug.Log(newX);
        Debug.Log(grid.Count);

        if (newX <= grid.Count-1 && newY <= grid[newX].Count-1){
            if (grid[newX][newY] == 0){
                grid[newX][newY] = objectId;
                grid[locationX][locationY] = 0;

                return true;
            }
        }

        return false;

    }

    public bool TryGetObjectIndex(int objectId, out int locationX, out int locationY){
        locationX = 0;
        locationY = 0;

        locationX = grid.IndexOf(grid.Find(x => objectId == x.Find(y => y == objectId)));
        locationY = grid[locationX].IndexOf(grid[locationX].Find(x => objectId == x));

        return true;

    }

}
