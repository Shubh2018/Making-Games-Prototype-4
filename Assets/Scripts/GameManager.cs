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
    private WeatherController _weatherController;

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
        _weatherController = FindObjectOfType<WeatherController>();

        if(_obstacleManagers.Length > 0)
        {
            foreach(var obstacleManager in _obstacleManagers)
            {
                obstacleManager.RandomizeObs();
                obstacleManager.ChangeObstacleState((int)Weather);
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            foreach(var obstacleManager in _obstacleManagers)
            {
                obstacleManager.ChangeObstacleState((int)Weather);
            }
        }
    }
}
