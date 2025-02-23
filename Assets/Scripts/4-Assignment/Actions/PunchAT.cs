using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class PunchAT : ActionTask {

		public BBParameter<float> damage;
		public BBParameter<Transform> currentTarget;
		public BBParameter<float> punchRange;
        public BBParameter<float> punchForce;

        protected override string OnInit() {
			return null;
		}

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
		
	}
}