using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] private Obs[] _obstacles;

/*    private void Start()
    {
        this.transform.position = new Vector2(Random.Range(0, 10), Random.Range(0, 10));
    }*/

    public void RandomizeObs()
    {
        int randomizeObstacle = Random.Range(0, 100);
        
        if(randomizeObstacle < 40)
        {
            foreach(var obstacle in _obstacles)
                obstacle.Obstacle.gameObject.SetActive(false);   
        }

        else
        {
            if (randomizeObstacle < 100)
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

/*    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            ChangeObstacleState();
        }
    }*/

    public void ChangeObstacleState(int state)
    {
        //int randomNumber = Random.Range(0, 4);

/*        while(_obstacles[state].IsEnabled)
        {
            randomNumber = Random.Range(0, 4);
        }*/

        foreach (var obstacle in _obstacles)
        {
            obstacle.TurnOn();
        }

        _obstacles[state].TurnOff();

        Debug.Log($"Weather Changed!: {state}");
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