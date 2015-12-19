using UnityEngine;
using System.Collections;

static public class FibrumController {

	static public VRSensor vrs;
	static public VRCamera vrCamera;
	static public VRSetupGUI vrSetup;
	static public float distanceBetweenLens=0f;
	static public bool isHandOriented;
	static public bool useAntiDrift;
	static public bool useCompassForAntiDrift;

	static public void Init()
	{
		#if UNITY_ANDROID && !UNITY_EDITOR
		if( vrs == null  )
		{
			GameObject vrsGO = GameObject.Instantiate((GameObject)Resources.Load("FibrumResources/VRSensor",typeof(GameObject))) as GameObject;
			vrs = vrsGO.GetComponent<VRSensor>();
		}
		#endif
		distanceBetweenLens = PlayerPrefs.GetFloat("FIB_lensDistance",0f);
	}
}
