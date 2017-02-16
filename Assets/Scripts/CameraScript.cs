using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	private Vector3 positionMovingTo;
	private bool moving;
	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (moving) {
			float step = speed * Time.deltaTime;
			transform.position =  Vector3.MoveTowards(transform.position, positionMovingTo,step);
		}
	}

	public void moveCameraToPosition(Vector3 position){
		positionMovingTo = position;
		moving = true;
	}
}
