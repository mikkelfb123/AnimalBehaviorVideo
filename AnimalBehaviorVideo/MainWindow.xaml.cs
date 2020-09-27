using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AnimalBehaviorVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        //bools used for controlling the slider dragging for the individual sliders
        private bool mPlayer1_userIsDraggingSlider = false;
        private bool mPlayer2_userIsDraggingSlider = false;
        private bool mPlayer3_userIsDraggingSlider = false;
        private bool mPlayer4_userIsDraggingSlider = false;

        private bool sync_slider_userIsDraggingSlider = false;

        //sync offsets used when the videos iss synced up
        private double mPlayer2_sync_offset = 0;
        private double mPlayer3_sync_offset = 0;
        private double mPlayer4_sync_offset = 0;

        //variable for controlling the normalized time
        private double normalizeTime = 0;
        //timespam used for the synced time.
        private TimeSpan syncedTimeStamp = new TimeSpan(0,0,0);

        //bool for controlling if the videos have been synced
        private bool is_synced = false;

        public MainWindow()
        {
            InitializeComponent();
            //make timer for updating sliders when the video is playing.
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //update timers if the slider is not been moved.
            if ((mPlayer1.Source != null) && (mPlayer1.NaturalDuration.HasTimeSpan) && (!mPlayer1_userIsDraggingSlider))
            {
                sld_mPlayer1.Minimum = 0;
                sld_mPlayer1.Maximum = mPlayer1.NaturalDuration.TimeSpan.TotalSeconds;
                sld_mPlayer1.Value = mPlayer1.Position.TotalSeconds;
            }

            if ((mPlayer2.Source != null) && (mPlayer2.NaturalDuration.HasTimeSpan) && (!mPlayer2_userIsDraggingSlider))
            {
                sld_mPlayer2.Minimum = 0;
                sld_mPlayer2.Maximum = mPlayer2.NaturalDuration.TimeSpan.TotalSeconds;
                sld_mPlayer2.Value = mPlayer2.Position.TotalSeconds;
            }

            if ((mPlayer3.Source != null) && (mPlayer3.NaturalDuration.HasTimeSpan) && (!mPlayer3_userIsDraggingSlider))
            {
                sld_mPlayer3.Minimum = 0;
                sld_mPlayer3.Maximum = mPlayer3.NaturalDuration.TimeSpan.TotalSeconds;
                sld_mPlayer3.Value = mPlayer3.Position.TotalSeconds;
            }

            if ((mPlayer4.Source != null) && (mPlayer4.NaturalDuration.HasTimeSpan) && (!mPlayer4_userIsDraggingSlider))
            {
                sld_mPlayer4.Minimum = 0;
                sld_mPlayer4.Maximum = mPlayer4.NaturalDuration.TimeSpan.TotalSeconds;
                sld_mPlayer4.Value = mPlayer4.Position.TotalSeconds;
            }

            if ((mPlayer1.Source != null) && (mPlayer1.NaturalDuration.HasTimeSpan) && (!sync_slider_userIsDraggingSlider))
            {
                sld_sync_global.Minimum = 0;
                sld_sync_global.Maximum = mPlayer1.NaturalDuration.TimeSpan.TotalSeconds;
                sld_sync_global.Value = mPlayer1.Position.TotalSeconds;

                if(is_synced == true)
                {
                    sld_mPlayer2.Value = mPlayer1.Position.TotalSeconds + mPlayer2_sync_offset;
                    sld_mPlayer3.Value = mPlayer1.Position.TotalSeconds + mPlayer3_sync_offset;
                    sld_mPlayer4.Value = mPlayer1.Position.TotalSeconds + mPlayer4_sync_offset;
                }
            }
        }

        //method for handling the event of a normal open click for each of the video windows
        private void btn_open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";

            var filePath = string.Empty;
            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                System.Uri uri = new Uri(filePath);

                if (sender.Equals(btn_mPlayer1_open))
                {
                    mPlayer1.Source = uri;
                }
                else if (sender.Equals(btn_mPlayer2_open))
                {
                    mPlayer2.Source = uri;
                }
                else if (sender.Equals(btn_mPlayer3_open))
                {
                    mPlayer3.Source = uri;
                }
                else if (sender.Equals(btn_mPlayer4_open))
                {
                    mPlayer4.Source = uri;
                }
            }

        }

        //method for handling the event of a normal play click for each of the videos
        private void btn_play_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(btn_mPlayer1_play))
            {
                mPlayer1.Play();
            }
            else if (sender.Equals(btn_mPlayer2_play))
            {
                mPlayer2.Play();
            }
            else if (sender.Equals(btn_mPlayer3_play))
            {
                mPlayer3.Play();
            }
            else if (sender.Equals(btn_mPlayer4_play))
            {
                mPlayer4.Play();
            }
        }

        //method for handling the event of a normal pause click for each of the vide
        private void btn_Pause_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(btn_mPlayer1_Pause))
            {
                mPlayer1.Pause();
            }
            else if (sender.Equals(btn_mPlayer2_Pause))
            {
                mPlayer2.Pause();
            }
            else if (sender.Equals(btn_mPlayer3_Pause))
            {
                mPlayer3.Pause();
            }
            else if (sender.Equals(btn_mPlayer4_Pause))
            {
                mPlayer4.Pause();
            }
        }

        //handling the slider dragging
        private void sld_mPlayer_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbl_mPlayer1_duration.Content = TimeSpan.FromSeconds(sld_mPlayer1.Value).ToString(@"hh\:mm\:ss");
        }

        private void sld_mPlayer1_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            mPlayer1_userIsDraggingSlider = true;

        }

        private void sld_mPlayer1_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            mPlayer1_userIsDraggingSlider = false;
            mPlayer1.Position = TimeSpan.FromSeconds(sld_mPlayer1.Value);
        }

        private void sld_mPlayer2_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            mPlayer2_userIsDraggingSlider = true;
        }

        private void sld_mPlayer2_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            mPlayer2_userIsDraggingSlider = false;
            mPlayer2.Position = TimeSpan.FromSeconds(sld_mPlayer2.Value);
        }

        private void sld_mPlayer2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbl_mPlayer2_duration.Content = TimeSpan.FromSeconds(sld_mPlayer2.Value).ToString(@"hh\:mm\:ss");
        }

        private void sld_mPlayer3_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            mPlayer3_userIsDraggingSlider = true;
        }

        private void sld_mPlayer3_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            mPlayer3_userIsDraggingSlider = false;
            mPlayer3.Position = TimeSpan.FromSeconds(sld_mPlayer3.Value);
        }

        private void sld_mPlayer3_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbl_mPlayer3_duration.Content = TimeSpan.FromSeconds(sld_mPlayer3.Value).ToString(@"hh\:mm\:ss");
        }

        private void sld_mPlayer4_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            mPlayer4_userIsDraggingSlider = true;
        }

        private void sld_mPlayer4_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            mPlayer4_userIsDraggingSlider = false;
            mPlayer4.Position = TimeSpan.FromSeconds(sld_mPlayer4.Value);
        }

        private void sld_mPlayer4_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lbl_mPlayer4_duration.Content = TimeSpan.FromSeconds(sld_mPlayer4.Value).ToString(@"hh\:mm\:ss");
        }


        //sync button clicked
        private void bnt_sync_Click(object sender, RoutedEventArgs e)
        {
            //makes new window of the syncbox class
            Syncbox syncbox = new Syncbox();
            bool? result = syncbox.ShowDialog(); //open it as a dialog so the button push from the Syncbox window is handled easily 


            if(result == true)
            {
                //sets the offset for each video
                mPlayer2_sync_offset = mPlayer2.Position.TotalSeconds - mPlayer1.Position.TotalSeconds;
                mPlayer3_sync_offset = mPlayer2.Position.TotalSeconds - mPlayer1.Position.TotalSeconds;
                mPlayer4_sync_offset = mPlayer2.Position.TotalSeconds - mPlayer1.Position.TotalSeconds;

                //gets the time returned from the syncbox window
                string globalTime = syncbox.HhI + ":" + syncbox.MmI + ":" + syncbox.SsI;

                //reset label
                lbl_sync_globalTime.Content = globalTime;

                //make a stamp of the now synced time
                syncedTimeStamp = new TimeSpan(syncbox.HhI, syncbox.MmI, syncbox.SsI);

                MessageBoxResult msgboxResult = MessageBox.Show("Reset normalized time?", "Reset", MessageBoxButton.OKCancel);

                //reset the normalized time
                if(msgboxResult == MessageBoxResult.OK)
                {
                    normalizeTime = 0;
                    lbl_sync_globalNormTime.Content = "00:00:00";
                }
                //reset the local time.
                lbl_sync_localNormTime.Content = "00:00:00";
                is_synced = true;
            }
        }

        private void sld_sync_global_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            sync_slider_userIsDraggingSlider = true;
        }

        private void sld_sync_global_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            sync_slider_userIsDraggingSlider = false;
            mPlayer1.Position = TimeSpan.FromSeconds(sld_sync_global.Value);

            if(is_synced == true)
            {
                mPlayer2.Position = TimeSpan.FromSeconds(sld_sync_global.Value + mPlayer2_sync_offset);
                mPlayer3.Position = TimeSpan.FromSeconds(sld_sync_global.Value + mPlayer3_sync_offset);
                mPlayer4.Position = TimeSpan.FromSeconds(sld_sync_global.Value + mPlayer4_sync_offset);
            }
        }

        private void sld_sync_global_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double GTTTime = syncedTimeStamp.TotalSeconds + sld_sync_global.Value;
            double GNTTime = normalizeTime + sld_sync_global.Value;

            lbl_sync_globalTime.Content = "GT: " + TimeSpan.FromSeconds(GTTTime).ToString(@"hh\:mm\:ss");
            lbl_sync_globalNormTime.Content = "GNT: " + TimeSpan.FromSeconds(sld_sync_global.Value).ToString(@"hh\:mm\:ss");
            lbl_sync_localNormTime.Content = "LNT: " + TimeSpan.FromSeconds(sld_sync_global.Value).ToString(@"hh\:mm\:ss");
        }

        private void btn_playAll_Click(object sender, RoutedEventArgs e)
        {
            mPlayer1.Play();
            mPlayer2.Play();
            mPlayer3.Play();
            mPlayer4.Play();

        }

        private void btn_puaseAll_Click(object sender, RoutedEventArgs e)
        {
            mPlayer1.Pause();
            mPlayer2.Pause();
            mPlayer3.Pause();
            mPlayer4.Pause();
        }
    }
}
