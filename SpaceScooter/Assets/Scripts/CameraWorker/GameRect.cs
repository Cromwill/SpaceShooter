using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRect : MonoBehaviour
{

    public static float LeftBrim = 1f;
    public static float RightBrim = 1f;
    public static float UpBrim = 1f;
    public static float DownBrim = 1f;

    private static Rect _gameRect;
    private static Camera _main;



    private static void AppointRect()
    {
        if(_main == null)
        {
            _main = Camera.main;
        }

        Vector3 startPosition = _main.ScreenToWorldPoint(new Vector3(_main.pixelRect.xMin, _main.pixelRect.yMin));
        Vector3 finishPosition = _main.ScreenToWorldPoint(new Vector3(_main.pixelRect.xMax, _main.pixelRect.yMax));

        Vector3 position = new Vector3(startPosition.x + LeftBrim, startPosition.y + DownBrim);
        float width = Vector3.Distance(new Vector3(position.x, 0), new Vector3(finishPosition.x - RightBrim, 0));
        float hight = Vector3.Distance(new Vector3(0, position.y), new Vector3(0, finishPosition.y - UpBrim));
        Vector3 size = new Vector3(width, hight);

        _gameRect = new Rect(position, size);

    }

    public static Rect GetGameRect()
    {
        AppointRect();
        return _gameRect;
    }

    public float[] GetXPositions(int collumn)
    {
        AppointRect();

        float[] collumns = new float[collumn];
        float step = _gameRect.size.x / (collumn + 1);


        float Xposition = _gameRect.xMin;

        for(int i = 0; i < collumns.Length; i++)
        {
            Xposition += step;
            collumns[i] = Xposition;

        }

        return collumns;
    }

    public float[] GetYPositions(float YInterval)
    {
        AppointRect();


        int lineCount = Mathf.CeilToInt(_gameRect.size.y / YInterval);


        float YPosition = _gameRect.yMax;
        float[] lines = new float[lineCount]; 

        for(int i = 0; i < lines.Length; i++)
        {
            YPosition += YInterval;
            lines[i] = YPosition;
        }

        return lines;
    }

    public bool IsContainsPosition(Vector3 position)
    {
        AppointRect();
        return _gameRect.Contains(position);
    }
}
