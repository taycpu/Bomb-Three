using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype.Core
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private FloatVariable bombCount;
        [SerializeField] private FloatVariable levelIndex;
        [SerializeField] private LevelStarMapping levelStarMapping;
        [SerializeField] private ScreenManager screenManager;
        [SerializeField] private EndScreen endScreen;

        private bool isGameEnd;

        public void AllWallsDemolished()
        {
            if (isGameEnd) return;
            isGameEnd = true;
            screenManager.ChangeScreen(1);
            int stars = bombCount.Value > 2 ? 2 : bombCount.Value;
            stars += 1;
            endScreen.Configure("CONGRATS", stars);

            levelStarMapping.starAmount[levelIndex.Value] = stars;
        }

        public void WhenBombInvoke()
        {
            if (isGameEnd) return;
            if (bombCount.Value <= 0)
            {
                isGameEnd = true;
                screenManager.ChangeScreen(1);

                endScreen.Configure("Game Over", 0);
            }
        }
        
        
        public void GoToMainMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(1);
        }
    }
}