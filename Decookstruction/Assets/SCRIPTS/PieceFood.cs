using UnityEngine;
using System.Collections;

public class PieceFood : MonoBehaviour {

    public string namePiece;

    public bool drag;



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 21f));
    }
    
    
}
