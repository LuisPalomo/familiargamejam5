using UnityEngine;
using System.Collections;

public class StarsController : MonoBehaviour
{
    private ParticleSystem pSystem;

    private void Awake()
    {
        this.pSystem = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    public void MakeStars()
    {
        if (this.pSystem != null)
            this.pSystem.Emit(30);
    }
}
