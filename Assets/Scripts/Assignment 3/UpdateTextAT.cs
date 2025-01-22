using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using TMPro;

namespace NodeCanvas.Tasks.Actions {

	public class UpdateTextAT : ActionTask
	{

		public TMP_Text text;
		public BBParameter<float> score;
		public bool inUpdate;

		protected override string OnInit()
		{
			return null;
		}

		protected override void OnUpdate()
		{
            text.text = "Score: " + (int)score.value;

			if (inUpdate) score.value += Time.deltaTime;
			else EndAction(true);

		}
	}
}