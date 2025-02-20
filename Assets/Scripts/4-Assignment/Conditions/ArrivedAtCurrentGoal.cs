using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class ArrivedAtCurrentGoal : ConditionTask {

		public BBParameter<Transform> currentGoal;
		public BBParameter<float> minDistanceToTrigger;

		protected override string OnInit(){

            return null;
		}

		protected override bool OnCheck() {

			if (currentGoal.value == null)
			{
				return false;
			}

			if ((currentGoal.value.position - agent.transform.position).magnitude < minDistanceToTrigger.value)
			{
                return true;
			}
			else
			{
                return false;
			}
		}
	}
}