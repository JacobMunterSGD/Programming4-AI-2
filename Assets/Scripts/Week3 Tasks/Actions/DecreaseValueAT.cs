using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DecreaseValueAT : ActionTask {

		public BBParameter<float> repairValue;
		public float decreaseRate;
		public float minValue;

		protected override string OnInit() {
			return null;
		}

		protected override void OnUpdate() {
			repairValue.value += decreaseRate * Time.deltaTime;

			if (repairValue.value < minValue)
			{
				repairValue.value = minValue;
			}
		}

	}
}