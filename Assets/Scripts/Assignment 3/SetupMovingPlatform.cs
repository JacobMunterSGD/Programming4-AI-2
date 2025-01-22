using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SetupMovingPlatform : ActionTask {

		public BBParameter<List<Transform>> waypoints;
		public BBParameter<int> currentWaypoint;

        protected override string OnInit() {

            foreach (Transform waypointTransform in agent.GetComponentInChildren<Transform>())
			{
				waypoints.value.Add(waypointTransform);
			}

            currentWaypoint = waypoints.value.Count;

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}