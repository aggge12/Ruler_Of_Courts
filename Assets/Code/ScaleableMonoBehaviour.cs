using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class ScaleableMonoBehaviour : MonoBehaviour
{
    protected void SetLocalScale() {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr == null)
            return;

        // Set filterMode
        sr.sprite.texture.filterMode = FilterMode.Point;

        // Get stuff
        double width = sr.sprite.bounds.size.x;
        double cameraHeight = Camera.main.orthographicSize * 2.0;

        // Resize
        transform.localScale = new Vector2 (1, 1) * (float)(cameraHeight / width);
    }   

    public Vector3 GetLocalScale() {
        return transform.localScale;
    }
}
