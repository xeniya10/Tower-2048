using UnityEngine;

public class AudioManager : MonoBehaviour
{
	[SerializeField] private AudioSource DropingSound;
	[SerializeField] private AudioSource UnitingSound;

	public void PlayDropingSound()
	{
		DropingSound.Play();
	}

	public void PlayUnitingSound()
	{
		UnitingSound.Play();
	}
}
