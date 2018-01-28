using UnityEngine;
using UnityEngine.AI;

public class CharControl : MonoBehaviour {

	[Header("Character movement")]
	[SerializeField]
    float characceleration;
	[SerializeField]
    float maxSpeed;

	[Header("Rigidbody movement type")]
	[SerializeField]
    bool _impulse;
	[SerializeField]
    bool _acceleration;
	private Rigidbody rb;
	private Quaternion rotation;

	private float StartAcc;
	private float StartMaxSpeed;

    public bool AllowInput = false;

    public static CharControl Instance { get; private set; }

	void Awake()
	{
	    Instance = this;

        if (rb == null)
        {
			rb = GetComponent<Rigidbody>();
		}

        NavMeshAgent agent = GetComponent<NavMeshAgent>();

	    if (agent != null)
        {
            agent.updateRotation = false;
            agent.updatePosition = false;
        }

		StartAcc = characceleration;
		StartMaxSpeed = maxSpeed;

		if(_impulse){
			_acceleration = false;
		} else if (_acceleration){
			_impulse = false;
		} else {
			_impulse = true;
		}
	}
	
	void Update ()
    {
	    if (!AllowInput)
	    {
	        return;
	    }

		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 charmovement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		if(_impulse){
			rb.AddForce(charmovement * maxSpeed, ForceMode.Impulse);
		} else if (_acceleration){
			rb.AddForce(charmovement * characceleration * 2, ForceMode.Acceleration);
		}
		if(moveHorizontal != 0 || moveVertical != 0){
			transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(charmovement), 0.15F);
		}

		rb.drag = characceleration / maxSpeed;

		if(rb.velocity.magnitude > maxSpeed){
			rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
         }

		 if(Input.GetKeyDown(KeyCode.F1)){
			 Impulse();
		 }
		 if(Input.GetKeyDown(KeyCode.F2)){
			 Acceleration();
		 }

	}

	private void Impulse()
    {
		if(_impulse){
			return;
		} else {
			_impulse = true;
			_acceleration = false;
			characceleration = StartAcc;
			maxSpeed = StartMaxSpeed;
		}
	}

	private void Acceleration()
    {
		if(_acceleration){
			return;
		} else {
			_acceleration = true;
			_impulse = false;
			characceleration = characceleration + 50;
			maxSpeed = maxSpeed + 2;
		}
	}

}
