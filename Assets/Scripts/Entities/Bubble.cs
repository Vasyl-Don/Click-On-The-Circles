using System;
using Enums;
using ScriptableObjects;
using UnityEngine;
using DG.Tweening;
using EventProcessors;

namespace Entities
{
    [RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
    public class Bubble : MonoBehaviour
    {
        private SpriteRenderer _spriteRenderer;
        private Sprite _sprite;
        private int _pointsValue;
        
        private const float AppearAnimationTime = 1f;
        private const float DisappearAnimationTime = 0.1f;

        private ProgressScriptableObject _progress;
        private const string ProgressScriptableObjectPath = "Scriptables/Progress Info";

        private AudioEventProcessor _audioEventProcessor;

        public void Awake()
        {
            _progress = Resources.Load<ProgressScriptableObject>(ProgressScriptableObjectPath);
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _audioEventProcessor = FindObjectOfType<AudioEventProcessor>();
        }

        public void Initialize(Sprite sprite, int pointsValue)
        {
            _pointsValue = pointsValue;

            _sprite = sprite;
            _spriteRenderer.sprite = _sprite;

            var desiredScale = transform.localScale;
            transform.localScale = Vector3.zero;
            transform.DOScale(desiredScale, AppearAnimationTime).SetEase(Ease.InOutSine);
        }

        private void OnMouseDown()
        {
            PopBubble();
        }

        public void PopBubble(bool addScore = true)
        {
            if (addScore)
                _progress.UpdateScore(_pointsValue);

            _audioEventProcessor.PlaySound(SoundType.BubblePop);
            transform.DOScale(0, DisappearAnimationTime)
                .SetEase(Ease.InOutSine)
                .OnComplete(() => Destroy(gameObject));
        }
    }
}