using UnityEngine;
using System.Collections;

public class Cap : MonoBehaviour {

	public Vector3 target;
	private NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		target = transform.position;
		nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){
				target = hit.point;
			}
			Debug.Log(hit);
		}
		nav.SetDestination(target);
	}
}
