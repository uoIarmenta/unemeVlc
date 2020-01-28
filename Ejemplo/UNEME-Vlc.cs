using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Configuration;

namespace Ejemplo
{
    public partial class UnemeVlc : Form
    {
        string[] filesPeliculas = null;
        string[] filesAnuncios = null;
        int contadorPeliculas = 0;
        int maximoPeliculas = 0;
        int contadorAnuncios = 0;
        int maximoAnuncios = 0;


        public UnemeVlc()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarPeliculas();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            CargarPeliculas();
        }

        private void CargarPeliculas()
        {
            string rutaPeliculas = ConfigurationSettings.AppSettings["RutaPeliculas"];
           // System.Configuration.ConfigurationSettings.AppSettings.
            string currentDirName = @"C:\Peliculas\";
            Console.WriteLine(currentDirName);

            // Get an array of file names as strings rather than FileInfo objects.
            // Use this method when storage space is an issue, and when you might
            // hold on to the file name reference for a while before you try to access
            // the file.
            if (filesPeliculas == null)
            {
                filesPeliculas = System.IO.Directory.GetFiles(currentDirName, "*.*");
                maximoPeliculas = filesPeliculas.Length;
            }
            if (contadorPeliculas >= maximoPeliculas)
                contadorPeliculas = 0;
            bool valido = false;
            do
            {

                if (filesPeliculas[contadorPeliculas].ToString().EndsWith("mp4") ||
                    filesPeliculas[contadorPeliculas].ToString().EndsWith("avi") ||
                    filesPeliculas[contadorPeliculas].ToString().EndsWith("mkv"))
                {
                    valido = true;
                }
                else
                {
                    contadorPeliculas++;
                }
            } while (!valido);

            FileInfo info = new FileInfo(filesPeliculas[contadorPeliculas].ToString());
            contadorPeliculas++;

            vlcControl1.SetMedia(info);

            vlcControl1.Play();
            vlcControl1.GetCurrentMedia();
            vlcControl1.Dock = DockStyle.Fill;

            if (InvokeRequired)
                Invoke(new Action(() => vlcControl1.Visible = true));
            else
                vlcControl1.Visible = true;
            if (InvokeRequired)
                Invoke(new Action(() => vlcControl2.Visible = false));
            else
                vlcControl2.Visible = false;

            vlcControl1.VlcMediaPlayer.OnMediaPlayerAudioVolume(150);
        }


        private void CargarAnuncios()
        {
            string currentDirName = @"C:\Users\Administrador Local\Videos\Uneme";
            Console.WriteLine(currentDirName);

            // Get an array of file names as strings rather than FileInfo objects.
            // Use this method when storage space is an issue, and when you might
            // hold on to the file name reference for a while before you try to access
            // the file.
            if (filesAnuncios == null)
            {
                filesAnuncios = System.IO.Directory.GetFiles(currentDirName, "*.*");
                maximoAnuncios = filesAnuncios.Length;
            }
            if (contadorAnuncios >= maximoAnuncios)
                contadorAnuncios = 0;
            bool valido = false;
            do
            {
                if (filesAnuncios[contadorAnuncios].ToString().EndsWith("mp4") ||
                    filesAnuncios[contadorAnuncios].ToString().EndsWith("avi") ||
                    filesAnuncios[contadorAnuncios].ToString().EndsWith("mkv"))
                {
                    valido = true;
                }
                else
                {
                    contadorAnuncios++;
                }
            } while (!valido);

            FileInfo info = new FileInfo(filesAnuncios[contadorAnuncios].ToString());
            contadorAnuncios++;

            vlcControl2.SetMedia(info);
            vlcControl2.Play();
            vlcControl2.GetCurrentMedia();
            vlcControl1.Pause();
            vlcControl2.Dock = DockStyle.Fill;
            vlcControl2.Visible = true;
            vlcControl1.Visible = false;
            //}
            vlcControl2.VlcMediaPlayer.OnMediaPlayerAudioVolume(100);
        }


        private void SplitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SplitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (vlcControl1.IsPlaying)
            {
                vlcControl1.Pause();

                vlcControl1.Visible = true;
                vlcControl2.Visible = false;
            }
            else
            {
                vlcControl1.Play();
                vlcControl1.Dock = DockStyle.Fill;
                vlcControl1.Visible = true;
                vlcControl2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CargarAnuncios();
        }

        private void cambio()
        {
            try
            {
                if (InvokeRequired)
                    Invoke(new Action(() => vlcControl1.Visible = true));
                else
                    vlcControl1.Visible = true;
                if (InvokeRequired)
                    Invoke(new Action(() => vlcControl2.Visible = false));
                else
                    vlcControl2.Visible = false;
                vlcControl1.Dock = DockStyle.Fill;
                vlcControl1.Play();
            }
            catch (Exception ex) { }
            vlcControl2.GetCurrentMedia();
        }

        private void vlcControl2_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            cambio();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (vlcControl1.IsPlaying)
            {
                vlcControl1.Stop();
            }
            if (vlcControl2.IsPlaying)
                vlcControl2.Stop();
        }

        private void vlcControl1_Stopped(object sender, Vlc.DotNet.Core.VlcMediaPlayerStoppedEventArgs e)
        {
            CargarPeliculas();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (vlcControl1.IsPlaying)
                vlcControl1.Stop();
            if (vlcControl2.IsPlaying)
                vlcControl2.Stop();
        }
    }
}
