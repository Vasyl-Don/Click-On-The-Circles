using System.Collections.Generic;
using System.Linq;
using Entities;
using UnityEngine;

namespace Services
{
    public class BubbleSpawner
    {
        private const string PrefabPath = "Prefabs/Bubble";
        private readonly GameObject _bubblePrefab;
        private readonly List<Sprite> _sprites;

        public BubbleSpawner()
        {
            _bubblePrefab = Resources.Load<GameObject>(PrefabPath);
            _sprites = Resources.LoadAll<Sprite>("Sprites/Bubbles").ToList();
        }

        public void SpawnRandomBubble()
        {
            var index = Random.Range(0, _sprites.Count);
            var sprite = _sprites[index];
            
            var bottomLeft = Camera.main.ViewportToWorldPoint(new Vector3(0.1f, 0.1f, 0));
            var topRight = Camera.main.ViewportToWorldPoint(new Vector3(0.9f, 0.7f, 0));
            var position = new Vector3(Random.Range(bottomLeft.x, topRight.x), Random.Range(bottomLeft.y, topRight.y), 0);
            
            var scale = Random.Range(0.5f, 1.5f);
            
            var pointsValue = index * 10 + Mathf.RoundToInt(1/scale * 10);

            var bubble = Object.Instantiate(_bubblePrefab, position, Quaternion.identity);
            bubble.transform.localScale = new Vector3(scale, scale, 1);
            bubble.GetComponent<Bubble>().Initialize(sprite, pointsValue);
        }
    }
}