using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System.Text;

public class skyDiver_Horizontal_movement : MonoBehaviour {


	public Rigidbody rb;
	int speed = 0;
	int time = 0;
	public Text altitude_text;
	public Text velocity_text;
	public Text gameTime_text;
	public Text airDrag_text;
	public Text playerHeight_Text;
	public Text playerWeight_Text;
	private int altitude;
	public float playerHeight = 1.8f;
	public float playerBreadth = 0.4f;
	public static float airConstant_skyDiver = 1.0f;
	public static float airConstant_parachute = 0.75f;
	public ConstantForce airDrag;
	private bool parachuteOpen = false;
	[HideInInspector] public int parachuteOpenTime;
	public Text warning;
	[HideInInspector] public int impactVelocity;
	[HideInInspector] public int impactTime;
	[HideInInspector] public int parachuteOpenAltitude;
    [HideInInspector] public string filePath;
   public string filepath;



    float calculateDensity()
	{
		if (altitude <= 4000 && altitude > 3000) {

			return 0.8194f;
		}
		else if (altitude <= 3000 && altitude > 2000) {
			
			return 0.9093f;
		}
		else if (altitude <= 2000 && altitude > 1000) {
			
			return 1.007f;
		}
		else if (altitude <= 1000 && altitude > 0) {
			
			return 1.112f;
		}

		return 0;

	}


	float calculateArea()
	{

		float temp = transform.rotation.x;

		temp = 1 - Mathf.Abs (temp);

		temp = playerHeight * playerBreadth * temp;

		return temp;


	}


	float calculateArea_parachute()
	{
		float temp = 0.0f;
		if ((calculateTime () - parachuteOpenTime) < 6) {

			temp = Mathf.PI * Mathf.Pow (1.0f, 2.0f);

		}
		else if((calculateTime () - parachuteOpenTime) < 8) {
			
			temp = Mathf.PI * Mathf.Pow (1.5f, 2.0f);
			
		}
		else if((calculateTime () - parachuteOpenTime) < 10) {
			
			temp = Mathf.PI * Mathf.Pow (2.0f, 2.0f);
			
		}
		else if((calculateTime () - parachuteOpenTime) < 12) {
			
			temp = Mathf.PI * Mathf.Pow (2.5f, 2.0f);
			
		}
		else if((calculateTime () - parachuteOpenTime) < 14) {
			
			temp = Mathf.PI * Mathf.Pow (3.0f, 2.0f);
			
		}
		else if((calculateTime () - parachuteOpenTime) < 16) {
			
			temp = Mathf.PI * Mathf.Pow (3.5f, 2.0f);
			
		}
		else {
			
			temp = Mathf.PI * Mathf.Pow (4.0f, 2.0f);
			
		}

		return temp;
	
	}

	int calculateSpeed()
	{

		int speed = (int)rb.velocity.magnitude;

		return speed;

	}

	int calculateTime()
	{

		int time = (int)Time.time;

		return time;

	}

	double calculateThrust()
	{
		double thrust = 0.0f;

		if (parachuteOpen == false) {
			 thrust = 0.5 * airConstant_skyDiver * calculateDensity () * calculateArea () * Mathf.Pow (calculateSpeed (), 2f);
		} 
		else if(parachuteOpen == true) {

			thrust = 0.5 * airConstant_parachute * calculateDensity () * calculateArea_parachute() * Mathf.Pow (calculateSpeed (), 2f);

		}

		return thrust;
	

	}

	void endGame()
	{
		if (transform.position.y < 40) {

			impactVelocity = calculateSpeed();
			impactTime = calculateTime();
			
			Application.LoadLevel(2);
		}
	}

	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}


	// Use this for initialization
	void Start () {

          

        GameObject g = GameObject.Find("Canvas");

		user_interface inputs = g.GetComponent<user_interface>();


		rb.mass = inputs.Weight + 15.000f;
		transform.position = new Vector3(50000,inputs.Altitude,50000);
		playerHeight = inputs.Height;

		Destroy (g);
	
	}
   
    // Update is called once per frame
    void FixedUpdate () {
        
        
       // var newLine = string.Format("{0},{1}{2}", val1, );
     //   csv.Append(newLine);

        //after your loop
  

        

        //add the values that you want inside a csv file.

     


        altitude = (int)transform.position.y;

		speed = calculateSpeed ();

		time = calculateTime ();

		if (Input.GetKey(KeyCode.P) && parachuteOpen == false) {

			parachuteOpen = true;

			parachuteOpenTime = calculateTime();
			parachuteOpenAltitude = (int)transform.position.y;

			Time.timeScale = 100.0f;
			Time.fixedDeltaTime = 0.02F*Time.timeScale;

			warning.text  = " " ;


		}


		airDrag.force = new Vector3 (0, (float)calculateThrust (), 0);

		Time.timeScale = 2f;
		Time.fixedDeltaTime = 0.02F*Time.timeScale;
	
		altitude_text.text = " HEIGHT : " + altitude + " METER " ;
		gameTime_text.text = " TIME : " + time + " SECOND " ;
		velocity_text.text = " VELOCITY : " + speed + " METER/SECOND";
		airDrag_text.text = " AIR DRAG : " + (int)calculateThrust () + " NEWTON ";
		playerHeight_Text.text = " SKYDIVER HEIGHT : " + playerHeight + " METER ";
		playerWeight_Text.text = " SKYDIVER WEIGHT : " + (int)rb.mass + " KG " ;

		if (transform.position.y <= 500 && parachuteOpen == false) {


			warning.text = " OPEN PARACHUTE NOW " ;
		}


		endGame ();


	}




	
}
