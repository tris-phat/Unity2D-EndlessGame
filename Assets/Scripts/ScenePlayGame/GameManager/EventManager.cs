using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    //Event count number star
    //1.Call to Script PickupStar
    //2.Call to GameManager
    public static event Action CountStarEvent;

    public static event Action GameOverEvent;

    public static void CountStart()
    {
        CountStarEvent?.Invoke();
    }

    public static void GameOver()
    {
        GameOverEvent?.Invoke();
    }
}
