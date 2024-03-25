using System;
using System.Collections;
using GeneralsMiniGames;
using MiniGameTest.Challenges;
using UnityEngine;

namespace MiniGameTest.Interactable
{

    [Serializable]
    public enum GallinaType
    {
        Blanca,
        BlancaManchas,
        Marron,
        Negra,
    }

    [Serializable]
    public class GallinaConfig
    {
        public enum GallinaState { Aleteando, Caminando, Sentada, None }
        
        public GameObject gallinaAleteando;
        public GameObject gallinaCaminando;
        public GameObject gallinaSentada;
        public GameObject gallinaPlumas;

        private GallinaState _currentState = GallinaState.Caminando;
        
        public void ShowState(GallinaState newState)
        {
            GetGameObject(_currentState).SetActive(false);
            GetGameObject(newState)?.SetActive(true);
            _currentState = newState;
        }
        
        public void ShowPlumas(bool state)
        {
            gallinaPlumas.gameObject.SetActive(state);
        }

        private GameObject GetGameObject(GallinaState gallinaState)
        {
            switch (gallinaState)
            {
                case GallinaState.Aleteando:
                    return gallinaAleteando;
                case GallinaState.Caminando:
                    return gallinaCaminando;
                case GallinaState.Sentada:
                    return gallinaSentada;
                case GallinaState.None:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gallinaState), gallinaState, null);
            }
        }
        
    }
    
    public class Gallina : InteractableBase
    {
        public GallinaType type;
        public GallinaConfig gallinaConfig;

        private Challenge01 _challenge01;

        private bool _canTouch;
        
        protected override void Awake()
        {
            base.Awake();
            _canTouch = true;
            gallinaConfig.ShowPlumas(false);
            gallinaConfig.ShowState(GallinaConfig.GallinaState.Caminando);
        }

        private void Start()
        {
            _challenge01 = SelectChallenge.Instance.RefChallengeSetupSelected as Challenge01;
        }

        protected override void ComenzoSeleccionDeEsteObjeto()
        {
            
        }

        public override void SeSoltoEsteObjetoSobreAlgunaZonaActiva(string argNombreZonaActivaSobreLaQueSeSoltoEsteObjeto)
        {
            
        }

        protected override void SeSoltoEsteObjetoSinEstarCercaAUnaZonaActiva()
        {
            
        }

        protected override void ObjetoAlcanzoLaPosicionPreviaDespuesDeSoltarseSobreNada()
        {
            
        }

        public override void TabSobreEsteObjeto()
        {
            if (!_canTouch) return;
            
            ChallengeSetup currentChallenge = SelectChallenge.Instance.RefChallengeSetupSelected;
            if (currentChallenge is Challenge01 challenge)
            {
                if (challenge.CurrentChallange.gallinaType == type)
                {
                    _challenge01.GallinasQuantity++;
                    StartCoroutine(KillGallina());
                }
                else
                {
                    AttemptsCounter.Instance.AddAttempt();
                }
            }
            
        }

        protected override void TabSobreAlgunaZonaActivaDeEsteObjeto(string argNombreZonaActivaSobreLaQueSeHizoTab)
        {
            
        }

        protected override void EsteObjetoSeEstaTransladandoMientrasSeSelecciona()
        {
            
        }

        private IEnumerator KillGallina()
        {
            _canTouch = false;
            
            gallinaConfig.ShowState(GallinaConfig.GallinaState.Aleteando);
            
            yield return new WaitForSeconds(2f);
            
            gallinaConfig.ShowState(GallinaConfig.GallinaState.None);
            gallinaConfig.ShowPlumas(true);

            yield return new WaitForSeconds(1f);
            
            gallinaConfig.ShowPlumas(false);
            
            Destroy(gameObject);
        }
        
    }
}