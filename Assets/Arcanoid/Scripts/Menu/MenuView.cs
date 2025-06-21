using System.Collections.Generic;
using DG.Tweening;
using strange.extensions.mediation.impl;
using UnityEngine;
using UnityEngine.UI;

namespace Arcanoid.Scripts.Menu
{
    public class MenuView : View
    {
        [Header("Clouds Anim")]
        [SerializeField] private List<RectTransform> clouds;
        [SerializeField] private float cloudsMoveSpeed;
        
        [Header("Leaf Anim")]
        [SerializeField] private List<RectTransform> leafs;
        [SerializeField] private float leafMoveSpeed;
        [SerializeField] private float leafPower;
        
        [Header("CandyPop")]
        [SerializeField] private RectTransform candyPop;
        [SerializeField] private float candyPopSpeed;
        [SerializeField] private float candyPopYScale;
        
        [Header("Rays")]
        [SerializeField] private RectTransform rays;
        [SerializeField] private float raysSpeed;
        
        [Header("Rock")]
        [SerializeField] private RectTransform rock;
        [SerializeField] private float rockSpeed;
        
        public Button startButton;

        private List<Sequence> _leafSequences = new List<Sequence>();
        private Sequence _candyPopSequence;
        private Sequence _raysSequence;
        private Sequence _rockSequence;

        protected override void Start()
        {
            foreach (var cloud in clouds)
            {
                AnimateCloud(cloud);
            }

            foreach (var leaf in leafs)
            {
                float randomSpeed = leafMoveSpeed * Random.Range(0.8f, 1.2f);
                float randomPower = leafPower * Random.Range(0.8f, 1.2f);
                float randomDelay = Random.Range(0f, randomSpeed);

                var seq = DOTween.Sequence();
                seq.PrependInterval(randomDelay);

                seq.Append(leaf.DORotate(new Vector3(0, 0, randomPower), randomSpeed / 2).SetEase(Ease.InOutSine));
                seq.Join(leaf.DOScale(1f + randomPower * 0.01f, randomSpeed / 2).SetEase(Ease.InOutSine));

                seq.Append(leaf.DORotate(new Vector3(0, 0, -randomPower), randomSpeed / 2).SetEase(Ease.InOutSine));
                seq.Join(leaf.DOScale(1f - randomPower * 0.01f, randomSpeed / 2).SetEase(Ease.InOutSine));

                seq.Append(leaf.DORotate(Vector3.zero, randomSpeed / 2).SetEase(Ease.InOutSine));
                seq.Join(leaf.DOScale(1f, randomSpeed / 2).SetEase(Ease.InOutSine));

                seq.SetLoops(-1, LoopType.Restart);
                _leafSequences.Add(seq);
            }
            
            _candyPopSequence = DOTween.Sequence();
            _candyPopSequence.Append(candyPop.DOScaleY(candyPopYScale, candyPopSpeed).From(1f).SetEase(Ease.InOutSine));
            _candyPopSequence.SetLoops(-1, LoopType.Yoyo);
            
            _raysSequence = DOTween.Sequence();
            _raysSequence.Append(rays.DOLocalRotate(new Vector3(0, 0, 360), raysSpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear));
            _raysSequence.SetLoops(-1, LoopType.Incremental);
            
            _rockSequence = DOTween.Sequence();
            _rockSequence.Append(rock.DOLocalRotate(new Vector3(0, 0, -360), rockSpeed, RotateMode.FastBeyond360).SetEase(Ease.Linear));
            _rockSequence.SetLoops(-1, LoopType.Incremental);
        }

        private void AnimateCloud(RectTransform cloud)
        {
            float startX = cloud.anchoredPosition.x;
            float endX = 1000f; // конечная координата вправо — можно сделать поле или параметр

            float distance = endX - startX;
            if (distance <= 0) distance = 0.1f; // чтобы не было деления на 0

            float duration = distance / cloudsMoveSpeed;

            cloud.DOAnchorPosX(endX, duration).SetEase(Ease.Linear).OnComplete(() =>
            {
                cloud.anchoredPosition = new Vector2(-endX, cloud.anchoredPosition.y);

                AnimateCloud(cloud);
            });
        }


        protected override void OnDestroy()
        {
            startButton.onClick.RemoveAllListeners();

            clouds.ForEach(cloud => cloud.DOKill());
            
            foreach (var seq in _leafSequences)
                seq.Kill();

            _candyPopSequence?.Kill();
            _raysSequence?.Kill();
            _rockSequence?.Kill();
        }
    }
}
