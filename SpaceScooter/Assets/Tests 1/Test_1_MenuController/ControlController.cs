using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlController : MonoBehaviour
{
    [SerializeField] private float _freezeTime;
    private MenuRepository _currentMenu;
    private bool _isAxisReady = true;
    private float _timer;

    public Action UseBattonEvent;
    public Action CancelButtonEvent;

    private void Update()
    {
        if (!_isAxisReady)
        {
            _timer += Time.deltaTime;
            if (_timer > _freezeTime) _isAxisReady = true;
        }
    }

    public void UseGamePad()
    {
        if (_isAxisReady)
        {
            if (Input.GetAxisRaw("LeftCrossY") == -1.0f || Input.GetAxisRaw("Vertical") == -1.0f)
            {
                _currentMenu.GetNextElement();
                UseAxis();
                return;
            }
            if (Input.GetAxisRaw("LeftCrossY") == 1.0f || Input.GetAxisRaw("Vertical") == 1.0f)
            {
                _currentMenu.GetPreviousElement();
                UseAxis();
                return;
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                UseBattonEvent?.Invoke();
            }
            if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            {
                CancelButtonEvent?.Invoke();
            }
        }
    }

    public void SetCurrentMenu(MenuRepository repositoriy)
    {
        _currentMenu = repositoriy;
    }

    private void UseAxis()
    {
        _isAxisReady = false;
        _timer = 0;
    }
}