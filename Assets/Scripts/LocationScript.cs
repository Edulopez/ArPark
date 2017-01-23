using UnityEngine;
using System.Collections;

public class LocationScript : MonoBehaviour
{
    public float latitude;
    public float longitude;

    public static readonly float DistantePerDecimalDegree = 111111.11f;

    // Use this for initialization
    void Start()
    {
        Input.location.Start(50,0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.location.isEnabledByUser)
        {
            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
        }
        else
        {
            
        }
    }

    Vector2 CartesianToPolar(Vector3 point)
    {
        Vector2 polar;

        //calc longitude
        polar.y = Mathf.Atan2(point.x, point.z);

        //this is easier to write and read than sqrt(pow(x,2), pow(y,2))!
        var  xzLen = new Vector2(point.x, point.z).magnitude;
        //atan2 does the magic
        polar.x = Mathf.Atan2(-point.y, xzLen);

        //convert to deg
        polar *= Mathf.Rad2Deg;

        return polar;
    }

    Vector3 PolarToCartesian(Vector2 polar)
    {

        //an origin vector, representing lat,lon of 0,0. 

        var origin = new Vector3(0, 0, 1);
        //build a quaternion using euler angles for lat,lon
        var rotation = Quaternion.Euler(polar.x, polar.y, 0);
        //transform our reference vector by the rotation. Easy-peasy!
        Vector3 point = rotation * origin;

        return point;
    }

    public float Distance ( float lat, float lon)
    {
        return Distance(latitude, longitude, lat, lon);
    }
    public static float Distance(float lat1, float lon1, float lat2, float lon2)
    {  // generally used geo measurement function
        float R = 6378.137f; // Radius of earth in KM
        float dLat = (lat2 - lat1) * Mathf.PI / 180;
        float dLon = (lon2 - lon1) * Mathf.PI / 180;

        float a = Mathf.Sin(dLat / 2) * Mathf.Sin(dLat / 2) +
            Mathf.Cos(lat1 * Mathf.PI / 180) * Mathf.Cos(lat2 * Mathf.PI / 180) *
            Mathf.Sin(dLon / 2) * Mathf.Sin(dLon / 2);

        float c = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));
        float d = R * c;


        //modified
        if (((lat2 - lat1) < 0) || ((lon2 - lon1) < 0))
        {
            d = -1 * d;
        }

        return d * 1000; // meters
    }

    public float GetAproxDistance( float value1, float value2)
    {
        value1 = value1 * DistantePerDecimalDegree;
        value2 = value2 * DistantePerDecimalDegree;
        return value2 - value1;
    }
}

