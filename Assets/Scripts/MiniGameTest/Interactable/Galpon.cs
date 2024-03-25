using System;
using ActiveZones2D.Scripts.NSActiveZones2D;

namespace MiniGameTest.Interactable
{
    public class Galpon : Objeto2D
    {
        public override Enum ActualStage { protected get; set; }

        protected override void Awake()
        {
            base.Awake();
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
            
        }

        protected override void TabSobreAlgunaZonaActivaDeEsteObjeto(string argNombreZonaActivaSobreLaQueSeHizoTab)
        {
            
        }

        protected override void EsteObjetoSeEstaTransladandoMientrasSeSelecciona()
        {
            
        }
    }
}