using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
	private float deadZone = 0.15f;
	private float liveZone = 0.975f;

	public Vector2 move;
	public Vector2 aim;

	void Update()
	{
		UpdateInputs();
	}

	private void ResetInputs()
	{
		move = Vector2.zero;
		aim = Vector2.zero;
	}

	private void UpdateInputs()
	{
		ResetInputs();

		move.Set(Input.GetAxisRaw("left stick x"), Input.GetAxisRaw("left stick y"));
		move = move.normalized * Map(move.magnitude, deadZone, liveZone, 0, 1);
	}

	public float Map(float val, float inMin, float inMax, float outMin, float outMax)
	{
		return Mathf.Lerp(outMin, outMax, Mathf.InverseLerp(inMin, inMax, val));
	}
}
