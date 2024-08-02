using ADH.Game;

namespace ADH.Audio.UI
{
    using ADH.Game;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Slider))]
    public class MusicSlider : MonoBehaviour
    {
        private IAudioManager _audioManager;

        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
            _audioManager = InterfaceUtilities.FindObjectOfType<IAudioManager>();
        }

        private void Start()
        {
            _slider.value = _audioManager.MusicVolume;

            _slider.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnValueChanged(float value)
        {
            _audioManager.MusicVolume = value;
        }
    }
}