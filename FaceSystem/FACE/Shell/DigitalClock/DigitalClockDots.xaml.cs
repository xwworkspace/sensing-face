using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Shell.DigitalClock
{
    /// <summary>
    /// Interaction logic for DigitalClockDots.xaml
    /// </summary>
    public partial class DigitalClockDots : UserControl
    {
        private Brush renderBrush = null;

        

        public DigitalClockDots()
        {
            InitializeComponent();

            this.RenderBrush = new SolidColorBrush(Colors.AliceBlue);

            DispatcherTimer timer = new DispatcherTimer(new TimeSpan(0,0,0,1),DispatcherPriority.Normal, OnFlashTheEvent,this.Dispatcher);
        }

        private void OnFlashTheEvent(object sender, EventArgs e)
        {
            SolidColorBrush brush = RenderBrush as SolidColorBrush;


            if(brush !=null)
            {
                if (brush.Color == Colors.AliceBlue)
                {
                    RenderBrush = new SolidColorBrush(Colors.Transparent);
                }
                else
                {
                    RenderBrush = new SolidColorBrush(Colors.AliceBlue);
                }

                if (brush.Color == Colors.Black)
                {
                    RenderBrush = new SolidColorBrush(Colors.Transparent);
                }
                else
                {
                    RenderBrush = new SolidColorBrush(Colors.Black);
                }
            }

           
        }

        public Brush RenderBrush
        {
            get
            {
                return renderBrush;
            }
            set
            {
                renderBrush = value;
                p0.Fill = renderBrush;
                p1.Fill = renderBrush;
            }
        }
    }
}
