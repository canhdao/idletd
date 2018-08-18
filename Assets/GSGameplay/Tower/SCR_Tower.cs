using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Tower : MonoBehaviour {
	public const float FIRE_RANGE = 3.5f;
	public const float FIRE_RATE = 4.0f;

	public GameObject PFB_BULLET;

	private float fireTime = 0;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		fireTime += Time.deltaTime;

		foreach (GameObject e in SCR_Gameplay.enemies) {
			float sqrDistance = (e.transform.position - transform.position).sqrMagnitude;
			if (sqrDistance < FIRE_RANGE * FIRE_RANGE) {
				if (fireTime >= 1 / FIRE_RATE) {
					GameObject bullet = Instantiate(PFB_BULLET, transform.position, PFB_BULLET.transform.rotation);
					bullet.GetComponent<SCR_Bullet>().SetTarget(e);
					fireTime = 0;
				}
			}
		}
	}
}
