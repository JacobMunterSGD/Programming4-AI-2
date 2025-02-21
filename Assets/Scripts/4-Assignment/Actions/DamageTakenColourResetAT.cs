using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	// This script sets the color of the kangaroos material every frame its run

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
			currentRvalue = startingRValue + (damageTaken.value / 255);
			Color currentColor = new Color(currentRvalue, kangarooMeshRenderer.material.color.g, kangarooMeshRenderer.material.color.b);
			kangarooMeshRenderer.material.color = currentColor;
			EndAction(true);
		}
	}
}