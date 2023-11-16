using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class PointCounter : MonoBehaviour
{
    public int points = 0;
    public TextMeshProUGUI textMeshProUGUI;
    public TextMeshProUGUI finalText;
    public List<Crate> cratesInside = new List<Crate>();
    
    // Start is called before the first frame update
    void Start()
    {
        textMeshProUGUI.text = $"{points}";
    }

    // Update is called once per frame
    void Update()
    {
        
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
        points += delta;
        textMeshProUGUI.text = $"{points}";
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
