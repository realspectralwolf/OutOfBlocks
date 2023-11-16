using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public int sideId = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //GameMgr.Instance.UsePowerUpOnSide(sideId);
            Destroy(gameObject);
        }
    }
}
