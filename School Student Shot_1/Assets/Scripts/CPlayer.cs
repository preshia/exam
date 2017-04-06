using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPlayer : MonoBehaviour {

	public bool mIsJoyPadTouched = false;
	public Vector3 mMoveVector = Vector3.zero;
	public float mSpeed = 2.0f;
	//public Rigidbody mRigidbody;
	public CharacterController mController = null;
	private float mRotationValue = 0.0f;

	Vector3 mTempPosition = Vector3.zero;

	// Use this for initialization
	void Start () {
		//mRigidbody = this.gameObject.GetComponent<Rigidbody> ();
		mController = this.gameObject.GetComponent<CharacterController> ();
	}

	// Update is called once per frame
	void Update () {
		if(true == mIsJoyPadTouched)
		{
			//transform.localPosition += mMoveVector * Time.deltaTime * mSpeed;
			transform.rotation = Quaternion.Euler (new Vector3(0,mRotationValue, 0));
			//transform.rotation = Quaternion.Euler();
			//mRigidbody.MovePosition(transform.position + mMoveVector * Time.deltaTime*mSpeed);
			mController.Move( mMoveVector * Time.deltaTime*mSpeed);
		}
	}

	public void SetMoveInput(Vector3 tTemp)
	{
		mMoveVector = new Vector3(tTemp.x, 0, tTemp.y);
	}

	public void SetRotateInput(float tTemp)
	{
		mRotationValue = tTemp;
	}

	public void setIsJoyPadTouched(bool tTemp)
	{
		mIsJoyPadTouched = tTemp;
	}
		


}