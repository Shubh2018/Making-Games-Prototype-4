using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private Obs[] _obstacles;

    public void RandomizeObs()
    {
        int randomizeObstacle = Random.Range(0, 101);
        
        if(randomizeObstacle < 80)
        {
            foreach(var obstacle in _obstacles)
                obstacle.Obstacle.gameObject.SetActive(false);   
        }

        else
        {
            if (randomizeObstacle < 85)
            {
                int random = Random.Range(0, 4);

                for (int i = 0; i < _obstacles.Length; i++)
                {
                    if (i != random)
                    {
                        _obstacles[i].Obstacle.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            ChangeObstacleSTate();
        }
    }

    public void ChangeObstacleSTate()
    {
        int randomNumber = Random.Range(0, 4);
        WeatherStates state = (WeatherStates)randomNumber;
        GameManager.Instance.Weather = state;

        while(_obstacles[randomNumber].IsEnabled)
        {
            randomNumber = Random.Range(0, 4);
        }

        foreach (var obstacle in _obstacles)
        {
            obstacle.TurnOff();
        }

        _obstacles[randomNumber].TurnOn();

        Debug.Log($"Weather Changed!: {randomNumber}");
    }
}

[System.Serializable]
public class Obs
{
    [SerializeField] private Obstacles _obstacle;

    [SerializeField] private WeatherStates _weatherState;

    public bool IsEnabled => _obstacle.OnState.gameObject.activeInHierarchy;
    public Obstacles Obstacle => _obstacle;

    public void TurnOn()
    {
       _obstacle.OnState.gameObject.SetActive(true);
        _obstacle.OffState.gameObject.SetActive(false);
    }

    public void TurnOff()
    {
        _obstacle.OnState.gameObject.SetActive(false);
        _obstacle.OffState.gameObject.SetActive(true);
    }
}
