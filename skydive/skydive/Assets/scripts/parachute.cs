using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class parachute : MonoBehaviour {

	public Renderer rend;
	public AudioSource wing_flaping;
	public AudioSource parachute_open;
	private float volume = 1.0f;

	// Use this for initialization
	void Start () {
	
		parachute_open.enabled = false;
		rend.enabled = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetKey(KeyCode.P)) {

			rend.enabled = true;
		
			wing_flaping.volume = volume;
			parachute_open.enabled = true;

			}
		}


}
