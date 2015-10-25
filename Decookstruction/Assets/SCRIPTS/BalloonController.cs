using System;
using UnityEngine;
using UnityEngine.UI;

public class BalloonController : MonoBehaviour
{
    private Image ingredientImage;
    private Text ingredientPercentage;

    private void Awake()
    {
        Transform ingredientImageTransform = this.transform.Find("IngredientImage");
        if (ingredientImageTransform != null)
        {
            this.ingredientImage = ingredientImageTransform.GetComponent<Image>();
        }

        Transform ingredientPercentageTransform = this.transform.Find("IngredientPercentage");
        if (ingredientPercentageTransform != null)
        {
            this.ingredientPercentage = ingredientImageTransform.GetComponent<Text>();
        }
    }
    
    private void Update()
    {
        this.transform.localRotation = Quaternion.AngleAxis(Mathf.Sin(Time.time) * 1.0f, Vector3.forward);
        this.transform.localScale = new Vector3(1.0f + (Mathf.Sin(Time.time * 4.0f) * 0.01f), 1.0f + (Mathf.Sin(Time.time * 6.0f) * 0.01f), 1.0f);
    }

    public void SetIngredientSprite(Sprite sprite)
    {
        if (this.ingredientImage != null)
            this.ingredientImage.sprite = sprite;
    }

    public void SetIngredientPercentage(int percentage)
    {
        if (this.ingredientPercentage != null)
            this.ingredientPercentage.text = string.Format("{0}%", percentage);
    }
}
