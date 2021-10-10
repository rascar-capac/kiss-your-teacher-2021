using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RasPacJam.Audio
{
    public class ButtonAudioPlayer : MonoBehaviour
    {
        [SerializeField] private string soundName = null;
        [SerializeField] private float delay = 0f;

        public void PlaySound()
        {
            AudioManager.Instance.Play(soundName, delay);
        }
    }
}
