using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreateMenu : MonoBehaviour, IMenu
{
    public Button[] Battons;

    private int _index;

    public void GetNextElement()
    {
        _index++;
        SetIndex();

    }

    public void GetPreviousElement()
    {
        _index--;
        SetIndex();
    }

    public void UseElement(GameObject obj)
    {
        if(!obj.activeSelf)
        {
            obj.SetActive(true);
        }
        else
        {
            obj.SetActive(false);
        }
    }

    public void Show() // убрать потом
    {
        Debug.Log("Array Leneght - " + Battons.Length);
        Debug.Log("Index - " + _index);
        Battons[_index].Select();
    }

    private void SetIndex()
    {
        if (_index > Battons.Length - 1)
        {
            _index = 0;
        }

        else if (_index < 0)
        {
            _index = Battons.Length - 1;
        }

    }

}
