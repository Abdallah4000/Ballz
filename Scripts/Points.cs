using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    int hitsRemaining = 10;
    
    [SerializeField] TextMeshProUGUI text ;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateTheBlockState();
    }

    void UpdateTheBlockState()
    {
        text.SetText(hitsRemaining.ToString());
        spriteRenderer.color = Color.Lerp(new Color32(119,217,186,166), new Color32(255,71,0,166) , hitsRemaining / 10f);
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        hitsRemaining--;

        if(hitsRemaining > 0)
        {
            UpdateTheBlockState();
        }
        else
        {


            GameManager.gm.score ++;
            if(GameManager.gm.score > GameManager.gm.highScore)
            {
                GameManager.gm.highScore = GameManager.gm.score;
                GameManager.gm.SaveHihgScore();
            }

            Destroy(gameObject);
        }
    }

    public void SetHits(int hits)
    {
        hitsRemaining = hits;
        UpdateTheBlockState();

    }

}
