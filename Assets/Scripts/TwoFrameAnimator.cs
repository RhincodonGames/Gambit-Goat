using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TwoFrameAnimator : MonoBehaviour
{
    public Sprite frameA;
    public Sprite frameB;
    public float fps = 6f;

    SpriteRenderer sr;
    float timer;
    bool showingA = true;
    float frameDuration;
    // Start is called before the first frame update
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        frameDuration = 1f / Mathf.Max(0.0001f, fps);
        if (frameA != null) sr.sprite = frameA;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if (Mathf.Abs(horizontal) > 0.01f)
        {
            timer += Time.deltaTime;
            if (timer >= frameDuration)
            {
                timer -= frameDuration;
                showingA = !showingA;
                sr.sprite = showingA ? frameA : frameB;
            }
        } else
        {
            sr.sprite = frameA;
            timer = 0f;
            showingA = true;
        }
    }
}
