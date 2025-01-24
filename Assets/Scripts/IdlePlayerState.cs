using UnityEngine;

public class IdlePlayerState : AimAndLaunch.IPlayerState
{
    public void OnEnter(AimAndLaunch controller){
        controller.JaugePower.SetActive(false);
        controller.CoefPower = 0;
        controller.ActualPower = 0;
    }

    public void UpdateState(AimAndLaunch controller){
        _selectProjectile(controller);
        _aim(controller);
    }

    public void OnExit(AimAndLaunch controller){

    }

    public void OnAimed(AimAndLaunch controller){
        controller.ChangeState(AimAndLaunch.PlayerState.SelectingPower);
    }



    
    private void _selectProjectile(AimAndLaunch controller){
        if(Input.GetKeyUp(KeyCode.A))
            controller.ProjectileSelected = controller.ProjectilesPrefab[0];
        else if(Input.GetKeyUp(KeyCode.Z))
            controller.ProjectileSelected = controller.ProjectilesPrefab[1];
        else if(Input.GetKeyUp(KeyCode.E))
            controller.ProjectileSelected = controller.ProjectilesPrefab[2];
    }
    
    private void _aim(AimAndLaunch controller){
        Vector3 screenPos = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        RaycastHit hitInfo; 
        if (Physics.Raycast(ray, out hitInfo, Mathf.Infinity)){
            if(Input.GetMouseButton(0)){
                controller.AimPoint = hitInfo.point;
                controller.Direction = hitInfo.point-controller.transform.position;
                OnAimed(controller);
            }
        }
    }
}
