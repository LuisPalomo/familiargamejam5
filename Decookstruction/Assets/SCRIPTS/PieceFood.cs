using UnityEngine;
using System.Collections;

public class PieceFood : MonoBehaviour {

    public string namePiece;

    public bool drag;

	public AudioClip foodPick;
    
	// Use this for initialization
	void Start () {
		namePiece = transform.parent.name;
	
	}
	
	// Update is called once per frame
	void Update () {
    
	}

	void OnMouseDown()
	{
		SoundManager.instance.PlaySingle (foodPick);
	}

    void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 21f));
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    
    void OnMouseUp()
    {
        Vector2 MouseV= new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        Debug.Log(MouseV);
        GetComponent<Rigidbody2D>().AddForce(MouseV*5,ForceMode2D.Impulse);
    }

    public string getNamePiece(){
        return namePiece;
    }
    
}
