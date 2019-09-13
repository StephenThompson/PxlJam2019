using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {
	public float time = 111;
	public int money = 522;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;

		if (Input.GetButtonDown ("UseTime")) {
			time -= 10;
			money += 10;
		}

		if (Input.GetButtonDown ("UseMoney")) {
			money -= 10;
		}
	}
}
