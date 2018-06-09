using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

using ForestGuard;

public class LobbyController : MonoBehaviour {

    public GameObject Panel;
    public static int LobbyState = -1;
    public static RoomList RoomList = null;
    private int NumOfRoom = 0;
    private int RoomIndex = 0;

    // Use this for initialization
    void Start ()
    {
        Panel = GameObject.Find("CreationPanel");
        Panel.SetActive(false);

        var btns = GameObject.FindGameObjectsWithTag("Room");
        foreach (var btn in btns)
        {
            btn.GetComponent<Button>().onClick.AddListener(delegate () { EnterRoom(btn.gameObject); });
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (LobbyState)
        {
            //case 0:
            //    MessageShow(Message); break;
            case 1:
                NumOfRoom = RoomList.List.Count;
                GameObject.Find("RoomNums").GetComponent<Text>().text = "房间数: " + NumOfRoom;
                LoadRoom(RoomIndex); break;
            case 2:
                SceneManager.LoadSceneAsync(2); break;
            default:
                return;
        }
        LobbyState = -1;
    }

    public void ShowRoomCreation(bool visible)
    {
        Panel.SetActive(visible);
    }

    public void CreateRoom()
    {
        var room = GameObject.Find("RoomName").GetComponent<InputField>();
        var list = new List<PlayerInfo>();
        list.Add(new PlayerInfo { Id = User.Id, Nickname = User.Nickname });
        var info = new RoomInfo { Id = 0, Name = room.text, Players = list };
        Client.Instance.Send(RequestType.CreateRoom, Proto.Serialize(info));
        //Debug.Log("Create Room Request");
    }
    
    public void EnterRoom(GameObject sender)
    {
        var index = sender.name[4] - '0' - 1;
        var room_id = RoomList.List[index].Id;
        var info = new JoinOrLeaveRoom { UserId = User.Id, RoomId = room_id };
        Client.Instance.Send(RequestType.EnterRoom, Proto.Serialize(info));
    }

    public void QuickEnter()
    {
        var rooms = GameObject.FindGameObjectsWithTag("Room").OrderBy(g => g.transform.name).ToArray();
        int i = 1;
        foreach (var r in rooms)
        {
            if(i <= 4)
            {
                r.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/InputBox/room_active");
                r.GetComponent<Button>().interactable = true;
            }
            else
            {
                r.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/InputBox/room_deactivate");
                r.GetComponent<Button>().interactable = false;
            }
            ++i;
        }
            //var user = new PlayerInfo { Id = User.Id, Nickname = User.Nickname };
            //Client.Instance.Send(RequestType.QuickEnter?, Proto.Serialize(user));
            //Client.Instance.Send(RequestType.MaxType, new byte[0]);
            //SceneManager.LoadSceneAsync(2);
        }

    public void FetchRoomList()
    {
        RoomIndex = 0;
        Client.Instance.Send(RequestType.FetchRoomList, new byte[0]);
    }

    public void LoadRoom(int index)
    {
        int loadRoomNum = NumOfRoom - RoomIndex;
        if(loadRoomNum < 0) { return; }
        var rooms = GameObject.FindGameObjectsWithTag("Room").OrderBy(g => g.transform.name).ToArray();
        if (loadRoomNum <= 8)
        {
            int i = 0;
            foreach (var r in rooms)
            {
                //Debug.Log(r.name);
                if (i < loadRoomNum)
                {
                    r.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/InputBox/room_active");
                    r.GetComponent<Button>().interactable = true;
                    foreach (var text in r.GetComponentsInChildren<Text>())
                    {
                        if (text.name == "Name")
                        {
                            text.text = RoomList.List[RoomIndex + i].Name;
                        }
                        else if (text.name == "RoomStatus")
                        {
                            text.text = RoomList.List[RoomIndex + i].Players.Count + "/4";
                        }
                    }
                }
                else
                {
                    r.GetComponent<Image>().sprite = Resources.Load<Sprite>("UI/InputBox/room_deactivate");
                    r.GetComponent<Button>().interactable = false;
                    foreach (var text in r.GetComponentsInChildren<Text>())
                    {
                        if (text.name == "Name")
                        {
                            text.text = null;
                        }
                        else if (text.name == "RoomStatus")
                        {
                            text.text = null;
                        }
                    }
                }
                ++i;
            }
        }
        RoomIndex += loadRoomNum;
    }
}
