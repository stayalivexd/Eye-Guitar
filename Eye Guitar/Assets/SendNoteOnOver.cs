using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace extOSC.Examples
{
	public class SendNoteOnOver : MonoBehaviour
	{
		#region Public Vars

		public string Address = "/hand0";

		[Header("OSC Settings")]
		public OSCTransmitter Transmitter;

		#endregion

		#region Unity Methods

		protected virtual void Start()
		{
		}

        private void OnMouseEnter()
        {
			OSCMessage message = CreateLeapNote(70, 80);
			Transmitter.Send(message);

			// Get the Renderer component from the new cube
			var cubeRenderer = GetComponent<Renderer>();

			// Call SetColor using the shader property name "_Color" and setting the color to red
			cubeRenderer.material.SetColor("_Color", Color.red);

		}

        private void OnMouseExit()
        {
			OSCMessage message = CreateLeapNote(0, 0);
			Transmitter.Send(message);

			// Get the Renderer component from the new cube
			var cubeRenderer = GetComponent<Renderer>();

			// Call SetColor using the shader property name "_Color" and setting the color to red
			cubeRenderer.material.SetColor("_Color", Color.blue);
		}

		private OSCMessage CreateLeapNote(int pitch, int velocity)
        {
			var message = new OSCMessage(Address);
			message.AddValue(OSCValue.Int(0)); //not used
			message.AddValue(OSCValue.Int(0)); //not used
			message.AddValue(OSCValue.Int(0)); //not used
			message.AddValue(OSCValue.Int(velocity));
			message.AddValue(OSCValue.Int(pitch));

			return message;
		} 

        #endregion
    }
}
