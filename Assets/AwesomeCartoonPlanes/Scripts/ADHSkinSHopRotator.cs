using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ADH
{
    public class ADHSkinSHopRotator : MonoBehaviour
    {
        [SerializeField] private MeshRenderer ADHMR;
        
        [SerializeField] private Button ADHLeft;
        [SerializeField] private Button ADHRight;
        
        [SerializeField] private List<Material> ADHSkins;
        [SerializeField] private List<int> ADHSkinsPrice;

        [SerializeField] private Button ADHBuyBtn;
        [SerializeField] private Text ADHBuyText;

        [SerializeField] private Color32 ADHBuyCol;
        [SerializeField] private Color32 ADHSelectCol;

        [SerializeField] private Text ADHWallet;

        private int ADHCurSkin;
        
        private void Start()
        {
            var adhCoins = PlayerPrefs.GetInt("ADHCoins", 0);
            ADHWallet.text = $"Coins: {adhCoins}";
            
            PlayerPrefs.SetString("ADHSkinIDPur 0", "pur");
            
            ADHCurSkin = PlayerPrefs.GetInt("ADHSkinID", 0);

            ADHUpdateButton();

            ADHLeft.onClick.AddListener(ADHLeftClick);
            ADHRight.onClick.AddListener(ADHRightClick);
            
            ADHBuyBtn.onClick.AddListener(ADHBuyClick);
        }

        private void ADHBuyClick()
        {
            if (PlayerPrefs.HasKey($"ADHSkinIDPur {ADHCurSkin}"))
            {
                PlayerPrefs.SetInt("ADHSkinID", ADHCurSkin);
                
                ADHBuyBtn.image.color = ADHSelectCol;
                ADHBuyBtn.interactable = false;
                ADHBuyText.text = "Selected";
            }
            else
            {
                var adhCoins = PlayerPrefs.GetInt("ADHCoins", 0);

                if (adhCoins < ADHSkinsPrice[ADHCurSkin])
                    return;
                
                adhCoins -= ADHSkinsPrice[ADHCurSkin];
                PlayerPrefs.SetInt("ADHCoins",adhCoins);
                ADHWallet.text = $"Coins: {adhCoins}";
                
                
                PlayerPrefs.SetString($"ADHSkinIDPur {ADHCurSkin}", "pur");

                ADHUpdateButton();
            }
        }

        private void ADHUpdateButton()
        {
            ADHMR.material = ADHSkins[ADHCurSkin];
            
            ADHRight.interactable = ADHCurSkin < ADHSkins.Count - 1;
            ADHLeft.interactable = ADHCurSkin != 0;

            if (PlayerPrefs.GetInt("ADHSkinID", 0) == ADHCurSkin)
            {
                ADHBuyBtn.image.color = ADHSelectCol;
                ADHBuyBtn.interactable = false;
                ADHBuyText.text = "Selected";
                
                return;
            }
            
            if (PlayerPrefs.HasKey($"ADHSkinIDPur {ADHCurSkin}"))
            {
                ADHBuyBtn.image.color = ADHSelectCol;
                ADHBuyBtn.interactable = true;
                ADHBuyText.text = "Select";
            }
            else
            {
                ADHBuyBtn.image.color = ADHBuyCol;
                ADHBuyBtn.interactable = true;
                ADHBuyText.text = $"Buy {ADHSkinsPrice[ADHCurSkin]}";
                
            }
        }

        private void ADHRightClick()
        {
            ADHCurSkin++;
            
            if (ADHCurSkin >= ADHSkins.Count)
                ADHCurSkin = ADHSkins.Count - 1;

            ADHUpdateButton();
        }

        private void ADHLeftClick()
        {
            ADHCurSkin--;
            
            if (ADHCurSkin < 0)
                ADHCurSkin = 0;
            
            ADHUpdateButton();
        }

        private void Update()
        {
            transform.Rotate(Vector3.forward, 15f * Time.deltaTime);
        }
    }
}