using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool setRunning;
    public bool setMenu;
    public bool setPaused;
    public enum GameStatus
    {
        running,
        menu,
        paused
    }

    public static GameStatus state;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
        if (setRunning)
        {
            state = GameStatus.running;
            setRunning = false;
        }
        if (setMenu)
        {
            state = GameStatus.menu;
            setMenu = false;
        }
        if (setPaused)
        {
            state = GameStatus.paused;
            setPaused = false;
        }
    }
    
}
