using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IMenu
{
    void GetNextElement();
    void GetPreviousElement();
    void UseElement(GameObject obj);
    void Show();
}
