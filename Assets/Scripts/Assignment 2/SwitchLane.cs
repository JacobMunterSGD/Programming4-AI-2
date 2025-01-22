using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SwitchLane : ActionTask {

		public BBParameter<float> targetLaneXPos;
        public BBParameter<float> moveSpeed;

		float zOffset;

        CharacterController cc;

        protected override string OnInit() {
            cc = agent.GetComponent<CharacterController>();

            return null;
		}

		protected override void OnExecute() {
            zOffset = 5;
        }

		protected override void OnUpdate() {

			Vector3 target = new Vector3(targetLaneXPos.value, agent.transform.position.y, agent.transform.position.z + zOffset);
			target -= agent.transform.position;

			zOffset -= Time.deltaTime * 4;

			cc.Move(target.normalized * moveSpeed.value * Time.deltaTime);
        }

	}
}