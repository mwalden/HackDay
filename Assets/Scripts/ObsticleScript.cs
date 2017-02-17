using UnityEngine;
using System.Collections;

public class ObsticleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll){
		Debug.Log ("in trigger : " + coll.tag);
		if (coll.gameObject.tag != "Player")
			return;
		GameObject go = coll.gameObject;
		PlayerScript playerScript = go.GetComponent<PlayerScript> ();
		playerScript.resetPlayerPosition ();
	}
}
