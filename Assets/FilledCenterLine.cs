using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FilledCenterLine : MonoBehaviour
{
    [SerializeField] Vector3 startPos = new Vector3 (0, 12, 0);
    [SerializeField] float _animSpeed = .6f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = startPos;
        transform.DOMove(Vector3.zero, _animSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
