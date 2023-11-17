using UnityEngine;

public class CenterLine : MonoBehaviour
{
    [SerializeField] Vector3 startPos = new Vector3 (0, 12, 0);
    [SerializeField] float _animSpeed = .6f;

    Transform filledLine;

    // Start is called before the first frame update
    void Start()
    {
        filledLine = transform.GetChild(0);
        filledLine.localPosition = startPos;
        filledLine.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        GameManager.OnRoundFinished += PlayFilledLine;
    }

    private void OnDisable()
    {
        GameManager.OnRoundFinished -= PlayFilledLine;
    }

    private void PlayFilledLine()
    {
        filledLine.gameObject.SetActive(true);
        filledLine.LeanMoveLocal(Vector3.zero, _animSpeed);
        AudioManager.Instance.PlayAudioClip(GameManager.Instance.Settings.gateClosedClip);
    }
}
