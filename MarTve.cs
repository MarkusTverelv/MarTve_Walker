using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarTve : IRandomWalker
{
    //Add your own variables here.
    //Do not use processing variables like width or height
    int[] direction = new int[40];

    int maxHeight = 0;
    int maxWidth = 0;

    int currentPosition = 0;

    public string GetName()
    {
        return "MarTveWalker"; //When asked, tell them our walkers name
    }

    public Vector2 GetStartPosition(int playAreaWidth, int playAreaHeight)
    {
        maxHeight = playAreaHeight;
        maxWidth = playAreaWidth;

        //Select a starting position or use a random one.
        float x = playAreaWidth / 2;
        float y = playAreaHeight / 2;

        //a PVector holds floats but make sure its whole numbers that are returned!
        return new Vector2(x, y);
    }

    public Vector2 Movement()
    {
        //add your own walk behavior for your walker here.
        //Make sure to only use the outputs listed below.

        for (int i = 0; i < direction.Length; i++)
            direction[i] = Mathf.RoundToInt(Random.Range(0, 16) * Mathf.PerlinNoise(100, 100) * 2.15f) / 4;

        currentPosition = direction[Random.Range(0, 40)];

        switch (currentPosition)
        {
            case 0:
                return new Vector2(-1, 0);  //Left
            case 1:
                return new Vector2(1, 0);   //Right
            case 2:
                return new Vector2(0, 1);   //Up
            default:
                return new Vector2(0, -1);  //Down
        }
    }
}
