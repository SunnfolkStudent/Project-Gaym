using System.Collections;
using UnityEngine;

namespace Cutscene
{
    public class Mover : MonoBehaviour
    {
        private bool _stop;
        public float heroSpeed = 5f;
        public float cameraSpeed = 4f;
        public float laughDelay = 0.5f;
        public float dialogueDelay = 1f;
        public GameObject hero;
        public GameObject cameraObject;
        private Animations _animations;
        private bool _drawSwordOnce;
        private bool _stopOnce;
        private bool _walkOnce;
        private SpriteRenderer _heroSpriteRenderer;
        public Sprite heroStandingSprite;
        public bool startCutscene;
        public GameObject[] TextBubbles;


        private void Start()
        {
            _animations = GetComponent<Animations>();
            _heroSpriteRenderer = hero.GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            if (!startCutscene) return;
            if (!_walkOnce)
            {
                _walkOnce = true;
                _animations.HeroWalk();
            }
            if (hero.transform.position.y < 20)
            {
                hero.transform.Translate(Vector3.up * (heroSpeed * Time.deltaTime));
            }
            else if(!_stopOnce)
            {
                _stopOnce = true;
                _animations.HeroStop();
                _heroSpriteRenderer.sprite = heroStandingSprite;
            }

            if (cameraObject.transform.position.y < 22)
            {
                cameraObject.transform.Translate(Vector3.up * (cameraSpeed * Time.deltaTime));
            }
            else if (!_drawSwordOnce)
            {
                _drawSwordOnce = true;
                _animations.HeroDrawSword();
                StartCoroutine(RestOfScene());
            }
        }

        private IEnumerator RestOfScene()
        {
            foreach (var textBubble in TextBubbles)
            {
                yield return new WaitForSeconds(dialogueDelay);
                textBubble.SetActive(true);
            }
            yield return new WaitForSeconds(laughDelay);
            _animations.BossLaugh();
        }
    }
}