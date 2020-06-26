using Photon.Pun;
using UnityEngine;

public class InstantiateExample : MonoBehaviourPun
{
    [SerializeField]
    private GameObject _prefab;
    private GameObject _player;
    [SerializeField]
    private float _animationspeed = 2.0f;
    private Animator _animator;


    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            _player = MasterManager.NetworkInstantiate(_prefab, new Vector3(-4,-2,0), Quaternion.identity);
            //PhotonNetwork.Instantiate("_prefab", new Vector3(-4, -2, 0), Quaternion.identity);
        }
        else
        {
            _player = MasterManager.NetworkInstantiate(_prefab, new Vector3(4, -2, 0), Quaternion.Euler(0,180,0));
        }
        _animator = _player.GetComponent<Animator>();
    }
    public void OnClick_WalkRight()
    {


        _player.transform.position += new Vector3(0.5f, 0f, 0f);
        _animator.speed = _animationspeed;
         _animator.Play("walkForw");
        


    }
    public void OnClick_WalkLeft()
    {


        _player.transform.position -= new Vector3(0.5f, 0f, 0f);
        _animator.speed = _animationspeed;
        _animator.Play("walkBack");


    }
    public void OnClick_Attack1()
    {


        _animator.speed = _animationspeed;
        _animator.Play("attack1");


    }
    public void OnClick_Attack2()
    {

        _animator.speed = _animationspeed;
        _animator.Play("attack2");


    }
    public void OnClick_Attack3()
    {


        _animator.speed = _animationspeed;
        _animator.Play("attack3");


    }

    private void UpdateAnimationBool(bool boolean, string animation)
    {
        _animator.speed = _animationspeed;
        _animator.SetBool(animation, boolean);
    }
}
