using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class endGame :MonoBehaviour {




	public Text impactVelocity;
	public Text impactTime;
	public Text parachuteOpenTime;
	public Text parachuteOpenDistacne;
	public float volume = 0.0f;







	// Use this for initialization
	void Start () {

		GameObject g = GameObject.Find("skyDiver");
		GameObject p = GameObject.Find("parachute");
		skyDiver_Horizontal_movement skyDiver = g.GetComponent<skyDiver_Horizontal_movement>();
		parachute Parachute = p.GetComponent<parachute>();
		impactVelocity.text = " VELOCITY OF IMPACT : " + skyDiver.impactVelocity + " METER/SECOND";
		impactTime.text = " TIME OF FLIGHT : " + skyDiver.impactTime + " SECOND";
		parachuteOpenTime.text = " PARACHUTE OPENING TIME :" + skyDiver.parachuteOpenTime + " SECOND";
		parachuteOpenDistacne.text = "PARACHUTE OPENING ALTITUDE :" + skyDiver.parachuteOpenAltitude + " METER";

		Destroy (g);
		Destroy (p);

		//Parachute.wing_flaping.enabled = false;




	}

	// Update is called once per frame
	void Update () {

	
	}
}
