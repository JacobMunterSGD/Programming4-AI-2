using NodeCanvas.Framework;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization.FullSerializer;
using UnityEngine;

namespace NodeCanvas.Tasks.Conditions {

	public class PlayerInput : ConditionTask {

		public BBParameter<string> LeftOrRight;
		public BBParameter<KeyCode> keyPressed;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			if (LeftOrRight.value == "Left" && Input.GetKey(KeyCode.LeftArrow))
			{
                return true;
            }
            else if (LeftOrRight.value == "Right" && Input.GetKey(KeyCode.RightArrow))
            {
                return true;
            }
			else if (keyPressed.value == KeyCode.Space && Input.GetKeyDown(KeyCode.Space))
			{
				return true;
			}

			else return false;



        }
	}
}