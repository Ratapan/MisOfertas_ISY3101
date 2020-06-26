using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MisOfertasWPF
{
    /// <summary>
    /// Lógica de interacción para Bienvenido.xaml
    /// </summary>
    public partial class Bienvenido
    {
        public Bienvenido()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0,0,3);
            timer.Tick += (a, b) =>
            {
                this.Close();

                timer.Stop();
            };
            timer.Start();
            
        }


    }
}
