using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Threading;

namespace Shell.DigitalClock
{
    /// <summary>
    /// Interaction logic for DigitalClock.xaml
    /// </summary>
    public partial class DigitalClockControl : UserControl
    {

        

        protected delegate void RefreshDelegate();
        private Thread updateThread = null;
        public static double AdjustHours = 0;
        private DateTime currentTime = DateTime.Now.AddHours(AdjustHours);

        public DigitalClockControl()
        {
            InitializeComponent();

            this.AutoUpdate = true;

            
          
        }
        
       
        #region styling
        public Brush DigitBrush
        {
            set
            {
                p0.RenderBrush = value;
                p1.RenderBrush = value;
                p3.RenderBrush = value;
                p4.RenderBrush = value;
                //p6.RenderBrush = value;
                //p7.RenderBrush = value;
            }
        }

        public Brush YearNumberBrush
        {
            set { yearNumber.Foreground = value; }
        }

        public Brush DotBrush
        {
            set
            {
                p2.RenderBrush = value;
                //p5.RenderBrush = value;
            }
        }

        public Brush ClockBackground
        {
            get
            {
                return masterBorder.Background;
            }
            set
            {
                masterBorder.Background = value;
            }
        }
        #endregion

        public DateTime CurrentTime
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;

                #region hours
                if (value.Hour > 9)
                {
                    p0.Value = int.Parse(value.Hour.ToString()[0].ToString());
                    p1.Value = int.Parse(value.Hour.ToString()[1].ToString());
                }
                else
                {
                    p0.Value = 0;
                    p1.Value = int.Parse(value.Hour.ToString()[0].ToString());

                }
                #endregion

                #region minutes
                if (value.Minute > 9)
                {
                    p3.Value = int.Parse(value.Minute.ToString()[0].ToString());
                    p4.Value = int.Parse(value.Minute.ToString()[1].ToString());
                }
                else
                {
                    p3.Value = 0;
                    p4.Value = int.Parse(value.Minute.ToString()[0].ToString());

                }
                #endregion

                #region seconds
                //if (value.Second > 9)
                //{
                //    p6.Value = int.Parse(value.Second.ToString()[0].ToString());
                //    p7.Value = int.Parse(value.Second.ToString()[1].ToString());
                //}
                //else
                //{
                //    p6.Value = 0;
                //    p7.Value = int.Parse(value.Second.ToString()[0].ToString());

                //}
                #endregion
            }
        }

        public bool AutoUpdate
        {
            get
            {
                return updateThread != null;
            }
            set
            {
                if (updateThread != null)
                {
                    try
                    {
                        updateThread.Abort();
                    }
                    catch (Exception)
                    { }
                }

                if (value)
                {
                    updateThread = new Thread(delegate()
                    {
                        try
                        {
                            while (true)
                            {
                                DateTime d = DateTime.Now.AddHours(AdjustHours);

                                bool complete = false;
                                this.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new RefreshDelegate(delegate()
                                {
                                    this.CurrentTime = d;
                                    this.yearNumber.Text = string.Join(".", d.Year.ToString(), d.Month.ToString(), d.Day.ToString());
                                    complete = true;
                                }));

                                #region pause
                                try
                                {
                                    do
                                    {
                                        Thread.Sleep(900);
                                    }
                                    while (!complete);
                                }
                                catch (Exception)
                                {
                                }
                                #endregion
                            }
                        }
                        catch (Exception)
                        {
                        }
                    });
                    updateThread.Name = "Clock Thread";
                    updateThread.Start();
                }
            }
        }

        private void masterBorder_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(  AdjustHours.CompareTo(0)==0)
            {
                AdjustHours = -8;
                this.AutoUpdate = true;
                this.zone1.Text = "U";
                this.zone2.Text = "T";
                this.zone3.Text = "C";
                this.zone4.Visibility = Visibility.Collapsed;
               
            }
            else
            {
                AdjustHours = 0;
                this.AutoUpdate = true;

                this.zone1.Text = "北";
                this.zone2.Text = "京";
                this.zone3.Text = "时";
                this.zone4.Visibility = Visibility.Visible;
                this.zone4.Text = "间";

                
            }
            e.Handled = true;
        }
    }
}
