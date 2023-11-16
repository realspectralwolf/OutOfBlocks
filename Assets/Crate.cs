using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
    public bool isNearFloor = false;

    public void ChildTriggerEnter(Collider2D collision)
    {
        if (collision.CompareTag("SideWall"))
        {
            isNearFloor = true;
        }
    }

    public void ChildTriggerExit(Collider2D collision)
    {
        if (collision.CompareTag("SideWall"))
        {
            isNearFloor = false;
        }
    }
}
