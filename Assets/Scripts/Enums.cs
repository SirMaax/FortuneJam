using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enums : MonoBehaviour
{
    public enum EnumBulletType
    {
        player,
        bulletHellBullet,
    }
    
    public enum RefEnum
    {
        inputHandler,
        playerControl,
    }

    public enum RefEnumGame
    {
        player,
    }
    
    public enum GameStatus
    {
        running,
        menu,
        paused
    }
}
