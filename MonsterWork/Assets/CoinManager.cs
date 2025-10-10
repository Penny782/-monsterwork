using System.Collections;
using System.Collections.Generic;
namespace DummyNamespace{  //強制進入
    using UnityEngine;
    using UnityEngine.UI;
    using TMPro; //Unity有改版所以需要

    public class CoinManager : MonoBehaviour
    {
        public TextMeshProUGUI coinText;//改版需要
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

            Debug.Log("目前總金額:" + totalCoins);

        }


        // Update is called once per frame
        private void UpdateCoinText()
        {
            //int displayAmount = totalCoins + uncollectedCoins;
            //coinText.text = "金額:" + displayAmount;
            coinText.text = "金額:" + totalCoins;
        }

    }
}
