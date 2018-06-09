using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using ForestGuard;

public class RoomController : MonoBehaviour {

    public static int State { get; set; }
    public static List<PlayerInfo> Players { get; set; }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ReturnLobby()
    {
        var info = new JoinOrLeaveRoom { UserId = User.Id, RoomId = User.RoomId };
        Client.Instance.Send(RequestType.LeaveRoom, Proto.Serialize(info));
        SceneManager.LoadSceneAsync(1);
    }
}
