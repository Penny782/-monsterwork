using System.Collections;
using System.Collections.Generic;

namespace DummyNamespace{  //強制進入
    using TMPro; //Unity有改版所以需要
    using Unity.VisualScripting;
    using UnityEngine;
    using UnityEngine.UI;

    public class CoinManager : MonoBehaviour
    {
        [Header("🔹 TextMeshPro UI 元件")]
        public TextMeshProUGUI coinTextMoneyUI;   // 顯示玩家總寶錢
        public Button coinManagerButton;          // CoinManager 按鈕（上面有顯示掛機錢數）
        public TextMeshProUGUI coinTextOnButton;  // 按鈕上顯示掛機金錢的文字

        [Header("🔹 金錢數值設定")]
        private int totalCoins = 0;              // 玩家已收集的總寶錢
        private float uncollectedCoins = 0f;     // 掛機累積中的寶錢
        public int coinsPerSecond = 5;           // 每秒掛機產生的寶錢

        // Start is called before the first frame update
        private void Start()
        {
            // 綁定按鈕事件
            coinManagerButton.onClick.AddListener(OnButtonClicked);

            // 初始更新顯示
            UpdateUI();
        }

        // Update is called once per frame
        // 🔵 每幀更新：模擬掛機自動產錢
        private void Update()
        {
            // 每秒自動增加掛機金錢
            uncollectedCoins += coinsPerSecond * Time.deltaTime;
            UpdateUI();
        }

        // 🟡 當按下收集按鈕
        private void OnButtonClicked()
        {
            totalCoins += Mathf.FloorToInt(uncollectedCoins);
            uncollectedCoins = 0f;
            UpdateUI();

            Debug.Log("目前總寶錢：" + totalCoins);
        }


        // Update is called once per frame
        // 🟣 更新畫面上兩個 TextMeshPro 顯示
        private void UpdateUI()
        {
            // 顯示總寶錢（上方 UI）
            coinTextMoneyUI.text = $"寶錢：{totalCoins:N0}";

            // 顯示掛機累積金錢（按鈕上）
            coinTextOnButton.text = $"+{uncollectedCoins:F1}";
        }

    }
}
