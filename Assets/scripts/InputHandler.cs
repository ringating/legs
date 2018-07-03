using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	private float deadZone = 0.15f;
	private float liveZone = 0.975f;

	// axes
	public Vector2 move;
	public Vector2 aim;

	// buttons
	public bool hop;
	public bool hopDown;
	public bool hopUp;

	void Update()
	{
		UpdateInputs();
	}

	private void ResetInputs()
	{
		// axes
		move = Vector2.zero;
		aim = Vector2.zero;

		// buttons
		hop = false;
		hopDown = false;
		hopUp = false;
	}

	private void UpdateInputs()
	{
		ResetInputs();

		// axes
		move.Set(Input.GetAxisRaw("left stick x"), Input.GetAxisRaw("left stick y"));
		move = move.normalized * Map(move.magnitude, deadZone, liveZone, 0, 1);

		aim.Set(Input.GetAxisRaw("right stick x"), Input.GetAxisRaw("right stick y"));
		aim = aim.normalized * Map(aim.magnitude, deadZone, liveZone, 0, 1);

		// buttons
		hop = Input.GetButton("hop");
		hopDown = Input.GetButtonDown("hop");
		hopUp = Input.GetButtonUp("hop");
	}

	public float Map(float val, float inMin, float inMax, float outMin, float outMax)
	{
		return Mathf.Lerp(outMin, outMax, Mathf.InverseLerp(inMin, inMax, val));
	}
}
