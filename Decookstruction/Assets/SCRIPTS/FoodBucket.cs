using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FoodBucket : MonoBehaviour {

    public int nIngredient;

    public string kindPiece;

    public string button;

    public bool random;

    public Text percentText;

    string namePiece;

    GameObject dishAsso;

    

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
                    percentText.text = dishAsso.GetComponent<Dish>().perFood1()+" %";
                    break;
                case 2:
                    kindPiece = dishAsso.GetComponent<Dish>().ingredient2.name;
                    percentText.text = dishAsso.GetComponent<Dish>().perFood2() + " %";
                    break;
                case 3:
                    kindPiece = dishAsso.GetComponent<Dish>().ingredient3.name;
                    percentText.text = dishAsso.GetComponent<Dish>().perFood3() + " %";
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
            Destroy(coll.gameObject);
        }
       
    }
}
