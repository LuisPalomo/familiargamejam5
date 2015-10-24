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
            NewDish();
        }
    }

	void NewDish()
	{
		int randomInt = Random.Range(0, dishes.Length);
		GameObject dish = GameObject.FindGameObjectWithTag ("Dish");
		if ( dish == null) 
		{
			Instantiate(dishes[randomInt], transform.position, Quaternion.identity);
		}else
		{
			dish.GetComponent<Dish>().CalculateScore();
			Destroy(dish);

			Instantiate(dishes[randomInt], transform.position, Quaternion.identity);
		}
	}
}
