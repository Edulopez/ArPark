using UnityEngine;
using System.Collections;

public class WatcherScript : MonoBehaviour
{

    // Use this for initialization
    private float LastLatitude;
    private float LastLongitude;
    private LocationScript _Location;

    public int UnitsPerMeter = 1;
    void Start()
    {
        _Location = this.GetComponent<LocationScript>();
        LastLatitude = _Location.latitude;
        LastLongitude = _Location.longitude;
    }

    // Update is called once per frame
    void Update()
    {

        LocationBasedMovement();

        LastLatitude = _Location.latitude;
        LastLongitude = _Location.longitude;

    }

    private void LocationBasedMovement()
    {
        var translation = new Vector3(
            _Location.GetAproxDistance(LastLongitude, _Location.longitude)
            , 0
            , _Location.GetAproxDistance(LastLatitude, _Location.latitude));
        var position = this.transform.position;
        position.x += translation.x;
        position.y += translation.y;
        position.z += translation.z;
        this.transform.position = position;
    }
}
