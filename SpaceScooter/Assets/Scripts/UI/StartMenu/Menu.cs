using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour, IMenu
{
    public IMenu CurrentMenu;
    public List<IMenu> Elements = new List<IMenu>();
    public UIBehaviour Element;

    private int _index;

    private void Start()
    {
        //if (Elements == null)
        //{
        //    foreach (var v in GetComponentsInChildren<Menu>())
        //    {
        //        Debug.Log(v.name);

        //    }
        //}
        foreach (var v in GetComponentsInChildren<Menu>())
        {
            Debug.Log(v.name);

        }

    }

    public void Show()
    {
        
    }

    public void GetNextElement()
    {
        _index++;

    }

    public void GetPreviousElement()
    {
        _index--;

    }

    public void UseElement(GameObject obj)
    {
        throw new System.NotImplementedException();
    }

    private int GetIndex(int value)
    {
        if (_index > Elements.Count - 1)
        {
            return 0;
        }

        else if(_index < 0)
        {
            return Elements.Count - 1;
        }

        else
        {
            return value;
        }
    }
}
