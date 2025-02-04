using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class RunFowards : ActionTask {

		public BBParameter<float> moveSpeed;
        public BBParameter<float> increaseSpeedBy;
        CharacterController cc;

		protected override string OnInit() {
			cc = agent.GetComponent<CharacterController>();
			
			return null;
		}

		protected override void OnUpdate() {
            
            cc.Move(agent.transform.forward * moveSpeed.value * Time.deltaTime);
			//moveSpeed.value += increaseSpeedBy.value * Time.deltaTime;

        }
	}
}