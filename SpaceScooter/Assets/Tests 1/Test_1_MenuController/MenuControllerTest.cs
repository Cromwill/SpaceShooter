using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuControllerTest : MonoBehaviour
{

    [SerializeField] private MenuRepository _menuRepository;


    private ControlController _gamepadHandler;

    private void Start()
    {
        _gamepadHandler = GetComponent<ControlController>();
        _gamepadHandler.SetCurrentMenu(_menuRepository);
    }

    private void Update()
    {
        _gamepadHandler.UseGamePad();
    }
}
