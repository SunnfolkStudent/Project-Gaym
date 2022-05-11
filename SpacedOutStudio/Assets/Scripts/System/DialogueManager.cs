using System.Collections;
using Inputs;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace System
{
    [RequireComponent(typeof(SaveManager))]
    [RequireComponent(typeof(ExpressionsEmotesAndMovements))]
    [RequireComponent(typeof(ChoiceManager))]
    [RequireComponent(typeof(SceneController))]
    [RequireComponent(typeof(InputManager))]
    public class DialogueManager : MonoBehaviour
    {
        public string dialogueChoicesChar = "/c";
        public string responseOneChar = "/c1";
        public string responseTwoChar = "/c2";
        public string responseThreeChar = "/c3";
        public string returnChar = "/r";
        public string goodRlvlChar = "/gr";
        public string badRlvlChar = "/br";

        public string goodOrBadCheckChar = "/lvl";

        //public string goodOrBadCheckReturn = "/rr";
        public bool debug;
        public int debugDialogue;
        public int debugChoice;

        public string[] script;

        public string sceneToLoad;

        //public GameObject dialogueGameObject;
        public GameObject logGameObject;
        public TMP_Text dialogueText;
        public TMP_Text namePlate;
        public string replaceString;
        public string playerName;
        private InputManager _inputManager;
        [HideInInspector] public int currentDialogue;
        private TMP_Text _logText;
        [HideInInspector] public string[] names;
        private SceneController _sceneController;

        public float textSpeed = 1;
        
        public int rScoreMinP;
        private bool _generatingDialogue;
        private bool _stopGeneratingDialogue;
        private bool[] _choiceDialogues;
        private bool[] _choiceDialogues1;
        private bool[] _choiceDialogues2;
        private bool[] _choiceDialogues3;
        private bool[] _returnDialogues;
        private bool[] _goodorbadCheck;
        private bool[] _goodRlvlDialogues;
        private bool[] _badRlvlDialogues;
        
        
        private ChoiceManager _choiceManager;
        private bool _inChoices1;
        private bool _inChoices2;
        private bool _inChoices3;
        private bool _inGoodR;
        private bool _inBadR;

        public bool loadFinalScene;
        
        private int _currentScoreCheck;
        private ExpressionsEmotesAndMovements _expressionsEmotesAndMovements;
        private bool _skipOne;
        private Movements _movements;
        private bool _hovering;

        private void Start()
        {
            _movements = GetComponent<Movements>();
            _expressionsEmotesAndMovements = GetComponent<ExpressionsEmotesAndMovements>();
            _choiceManager = GetComponent<ChoiceManager>();
            _sceneController = GetComponent<SceneController>();
            _logText = logGameObject.GetComponentInChildren<TMP_Text>();
            _inputManager = GetComponent<InputManager>();
            _choiceManager.relationScore = PlayerPrefs.GetInt("relScore");
            playerName = PlayerPrefs.GetString("pName");
            Save();
            ExtractAndReplaceNames();
            dialogueText.text = "";
            namePlate.text = names[currentDialogue];
        }

        private void Update()
        {
            if (_inputManager.interact)
            {
                //TODO ask eren how to do the skip
                if (_movements.moving)
                {
                    _movements.stopMoving = true;
                }

                if (!_generatingDialogue)
                {
                    NextDialogue();
                }
                else
                {
                    _stopGeneratingDialogue = true;
                }
            }

            if (_inputManager.log)
            {
                Log();
            }
        }

        public void NextDialogue()
        {
            if (logGameObject.activeSelf || _choiceManager.showingDialogue || _hovering || PauseScript.GameIsPaused) return;
            SaveManager.SaveName(playerName);

            if (currentDialogue < script.Length - 1)
            {
                currentDialogue++;
            }
            else
            {
                _sceneController.LoadWithTransition();
                return;
            }

            if (_inChoices1)
            {
                if (!_choiceDialogues1[currentDialogue])
                {
                    _inChoices1 = false;
                    _inGoodR = false;
                    _inBadR = false;
                    GotoCorrectDialogue(_choiceManager.currentChoices, _returnDialogues);
                    return;
                }
            }
            else if (_inChoices2)
            {
                if (!_choiceDialogues2[currentDialogue])
                {
                    _inChoices2 = false;
                    _inGoodR = false;
                    _inBadR = false;
                    GotoCorrectDialogue(_choiceManager.currentChoices, _returnDialogues);
                    return;
                }
            }
            else if (_inChoices3)
            {
                if (!_choiceDialogues3[currentDialogue])
                {
                    _inChoices3 = false;
                    _inGoodR = false;
                    _inBadR = false;
                    GotoCorrectDialogue(_choiceManager.currentChoices, _returnDialogues);
                    return;
                }
            }

            if (_inGoodR)
            {
                if (!_goodRlvlDialogues[currentDialogue])
                {
                    _inGoodR = false;
                    _inChoices1 = false;
                    _inChoices2 = false;
                    _inChoices3 = false;
                    GotoCorrectDialogue(_choiceManager.currentChoices, _returnDialogues);
                    return;
                }
            }
            else if (_inBadR)
            {
                if (!_badRlvlDialogues[currentDialogue])
                {
                    _inBadR = false;
                    _inChoices1 = false;
                    _inChoices2 = false;
                    _inChoices3 = false;
                    GotoCorrectDialogue(_choiceManager.currentChoices, _returnDialogues);
                    return;
                }
            }

            if (_choiceDialogues[currentDialogue])
            {
                _choiceManager.DialogueOptionsShow();
            }
            else if (_goodorbadCheck[currentDialogue])
            {
                _currentScoreCheck++;
                if (_choiceManager.relationScore >= rScoreMinP)
                {
                    _inGoodR = true;
                    print("positive");
                    GotoCorrectDialogue(_currentScoreCheck, _goodRlvlDialogues);
                }
                else
                {
                    _inBadR = true;
                    print("negative");
                    GotoCorrectDialogue(_currentScoreCheck, _badRlvlDialogues);
                }
            }
            else
            {
                if (debug)
                {
                    currentDialogue = debugDialogue;
                    _choiceManager.currentChoices = debugChoice;
                    
                    debug = false;
                    
                }

                StartCoroutine(GradualText());
            }
        }


        public IEnumerator GradualText()
        {
            _generatingDialogue = true;
            _logText.text += names[currentDialogue] + ": " + script[currentDialogue] + "\n";
            namePlate.text = names[currentDialogue];
            dialogueText.text = "";
            _expressionsEmotesAndMovements.UpdateSprite();
            var charArray = script[currentDialogue].ToCharArray();
            for (var i = 0; i < charArray.Length; i++)
            {
                if (_stopGeneratingDialogue) break;
                yield return new WaitForSeconds(textSpeed / 100);
                dialogueText.text = dialogueText.text.Insert(i, charArray[i].ToString());
            }

            if (_stopGeneratingDialogue)
            {
                dialogueText.text = script[currentDialogue];
                _stopGeneratingDialogue = false;
            }

            _generatingDialogue = false;
        }


        public void Log()
        {
            logGameObject.SetActive(!logGameObject.activeSelf);
        }


        private void ExtractAndReplaceNames()
        {
            names = new string[script.Length];
            _choiceDialogues = new bool[script.Length];
            _choiceDialogues1 = new bool[script.Length];
            _choiceDialogues2 = new bool[script.Length];
            _choiceDialogues3 = new bool[script.Length];
            _returnDialogues = new bool[script.Length];
            _goodorbadCheck = new bool[script.Length];
            _goodRlvlDialogues = new bool[script.Length];
            _badRlvlDialogues = new bool[script.Length];
            for (var i = 0; i < script.Length; i++)
            {
                if (script[i].Contains(goodOrBadCheckChar))
                {
                    script[i] = script[i].Remove(script[i].IndexOf(goodOrBadCheckChar, StringComparison.Ordinal),
                        goodOrBadCheckChar.Length);
                    _goodorbadCheck[i] = true;
                }
                else if (script[i].Contains(goodRlvlChar))
                {
                    script[i] = script[i].Remove(script[i].IndexOf(goodRlvlChar, StringComparison.Ordinal),
                        goodRlvlChar.Length);
                    _goodRlvlDialogues[i] = true;
                }
                else if (script[i].Contains(badRlvlChar))
                {
                    script[i] = script[i].Remove(script[i].IndexOf(badRlvlChar, StringComparison.Ordinal),
                        badRlvlChar.Length);
                    _badRlvlDialogues[i] = true;
                }

                if (script[i] == dialogueChoicesChar)
                {
                    _choiceDialogues[i] = true;
                }
                else if (script[i].Contains(responseOneChar))
                {
                    script[i] = script[i].Remove(0, responseOneChar.Length);
                    _choiceDialogues1[i] = true;
                }
                else if (script[i].Contains(responseTwoChar))
                {
                    script[i] = script[i].Remove(0, responseTwoChar.Length);
                    _choiceDialogues2[i] = true;
                }
                else if (script[i].Contains(responseThreeChar))
                {
                    script[i] = script[i].Remove(0, responseThreeChar.Length);
                    _choiceDialogues3[i] = true;
                }
                else if (script[i].Contains(returnChar))
                {
                    script[i] = script[i].Remove(0, returnChar.Length);
                    _returnDialogues[i] = true;
                }

                /*if (script[i].StartsWith(" "))
                {
                    script[i] = script[i].Remove(0, 1);
                }*/
                script[i] = script[i].Replace(replaceString, playerName);
                names[i] = script[i].Split(":")[0];
                script[i] = script[i].Remove(0, script[i].IndexOf(":", StringComparison.Ordinal) + 2);
            }
        }

        public void PositiveChoice(int currentChoice)
        {
            _inChoices1 = true;
            _skipOne = true;
            GotoCorrectDialogue(currentChoice, _choiceDialogues1);
            CheckScore();
        }

        public void NeutralChoice(int currentChoice)
        {
            _inChoices2 = true;
            _skipOne = true;
            GotoCorrectDialogue(currentChoice, _choiceDialogues2);
            CheckScore();
        }

        public void NegativeChoice(int currentChoice)
        {
            _inChoices3 = true;
            if (_skipOne && loadFinalScene)
            {
                _currentScoreCheck++;
            }

            _skipOne = true;
            GotoCorrectDialogue(currentChoice, _choiceDialogues3);
            CheckScore();
        }

        public void GotoCorrectDialogue(int currentChoice, bool[] boolArray)
        {
            //TODO if skips all go to next scene
            var inStreak = false;
            var skipNumber = currentChoice;
            for (var i = 0; i < boolArray.Length; i++)
            {
                if (boolArray[i])
                {
                    if (!inStreak)
                    {
                        skipNumber--;
                    }

                    inStreak = true;
                    if (skipNumber > 0) continue;
                    currentDialogue = i;
                    StartCoroutine(GradualText());
                    return;
                }
                inStreak = false;
            }
            _sceneController.LoadWithTransition();
        }

        private void CheckScore()
        {
            if (!_goodorbadCheck[currentDialogue]) return;
            _currentScoreCheck++;
            if (_choiceManager.relationScore >= rScoreMinP)
            {
                _inGoodR = true;
                GotoCorrectDialogue(_currentScoreCheck, _goodRlvlDialogues);
            }
            else
            {
                _inBadR = true;
                GotoCorrectDialogue(_currentScoreCheck, _badRlvlDialogues);
            }
        }
        
        
        public void Save()
        {
            SaveManager.Save(_choiceManager.relationScore,playerName,SceneManager.GetActiveScene().buildIndex);
        }

        public void OnHover()
        {
            _hovering = true;
        }

        public void OnHoverExit()
        {
            _hovering = false;
        }
    }
}