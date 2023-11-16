using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using static UnityEngine.GraphicsBuffer;

public class Punch : MonoBehaviour
{
    List<Transform> cratesInRange = new List<Transform>();
    public int playerId = 0;
    public float hitForce = 0.5f;
    public Transform fist;
    public float hitAnimSpeed = 0.5f;
    public float punchDistance = 2;

    // Start is called before the first frame update
    void Start()
    {
        cachedSprite = fist.GetComponent<SpriteRenderer>();
    }

    SpriteRenderer cachedSprite;
    Sequence punchSequence;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp($"Fire{playerId}"))
        {
            Debug.Log(cratesInRange);
            Rigidbody2D crateRb = GetClosestCrateRb();
            if (crateRb == null) return;

            Vector2 relativeHitPos = (crateRb.transform.position - transform.position);
            crateRb.AddRelativeForce(hitForce * relativeHitPos.normalized);
            fist.rotation = Quaternion.identity;
            Vector2 direction = crateRb.transform.position - transform.position;
            fist.rotation = Quaternion.FromToRotation(Vector3.up, direction);

            //punch effect
            fist.GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
            fist.localPosition = Vector3.zero;
            fist.localScale = Vector3.zero;

            if (punchSequence != null)
            {
                punchSequence.Kill();
            }

            punchSequence = DOTween.Sequence();
            punchSequence.Append(fist.DOLocalMove(relativeHitPos.normalized * punchDistance, hitAnimSpeed))
                .SetEase(Ease.OutElastic);
            punchSequence.Join(fist.DOScale(Vector3.one, hitAnimSpeed));
            var col = cachedSprite.color;
            punchSequence.Append(DOTween.To(() => col.a, x => col.a = x, 0, hitAnimSpeed).OnUpdate(() => cachedSprite.color = col));
            punchSequence.Join(fist.DOLocalMove(Vector3.zero, hitAnimSpeed))
                .SetEase(Ease.OutCubic);
            punchSequence.Join(fist.DOScale(Vector3.zero, hitAnimSpeed))
                .SetEase(Ease.OutCubic);


            punchSequence.Play();
            //fist.GetComponent<SpriteRenderer>().DOFade(0, hitAnimSpeed);
            //fist.DOScale(Vector3.one, hitAnimSpeed);
            //fist.DOLocalMove(relativeHitPos.normalized * punchDistance, hitAnimSpeed);
        }
    }

    Rigidbody2D GetClosestCrateRb()
    {
        Rigidbody2D closestRb = null;
        for (int i = 0; i < cratesInRange.Count; i++)
        {
            if (closestRb == null)
            {
                closestRb = cratesInRange[i].GetComponent<Rigidbody2D>();
            }
            else if (Vector3.Distance(closestRb.transform.position, transform.position) > Vector3.Distance(cratesInRange[i].transform.position, transform.position))
            {
                closestRb = cratesInRange[i].GetComponent<Rigidbody2D>();
            }
        }
        return closestRb;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Crate"))
        {
            cratesInRange.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Crate"))
        {
            cratesInRange.Remove(collision.transform);
        }
    }
}
