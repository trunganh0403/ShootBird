using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgController : MonoBehaviour
{
    public Sprite[] BgSprites;
    public SpriteRenderer BgRenderer;

    private void Start()
    {
        RandomBg();
    }
    void RandomBg()
    {
       
        if (BgSprites!= null && BgRenderer != null && BgSprites.Length >0 )
        {
            int ranDomInt = Random.Range(0, BgSprites.Length);
            if (BgSprites[ranDomInt] != null )
            {
                BgRenderer.sprite = BgSprites[ranDomInt];
            }
           
        }
    }
}
