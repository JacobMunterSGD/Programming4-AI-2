using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;
using System;

namespace NodeCanvas.Tasks.Actions {

	public class StopAllAudioAT : ActionTask {

		AudioSource[] audioSources;

		protected override string OnInit() {
			
			return null;
		}
		protected override void OnExecute() {

			audioSources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
			foreach (AudioSource audioSource in audioSources)
			{				
				if (audioSource.clip.name != "punch") // stop all audio except the punch sound
				{
					GameObject.Destroy(audioSource.gameObject);
				}

			}
			EndAction(true);
		}
	}
}