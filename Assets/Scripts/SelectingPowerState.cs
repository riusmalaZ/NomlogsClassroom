using UnityEngine;

public class SelectingPowerState : AimAndLaunch.IPlayerState
{
    public void OnEnter(AimAndLaunch controller){
        controller.JaugePower.SetActive(true);
        controller.JaugeVariablePower.fillAmount = 0;
        controller.CoefPower = 0;
        controller.ActualPower = 0;
    }

    public void UpdateState(AimAndLaunch controller){
        _increasePower(controller);
    }

    public void OnExit(AimAndLaunch controller){
        controller.JaugePower.SetActive(false);
    }

    public void OnLaunch(AimAndLaunch controller){
        controller.ChangeState(AimAndLaunch.PlayerState.Launching);
    }



    

    private void _increasePower(AimAndLaunch controller){
        if(Input.GetMouseButton(0)){
            if(controller.CoefPower < 1){
                controller.ActualPower += controller.SpeedIncrease*Time.deltaTime;
                controller.CoefPower = controller.ActualPower/(controller.LaunchPowerLimits.y-controller.LaunchPowerLimits.x);
            }
            else
                controller.CoefPower = 1;
            controller.JaugeVariablePower.fillAmount = controller.CoefPower;
        } 
        if(Input.GetMouseButtonUp(0)){
            OnLaunch(controller);
        }

    }
}
