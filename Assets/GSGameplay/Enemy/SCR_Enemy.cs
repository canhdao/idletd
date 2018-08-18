using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Enemy : MonoBehaviour {
	public const float MOVE_SPEED = 2.0f;

	private MoveDirection moveDirection = MoveDirection.DOWN;
	private MoveDirection nextDirection = MoveDirection.DOWN;

	private Vector3 turnPosition = Vector3.zero;

	// Use this for initialization
	void Start() {
		
	}
	
	// Update is called once per frame
	void Update() {
		float x = transform.position.x;
		float y = transform.position.y;
		float z = transform.position.z;

		if (moveDirection == MoveDirection.UP) {
			y += MOVE_SPEED * Time.deltaTime;
		}
		else if (moveDirection == MoveDirection.DOWN) {
			y -= MOVE_SPEED * Time.deltaTime;
		}
		else if (moveDirection == MoveDirection.LEFT) {
			x -= MOVE_SPEED * Time.deltaTime;
		}
		else if (moveDirection == MoveDirection.RIGHT) {
			x += MOVE_SPEED * Time.deltaTime;
		}

		if (nextDirection == MoveDirection.LEFT || nextDirection == MoveDirection.RIGHT) {
			if (y <= turnPosition.y) {
				y = turnPosition.y;
				moveDirection = nextDirection;
			}
		}
		else if (nextDirection == MoveDirection.DOWN) {
			if (moveDirection == MoveDirection.LEFT) {
				if (x <= turnPosition.x) {
					x = turnPosition.x;
					moveDirection = nextDirection;
				}
			}
			else if (moveDirection == MoveDirection.RIGHT) {
				if (x >= turnPosition.x) {
					x = turnPosition.x;
					moveDirection = nextDirection;
				}
			}
		}

		transform.position = new Vector3(x, y, z);

		if (y < -SCR_Gameplay.SCREEN_HEIGHT * 0.5f) {
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Path") {
			SCR_Path scrPath = other.gameObject.GetComponent<SCR_Path>();
			nextDirection = scrPath.moveDirection;
			turnPosition = scrPath.transform.position;
		}
	}

	public void Damage() {
		
	}
}
