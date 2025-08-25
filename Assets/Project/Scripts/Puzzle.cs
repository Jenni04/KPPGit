using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class Puzzle : MonoBehaviour
{

public UnityEvent OnPuzzle;
private Animator switchAnim;
[SerializeField]
private Animator gateAnim;

    // Start is called before the first frame update
    void Start()
    {
        switchAnim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision){

    if (collision.CompareTag("Player")){

    GetComponent<BoxCollider2D>().enabled = false;
    OnPuzzle?.Invoke();
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HandleAnimations(int _puzzleID){

    switch (_puzzleID){

    case 1:
    switchAnim.SetTrigger("SwitchLaserOn");
    gateAnim.SetTrigger("GateDown1");
                AudioManager.instance.Play("SwitchAnim");
                break;

            case 2:
                switchAnim.SetTrigger("SwitchLaserOn2");
                gateAnim.SetTrigger("GateDown1");
                AudioManager.instance.Play("SwitchAnim");
                break;

            default:
    break;
    }
    }
}
