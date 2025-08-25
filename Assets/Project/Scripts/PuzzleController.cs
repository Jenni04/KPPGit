using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditorInternal;
using UnityEngine.UI;

public class PuzzleController : MonoBehaviour
{
public static PuzzleController instance;
[SerializeField] private Puzzle[] puzzles;

[SerializeField] private GameObject puzzlePanel; 
[SerializeField] private Text questionText;
[SerializeField] private Button answer1Button; 
[SerializeField] private Button answer2Button; 
[SerializeField] private Button answer3Button; 
[SerializeField] private Text answer1Text; 
[SerializeField] private Text answer2Text; 
[SerializeField] private Text answer3Text;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void HandlePuzzle(int _puzzleID)
    {

    PlayerController.instance.MyCanMove = false;

    PlayerController.instance.MyAnim.SetFloat("Speed", 0);
    PlayerController.instance.MyAnim.SetBool("Grounded", true);

    puzzlePanel.SetActive(true);

    switch (_puzzleID){
    case 1:
  ShowProblem1();
    break;

            case 2:
                ShowProblem2();
                break;

            default:
    break;
    }}

    public void ShowProblem1()
{
questionText.text = "4 - 0 = _";

answer1Button.name = "1";
answer1Text.text = "4";

answer2Button.name = "Wrong";
answer2Text.text = "3";

answer3Button.name = "Wrong";
answer3Text.text = "8";}


    public void ShowProblem2()
    {
        questionText.text = "4 - 3 = _";

        answer1Button.name = "Wrong";
        answer1Text.text = "2";

        answer2Button.name = "1";
        answer2Text.text = "1";

        answer3Button.name = "Wrong";
        answer3Text.text = "4";
    }


    public void HandleCorrectAnswer(Button button){

switch (button.name){

case "1":
StartCoroutine(CheckAnswerCO(1));
break;

case "2":
StartCoroutine(CheckAnswerCO(2));
break;

default:
StartCoroutine(CheckAnswerCO(0));
break;

}

}

private IEnumerator CheckAnswerCO (int _puzzleID){
   
if (_puzzleID == 0){
    questionText.text = "Väärin";
}
else
{
questionText.text = "Oikein";
puzzles[_puzzleID].HandleAnimations(_puzzleID);
}

yield return new WaitForSeconds (2f);
puzzlePanel.SetActive(false);
PlayerController.instance.MyCanMove = true;

}

}
