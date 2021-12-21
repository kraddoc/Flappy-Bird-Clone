using FlappyClone.Core;
using UnityEngine;

namespace FlappyClone.UI
{
    // Rudimentary UI manager. It runs only twice a run, so it's fine,
    // but for more expansive games implementing a state machine or at least
    // an enum controlled behavior is justified. 
    public class UISwitcher : MonoBehaviour
    {
        [Header("Events.")]
        [SerializeField] private GameStart gameStarter;
        [SerializeField] private DeathObserver deathObserver;
        
        [Header("UIs.")]
        [SerializeField] private RectTransform startUI;
        [SerializeField] private RectTransform playUI;
        [SerializeField] private RectTransform deathUI;

        private void OnEnable()
        {
            gameStarter.OnStart += EnablePlayUI;
            deathObserver.OnDeath += EnableDeathUI;
        }

        private void OnDisable()
        {
            gameStarter.OnStart -= EnablePlayUI;
            deathObserver.OnDeath -= EnableDeathUI;
        }

        private void EnablePlayUI()
        {
            startUI.gameObject.SetActive(false);
            playUI.gameObject.SetActive(true);
            deathUI.gameObject.SetActive(false);
        }

        private void EnableDeathUI()
        {
            playUI.gameObject.SetActive(false);
            deathUI.gameObject.SetActive(true);
        }
    }
}