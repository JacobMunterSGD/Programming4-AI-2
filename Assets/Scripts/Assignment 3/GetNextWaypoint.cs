using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class GetNextWaypoint : ActionTask {

        public BBParameter<List<Transform>> waypoints;
        public BBParameter<int> currentWaypoint;

        protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			currentWaypoint.value += 1;

			if (currentWaypoint.value == waypoints.value.Count) currentWaypoint.value = 0;

            EndAction(true);
		}

	}
}