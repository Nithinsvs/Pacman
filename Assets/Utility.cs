using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour
{

    public static float screenWidthInPoints, screenHeightInPoints;


    public static float GetWorldWidth()
    {
        float height = 2.0f * Camera.main.orthographicSize;

        screenWidthInPoints = height * Camera.main.aspect;
        return screenWidthInPoints;
    }

    public static float GetWorldHeight()
    {
        screenHeightInPoints = 2.0f * Camera.main.orthographicSize;
        return screenHeightInPoints;
    }


}