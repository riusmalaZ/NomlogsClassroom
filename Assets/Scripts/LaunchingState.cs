using UnityEngine;

public class LaunchingState : AimAndLaunch.IPlayerState
{
    public void OnEnter(AimAndLaunch controller){
        controller.Launch();
    }

    public void UpdateState(AimAndLaunch controller){

    }

    public void OnExit(AimAndLaunch controller){

    }
}
