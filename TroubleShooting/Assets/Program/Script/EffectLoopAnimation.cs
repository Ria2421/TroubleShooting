using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectLoopAnimation : MonoBehaviour
{
    Texture texture;
    public Sprite[] sprites;
    private SpriteRenderer sprite;
    private int index;
    private int count; 
    public int frame = 60;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        SetSprite(sprites[0]);
        index = 0;
        count = 0;
    }

    void Update () 
    {
        if(sprites.Length>index){
            SetSprite(sprites[index]);
        }else{
            Destroy(gameObject);
        }
        if(count>frame){
            index++;
            count=0;
        }
        count+=1;
        //Debug.Log(count);

        if(count == frame){index=0;}
    }

    void SetSprite(Sprite sp){
        sprite.sprite = sp;
    }
}