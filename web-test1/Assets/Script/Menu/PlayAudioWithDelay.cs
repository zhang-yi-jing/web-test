using UnityEngine;

public class PlayAudioWithDelay : MonoBehaviour
{
    public float delayInSeconds = 2.0f;

    private AudioSource audioSource;

    void Start()
    {
        // ��ȡͬһ�����ϵ� AudioSource ���
        audioSource = GetComponent<AudioSource>();

    }

    public void PlayAudioAfterDelay()
    {
        Invoke("PlayAudio", delayInSeconds);
    }

    private void PlayAudio()
    {
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}