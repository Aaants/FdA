using UnityEngine;
using System.Collections;

public class Cube : MonoBehaviour {

	public float speed = 1f;
	public float jumpPower=0.05f;

	private float jumping=-1f;
	private const float maxJumping = 0.2f;
	private CharacterController controller;
	private Vector3 vel = Vector3.zero;
	private Vector2 norm = Vector2.zero;
	private bool started=false;

	void Start () {
		controller = GetComponent<CharacterController>();
		ChangeColour();
	}

	void Update() {
		if (started) {
			norm.x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
			norm.y = Input.GetAxis("Vertical") * Time.deltaTime * speed;
			if (norm.magnitude>speed*Time.deltaTime) norm *= (speed*Time.deltaTime)/norm.magnitude;
			vel.x = norm.x;
			vel.z = norm.y;
			//Debug.Log(norm.magnitude);
		}
		if (controller.isGrounded) {
			jumping = -1f;
			vel.y=-Time.deltaTime;
			started=true;
			if (Input.GetButtonDown("Jump")) {
				vel.y=jumpPower;
				jumping=Time.deltaTime;
			}
		} else {
			if (Input.GetButton("Jump") && jumping<maxJumping && jumping >=0f) {
				vel.y=jumpPower;
				jumping+=Time.deltaTime;
			} else jumping = maxJumping;
		}
		vel.y -= Time.deltaTime/2f;
		controller.Move(vel);
		if (Input.GetKey(KeyCode.Space)) Application.LoadLevel(Application.loadedLevel);
	}

	void ChangeColour() {
		renderer.material.color = new Color(0.0f, 0.8f, 0.5f);
	}
}
