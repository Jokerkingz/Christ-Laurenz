using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour {

	//Find Cover Variables
	public AI ai;

	//Patrol Variables
	public Transform[] points;
	private int destPoint = 0;
	private UnityEngine.AI.NavMeshAgent agent;

	//States
	public string currentState;

	//Assign variables
	void Start(){
		agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();

		agent.autoBraking = false;

		currentState = "isMoving";
	}

	void Update(){
		RunStates ();
	}

	void RunStates(){

		if (ai.fpsTargetDistance < ai.enemyLookDistance && ai.lookfornew == true) {
			ai.findCover();
		}else if (agent.remainingDistance < 0.5f && currentState == "none"){
			StartMove ();
		}

		
		//Run ongoing states 8===D
		switch (currentState) {
		case "isGettingHit":  		GetHit (); 		break;
		case "isAttacking":  		Attack (); 		break;
		case "isMoving":  			Move (); 		break;
		case "isIdling":  			Idle (); 		break;
		case "isGettingCover":		GetCover ();	break;
		}
	}
	void ResetStates(){
		StopIdle ();
		StopAttack ();
		StopMove ();
		StopGetHit ();
		StopGetCover ();

	}
	//Idle

	void StartIdle(){
		ResetStates ();
		currentState = "isIdling";
	}
	void Idle(){
		//do fucking nothing
	}

	void StopIdle(){
		
	}
	//Walk

	void StartMove(){
		ResetStates ();
		currentState = "isMoving";
	}
	void Move(){


		// Returns if no points have been set up
		if (points.Length == 0)
			return;

		// Set the agent to go to the currently selected destination.
		ai.goHereTrans = points[destPoint];

		// Choose the next point in the array as the destination,
		// cycling to the start if necessary.
		destPoint = (destPoint + 1) % points.Length;

		if(agent.remainingDistance < 0.5f)
		StopMove ();


		/*
		//Wait before trying a new patrol point.
		StartCoroutine (Wait ());
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds (5F);
		StopMove();
		*/
	}

	void StopMove(){
		currentState = "none";
	}

	//Attack

	public void StartAttack(){
		ResetStates ();
		currentState = "isAttacking";
	}
	void Attack(){
		
	}
	void StopAttack(){

	}
	//GetHit

	void StartGetHit(){
		ResetStates ();
		currentState = "isIdling";
	}
	void GetHit(){

	}
	void StopGetHit(){

	}
	//Get Cover

	void StartGetCover(){
		ResetStates ();
		currentState = "isIdling";
	}
	void GetCover(){

	}
	void StopGetCover(){

	}
}