using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodBucket : MonoBehaviour {

    public int nIngredient;

    public string kindPiece;

    public string button;

    public bool random;

    public BalloonController balloon;

	public AudioClip drop;

	public AudioClip dropError;

    string namePiece;

    GameObject dishAsso;

	public Sprite[] arraySprites;

    

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(button))
        {

            if (GameManager.Instance.getBuckOpen() == false)
            {
                GetComponent<TaperControl>().OpenTaper();
                Debug.Log("Abierto");
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                GameManager.Instance.setBuckOpen(true);
                GameManager.Instance.setButtonBuck(button);
            }  

        }
        if (Input.GetKeyUp(button) && GameManager.Instance.getBuckOpen() == true && GameManager.Instance.getButtonBuck().Equals(button))
        {
            GetComponent<TaperControl>().CloseTaper();
            GameManager.Instance.setBuckOpen(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (GameObject.FindGameObjectWithTag("Dish")!=null && dishAsso==null)
        {
            dishAsso = GameObject.FindGameObjectWithTag("Dish");

            switch (nIngredient)
            {
                case 1:
                    kindPiece=dishAsso.GetComponent<Dish>().ingredient1.name;
                    balloon.SetIngredientPercentage(dishAsso.GetComponent<Dish>().perFood1());
					if(kindPiece == "Arroces"){
						balloon.SetIngredientSprite(arraySprites[0]);
					}
					if(kindPiece == "Claras"){
						balloon.SetIngredientSprite(arraySprites[1]);
					}
					if(kindPiece == "Albondigas"){
						balloon.SetIngredientSprite(arraySprites[2]);
					}
                    break;
                case 2:
                    kindPiece = dishAsso.GetComponent<Dish>().ingredient2.name;
					balloon.SetIngredientPercentage(dishAsso.GetComponent<Dish>().perFood2());
					if(kindPiece == "Guisantes"){
						balloon.SetIngredientSprite(arraySprites[0]);
					}
					if(kindPiece == "Yemas"){
						balloon.SetIngredientSprite(arraySprites[1]);
					}
					if(kindPiece == "Lechugas"){
						balloon.SetIngredientSprite(arraySprites[2]);
					}
                    break;
                case 3:
                    kindPiece = dishAsso.GetComponent<Dish>().ingredient3.name;
					balloon.SetIngredientPercentage(dishAsso.GetComponent<Dish>().perFood3());
					if(kindPiece == "Gambas"){
						balloon.SetIngredientSprite(arraySprites[0]);
					}
					if(kindPiece == "Patatas"){
						balloon.SetIngredientSprite(arraySprites[1]);
					}
                    break;
            }

        }
        

    }

   void OnCollisionEnter2D(Collision2D coll)
    {
        namePiece=coll.gameObject.GetComponent<PieceFood>().getNamePiece();

        if (kindPiece.Equals(namePiece))
        {
            Destroy(coll.gameObject);

			SoundManager.instance.PlaySingle(drop);

            switch (nIngredient)
            {
                case 1:
                    dishAsso.GetComponent<Dish>().NfoodBucketScore11++;
                    break;
                case 2:
                    dishAsso.GetComponent<Dish>().NfoodBucketScore21++;
                    break;
                case 3:
                    dishAsso.GetComponent<Dish>().NfoodBucketScore31++;
                    break;
            }
        }
        else
        {
			SoundManager.instance.PlaySingle(dropError);
            Destroy(coll.gameObject);
        }
       
    }
}
