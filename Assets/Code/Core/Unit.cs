using UnityEngine;


namespace RTS
{
    public class Unit : MonoBehaviour, ISelectable
    {
        [SerializeField] private Sprite _icon;

        private float _maxHealth = 1000;
        private float _health = 1000;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Sprite Icon => _icon;
        
    }
}