using UnityEngine;
using System.Collections;

public class Dish : MonoBehaviour {

	// Each dish has 3 ingredients and 3 boxes scores
	public Ingredient ingredient1;
	public Ingredient ingredient2;
	public Ingredient ingredient3;
	
	private int foodBucketScore1;
	private int foodBucketScore2;
	private int foodBucketScore3;
	

	// Use this for initialization
	void Start () {

		// Initialize the score for each bucket
		foodBucketScore1 = Random.Range (1, ingredient1.numPieces);
		foodBucketScore2 = Random.Range (1, ingredient2.numPieces);
		foodBucketScore3 = Random.Range (1, ingredient3.numPieces);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
