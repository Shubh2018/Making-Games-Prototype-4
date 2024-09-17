using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _onState;
    [SerializeField] private SpriteRenderer _offState;

    public SpriteRenderer OnState => _onState;
    public SpriteRenderer OffState => _offState;    
}
