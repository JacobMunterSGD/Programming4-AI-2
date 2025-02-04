using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Conditions {

	public class ReachedLane : ConditionTask {

		public BBParameter<float> targetLaneXPos;

        protected override string OnInit(){
			return null;
		}

		protected override bool OnCheck() {

			if (agent.transform.position.x + 0.2 >= targetLaneXPos.value && agent.transform.position.x - 0.2 <= targetLaneXPos.value)
			{
				return true;
			}

			return false;
		}
	}
}