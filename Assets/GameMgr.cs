using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMgr : MonoBehaviour
{
    public PointCounter[] sideManagers;
    public static GameMgr Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void UsePowerUpOnSide(int sideId)
    {
        sideManagers[sideId].RemoveCratesTouchingFloor();
    }
}
