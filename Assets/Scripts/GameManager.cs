using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public enum WeatherStates { Autumn, Winter, Summer, Spring };
public enum ObstacleStates { On, Off };

public class GameManager : MonoBehaviour
{   
    private static GameManager instance;

    public static GameManager Instance => instance;

    private void Awake()
    {
        if (instance != this)
            instance = this;
        else
        {
            Destroy(instance.gameObject);
            instance = this;
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
