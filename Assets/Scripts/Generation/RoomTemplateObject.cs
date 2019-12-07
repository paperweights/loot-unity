using UnityEngine;

namespace Generation
{
    [CreateAssetMenu(fileName = "Room Template", menuName = "ScriptableObject/RoomTemplate", order = 0)]
    public class RoomTemplateObject : ScriptableObject
    {
        [SerializeField] private GameObject[] _topRooms;
        [SerializeField] private GameObject[] _bottomRooms;
        [SerializeField] private GameObject[] _leftRooms;
        [SerializeField] private GameObject[] _rightRooms;

        public GameObject[] GetTopRooms()
        {
            return _topRooms;
        }
        
        public GameObject[] GetBottomRooms()
        {
            return _bottomRooms;
        }
        
        public GameObject[] GetLeftRooms()
        {
            return _leftRooms;
        }
        
        public GameObject[] GetRightRooms()
        {
            return _rightRooms;
        }
    }
}