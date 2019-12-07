using UnityEngine;

namespace Generation
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private RoomTemplateObject _roomTemplate;

        public RoomTemplateObject GetTemplate()
        {
            return _roomTemplate;
        }
    }
}