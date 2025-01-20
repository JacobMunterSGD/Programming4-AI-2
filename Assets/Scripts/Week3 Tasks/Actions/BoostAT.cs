using NodeCanvas.Framework;
using ParadoxNotion.Design;


namespace NodeCanvas.Tasks.Actions {

	public class BoostAT : ActionTask {

		public float boostValue;
		public BBParameter<float> scanRadius;

		protected override string OnInit() {
			return null;
		}

		protected override void OnExecute() {

			scanRadius.value += boostValue;

			EndAction(true);
		}
	}
}