// ReSharper disable CompareOfFloatsByEqualityOperator
namespace MaterialDesignXAMLProgressBug.ViewModels
{
    using System.Timers;

    using Caliburn.Micro;

    public class MainViewModel : Screen
    {
        private readonly Timer timer = new Timer(5000);

        public MainViewModel()
        {
            this.timer.Start();
            this.timer.Elapsed += this.Timer_Elapsed;
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //Giving it a little bit of delay to start the timer
            if (this.timer.Interval == 5000)
            {
                this.timer.Interval = 100;
            }

            if (this.Progress == 99)
            {
                this.timer.Stop();
                return;
            }
            this.Progress++;
            this.NotifyPropChanges();
        }

        //Not necessary on this case, but i am replicating my original project
        private void NotifyPropChanges()
        {
            this.NotifyOfPropertyChange(nameof (this.IsInderteminate));
            this.NotifyOfPropertyChange(nameof (this.Progress));
        }

        public bool IsInderteminate => this.Progress == 0;

        public uint Progress { get; set; }
    }
}
