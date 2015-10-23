using UnityEngine;
using System.Collections;

public class FoodBucket : MonoBehaviour {

    public string kindPiece;

    string namePiece;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

   void OnCollisionEnter2D(Collision2D coll)
    {
        namePiece=coll.gameObject.GetComponent<PieceFood>().getNamePiece();

        Debug.Log("works");

        if (kindPiece.Equals(namePiece))
        {
            Destroy(coll.gameObject);
        }
        else
        {
            Destroy(coll.gameObject);
        }
       
    }
}
