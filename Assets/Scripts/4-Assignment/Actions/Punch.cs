using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class Punch : ActionTask {

		public BBParameter<float> damage;
		public BBParameter<Transform> currentTarget;
		public BBParameter<float> punchRange;
        public BBParameter<float> punchForce;

        protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
            if ((agent.transform.position - currentTarget.value.position).magnitude < punchRange.value)
            {
                // subtract health
                currentTarget.value.gameObject.GetComponent<Health>().health -= damage.value; 

				// deal force in direction punched
				Vector3 targetPosition = currentTarget.value.gameObject.GetComponent<Transform>().position;
				targetPosition += agent.transform.forward * punchForce.value;
				currentTarget.value.gameObject.GetComponent<Rigidbody>().AddForce(targetPosition, ForceMode.Impulse);

				// temporarily turn off the targets nav mesh (simulate them being "stunned")
				currentTarget.value.gameObject.GetComponent<PlayerHurt>().JustBeenHit();

            }
            EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

		
	}
}