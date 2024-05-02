using UnityEngine;
using UnityEngine.Events;
using System.Collections;
using extOSC;

namespace TS.GazeInteraction
{
    public class GazeInteractableOSC : GazeInteractable
    {
        [Header("OSC Settings")]
        public OSCTransmitter Transmitter;
        public string OSCAddress = "/eye_gaze";

        /// <summary>
        /// Activates the GameObject and sends OSC message.
        /// </summary>
        public new void Activate()
        {
            base.Activate();

            // Send OSC message
            SendOSCMessage();
        }

        /// <summary>
        /// Sends an OSC message with the GameObject's position.
        /// </summary>
        private void SendOSCMessage()
        {
            var message = new OSCMessage(OSCAddress);
            message.AddValue(OSCValue.Float(transform.position.x));
            message.AddValue(OSCValue.Float(transform.position.y));
            message.AddValue(OSCValue.Float(transform.position.z));

            Transmitter.Send(message);
        }
    }
}