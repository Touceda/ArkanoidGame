using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkanoidMotor
{
    public class PlayerStats
    {
        private int partidasJugadas;
        public int PartidasJugadas { get { return partidasJugadas; } set { partidasJugadas = value; } }

        private int nivelesCompletos;
        public int NivelesCompletos { get { return nivelesCompletos; } set { nivelesCompletos = value; } }

        private int nivelesPerdidos;
        public int NivelesPerdidos { get { return nivelesPerdidos; } set { nivelesPerdidos = value; } }

        private int victorias;
        public int Victorias { get { return victorias; } set { victorias = value; } }

        private int derrotas;
        public int Derrotas { get { return derrotas; } set { derrotas = value; } }

        private int puntuacion;
        public int MaximaPuntuacion { get { return puntuacion; } set { puntuacion = value; } }

        private string tiempoJugado;
        public string TiempoJugado { get { return tiempoJugado; } set { tiempoJugado = value; } }

        public PlayerStats(int pJugadas, int nivCompletos, int nivPerdidos, int victoria, int derrota, int pts, string tiempjugado)
        {
            this.partidasJugadas = pJugadas;
            this.nivelesCompletos = nivCompletos;
            this.nivelesPerdidos = nivPerdidos;
            this.victorias = victoria;
            this.derrotas = derrota;
            this.puntuacion = pts;
            this.tiempoJugado = tiempjugado;
        }

        public void CalcularTiempoJugado(Stopwatch SW)
        {
            string tiempo = this.tiempoJugado;
            string Dias ="";
            string Horas = "";
            string Minutos = "";
            string Segundos = "";


            int TDias = 0;
            int THoras = 0;
            int TMinutos = 0;
            int TSeg = 0;
            int swMiliSegundos = int.Parse(SW.ElapsedMilliseconds.ToString());

            int count = 0;
            for (int index = 0; index < tiempo.Length; index++)
            {
                if (count == 3)
                {
                    if (tiempo[index].ToString() != ":")
                    {
                        Segundos += tiempo[index].ToString();
                    }
                }

                if (count == 2)
                {
                    if (tiempo[index].ToString() != ":")
                    {
                        Minutos += tiempo[index].ToString();
                    }
                    else
                    {
                        count++;
                    }
                }

                if (count == 1)
                {
                    if (tiempo[index].ToString() != ":")
                    {
                        Horas += tiempo[index].ToString();
                    }
                    else
                    {
                        count++;
                    }
                }

                if (count == 0)
                {
                    if (tiempo[index].ToString() != ":")
                    {
                        Dias += tiempo[index].ToString();
                    }
                    else
                    {
                        count++;
                    }
                }
            }

            TDias = int.Parse(Dias.ToString());
            THoras= int.Parse(Horas.ToString());
            TMinutos = int.Parse(Minutos.ToString());
            TSeg = int.Parse(Segundos.ToString());

            while (swMiliSegundos >= 1000)
            {
                TSeg += 1;
                swMiliSegundos += -1000;
            }

            while (TSeg >= 61) 
            {
                TMinutos += 1;
                TSeg += -60;
            }

            while (TMinutos >= 61)
            {
                THoras += 1;
                TMinutos += -60;
            }

            while (THoras >= 24)
            {
                TDias += 1;
                TMinutos += -24;
            }

            this.tiempoJugado = TDias.ToString() + ":" + THoras.ToString() + ":" + TMinutos.ToString() + ":" + TSeg.ToString();

        }

    }
}
