using System.Collections.Generic;
using System.IO.Compression;
using UnityEngine;
using UnityEngine.UI;

public class AimAndLaunch : MonoBehaviour
{
    [HideInInspector] public enum PlayerState{
        Idle, SelectingPower, Launching
    }


    [HideInInspector] public Vector3 Direction;
    [HideInInspector] public Vector3 AimPoint;
    [HideInInspector] public float ActualPower;
    [HideInInspector] public float CoefPower;
    [HideInInspector] public GameObject ProjectileSelected;
    [HideInInspector] public Dictionary<PlayerState,IPlayerState> PlayerStateDic = new();

    public WeaponManager weaponManager;
    public List<GameObject> ProjectilesPrefab = new List<GameObject>();
    public GameObject JaugePower;
    public Image JaugeVariablePower;
    public float SpeedIncrease;
    public Vector2 LaunchPowerLimits;
    public float DistanceForLethal;
    public Transform ObjectPosition;


    private IPlayerState _currentState;


    void Start()
    {
        _initStates();
        ChangeState(PlayerState.Idle);

        _init();
    }

    void Update()
    {
        if(_currentState != null)
            _currentState.UpdateState(this);
    }


    

    private void _init(){
        ProjectileSelected = weaponManager.RandomizeWeapon();
    }

    private void _initStates(){
        PlayerStateDic.Add(PlayerState.Idle, new IdlePlayerState());
        PlayerStateDic.Add(PlayerState.SelectingPower, new SelectingPowerState());
        PlayerStateDic.Add(PlayerState.Launching, new LaunchingState());
    }

    public void ChangeState(PlayerState newState){
        if(_currentState != null)
            _currentState.OnExit(this);
        _currentState = PlayerStateDic[newState];
        _currentState.OnEnter(this);
    }

    public void Launch(){
        GetComponent<AudioSource>().Play();
        GameObject projectile = Instantiate(ProjectileSelected, ObjectPosition.position, Quaternion.identity);
        projectile.GetComponent<BulletLife>().DistanceForLethal = DistanceForLethal;
        float launchPower = LaunchPowerLimits.x+((LaunchPowerLimits.y-LaunchPowerLimits.x)*CoefPower);
        projectile.GetComponent<Rigidbody>().AddForce(Direction.normalized*launchPower, ForceMode.Impulse);
        ProjectileSelected = weaponManager.RandomizeWeapon();
    }

    public void DoneLaunching(){
        ChangeState(PlayerState.Idle);
    }

    public interface IPlayerState{
        public void OnEnter(AimAndLaunch state);
        public void UpdateState(AimAndLaunch state);
        public void OnExit(AimAndLaunch state);
        
    }
}
