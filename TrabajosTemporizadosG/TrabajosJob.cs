using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.Deployment;

namespace TrabajosTemporizadosG
{
    public class TrabajosJob : SPJobDefinition
    {
        public TrabajosJob()
        {

        }

        public TrabajosJob(String name, SPWebApplication app, SPServer server, SPJobLockType bloqueo)
            : base(name, app, server, bloqueo)
        {
            using (SPSite sitio = new SPSite("http://spcursovm"))
            {
                using (SPWeb web = sitio.RootWeb)
                {
                    SPList lista = web.Lists["TrabajosPendientes"];

                    foreach (SPListItem item in lista.Items)
                    {
                        if (item["finalizado"] == "Yes")
                        {
                            
                        }
                    }
                }
            }

        }
    }
}
