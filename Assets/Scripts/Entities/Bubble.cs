using ScriptableObjects;
using UnityEngine;

namespace Entities
{
    [RequireComponent(typeof(SpriteRenderer), typeof(CircleCollider2D))]
    public class Bubble : MonoBehaviour
    {
        [SerializeField] private ProgressScriptableObject _progress;
    
        private Sprite _sprite;
        private SpriteRenderer _spriteRenderer;
        public int _pointsValue;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Initialize(Sprite sprite, int pointsValue)
        {
            _pointsValue = pointsValue;
            _sprite = sprite;
            _spriteRenderer.sprite = _sprite;
        }

        private void OnMouseDown()
        {
            _progress.UpdateScore(_pointsValue);
            Destroy(gameObject);
            // play sound
            // play animation
        }
        
        public void PopBubble()
        {
            Destroy(gameObject);
            // play sound
            // play animation
        }
    }
}