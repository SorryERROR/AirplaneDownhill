using UnityEngine;
using UnityEngine.UI;

namespace ADH.Game
{
    public class ADHPlayer : MonoBehaviour
    {
        [SerializeField] private float verticalSpeed = 15.0f;
        [SerializeField] private float horizontalSpeed = 10.0f;

        [SerializeField] private Text ADHWAllet;
        
        private IHealthSystem _healthSystem;
        private IADHHorizontalInputProvider iadhHorizontalInputProvider;
        private Rigidbody _rigidbody;
        private EventManager _eventManager;

        private void Awake()
        {
            ADHWAllet.text = $"Coins: {PlayerPrefs.GetInt("ADHCoins", 0)}";
            
            _eventManager = FindObjectOfType<EventManager>();

            _rigidbody = GetComponent<Rigidbody>();

            _healthSystem = GetComponent<IHealthSystem>();

            iadhHorizontalInputProvider = new AdhIadhHorizontalInputProvider();
        }

        public void ADHADDCoins()
        {
            var adhCoins = PlayerPrefs.GetInt("ADHCoins", 0);
            adhCoins += 25;
            PlayerPrefs.SetInt("ADHCoins",adhCoins);
            ADHWAllet.text = $"Coins: {adhCoins}";
        }

        private void Start()
        {
            _rigidbody.velocity = new Vector3(0, 0, -verticalSpeed);

            if (_healthSystem != null)
            {
                _healthSystem.OnHealthEmpty.AddListener(Die);
            }
        }

        private void FixedUpdate()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            var horizontalInput = iadhHorizontalInputProvider.GetHorizontalInput();

            var movement = new Vector3(horizontalInput, 0, 0);

            _rigidbody.AddForce(movement * horizontalSpeed);
            
            var targetTiltAngle = -horizontalInput * 35f;
            
            targetTiltAngle = Mathf.Clamp(targetTiltAngle, -35f, 35f);

            var targetRotation = Quaternion.Euler(0f, 0f, targetTiltAngle);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10f * Time.deltaTime);
        }

        private void Die()
        {
            //Invoke Game Over
            _eventManager.GetEvent<GameOverEvent>().Invoke();
        }
    }
}