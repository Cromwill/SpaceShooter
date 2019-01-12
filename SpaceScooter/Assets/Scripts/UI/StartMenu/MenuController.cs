using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    public IMenu CurrentMenu;

    private GamepadHandler _gamePadHandler = new GamepadHandler();

	void Start ()
    {
        CurrentMenu = GetComponentsInChildren<GreateMenu>().FirstOrDefault();
	}
	

	void Update ()
    {
        if (_gamePadHandler.isReady)
        {

            if (Input.GetAxisRaw("LeftCrossY") == -1.0f || Input.GetAxisRaw("Vertical") == -1.0f)
            {
                CurrentMenu.GetNextElement();
                _gamePadHandler.UseAxes();
            }
            if (Input.GetAxisRaw("LeftCrossY") == 1.0f || Input.GetAxisRaw("Vertical") == 1.0f)
            {
                CurrentMenu.GetPreviousElement();
                _gamePadHandler.UseAxes();
            }
            if(Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                Debug.Log("Cancel");
                
            }
        }

        _gamePadHandler.Timer(Time.deltaTime);
        CurrentMenu.Show();
    }
}

public class GamepadHandler
{
    public bool isReady = true;

    public float FreezeTime = 0.25f;
    private float _timer = 0;

    public void UseAxes()
    {
        isReady = false;
        _timer = 0;
    }

    public void Timer(float deltaTime)
    {
        _timer += deltaTime;

        if(_timer >= FreezeTime)
        {
            isReady = true;
        }
    }
}

