using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ScaleableMonoBehaviour : MonoBehaviour
{
    private const float margin = 0.8f;

    protected void SetLocalScale() {

        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        // Set filterMode
        sr.sprite.texture.filterMode = FilterMode.Point;

        double spriteHeight = sr.sprite.bounds.size.y;

        float cameraHeight = Camera.main.orthographicSize * 2;

        transform.localScale = margin * (Vector2.one * (float)(cameraHeight / spriteHeight));
    }   

    public Vector3 GetLocalScale() {
        return transform.localScale;
    }
}
