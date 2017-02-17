using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
	public Rigidbody2D player;
	private GameObject[] platforms;
	private CameraScript cameraScript;
	private Camera cam;
	private PlayerScript playerScript;
	private AudioScript audioScript;

	public int lockDownTotal;
	public int platformsPassed;
	public int totalLanes;
	public float distanceToMove;
	public float speed;
	public int laneId;

	void Start () {
		GameObject g = GameObject.FindGameObjectWithTag ("Player");
		GameObject audioGameObject = GameObject.FindGameObjectWithTag ("audio");
		audioScript = audioGameObject.GetComponent<AudioScript> ();
		audioScript.setCurrentLane(laneId);
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
		if (laneId == 0)
			return;
		Vector3 cameraDestination = new Vector3 (cam.transform.position.x - distanceToMove, cam.transform.position.y, cam.transform.position.z);
		Vector3 playerDestination = new Vector3 (player.transform.position.x - distanceToMove, player.transform.position.y, player.transform.position.z);
		platformsPassed = 0;
		playerScript.setKinematic (true);
		playerScript.moveToPosition (playerDestination);
		cameraScript.moveCameraToPosition (cameraDestination);
		laneId -= 1;
		audioScript.setCurrentLane (laneId);
	}


	public void onRightClick(){
		if (laneId == totalLanes -1)
			return;
		platformsPassed = 0;
		Vector3 cameraDestination = new Vector3 (cam.transform.position.x + distanceToMove, cam.transform.position.y, cam.transform.position.z);
		Vector3 playerDestination = new Vector3 (player.transform.position.x + distanceToMove, player.transform.position.y, player.transform.position.z);
		playerScript.setKinematic (true);
		playerScript.moveToPosition (playerDestination);
		cameraScript.moveCameraToPosition (cameraDestination);
		laneId += 1;
		audioScript.setCurrentLane (laneId);
	}

	public void addPlatformPassed(int value){
		platformsPassed += value;
		if (platformsPassed == lockDownTotal) {
			audioScript.lockDownLane (laneId);
			platformsPassed = 0;
		}
	}
}
