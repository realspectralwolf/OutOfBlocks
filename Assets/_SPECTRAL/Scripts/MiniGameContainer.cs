using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameContainer : MonoBehaviour
{
    [HideInInspector] public Wall Wall;
    [HideInInspector] public ScoreCounter Counter;
    [HideInInspector] public Spawner Spawner;
    [HideInInspector] public GameCanvas GameCanvas;

    public bool isRight = false;
}
