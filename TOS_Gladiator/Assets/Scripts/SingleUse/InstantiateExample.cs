using Photon.Pun;
using UnityEngine;

public class InstantiateExample : MonoBehaviour
{
    [SerializeField]
    private GameObject _prefab;
    

    private void Awake()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            MasterManager.NetworkInstantiate(_prefab, new Vector3(-4,-2,0), Quaternion.identity);
            //PhotonNetwork.Instantiate("_prefab", new Vector3(-4, -2, 0), Quaternion.identity);
        }
        else
        {
            MasterManager.NetworkInstantiate(_prefab, new Vector3(4, -2, 0), Quaternion.Euler(0,180,0));
        }
    }
}
