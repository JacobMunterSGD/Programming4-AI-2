using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Threading;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class DanceSwitchDelay : ConditionTask {

		public float timer;
		public float timerStartValue;

		protected override string OnInit(){
            return null;
		}

		protected override void OnEnable() {
            timer = timerStartValue;
        }

		protected override bool OnCheck() {

			if (timer < 0)
			{
				return true;
			}
			else
			{
				timer -= Time.deltaTime;
                return false;
            }

			
		}
	}
}