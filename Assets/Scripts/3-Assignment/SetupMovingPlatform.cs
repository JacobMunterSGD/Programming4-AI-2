using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Collections.Generic;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SetupMovingPlatform : ActionTask {

		public BBParameter<List<Transform>> waypoints;
		public BBParameter<int> currentWaypoint;
		public BBParameter<GameObject> box;

        protected override string OnInit() {

            foreach (Transform waypointTransform in agent.GetComponentInChildren<Transform>())
			{
				if (waypointTransform.gameObject.tag == "waypoint") waypoints.value.Add(waypointTransform);
				if (waypointTransform.gameObject.tag == "Obstacle") box.value = waypointTransform.gameObject;
            }

            currentWaypoint = waypoints.value.Count - 1;

            return null;
		}

        protected override void OnExecute()
        {
            EndAction(true);
        }

    }
}