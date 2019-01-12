using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuElement : MonoBehaviour, IMenuElement
{
    private Button _selfBatton;


    private void Start()
    {
        _selfBatton = GetComponent<Button>();
    }

    public void Selected()
    {
        _selfBatton.Select();
    }

    public void UseElement()
    {
        
    }
}
