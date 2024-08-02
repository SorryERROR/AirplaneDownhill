using UnityEngine;

namespace ADH.Game
{
    public class ADHCoinModifier : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var adhPlayer = other.GetComponentInParent<ADHPlayer>();

            if (adhPlayer != null)
            {
                adhPlayer.ADHADDCoins();
                gameObject.SetActive(false);
            }
        }
    }
}