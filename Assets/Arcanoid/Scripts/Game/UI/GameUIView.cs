using System.Collections.Generic;
using DG.Tweening;
using strange.extensions.mediation.impl;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
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

        [Header("Animations")] 
        
        [Space]
        
        [Header("CandyPop")] 
        [SerializeField] private float candyPopYScale;
        [SerializeField] private float candyPopSpeed;
        
        [Header("CandyRay")]
        [SerializeField] private RectTransform candyRay;
        [SerializeField] private float candyRaySpeed;
        
        public Button restartButton;
        public Button menuButton;
        
        private Sequence _candyPopSequence;
        private Sequence _raysSequence;

        
        protected override void Start()
        {
            _candyPopSequence = DOTween.Sequence();
            _candyPopSequence.Append(engGameEmojy.rectTransform.DOScaleY(candyPopYScale, candyPopSpeed).From(1f).SetEase(Ease.InOutSine));
            _candyPopSequence.SetLoops(-1, LoopType.Yoyo);
            
            _raysSequence = DOTween.Sequence();
            _raysSequence.Append(candyRay.DOLocalRotate(new Vector3(0, 0, 360), candyRaySpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear));
            _raysSequence.SetLoops(-1, LoopType.Incremental);
            
        }

        protected override void OnDestroy()
        {
            restartButton.onClick.RemoveAllListeners();
            menuButton.onClick.RemoveAllListeners();
            
            _raysSequence.Kill();
            _candyPopSequence.Kill();
        }
        
        public void ShowGameOverPanel(bool isWin, int score)
        {
            gameOverPanel.transform.DOScale(Vector3.one, .5f);
            
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