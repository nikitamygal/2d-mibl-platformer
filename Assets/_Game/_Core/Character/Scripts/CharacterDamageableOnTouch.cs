using UnityEngine;


namespace SoloGames.Characters
{
    public class CharacterDamageableOnTouch : CharacterAbility
    {
        protected float _attackDamage => _character.Settings.AttackDamage;

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == Tags.Shot) return;

            Health health = other.gameObject.GetComponent<Health>();
            health?.Damage(_attackDamage);
        }

    }
}
