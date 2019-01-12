using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRepository : MonoBehaviour
{
    private IMenuElement[] _menuElements;
    private int _index;


    private void Start()
    {
        int i = 0;
        _menuElements = GetComponentsInChildren<IMenuElement>();


        SelectCurrentElement();
    }

    private void Update() //удалить. Метод для проверки
    {
        Debug.Log("Index - " + _index);
    }

    public void SelectCurrentElement()
    {
        _menuElements[_index].Selected();
    }

    public void GetNextElement()
    {
        _index = ElementsCycle(_menuElements, _index + 1);
        SelectCurrentElement();
    }

    public void GetPreviousElement()
    {
        _index = ElementsCycle(_menuElements, _index - 1);
        SelectCurrentElement();
    }


    private int ElementsCycle<T>(T[] array, int index)
    {
        Debug.Log("Index in Cycle - " + index);
        if (index < 0) return array.Length - 1;
        else if (index >= array.Length) return 0;
        else return index;
    }
}
