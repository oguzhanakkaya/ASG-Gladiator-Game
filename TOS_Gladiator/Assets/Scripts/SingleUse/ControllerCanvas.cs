using Photon.Pun;
using UnityEngine;

public class ControllerCanvas : MonoBehaviourPun
{
    [SerializeField]
    private float _animationspeed = 2.0f;
    private Animator _animator;

    private void Awake()
    {

        _animator = GetComponent<Animator>();

    }

    public void OnClick_WalkRight()
    {
        if (base.photonView.IsMine)
        {
            transform.position += new Vector3(0.5f, 0f, 0f);
            _animator.speed = _animationspeed;
            _animator.Play("walkForw");
        }

    }
    public void OnClick_WalkLeft()
    {
        if (base.photonView.IsMine)
        {
            transform.position -= new Vector3(0.5f, 0f, 0f);
            _animator.speed = _animationspeed;
            _animator.Play("walkBack");
        }

    }
    public void OnClick_Attack1()
    {
        if (base.photonView.IsMine)
        {
            _animator.speed = _animationspeed;
            _animator.Play("attack1");
        }

    }
    public void OnClick_Attack2()
    {
        if (base.photonView.IsMine)
        {
            _animator.speed = _animationspeed;
            _animator.Play("attack2");
        }

    }
    public void OnClick_Attack3()
    {
        if (base.photonView.IsMine)
        {
            _animator.speed = _animationspeed;
            _animator.Play("attack3");
        }

    }

    //private void UpdateAnimationBool(bool boolean, string animation)
    //{
    //    _animator.SetBool(animation, boolean);
    //}
}
