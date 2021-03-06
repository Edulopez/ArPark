﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MappedObject : MonoBehaviour {

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
        distanceToReference = distance;

        if (text !=null)
            text.text =this.name+ "\n Lat: " + referenceLocation.latitude + "\n Lng: " + referenceLocation.longitude + "\n Distance: " + distance;
    }

    void ChangeScale (float x , float y , float z)
    {
        this.transform.localScale = new Vector3(this.transform.localScale.x+x
                                                , this.transform.localScale.y+y
                                                , this.transform.localScale.z + z);
    }
}
