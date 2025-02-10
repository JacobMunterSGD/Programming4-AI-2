using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Tasks.Actions {

	public class FindCurrentTargetAT : ActionTask {

		public BBParameter<Transform> currentTarget;
		public BBParameter<string> currentGoal;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			//if (currentGoal.value == "Eat") FindGoal("Food");

		}

        protected override void OnUpdate()
        {
            if (currentGoal.value == "Eat") FindGoal("Food");
            if (currentGoal.value == "Drink") FindGoal("Water");
            if (currentGoal.value == "Rest") FindGoal("Rest");
			if (currentGoal.value == "Fight") FindAgressor();

            EndAction(true);
        }

        void FindGoal(string tag)
		{
			GameObject[] foodSources = GameObject.FindGameObjectsWithTag(tag);

			GameObject closestFoodSource = null;
			float minDistance = -1;

			foreach(GameObject t in foodSources)
			{
				if (minDistance == -1)
				{
					closestFoodSource = t;
					minDistance = (t.transform.position - agent.transform.position).magnitude;
                }
				else if (minDistance < (t.transform.position - agent.transform.position).magnitude)
				{
                    closestFoodSource = t;
                    minDistance = (t.transform.position - agent.transform.position).magnitude;
                }
			}

			if (closestFoodSource != null)
			{
                currentTarget.value = closestFoodSource.transform;
            }
        }
		void FindAgressor()
		{
			// find the thing that attacked the agent (for now it's only be the player)
            currentTarget.value = GameObject.FindGameObjectWithTag("Player").transform;

        }

    }
}