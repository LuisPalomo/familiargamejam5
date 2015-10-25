using UnityEngine;
using System.Collections;


public class DishSpawner : MonoBehaviour {

	public GameObject[] dishes;

	// Use this for initialization
	void Start () {
		Invoke ("NewDish", 3);
		
	}
	
    void Update()
    {
        if(Input.GetButtonDown("Jump")){

            GameObject.Find("Timbre").GetComponent<TimbreController>().GenerateSound();
            NewDish();
        }
    }

	void NewDish()
	{
		int randomInt = Random.Range(0, dishes.Length);
		GameObject dish = GameObject.FindGameObjectWithTag ("Dish");
        GameObject nDish;
		if ( dish == null) 
		{
            nDish = (GameObject)Instantiate(dishes[randomInt], transform.position, Quaternion.identity);
		}else
		{
			dish.GetComponent<Dish>().CalculateScore();
            dish.GetComponent<Animator>().Play("Destroy");
            //yield WaitForSeconds (dish.GetComponent<Animator>().GetAnimatorTransitionInfo());
            Destroy(dish);
			
			nDish = (GameObject) Instantiate(dishes[randomInt], transform.position, Quaternion.identity);
		}
	}
}
