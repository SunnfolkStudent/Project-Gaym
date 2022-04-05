using Inputs;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(InputManager))]
public class ChoiceManager : MonoBehaviour
{
    public int relationScore;
    [SerializeField] [Range(0,100)] private int critChancePercentage = 20;
    private InputManager _inputManager;


    private void Start()
    {
        _inputManager = GetComponent<InputManager>();
    }

    private void Update()
    {
        if (_inputManager.pause)
        {
            ChangeScore(1);
        }
    }

    public void ChangeScore(int change)
    {
        var critValue = Random.Range(0, 99);
        if (critValue < critChancePercentage)
        {
            relationScore += change * 2;
            print("crit");
        }
        else
        {
            print("normal");
            relationScore += change;
        }
    }
    
}