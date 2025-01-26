using UnityEngine;

public class LaunchingState : AimAndLaunch.IPlayerState
{
    public void OnEnter(AimAndLaunch controller){
        controller.GetComponent<Animator>().SetTrigger("Launching");
    }

    public void UpdateState(AimAndLaunch controller){

    }

    public void OnExit(AimAndLaunch controller){

    }
}
