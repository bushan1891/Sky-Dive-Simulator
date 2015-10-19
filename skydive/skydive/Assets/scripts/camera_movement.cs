using UnityEngine;
using System.Collections;

public class camera_movement : MonoBehaviour {

	public Camera eyeCamera;
	public Camera mainCamera;

	public skyDiver_Horizontal_movement skyDiver;
	private bool parachuteOpen = false;
	// Use this for initialization
	void Start () {

		mainCamera.enabled = true;
		eyeCamera.enabled = false;

		mainCamera.transform.position = skyDiver.transform.position;
		eyeCamera.transform.rotation = Quaternion.identity;
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (parachuteOpen == false) {
			Vector3 movecamto = skyDiver.transform.position - skyDiver.transform.forward * 30.0f;
		
		
		
			mainCamera.transform.position = movecamto;


			mainCamera.transform.LookAt (skyDiver.transform.position);
		} else {

			/*Vector3 movecamto = skyDiver.transform.position - skyDiver.transform.forward * 70.0f;
			
			float bias = 0.95f;
			
			mainCamera.transform.position = mainCamera.transform.position * bias + movecamto * (1.0f - bias);
			
			
			mainCamera.transform.LookAt (skyDiver.transform.position + skyDiver.transform.forward * 10.0f);*/
			Vector3 movecamto = skyDiver.transform.position - skyDiver.transform.forward * 80.0f;
			
			mainCamera.transform.position = movecamto;
			
			
			mainCamera.transform.LookAt (skyDiver.transform.position);
		}

		if (Input.GetKey (KeyCode.P)) {
			
			parachuteOpen = true;
			eyeCamera.enabled = true;

			
		}


	    if (Input.GetKeyDown (KeyCode.C)&& mainCamera.enabled == true ) {

			mainCamera.enabled = false;
			eyeCamera.enabled = true;
		} 
		else if(Input.GetKeyDown(KeyCode.C)&& eyeCamera.enabled == true) {

			mainCamera.enabled = true;
			eyeCamera.enabled = false;

		}

	}
}
