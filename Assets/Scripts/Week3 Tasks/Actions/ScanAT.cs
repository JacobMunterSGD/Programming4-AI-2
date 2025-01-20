using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class ScanAT : ActionTask {
		public Color scanColour;
		public int numberOfScanCirclePoints;

		public float initialScanRadius;
		public float scanDuration;

		public BBParameter<float> currentScanRadius;
		public BBParameter<LayerMask> targetMask;
		public BBParameter<bool> hasTarget;
		public BBParameter<Transform> targetTransform;

		float timeScanning;

		protected override string OnInit() {

			currentScanRadius.value = initialScanRadius;

			return null;
		}

		protected override void OnExecute() {

			timeScanning = 0;

        }

		protected override void OnUpdate() {

			DrawCircle(agent.transform.position, currentScanRadius.value, scanColour, numberOfScanCirclePoints);

			timeScanning += Time.deltaTime;
			if (timeScanning > scanDuration)
			{
				Collider[] colliders = Physics.OverlapSphere(agent.transform.position, currentScanRadius.value, targetMask.value);
				foreach (Collider collider in colliders)
				{
					Blackboard blackboard = collider.GetComponent<Blackboard>();
					float currentRepairValue = blackboard.GetVariableValue<float>("repairValue");

					if (currentRepairValue == 0)
					{
						targetTransform.value = blackboard.GetVariableValue<Transform>("workpad");
						hasTarget.value = true;
					}
				}
                EndAction(true);
            }

		}

		private void DrawCircle(Vector3 center, float radius, Color colour, int numberOfPoints)
		{
			Vector3 startPoint, endPoint;
			int anglePerPoint = 360 / numberOfPoints;
			for (int i = 1; i <= numberOfPoints; i++)
			{
				startPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * (i-1)), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * (i-1)));
				startPoint = center + startPoint * radius;
				endPoint = new Vector3(Mathf.Cos(Mathf.Deg2Rad * anglePerPoint * i), 0, Mathf.Sin(Mathf.Deg2Rad * anglePerPoint * i));
				endPoint = center + endPoint * radius;
				Debug.DrawLine(startPoint, endPoint, colour);
			}			
		}

		protected override void OnStop() {
			
		}

		protected override void OnPause() {
			
		}
	}
}