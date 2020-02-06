﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        transform.localScale = new Vector3(1, 1, 1);

        float width = sr.sprite.bounds.size.x;
        float height = sr.sprite.bounds.size.y;
        float worldScreeHeight = Camera.main.orthographicSize * 2f;
        float worldScreenWidth = worldScreeHeight / Screen.height * Screen.width;

        Vector3 tempScale = transform.localScale;
        tempScale.x = worldScreenWidth / width + 0.1f;
        tempScale.y = worldScreeHeight / height + 0.1f;
        transform.localScale = tempScale;


    }
}