using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisTester : MonoBehaviour
{
	public Transform raw;
	public Transform processed;
	public InputHandler input;

	private float scalar = 4;

	void Update ()
	{
		raw.position = new Vector3(Input.GetAxisRaw("left stick x")*scalar, Input.GetAxisRaw("left stick y")*scalar, 0);
		processed.position = input.move * scalar;
	}
}
