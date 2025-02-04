using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SetWaypoint : ActionTask {

		public BBParameter<List<Transform>> waypoints;
		public BBParameter<Transform> currentTarget;
		public BBParameter<int> currentWaypoint;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			currentTarget.value = waypoints.value[currentWaypoint.value];

            EndAction(true);
		}

	}
}