using UnityEngine;

namespace Prototype.Core
{
    public class Wall : MonoBehaviour
    {
        public void SetWall()
        {
            gameObject.SetActive(true);
        }

        public void Demolish()
        {
            gameObject.SetActive(false);
        }
    }
}