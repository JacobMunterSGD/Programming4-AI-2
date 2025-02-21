using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DamageTakenColourResetAT : ActionTask {

		public BBParameter<float> damageTaken;
		public MeshRenderer kangarooMeshRenderer;
		Material startingMaterial;

		protected override string OnInit()
		{
			startingMaterial = kangarooMeshRenderer.material;
			return null;
		}

		protected override void OnExecute()
		{
			kangarooMeshRenderer.material.color = new Color(startingMaterial.color.r + damageTaken.value, startingMaterial.color.g, startingMaterial.color.b);
			//Debug.Log(kangarooMeshRenderer.material.color);
			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate()
		{

			

		}
	}
}