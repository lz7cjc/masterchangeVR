using UnityEngine;

namespace ReadyPlayerMe
{
    public class RuntimeExample : MonoBehaviour
    {
        [SerializeField]
        private string avatarUrl = "https://d1a370nemizbjq.cloudfront.net/9bcc6840-8b8b-420d-a9d8-bc9c275fce8f.glb";

        private GameObject avatar;
        public GameObject avatarPosition;
        public float xAngle, yAngle, zAngle;
        private void Start()
        {
            ApplicationData.Log();

            var avatarLoader = new AvatarLoader();
            avatarLoader.OnCompleted += (_, args) =>
            {
                avatar = args.Avatar;
                // set position
                //     avatar.transform.position = new Vector3(564, 0, 344);
          
                avatar.transform.position = avatarPosition.transform.position;
                avatar.transform.Rotate(0f, 180f, 0f);
            

            };
            avatarLoader.LoadAvatar(avatarUrl);
         
        }

        private void OnDestroy()
        {
            if (avatar != null) Destroy(avatar);
        }
    }
}
