using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewRelicCleanup.Model
{
    public class ServerSettings
    {
        public string ServerId { get; set; }
        public string Hostname { get; set; }
        public string AlertsEnabled { get; set; }
        public string DisplayName { get; set; }
        public string Url { get; set; }
    }


//      <server-setting>
//    <server-id type="integer">2481535</server-id>
//    <hostname>UK1VDW2003</hostname>
//    <alerts-enabled>true</alerts-enabled>
//    <display-name>UK1VDW2003</display-name>
//    <url>https://rpm.newrelic.com/api/v1/accounts/327885/server_settings/2481535
//</url>
//  </server-setting>
}
