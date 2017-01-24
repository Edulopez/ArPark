using UnityEngine;
using System.Collections;

public class webCamScript : MonoBehaviour {

	public GameObject webCameraPlane;

	// Use this for initialization
	void Start () {

		if (Application.isMobilePlatform 
            || true
            )
        {
			GameObject cameraParent = new GameObject ("camParent");
			cameraParent.transform.position = this.transform.position;
			this.transform.parent = cameraParent.transform;
			cameraParent.transform.Rotate (Vector3.right, 90);
		}

		Input.gyro.enabled = true;
		WebCamTexture webCameraTexture = new WebCamTexture();
		webCameraPlane.GetComponent<MeshRenderer>().material.mainTexture = webCameraTexture;
		webCameraTexture.Play();
    }

	
	// Update is called once per frame
	void Update ()
    {
        Quaternion cameraRotation = new Quaternion (Input.gyro.attitude.x, Input.gyro.attitude.y, -Input.gyro.attitude.z, -Input.gyro.attitude.w);
		this.transform.localRotation = cameraRotation;
    }

    public static float GetFrustumHeight(int distance, Camera camera)
    {
        var frustumHeight = 2.0f * distance * Mathf.Tan(camera.fieldOfView * 0.5f * Mathf.Deg2Rad);
        return frustumHeight;
    }
}
