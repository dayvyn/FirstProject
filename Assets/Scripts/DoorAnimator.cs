using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    [SerializeField] DoorArea DoorArea;
    Animation doorAnim;
    void Start()
    {
        doorAnim = GetComponent<Animation>();
        DoorArea.playerEntered += ()=> doorAnim.Play("New Animation");
        DoorArea.playerExited += () => doorAnim.Play("DoorClose");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
