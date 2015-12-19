using UnityEngine;
using System.Collections;

public class ChangeCameraEye : MonoBehaviour {

	float lastScreenWidth;
	float lastLensDist;
	private float initCameraRectXmin;
	private float initSidePosition;

	// Use this for initialization
	void Start () {
		GetComponent<Camera>().layerCullSpherical = true;
		initCameraRectXmin = GetComponent<Camera>().rect.xMin;
		initSidePosition = transform.localPosition.x;	
	}

	void ProcessCameraView()
	{
		float deviceDiagonal = Mathf.Sqrt((float)(Screen.width*Screen.width)+(float)(Screen.height*Screen.height))/Screen.dpi;
		#if UNITY_STANDALONE
		transform.localPosition = new Vector3(-initSidePosition,transform.localPosition.y,transform.localPosition.z);
		camera.rect = new Rect(0.5f-initCameraRectXmin,0f,0.5f,1f);
		#else
		if ( Application.isEditor )
		{
			transform.localPosition = new Vector3(-initSidePosition,transform.localPosition.y,transform.localPosition.z);
			GetComponent<Camera>().rect = new Rect(0.5f-initCameraRectXmin,0f,0.5f,1f);
		}
		else if ((deviceDiagonal<3.9f && deviceDiagonal>7.1f) || FibrumController.distanceBetweenLens<1f )
		{
			transform.localPosition = new Vector3(initSidePosition,transform.localPosition.y,transform.localPosition.z);
			GetComponent<Camera>().rect = new Rect(initCameraRectXmin,0f,0.5f,1f);
		}
		else
		{
			float screenLength = (Screen.width/Screen.dpi)*25.4f;
			float viewPortCenter = (FibrumController.distanceBetweenLens/2f)/screenLength;
			float viewPortHalfSize = Mathf.Min (viewPortCenter,0.5f-viewPortCenter);
			float screenHeight = (Screen.height/Screen.dpi)*25.4f;
			float viewPortYHalfSize = Mathf.Min (0.5f,0.5f*FibrumController.distanceBetweenLens/screenHeight);
			GetComponent<Camera>().rect = new Rect(0.5f+(initCameraRectXmin*4f-1f)*viewPortCenter-viewPortHalfSize,0.5f-viewPortYHalfSize,viewPortHalfSize*2f,viewPortYHalfSize*2f);
		}
		#endif
		lastScreenWidth = Screen.width;
		lastLensDist = FibrumController.distanceBetweenLens;
	}
	
	// Update is called once per frame
	void Update () {
		if( Screen.width != lastScreenWidth ) ProcessCameraView();
		if( lastLensDist != FibrumController.distanceBetweenLens ) ProcessCameraView();
	}
}
