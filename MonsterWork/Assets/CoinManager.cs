using System.Collections;
using System.Collections.Generic;
namespace DummyNamespace{  //�j��i�J
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro; //Unity���睊�ҥH�ݭn

    public class CoinManager : MonoBehaviour
    {
        public TextMeshProUGUI coinText;//�睊�ݭn
        public Button collectButton;

        private int totalCoins = 0;
        //private int uncollectedCoins = 0;
        private float uncollectedCoins = 0f;
        private int coinsPerSecond = 5;

        // Start is called before the first frame update
        private void Start()
        {
            UpdateCoinText();

            collectButton.onClick.AddListener(OnCollectButtonClicked);
            //StartCoroutine(AutoAddCoins());
        }

        // Update is called once per frame
        private void Update()
        {
            uncollectedCoins += coinsPerSecond * Time.deltaTime;
        }
        /* private IEnumerator AutoAddCoins()
       {
           while (true)
           {
               yield return new WaitForSeconds(coinsPerSecond);
               uncollectedCoins += coinsPerSecond;
               //UpdateCoinText();
           }
       }*/
        private void OnCollectButtonClicked()
        {

            //totalCoins += uncollectedCoins;
            totalCoins += Mathf.FloorToInt(uncollectedCoins);
            uncollectedCoins = 0f;
            UpdateCoinText();

            Debug.Log("�ثe�`���B:" + totalCoins);

        }


        // Update is called once per frame
        private void UpdateCoinText()
        {
            //int displayAmount = totalCoins + uncollectedCoins;
            //coinText.text = "���B:" + displayAmount;
            coinText.text = "���B:" + totalCoins;
        }

    }
}
