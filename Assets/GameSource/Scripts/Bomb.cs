using UnityEngine;

namespace Prototype.Core
{
    public class Bomb : MonoBehaviour
    {
        public void SetBomb()
        {
            gameObject.SetActive(true);
        }

        public void InvokeBomb()
        {
            gameObject.SetActive(false);
        }
    }
}