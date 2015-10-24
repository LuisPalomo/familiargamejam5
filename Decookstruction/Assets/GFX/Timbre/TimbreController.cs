using System;
using UnityEngine;

public class TimbreController : MonoBehaviour
{
    public ParticleSystem noteSystem;
    public ParticleSystem soundSystem;

    public Transform bell;
    public Transform button;

    private float timeCounter = 0.0f;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.C))
            this.GenerateSound();

        if (this.timeCounter > 0.0f)
        {
            float effectMultiplier = timeCounter * 8.0f;
            this.bell.localRotation = Quaternion.AngleAxis(Mathf.Sin(Time.time * 50.0f) * effectMultiplier, Vector3.forward);
            this.timeCounter -= Time.deltaTime;
        }

        float buttonScale = Mathf.SmoothStep(this.button.localScale.y, 1.0f, 0.5f);
        this.button.localScale = new Vector3(1.0f, buttonScale, 1.0f);
	}

    private void GenerateSound()
    {
        this.noteSystem.Emit(5);
        this.soundSystem.Emit(20);

        this.timeCounter = 1.0f;
        this.button.localScale = new Vector3(1.0f, 0.33f, 1.0f);
    }
}
