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

    private int NfoodBucketScore1;
    private int NfoodBucketScore2;
    private int NfoodBucketScore3;

   


    // Use this for initialization
    void Start () {

		// Initialize the score for each bucket
		FoodBucketScore1 = Random.Range (1, ingredient1.numPieces-1);
		FoodBucketScore2 = Random.Range (1, ingredient2.numPieces-1);
		FoodBucketScore3 = Random.Range (1, ingredient3.numPieces-1);
	}
	
	// Update is called once per frame
	void Update () {
	 
	}

    void CalculateScore()
    {

    }

    public int NfoodBucketScore11
    {
        get
        {
            return NfoodBucketScore1;
        }

        set
        {
            NfoodBucketScore1 = value;
        }
    }

    public int NfoodBucketScore21
    {
        get
        {
            return NfoodBucketScore2;
        }

        set
        {
            NfoodBucketScore2 = value;
        }
    }

    public int NfoodBucketScore31
    {
        get
        {
            return NfoodBucketScore3;
        }

        set
        {
            NfoodBucketScore3 = value;
        }
    }

    public int FoodBucketScore1
    {
        get
        {
            return foodBucketScore1;
        }

        set
        {
            foodBucketScore1 = value;
        }
    }

    public int FoodBucketScore2
    {
        get
        {
            return foodBucketScore2;
        }

        set
        {
            foodBucketScore2 = value;
        }
    }

    public int FoodBucketScore3
    {
        get
        {
            return foodBucketScore3;
        }

        set
        {
            foodBucketScore3 = value;
        }
    }
}
