using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ResetPlayerPosition : ActionTask {

		public BBParameter<Vector3> startPoint;

		protected override string OnInit() {

            return null;
		}

		protected override void OnExecute() {

			agent.transform.position = startPoint.value;

			EndAction(true);
		}
	}
}