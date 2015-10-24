using UnityEngine;
using System.Collections;

public class FoodBucket : MonoBehaviour {

    public string kindPiece;

    public string button;

    public bool random;

    string namePiece;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(button))
        {

            if (GameManager.Instance.getBuckOpen() == false)
            {
                Debug.Log("Abierto");
                gameObject.GetComponent<BoxCollider2D>().enabled = true;
                GameManager.Instance.setBuckOpen(true);
                GameManager.Instance.setButtonBuck(button);
            }  

        }
        if (Input.GetKeyUp(button) && GameManager.Instance.getBuckOpen() == true && GameManager.Instance.getButtonBuck().Equals(button))
        {
            GameManager.Instance.setBuckOpen(false);
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

   void OnCollisionEnter2D(Collision2D coll)
    {
        namePiece=coll.gameObject.GetComponent<PieceFood>().getNamePiece();

        if (kindPiece.Equals(namePiece))
        {
            Destroy(coll.gameObject);
			Debug.Log ("100 puntos!");
			GameManager.Instance.AddScore(100);
        }
        else
        {
            Destroy(coll.gameObject);
        }
       
    }
}
