using UnityEngine;
using System.Collections;

public class DishSpawner : MonoBehaviour {

	public GameObject[] dishes;

	// Use this for initialization
	void Start () {
		NewDish();
		
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

			StartCoroutine(DestroyOnAnimationEnd(dish, randomInt));
            //Destroy(dish);
		}
	}

	private IEnumerator DestroyOnAnimationEnd(GameObject go, int randomInt)
	{
		yield return new WaitForSeconds (1f);
		Destroy (go);
		GameObject nDish = (GameObject) Instantiate(dishes[randomInt], transform.position, Quaternion.identity);
	}
}
