using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using UnityEngine.AI;

namespace NodeCanvas.Tasks.Actions {

	public class SeekAT : ActionTask {

        public BBParameter<bool> hasTarget;
		public BBParameter<Vector3> targetPosition;
		public Transform target;

        protected override void OnUpdate()
        {
            hasTarget.value = target != null;
            targetPosition.value = target.position;
        }

    }
}