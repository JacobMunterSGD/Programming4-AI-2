using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class SwitchLane : ActionTask {

		public BBParameter<float> targetLaneXPos;
        public BBParameter<float> moveSpeed;
        CharacterController cc;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
            cc = agent.GetComponent<CharacterController>();
            
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
			//EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			//agent.transform.position = new Vector3(targetLaneXPos.value, agent.transform.position.y, agent.transform.position.z);

			Vector3 target = new Vector3(targetLaneXPos.value, agent.transform.position.y, agent.transform.position.z + 5);
			target -= agent.transform.position;

			cc.Move(target.normalized * moveSpeed.value * Time.deltaTime);
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}