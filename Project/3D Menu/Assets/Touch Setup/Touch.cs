using UnityEngine;
using System.Collections;



public class Touch : MonoBehaviour {

//For clicking on items
GameObject Object_to_move; 

private float timer;

//Current and previous frame vectors 
private Vector2 v2_currentFrame; 
private Vector2 v2_previousFrame;
private Vector2 v2_current; 
private Vector2 v2_previous;
//New vector from start to end vector 
private float newVector; 
// Camera
public Camera myCamera;

//For SmoothDamp: writing .zero is short for writing (0,0,0); 
private Vector3 velocity = Vector3.zero; 
public float smoothTime = 0.3F;

//Zooming 
public float ZoomComfortZone;
public byte zoomStrength; 
public byte maxFov; 
public byte minFov;


 
	// Use this for initialization
	void Start () {
		
	}
	
	/*public static Vector2 FixedTouchDelta(Vector2 aTouch)
	{
		float dt = Time.deltaTime / aTouch.deltaTime; 
		if (dt == 0 || float.IsNan(dt) || float.IsInfinity(dt))
			dt = 1.0f; 
		return atouch.deltaPosition * dt; 
	}*/
	
	// Update is called once per frame
	void Update () {
		
		//Will check if we're touching or not
		if(Input.touchCount == 1) {
			//Debug.Log("Debug: Touch Happened");			
			switch(Input.GetTouch(0).phase)
			{
				case TouchPhase.Began: 
					timer = Time.time; 

				break; 
				case TouchPhase.Moved: 
					if (Time.time-timer > 0.1F)
					myCamera.transform.Translate(-Input.GetTouch(0).deltaPosition.x*0.05F, 0,0) ;

				break; 
				case TouchPhase.Ended:
				if (Input.GetTouch(0).tapCount == 1) {
						Debug.Log("Single Tap with one Finger");
						 
						RaycastHit hit; 
						Ray ray; 
						
						ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); 
							if(Physics.Raycast(ray, out hit)) {
								
								Debug.Log(hit.transform.name);
								
							}
				}
				break; 
			}
			/*if (Input.GetTouch(0).phase == TouchPhase.Moved) {
				
				timer = Time.timer; 
				/* Tranforming the camera position (always a Vector3). 
				A new vector is created. To give it a smooth movement the Mathf function SmoothDamp is used for the x axis.
				SmoothDamp requires (Vector3 current, vector3 target, ref Vector3 currentVelocity, smoothTime); 
				Our Current vector is just the x position. Our target would be the current position minus the movement of 
				our finger since last frame. Input.GetTouch(0) is the current finger touching the screen, deltaPosition.x is 
				the movement in the x direction since last frame. The current velocity is just 0, read above. And smoothTime 				
				is the approximate time it takes to move from A to B.  If we have performance issues then instead of SmoothDamp 
				we could use Mathf.Lerp. Which is linear interpolation between to variables. 
				*/				
				/*myCamera.transform.position = new Vector3 (Mathf.SmoothDamp(myCamera.transform.position.x, 
																			myCamera.transform.position.x + Input.GetTouch(0).deltaPosition.x, 
																			ref velocity.x, smoothTime),
														myCamera.transform.position.y,
														myCamera.transform.position.z);*/
				
				//if (timer - Time.time >= 0.5)
				//myCamera.transform.Translate(-Input.GetTouch(0).deltaPosition.x*0.1F, 0,0) ;
				
			/*}
			if (Input.GetTouch(0).phase == TouchPhase.Ended) {

				if (Input.GetTouch(0).tapCount == 1) {
						Debug.Log("Single Tap with one Finger");
						 
						RaycastHit hit; 
						Ray ray; 
						
						ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position); 
							if(Physics.Raycast(ray, out hit)) {
								
								Debug.Log(hit.transform.name);
								
							}
				}
			}*/
			//****************************************************************************
			//I'll keep this here, since we might use it laster and it's already well-documented
			
			//Asking if the touching has stopped
			/*if (Input.GetTouch(0).phase == TouchPhase.Ended) {
				//set the v2_current vector to the end position of the touch
				v2_current = Input.GetTouch(0).position; 
				//Getting the length between the two vectors
				newVector = v2_current.magnitude - v2_previous.magnitude; 
				//Checking if the the length of touch can be considered a touch
				//Mathf.Abs gives us an absolute value (negative numbers becomes positive)
				if (Mathf.Abs(newVector) > i_comfort) {
					/*Next if, else statements will check if swipe is from right, left, top or bottom
					If the end vector(v2_current) is bigger than the start vector (v2_previous)
					we will either have a movement from the left to right or from the bottom 
					to the top.*/ /*
					if(newVector>0) {
						/*To check whether the swipe is from left to right or bottom to the top, we will
						check if the distance of the x value from the end and start vectors are bigger 
						Than the distance of the y values from the two vectors. If x distance is bigger 
						then we know that its a horizontal swipe. And if not it is a vertical swipe. 
						Notice the use of Mathf.Abs makes sure the arrangement of variables doesn't matter */
						/*if(Mathf.Abs(v2_current.x - v2_previous.x) > Mathf.Abs(v2_current.y - v2_previous.y))
						{
							Debug.Log("Left to right");
							Debug.Log(Mathf.Lerp(myCamera.transform.position.x, myCamera.transform.position.x + newVector, Time.deltaTime*5));
							myCamera.transform.position = new Vector3 
														(Mathf.Lerp(myCamera.transform.position.x, myCamera.transform.position.x + newVector, Time.deltaTime),
														myCamera.transform.position.y,
														myCamera.transform.position.z);
														
							
							
							
						}
						else 
						{
							Debug.Log("Bottom to top");
						}
						
					} else {
						//The opposite of what is calculated above. Checking right to left and top to bottom.
						if (Mathf.Abs(v2_current.x - v2_previous.x) > Mathf.Abs(v2_current.y - v2_previous.y))
						{
							Debug.Log("Right to left"); 
						}
						else 
						{
						Debug.Log("Top to Bottom"); 

						}
					}
				}
			}*/
		}
		if (Input.touchCount == 2 && Input.GetTouch(0).phase == TouchPhase.Moved && Input.GetTouch(1).phase == TouchPhase.Moved)
		{
			//v2_currentFrame = Input.GetTouch(0).position - Input.GetTouch(1).position; 
			//v2_previousFrame = (Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition)
							   //- (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition); 
			newVector = (Input.GetTouch(0).position - Input.GetTouch(1).position).magnitude 
								- ((Input.GetTouch(0).position - Input.GetTouch(0).deltaPosition)
							   - (Input.GetTouch(1).position - Input.GetTouch(1).deltaPosition)).magnitude;
			//newVector = v2_currentFrame.magnitude - v2_previousFrame.magnitude;

			if (Mathf.Abs(newVector) > ZoomComfortZone) {
				if (newVector > 0)
				{
					//Zoom in 
					//Debug.Log("Zoom In");
					myCamera.fieldOfView = Mathf.Clamp(
								   Mathf.Lerp(myCamera.fieldOfView,
								   myCamera.fieldOfView - Mathf.Abs(newVector) * zoomStrength, 
								   Time.deltaTime * zoomStrength),
								   minFov, maxFov);
				} else {
					//Zoom Out
					//Debug.Log("Zoom Out"); 
					myCamera.fieldOfView = Mathf.Clamp(
								   Mathf.Lerp(myCamera.fieldOfView,
								   myCamera.fieldOfView + Mathf.Abs(newVector) * zoomStrength, 
								   Time.deltaTime * zoomStrength),
								   minFov, maxFov); 
				}
			} else {
				
			}
			
		}
	}
}
