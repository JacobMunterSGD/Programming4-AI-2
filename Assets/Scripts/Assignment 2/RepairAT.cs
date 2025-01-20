using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class RepairAT : ActionTask {

		public float repairRate;

		public BBParameter<float> scanRadius;
        public BBParameter<float> initialScanRadius;

        public BBParameter<bool> hasTarget;
		public BBParameter<Transform> targetTransform;

        Blackboard lightMachineBB;
		float activeThreshold;
		float currentRepairValue;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			lightMachineBB = targetTransform.value.GetComponentInParent<Blackboard>();
			activeThreshold = lightMachineBB.GetVariableValue<float>("activeThreshold");
			currentRepairValue = lightMachineBB.GetVariableValue<float>("repairValue");

		}

		protected override void OnUpdate() {

			currentRepairValue += repairRate * Time.deltaTime;
			lightMachineBB.SetVariableValue("repairValue", currentRepairValue);

			if (currentRepairValue > activeThreshold)
			{
				hasTarget.value = false;
				scanRadius.value = initialScanRadius.value;
				EndAction(true);
			}

		}
	}
}