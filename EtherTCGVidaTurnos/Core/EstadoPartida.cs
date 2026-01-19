using EtherTCGVidaTurnos.Partida;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EtherTCGVidaTurnos.Core
{
    public static class EstadoPartida
    {
        public static ConfiguracaoPartida Configuracao { get; set; }

        public static void IniciarNovaPartida()
        {
            Configuracao = new ConfiguracaoPartida();
        }

        public static void EncerrarPartida()
        {
            Configuracao = null;
        }
    }

}
