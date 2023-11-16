using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

public class BottomAxe : MonoBehaviour
{
    public int playerId = 0;
    public int speed = 3;
    public float extensionLength = 3;

    Vector3 startPos, extendPos;

    [SerializeField] private CapsuleCollider2D collider;
    float value = 0;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.localPosition;
        extendPos = startPos + Vector3.down * extensionLength;
        //collider = GetComponentInParent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw($"Vertical{playerId}") < 0)
        {
            value += Time.deltaTime * speed;
        }
        else
        {
            value -= Time.deltaTime * speed;
        }
        value = Mathf.Clamp01(value);
        Vector2 newSize = new Vector2(0.96f, 1.32f - 0.27f * value);
        Vector2 newOffset = new Vector2(0, 0.7f + 0.11f * value);

        collider.size = newSize;
        collider.offset = newOffset;
    }
}
