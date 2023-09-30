using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool setRunning;
    public bool setMenu;
    public bool setPaused;
   

    public static Enums.GameStatus state;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    
    
    // Update is called once per frame
    void Update()
    {
        if (setRunning)
        {
            state = Enums.GameStatus.running;
            setRunning = false;
        }
        if (setMenu)
        {
            state = Enums.GameStatus.menu;
            setMenu = false;
        }
        if (setPaused)
        {
            state = Enums.GameStatus.paused;
            setPaused = false;
        }
    }

    public static void RestartStage()
    {
        //Gameover sound aka breaking glass. Animation
        //...
        
    }
    
}
