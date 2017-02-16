using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Rigidbody2D player;
	private GameObject[] platforms;
	private CameraScript cameraScript;
	private Camera cam;
	private PlayerScript playerScript;

	public float distanceToMove;
	public float speed;



	void Start () {
		GameObject g = GameObject.FindGameObjectWithTag ("Player");
		player = g.GetComponent<Rigidbody2D> ();
		playerScript = g.GetComponent<PlayerScript> ();
		platforms = GameObject.FindGameObjectsWithTag ("platform");
		cam = Camera.main;
		cameraScript = cam.GetComponent<CameraScript>();
	}
	
	void Update () {
		foreach (GameObject go in platforms){
			BoxCollider2D coll = go.GetComponent<BoxCollider2D> ();
			coll.enabled = !(player.velocity.y > .3);			
		}
	
	}

	public void onLeftClick(){
		Vector3 cameraDestination = new Vector3 (cam.transform.position.x - distanceToMove, cam.transform.position.y, cam.transform.position.z);
		Vector3 playerDestination = new Vector3 (player.transform.position.x - distanceToMove, player.transform.position.y, player.transform.position.z);

		playerScript.setKinematic (true);
		playerScript.moveToPosition (playerDestination);
		cameraScript.moveCameraToPosition (cameraDestination);
	}


	public void onRightClick(){
		Vector3 cameraDestination = new Vector3 (cam.transform.position.x + distanceToMove, cam.transform.position.y, cam.transform.position.z);
		Vector3 playerDestination = new Vector3 (player.transform.position.x + distanceToMove, player.transform.position.y, player.transform.position.z);
		playerScript.setKinematic (true);
		playerScript.moveToPosition (playerDestination);
		cameraScript.moveCameraToPosition (cameraDestination);
	}
}
