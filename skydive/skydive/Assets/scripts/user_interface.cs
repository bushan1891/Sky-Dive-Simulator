using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class user_interface : MonoBehaviour
{


    public float Altitude;
    public float Height;
    public float Weight;


    public Button play;


    public void StartLevel() //this function will be used on our Play button

    {
        Application.LoadLevel(1); //this will load our first level from our build settings. "1" is the second scene in our game

    }

    public void getAltitude(InputField altitude)
    {
        if (float.Parse(altitude.text) < 4000)
        {
            Altitude = float.Parse(altitude.text);

        }
        else
            Altitude = 4000;

    }
    public void getHeight(InputField height)
    {
        if (float.Parse(height.text) < 5.00f)
        {
            Height = float.Parse(height.text);
        }
        else
            Height = 5.00f;
    }
    public void getWeight(InputField weight)
    {
        if (float.Parse(weight.text) < 500)
        {
            Weight = float.Parse(weight.text);
        }
        else
            Weight = 500;
    }


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }



    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {



    }
}