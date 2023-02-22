//using UnityEngine;
//using Wolf3D.ReadyPlayerMe.AvatarSDK;

//public class loadavatar : MonoBehaviour
//{
//    [SerializeField] private string avatarUrl;
//    [SerializeField] private string objectName = "MyAvatar";
//    [SerializeField] private Vector3 spawnPosition;

//    // Start is called before the first frame update
//    void Start()
//    {
//        LoadAvatar();
//    }

//    private void LoadAvatar()
//    {
//        //don't run if url empty
//        if (string.IsNullOrEmpty(avatarUrl))
//        {
//            Debug.LogWarning("URL Not set");
//            return;
//        }

//        AvatarLoader avatarLoader = new AvatarLoader();
//        avatarLoader.LoadAvatar(avatarUrl, AvatarLoadedCallback);
//    }

//    private void AvatarLoadedCallback(GameObject avatar)
//    {
//        Debug.Log("Avatar Loaded!");

//        //Do Stuff
//        gameObject.name = objectName;
//        gameObject.transform.position = spawnPosition;
//    }
//}
