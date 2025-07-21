using UnityEngine;


namespace SoloGames.Gameplay
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
        private bool _right = true;
        private bool _moving = true;
        private readonly string _exolodeAnimParam = "Explode";

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            _audioSource?.PlayOneShot(_shotSound);
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
                _moving = false;
                _audioSource?.PlayOneShot(_explodeSound);
                _animator?.SetTrigger(_exolodeAnimParam);
                Destroy();
            }
        }

        private void Destroy()
        {
            Destroy(gameObject, 1f);
        }
    }
}