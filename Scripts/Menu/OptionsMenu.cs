using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour {

	public new AudioMixer audio;

	public void SetMenu(float volume) {

		audio.SetFloat("volume",volume);

	}
}
