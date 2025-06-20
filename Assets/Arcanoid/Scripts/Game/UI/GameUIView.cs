using System.Collections.Generic;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arcanoid.Scripts.Game.UI
{
    public class GameUIView : View
    {

        [Header("UI")] 
        [SerializeField] private TMP_Text mainScoreText;
        [SerializeField] private GameObject gameOverPanel;
        [SerializeField] private TMP_Text gameOverScoreText;
        
        [Header("GameStatus")]
        [SerializeField] private TMP_Text gameEndText;

        [SerializeField] private Image engGameEmojy;
        [SerializeField] private Sprite happyEmojy;
        [SerializeField] private Sprite sadEmojy;
        
        [Header("Stars")]
        [SerializeField] private List<Image> stars;
        [SerializeField] private Sprite starActive;
        [SerializeField] private Sprite starInactive;
        
        [Header("Buttons")]
        [SerializeField] private Button restartButton;
        [SerializeField] private Button menuButton;

        protected override void Start()
        {
            restartButton.onClick.AddListener(() =>
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
            });
            
            menuButton.onClick.AddListener(() =>
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene("Main");
            });
        }

        protected override void OnDestroy()
        {
            restartButton.onClick.RemoveAllListeners();
            menuButton.onClick.RemoveAllListeners();
        }
        
        public void ShowGameOverPanel(bool isWin, int score)
        {
            mainScoreText.gameObject.SetActive(false);
            gameOverPanel.SetActive(true);

            gameEndText.text = isWin ? "YOU WIN!" : "YOU LOSE!";
            engGameEmojy.sprite = isWin ? happyEmojy : sadEmojy;
            
            stars.ForEach(star => star.sprite = isWin ? starActive : starInactive);
            gameOverScoreText.text = score.ToString();
        }

        public void SetScore(int score)
        {
            mainScoreText.text = score.ToString();
        }

    }
}