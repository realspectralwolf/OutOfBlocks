using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private bool isRight = true;
    [SerializeField] private Range moveRange;
    [SerializeField] private float visualFinishX = -0.137f;

    private void Awake()
    {
        GetComponentInParent<MiniGameContainer>().Wall = this;
    }
    private void Start()
    {
        Vector3 pos = Vector3.zero;
        pos.x = moveRange.max;
        transform.position = pos;
    }

    private void Update()
    {
        UpdatePosition(GameManager.Instance.GetNormalizedTimePassed());
    }

    public void UpdatePosition(float value)
    {
        var pos = Vector3.zero;
        pos.x = Mathf.Lerp(moveRange.max, moveRange.min, value);
        transform.position = pos;
    }

    public void PlayFinishAnimation(){
        Transform visual = transform.GetChild(0);
        visual.LeanMoveLocalX(visualFinishX, GameManager.Instance.Settings.finishAnimTime).setEaseInBack()
            .setOnComplete(() => { Instantiate(GameManager.Instance.Settings.finishParticles); });
    }
}

[System.Serializable]
public struct Range{
    public float min;
    public float max;
}