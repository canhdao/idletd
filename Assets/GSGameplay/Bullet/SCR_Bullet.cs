using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Bullet : MonoBehaviour {
	public const float MOVE_SPEED = 10.0f;

	private GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null) {
			Vector3 delta = target.transform.position - transform.position;
			Vector3 velocity = delta.normalized * MOVE_SPEED;
			transform.position += velocity * Time.deltaTime;
		}
	}

	public void SetTarget(GameObject t) {
		target = t;
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Enemy") {
			SCR_Enemy scrEnemy = other.gameObject.GetComponent<SCR_Enemy>();
			scrEnemy.Damage();
			Destroy(gameObject);
		}
	}
}
