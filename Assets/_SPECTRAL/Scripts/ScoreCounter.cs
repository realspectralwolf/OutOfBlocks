using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [HideInInspector] public int score = 0;

    private List<Crate> cratesInside = new List<Crate>();
    private MiniGameContainer gameContainer;

    private void Awake()
    {
        gameContainer = GetComponentInParent<MiniGameContainer>();
        gameContainer.Counter = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameContainer.GameCanvas.UpdateScoreUI(score);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            AddToPoints(1);

            cratesInside.Add(collision.transform.parent.GetComponent<Crate>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Point"))
        {
            AddToPoints(-1);

            if (cratesInside.Contains(collision.transform.parent.GetComponent<Crate>()))
                cratesInside.Remove(collision.transform.parent.GetComponent<Crate>());
        }
    }

    void AddToPoints(int delta)
    {
        score += delta;
        gameContainer.GameCanvas.UpdateScoreUI(score);
    }

    public void RemoveCratesTouchingFloor()
    {
        for (int i = 0; i < cratesInside.Count; i++)
        {   
            Crate cachedCrate = cratesInside[i];
            if (cachedCrate.isNearFloor)
            {
                cratesInside.Remove(cachedCrate);
                Destroy(cachedCrate.gameObject);
            }
        }
    }
}
