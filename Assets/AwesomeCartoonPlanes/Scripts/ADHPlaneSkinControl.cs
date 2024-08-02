using System.Collections.Generic;
using UnityEngine;

namespace ADH
{
	public class ADHPlaneSkinControl : MonoBehaviour
	{
		[SerializeField] private MeshRenderer ADHMR;
		public GameObject prop;
		public GameObject propBlured;

		[SerializeField] private List<Material> ADHSkins;

		public bool engenOn;

		private void Start()
		{
			if (ADHMR == null)
				return;
			
			ADHMR.material = ADHSkins[PlayerPrefs.GetInt("ADHSkinID", 0)];
		}

		void Update () 
		{
			if (engenOn) {
				prop.SetActive (false);
				propBlured.SetActive (true);
				propBlured.transform.Rotate (1000 * Time.deltaTime, 0, 0);
			} else {
				prop.SetActive (true);
				propBlured.SetActive (false);
			}
		}
	}
}



