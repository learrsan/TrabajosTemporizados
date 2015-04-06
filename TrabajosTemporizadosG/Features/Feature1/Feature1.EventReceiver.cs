using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;

namespace TrabajosTemporizadosG.Features.Feature1
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("bcd016fd-c23f-4b03-9626-4b42fd6b3730")]
    public class Feature1EventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            var sitio = properties.Feature.Parent as SPSite;
            SPWebApplication webApplication = sitio.WebApplication;

            foreach (var job in webApplication.JobDefinitions)
            {
                if (job.Name == "TrabajosPendientesJob")
                {
                    job.Delete();
                }
            }

            var mijob = new TrabajosJob("TrabajosPendientesJob", webApplication, null, SPJobLockType.Job);
            
            var sched = new SPMinuteSchedule();
            sched.BeginSecond = 2;
            sched.EndSecond = 10;
            sched.Interval = 5;

            mijob.Schedule = sched;
            mijob.Update();

        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            var sitio = properties.Feature.Parent as SPSite;
            SPWebApplication webApplication = sitio.WebApplication;

            foreach (var job in webApplication.JobDefinitions)
            {
                if (job.Name == "TrabajosPendientesJob")
                {
                    job.Delete();
                }
            }
        }


        // Uncomment the method below to handle the event raised after a feature has been installed.

        //public override void FeatureInstalled(SPFeatureReceiverProperties properties)
        //{
        //}


        // Uncomment the method below to handle the event raised before a feature is uninstalled.

        //public override void FeatureUninstalling(SPFeatureReceiverProperties properties)
        //{
        //}

        // Uncomment the method below to handle the event raised when a feature is upgrading.

        //public override void FeatureUpgrading(SPFeatureReceiverProperties properties, string upgradeActionName, System.Collections.Generic.IDictionary<string, string> parameters)
        //{
        //}
    }
}
