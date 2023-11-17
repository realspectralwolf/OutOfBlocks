using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnim : MonoBehaviour
{
    [SerializeField] float animSpeed = 0.4f;
    // Start is called before the first frame update
    void Start()
    {
        transform.LeanScale(Vector3.one * 1.03f, animSpeed).setEaseInOutQuad().setLoopPingPong();
    }
}
