using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Rigidbody2D player;
	private GameObject[] platforms;
	private Camera cam;

	void Start () {
		GameObject g = GameObject.FindGameObjectWithTag ("Player");
		player = g.GetComponent<Rigidbody2D> ();
		platforms = GameObject.FindGameObjectsWithTag ("platform");
		cam = Camera.main;
	}
	
	void Update () {
		foreach (GameObject go in platforms){
			BoxCollider2D coll = go.GetComponent<BoxCollider2D> ();
			coll.enabled = !(player.velocity.y > .3);			
		}
	}

	public void onLeftClick(){
		Debug.Log ("Left clickd");
		Camera.main.transform.position = new Vector3 (cam.transform.position.x  - 1.0f, 0.0f,cam.transform.position.z);
	}


	public void onRightClick(){
		Debug.Log ("right clickd");
		Camera.main.transform.position = new Vector3 (cam.transform.position.x  + 1.0f, 0.0f,cam.transform.position.z);
	}
}
