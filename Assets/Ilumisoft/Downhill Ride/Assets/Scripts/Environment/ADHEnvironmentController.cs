using UnityEngine;

namespace ADH.Game
{
    public class ADHEnvironmentController : MonoBehaviour
    {
        [SerializeField]
        private Transform player = null;

        private Vector3 _ADHoffset;

        private Vector3 _ADHposition;

        private void Start()
        {
            _ADHposition = transform.position;
            _ADHoffset = player.position - _ADHposition;

        }

        private void Update()
        {
            _ADHposition.z = (player.position - _ADHoffset).z;

            transform.position = _ADHposition;
        }
    }
}