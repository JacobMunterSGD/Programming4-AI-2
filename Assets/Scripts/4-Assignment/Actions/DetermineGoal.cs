using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class DetermineGoal : ActionTask {

		public BBParameter<float> hunger;
        public BBParameter<float> thirst;
        public BBParameter<float> tiredness;
        public BBParameter<float> angriness;
        public BBParameter<string> currentGoal;

        float angryThreshold;
        float otherStateThreshold;

        protected override string OnInit() {

            angryThreshold = 30;
            otherStateThreshold = 40;

            return null;
		}

		protected override void OnExecute() {
			
		}

        protected override void OnUpdate()
        {

            // fight check
            if (angriness.value > angryThreshold &&
                thirst.value > 10 &&
                hunger.value > 10 &&
                tiredness.value > 10)
            {
                currentGoal.value = "Fight";
                return;
            }

            // check others
            float[] stateArray = { thirst.value, hunger.value, tiredness.value };
            float smallest = 100;

            foreach (float state in stateArray)
            {
                if (state < smallest) smallest = state;
            }

            if (smallest == thirst.value)currentGoal.value = "Drink";
            if (smallest == hunger.value) currentGoal.value = "Eat";
            if (smallest == tiredness.value) currentGoal.value = "Rest";

            if (smallest > otherStateThreshold) currentGoal.value = "Dance";


        }

	}
}