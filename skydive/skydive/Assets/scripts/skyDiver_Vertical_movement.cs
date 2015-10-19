using UnityEngine;
using System.Collections;

public class skyDiver_Vertical_movement : MonoBehaviour {

	public Rigidbody rb;
	public ConstantForce airDrag;
	private bool parachuteOpen = false;


	// Use this for initialization
	void Start () {

        }
	
	// Update is called once per frame
	void Update () {

		if (parachuteOpen == false) {
			if (Input.GetKey (KeyCode.LeftArrow)) {
				rb.AddTorque (0, 0, 1000f);

			}
		
			if (Input.GetKey (KeyCode.RightArrow)) {
				rb.AddTorque (0, 0, -1000f);
			}
		
			if (Input.GetKey (KeyCode.UpArrow)) {
				rb.AddTorque (-500f, 0, 0);

			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				rb.AddTorque (500f, 0, 0);

			}
			if (transform.rotation.z > 0.7) {

				rb.angularVelocity = new Vector3 (0, 0, 0);

			}
			if (transform.rotation.z < -0.7) {
			
				rb.angularVelocity = new Vector3 (0, 0, 0);
			}
			if (transform.rotation.x > 0.5) {
			
				rb.angularVelocity = new Vector3 (0, 0, 0);
			}
			if (transform.rotation.x < -0.5) {
			
				rb.angularVelocity = new Vector3 (0, 0, 0);
			}

		}

		if (Input.GetKey (KeyCode.P)) {
			
			parachuteOpen = true;

			rb.angularVelocity = new Vector3(0,0,0);
			rb.AddForce(0,0,0);
			transform.rotation = Quaternion.identity;
	
			}
	}
}
