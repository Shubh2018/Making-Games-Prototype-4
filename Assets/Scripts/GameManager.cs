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

    public WeatherStates Weather { get; set; }

    private ObstacleManager[] _obstacleManagers;

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

    private void Start()
    {
        Weather = WeatherStates.Spring;
        _obstacleManagers = FindObjectsOfType<ObstacleManager>();

        if(_obstacleManagers.Length > 0)
        {
            foreach(var obstacleManager in _obstacleManagers)
            {
                obstacleManager.RandomizeObs();
            }
        }
    }
}
