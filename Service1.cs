
using System.ServiceProcess;
using System.Timers;


namespace BlankService
{
    public partial class BlankService : ServiceBase
    {
        Timer tmrDelay;
        int count;
        System.DateTime scheduledTime = System.DateTime.MinValue;
        
        


        public BlankService()
        {
            InitializeComponent();

            if (!System.Diagnostics.EventLog.SourceExists("MyLogSrc"))
            {
                System.Diagnostics.EventLog.CreateEventSource("MyLogSrc", "MyLog");
            }

            //set our event log to system created log
            eventLog1.Source = "MyLogSrc";
            eventLog1.Log = "MyLog";

            tmrDelay = new System.Timers.Timer(Program.intervals); 
            tmrDelay.Elapsed += new System.Timers.ElapsedEventHandler(tmrDelay_Elapsed);

        }

        void tmrDelay_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //logic for service - on timer
            //configure intervals of timer in config
            Program.log.Info("============ BlankService Log info on interval ============");
        }

        protected override void OnStart(string[] args)
        {
            Program.log.Info("============ BlankService started ============");
            eventLog1.WriteEntry("BlankService started");
            tmrDelay.Enabled = true;
        }

        protected override void OnStop()
        {
            Program.log.Info("============ BlankService stopped ============");
            eventLog1.WriteEntry("BlankService stopped");
            tmrDelay.Enabled = false;
        }
    }
}
