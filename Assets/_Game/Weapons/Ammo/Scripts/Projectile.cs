using SoloGames.Characters;
using UnityEngine;


namespace SoloGames.Damage
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed = 5f;

        [Header("Bindings")]
        [SerializeField] private Animator _animator;

        [Header("Sounds")]
        [SerializeField] private AudioClip _shotSound;
        [SerializeField] private AudioClip _explodeSound;

        private AudioSource _audioSource;
        private Character _owner = null;
        private bool _right = true;
        private bool _moving = true;
        private readonly string _explodeAnimParam = "Explode";

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _right = _owner?.FaceDirection == FacingDirections.East;
            _audioSource?.PlayOneShot(_shotSound);
        }

        public void SetOwner(Character character)
        {
            _owner = character;
        }

        private void Update()
        {
            if (_moving)
                transform.position += (_right ? transform.right : -1 * transform.right) * _speed * Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_moving && other.tag != Tags.Player && other.tag != Tags.Shot)
            {
                Health health = other.GetComponent<Health>();
                health?.Damage(_owner.Settings.AttackDamage);

                _moving = false;
                _audioSource?.PlayOneShot(_explodeSound);
                _animator?.SetTrigger(_explodeAnimParam);
                Destroy();
            }
        }

        private void Destroy()
        {
            Destroy(gameObject, 1f);
        }
    }
}