using UnityEngine;

namespace ADH.Game
{
    public class ADHCameraController : MonoBehaviour
    {
        [SerializeField]
        private Transform target = null;

        private Vector3 _ADHoffset;

        private Vector3 _ADHposition;

        private void Start()
        {
            _ADHposition = transform.position;
            _ADHoffset = target.position - _ADHposition;
        }

        private void LateUpdate()
        {
            _ADHposition.z = (target.position - _ADHoffset).z;
            transform.position = _ADHposition;
        }
    }
}