using System;
using UnityEngine;

public class Loader : MonoBehaviour
{
	public GameObject gameManager;

	void Awake()
	{
		// Check if a GameManager has already been assigned to static variable GameManager.instance or if it's still null
		if (GameManager.Instance == null)
            GameObject.Instantiate(gameManager); // Instantiate gameManager prefab
	}
}