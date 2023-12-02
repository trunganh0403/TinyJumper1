using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgScale : MonoBehaviour
{
    

    private Camera mainCamera;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        mainCamera = Camera.main;
        spriteRenderer = GetComponent<SpriteRenderer>();

        
            ScaleBackground();
        
    }

    private void Update()
    {
        //if (Screen.width != mainCamera.pixelWidth || Screen.height != mainCamera.pixelHeight)
        //{
        //    ScaleBackground();
        //}
    }

    private void ScaleBackground()
    {
        Debug.Log("ra");
        if (spriteRenderer == null)
        {
            Debug.LogWarning("SpriteRenderer component not found.");
            return;
        }

        float cameraHeight = mainCamera.orthographicSize * 2f;//x
        float cameraWidth = cameraHeight * mainCamera.aspect;//y

        Vector3 backgroundScale = transform.localScale;
        backgroundScale.x = cameraWidth / spriteRenderer.bounds.size.x;
        backgroundScale.y = cameraHeight / spriteRenderer.bounds.size.y;
        transform.localScale = backgroundScale;
    }
}
