using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScalerScript : MonoBehaviour {

    public GameObject referenceObject;

    public float latitude;
    public float longitude;
    public float distanceToReference;

    public Text text;
	// Use this for initialization
	void Start () {
        var referenceLocation = referenceObject.GetComponent<LocationScript>();
        distanceToReference = LocationScript.Distance(latitude, longitude, referenceLocation.latitude, referenceLocation.longitude);

    }

    // Update is called once per frame
    void Update () {
        var referenceLocation = referenceObject.GetComponent<LocationScript>();

        float distance = LocationScript.Distance(latitude, longitude, referenceLocation.latitude, referenceLocation.longitude);
        distance = Mathf.Abs(distance);

        //if (distance > distanceToReference)
        //    ChangeScale(0.2f, 0.2f, 0.2f);
        //else if (distance < distanceToReference)
        //    ChangeScale(-0.2f, -0.2f, -0.2f);
        distanceToReference = distance;

        text.text = "Lat: " + referenceLocation.latitude + "\n Lng: " + referenceLocation.longitude + "\n Distance: " + distance;
    }

    void ChangeScale (float x , float y , float z)
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x+x
                                                , this.transform.localScale.y+y
                                                , this.transform.localScale.z + z);
    }
}
