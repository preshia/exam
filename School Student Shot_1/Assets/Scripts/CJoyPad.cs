using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CJoyPad : MonoBehaviour {

	public CPlayer mpPlayerScript;


	public RectTransform mpJoyPadBackRect;
	public Transform mpStickTr;
	private Vector3 mDefaultPos;
	private Vector3 mScreenPos;
	private Vector3 mTPos;
	private Vector3 mMove;
	private Touch mTouch;
	private float mRadian;

	// Use this for initialization
	void Start () {
		mRadian = mpJoyPadBackRect.sizeDelta.y / 2;
		mDefaultPos = mpStickTr.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void DoJoyPadMove()
	{
		mTouch = Input.GetTouch (Input.touchCount -1);
		mTPos = new Vector3 (mTouch.position.x, mTouch.position.y, mpStickTr.position.z);
		mMove = (mTPos - mDefaultPos).normalized;
		float tDistance = Vector3.Distance (mTPos, mDefaultPos);

		if (tDistance > mRadian) {
			mScreenPos = mDefaultPos + mMove * mRadian;
		} else {
			mScreenPos = mDefaultPos + mMove * tDistance;
		}

		float tRotationValue = (Mathf.Atan2 (mMove.x, mMove.y) * 180.0f) / Mathf.PI;

		if (tRotationValue < 0) {
			tRotationValue += 360.0f;
		}

		mpPlayerScript.SetMoveInput (mMove);
		mpPlayerScript.SetRotateInput (tRotationValue);
		mpPlayerScript.setIsJoyPadTouched (true);
		mpStickTr.position = mScreenPos;


	}

	public void DoJoyPadEnd()
	{
		mpPlayerScript.setIsJoyPadTouched (false);
		mpStickTr.position = mDefaultPos;
	}


}
