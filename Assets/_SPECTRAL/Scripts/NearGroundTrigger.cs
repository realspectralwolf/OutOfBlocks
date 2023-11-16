using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NearGroundTrigger : MonoBehaviour
{
    Crate crate;

    // Start is called before the first frame update
    void Start()
    {
        crate = GetComponentInParent<Crate>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        crate.ChildTriggerEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        crate.ChildTriggerExit(collision);
    }
}
