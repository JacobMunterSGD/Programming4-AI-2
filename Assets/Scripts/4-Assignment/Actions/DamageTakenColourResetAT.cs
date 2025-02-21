using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DamageTakenColourResetAT : ActionTask {

		public BBParameter<float> damageTaken;
		public MeshRenderer kangarooMeshRenderer;
		float startingRValue;
		float currentRvalue;

		protected override string OnInit()
		{
			startingRValue = kangarooMeshRenderer.material.color.r;
			return null;
		}

		protected override void OnExecute()
		{
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{

			currentRvalue = startingRValue + (damageTaken.value * 100 / 255);
			Color currentColor = new Color(currentRvalue, kangarooMeshRenderer.material.color.g, kangarooMeshRenderer.material.color.b);
			kangarooMeshRenderer.material.color = currentColor;
			Debug.Log(currentRvalue);
			EndAction(true);

		}
	}
}