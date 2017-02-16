using UnityEngine;
using System.Collections;

public class RotateScript : MonoBehaviour {

	public GameObject parentGameObject;
	public float speed;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (0, 0, speed * Time.deltaTime);
	}
}
