using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;
   
    [SerializeField] Sprite[] hitSprites;


    // cached reference 
    level Level;

    //state var
    [SerializeField] int timesHit;  

    private void Start()
    {
       Level = FindObjectOfType<level>();
        if (tag == "Breakable")

        {
            Level.CountBlocks();
        }
    }

   private void OnCollisionEnter2D(Collision2D colliosion)
    {
        

        if (tag == "Breakable")
        {
            timesHit++;
            int maxHits = hitSprites.Length + 1;
            if (timesHit >= maxHits)
            {
                FindObjectOfType<GameSession>().AddToScore();
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);

                Destroy(gameObject);
                Level.BlockDestroyed();
                TriggerSparklesVFX();
            }

            else
            {
                ShowNextHitSprite();
                
            }
            
        }

    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = timesHit - 1;

        if(spriteIndex != null)
        {
            GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
        }
        else
        {
            Debug.LogError("Block Sprite is missing from array + gameObject.name");
        }
        
    }


    private void TriggerSparklesVFX()
    {
        GameObject sparkles = Instantiate(blockSparklesVFX,transform.position,transform.rotation);
    }

}
