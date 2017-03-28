using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_GunControl : MonoBehaviour {
	// Weapons // Weapons // Weapons // Weapons // Weapons // Weapons // Weapons // Weapons // Weapons // Weapons // Weapons // Weapons // Weapons 
	public string vCurrentWeapon = "Shocker";
	public string vStatus;
	public float vCoolDown; // 0f = ready;
	public GameObject tGO; // 0f = ready;

	// Shoocker
	public GameObject vWeaponA; 		// First Weapon
	public bool vHasWepA; 				// Has The Weapon

	// Gun?
	public GameObject vWeaponB; 		// Second Weapon
	public bool vHasWepB; 				// Has The Weapon

	// Rocket?
	public GameObject vWeaponC; 		// Third Weapon
	public bool vHasWepC; 				// Has The Weapon

	// Grenades
	public GameObject vWeaponD; 		// Grenade Weapon
	public bool vHasWepD; 				// Has The Weapon


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SwitchGun(string tWeapon){
		tGO = null;
		switch (tWeapon) {
		case "Shocker":
			if (!vHasWepA)
				return;
			else
				tGO = vWeaponA;
			break;
		case "Gun":
			if (!vHasWepB)
				return;
			else
				tGO = vWeaponB;
			break;
		case "Rocket":
			if (!vHasWepC)
				return;
			else
				tGO = vWeaponC;
			break;
		case "Grenade":
			if (!vHasWepD)
				return;
			else
				tGO = vWeaponD;
			break;

		}
		if (vCurrentWeapon != tWeapon) {
			vCurrentWeapon = tWeapon;
			vCoolDown = 0f;
			vWeaponA.SetActive (false);
			vWeaponB.SetActive (false);
			vWeaponC.SetActive (false);
			vWeaponD.SetActive (false);
			tGO.SetActive (true);

			// Animate
			vStatus = "FirstAni";
		}
			
	}
	public void ShootGun(string tWeapon){
		if (vStatus == "FirstAni"){
			vStatus = "Shoot";
	}
		switch (tWeapon) {
		case "Shocker":
			// Poke attack
			break;
		case "Gun":
			// Shooting
			break;
		case "Rocket":
			// Wasabi
			break;
		case "Grenade":
			// OK
			break;

		}


	}
}
