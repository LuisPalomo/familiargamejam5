using System;
using UnityEngine;

public class TitleWiggle : MonoBehaviour
{
    private float timeCounter = 0.0f;
    private float wiggleTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        this.timeCounter += Time.deltaTime;
        
        if (this.timeCounter > 2.5f)
        {
            this.timeCounter -= 2.5f;
            this.wiggleTime = 1.0f;
        }

        if (this.wiggleTime > 0.0f)
            this.wiggleTime -= Time.deltaTime;
        this.wiggleTime = (this.wiggleTime > 0.0f) ? this.wiggleTime : 0.0f;

        this.Wiggle();
    }

    private void Wiggle()
    {
        //float wiggleFactor = Mathf.Abs(0.5f - this.wiggleTime) * 2.0f;
        this.transform.localRotation = Quaternion.AngleAxis(Mathf.Sin(Time.time) * 2.0f, Vector3.forward);
        this.transform.localScale = new Vector3(1.0f + (Mathf.Sin(Time.time * 10.0f) * 0.01f), 1.0f + (Mathf.Sin(Time.time * 20.0f) * 0.01f), 1.0f);
    }
}