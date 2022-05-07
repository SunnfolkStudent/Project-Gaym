using Inputs;
using UnityEngine;
using UnityEngine.UI;

namespace System
{
    public class Endings : MonoBehaviour
    {
        private ChoiceManager _choiceManager;
        public Transition transition;
        private InputManager _inputManager;
        public int minScoreForEnding = 10;
        public Image endingImage;
        public Sprite goodEndingBg;
        public Sprite badEndingBg;
        

        private void Start()
        {
            _choiceManager = GetComponent<ChoiceManager>();
            _inputManager = GetComponent<InputManager>();
            DetermineEnding();
        }

        private void Update()
        {
            if (_inputManager.interact) endingImage.transform.SetSiblingIndex(2);
        }

        private void DetermineEnding()
        {
            endingImage.transform.SetSiblingIndex(4);
            print(_choiceManager.relationScore);
            endingImage.sprite = _choiceManager.relationScore > minScoreForEnding ? goodEndingBg : badEndingBg;
        }
    }
}