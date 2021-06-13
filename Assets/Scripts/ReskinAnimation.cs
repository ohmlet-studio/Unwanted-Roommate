using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReskinAnimation : MonoBehaviour
{
    public string path;

    // Start is called before the first frame update
    void LateUpdate()
    {
        var subSprites = Resources.LoadAll<Sprite>(path);

        foreach(var renderer in GetComponentsInChildren<SpriteRenderer>()) {
            string spriteName = renderer.sprite.name;
            var newSprite = Array.Find(subSprites, item => item.name == spriteName);

            //Debug.Log(spriteName);

            if (newSprite) {
                renderer.sprite = newSprite;
            }
        }
    }
}
