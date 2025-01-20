using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class WaitCT : ConditionTask {
		public float waitDuration;

		private float timeWaiting = 0f;

		protected override string OnInit(){
			return null;
		}

		protected override void OnEnable() {
			timeWaiting = 0f;
		}

		protected override bool OnCheck() {
			timeWaiting += Time.deltaTime;
			return timeWaiting > waitDuration;
		}
	}
}