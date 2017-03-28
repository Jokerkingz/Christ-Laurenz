using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Player : MonoBehaviour {
	// Components // Components // Components // Components // Components // Components // Components // Components // Components // Components 
	public CharacterController cCC;
	public Scr_GunControl cGC;

	// Variables // Variables // Variables // Variables // Variables // Variables // Variables // Variables // Variables // Variables // Variables 
	private float vYSpeed = -1;
	private Vector3 vDirection = Vector3.zero;
	public float vSpeedMultiplier = 2f;
	public float vSpeed = 20f;
	public bool vActing;

	// Camera // Camera // Camera // Camera // Camera // Camera // Camera // Camera // Camera // Camera // Camera // Camera // Camera // Camera 
	public GameObject ViewBase;
	public Camera vCam;
	public GameObject vTargetSpot;
	private float vSpedH = 2f;
	private float vSpedV = 2f;
	public float vYaw = 90.0f;
	public float vPitch = 0.0f;



	void Start()
	{
	}

	void Awake ()
	{GameObject.DontDestroyOnLoad(transform.gameObject);
	}

	void Update ()
	{	
		if (!vActing)
			InputCheck ();

		vDirection = transform.TransformDirection (vDirection);
		cCC.Move(vDirection *vSpeed* Time.deltaTime);
		vSpeed = 20f;
		transform.eulerAngles = new Vector3 (0f, vYaw-90f,0f);
		ViewBase.transform.eulerAngles = new Vector3 (vPitch,vYaw, 0f);
		if (transform.position.y < -10)
			transform.position = Vector3.zero;
		RaycastHit hit;
		Ray ray = vCam.ScreenPointToRay ( new Vector2(vCam.pixelWidth/ 2f, vCam.pixelHeight / 2f));//point to ray
		if (Physics.Raycast (ray, out hit))
			vTargetSpot.transform.position = hit.point;
		else
			vTargetSpot.transform.position = ray.GetPoint(100);
		Debug.DrawRay (ViewBase.transform.position,ray.direction*100,Color.red);
	}

	void InputCheck(){ // Input // Input // Input // Input // Input // Input // Input // Input // Input 
		
		if (Input.GetKeyDown(KeyCode.Alpha1))
			cGC.SwitchGun("Shocker");
		if (Input.GetKeyDown(KeyCode.Alpha2))
			cGC.SwitchGun("Gun");
		if (Input.GetKeyDown(KeyCode.Alpha3))
			cGC.SwitchGun("Rocket");
		if (Input.GetKeyDown(KeyCode.Alpha4))
			cGC.SwitchGun("Grenade");

		if (Input.GetMouseButtonDown(0))
			cGC.ShootGun("Rocket");
		if (Input.GetMouseButtonDown(1))
			cGC.SwitchGun("Grenade");

		if (Input.GetKeyDown(KeyCode.LeftShift))
			vSpeed *= vSpeedMultiplier;

		/// Mouse Input
		vYaw += vSpedH * Input.GetAxis ("Mouse X");
		vPitch -= vSpedV * Input.GetAxis ("Mouse Y");
		if (vPitch > 90f) vPitch = 90f; 			// Clamp
		if (vPitch < -90f) vPitch = -90f;			// Clamp
		vDirection = new Vector3(Input.GetAxis("Vertical"),vYSpeed,(Input.GetAxis("Horizontal")*-1f));

	}
}
