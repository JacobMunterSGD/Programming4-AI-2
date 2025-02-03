using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class NavigateAT : ActionTask {

		public BBParameter<Vector3> targetPosition;
		public float sampleRate;
		public float sampleRadius;

		NavMeshAgent navAgent;
		Vector3 lastDestination;
		float timeSinceLastSample = 0;

		protected override string OnInit() {

			navAgent = agent.GetComponent<NavMeshAgent>();

			return null;
		}

        protected override void OnUpdate()
        {
			timeSinceLastSample += Time.deltaTime;
			if (timeSinceLastSample > sampleRate)
			{
				timeSinceLastSample = 0;

				if (lastDestination != targetPosition.value)
				{
					lastDestination = targetPosition.value;
					NavMesh.SamplePosition(targetPosition.value, out NavMeshHit hitInfo, sampleRadius, NavMesh.AllAreas);
					navAgent.SetDestination(hitInfo.position);
				}
			}
        }

    }
}