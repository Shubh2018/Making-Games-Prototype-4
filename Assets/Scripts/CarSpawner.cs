using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private CarController _car;
    private CinemachineVirtualCamera _camera;

    private void Awake()
    {
        CarController car = Instantiate(_car, this.transform.position, Quaternion.identity);
        _camera = FindObjectOfType<CinemachineVirtualCamera>();
        _camera.Follow = _camera.LookAt = car.transform;
    }
}
