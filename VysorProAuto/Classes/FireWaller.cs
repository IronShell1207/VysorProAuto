using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetFwTypeLib;

namespace EasyVysorPro
{
    public class FireWaller
    {
        public void firewalldown()
        {

            var apps = new List<string> {
                VysorProAuto.Constants.dirVysor + "Vysor.exe",
                VysorProAuto.Constants.dirVysor + "Update.exe",
                VysorProAuto.Constants.dirVysor + @"app-2.2.2\Vysor.exe",
                VysorProAuto.Constants.dirVysor + @"app-2.2.2\squirrel.exe"
            };
            var name = new List<string>
            {
                "VysorMain","VysorUpdater","VysorSec","VysorSquirrel"
            };
            foreach (string nam in name)
            {
                removerules(nam);
            }
           
            int i = 0;
            foreach (string App in apps)
            {
                netDisabler(App, name[i]);
                i++;
            }
        }
        public void netDisabler(string path, string name )
        {
            List<NET_FW_RULE_DIRECTION_> directions = new List<NET_FW_RULE_DIRECTION_> {
                NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN,
                NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT };
            foreach (NET_FW_RULE_DIRECTION_ rule in directions)
            {
                Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
                INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
                var currentProfiles = fwPolicy2.CurrentProfileTypes;

                INetFwRule2 inboundRule1 = (INetFwRule2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FWRule"));
                inboundRule1.Enabled = true;
                inboundRule1.ApplicationName = path;
                inboundRule1.Profiles = currentProfiles;
                inboundRule1.Description = "testtest";
                inboundRule1.Name = name;
                inboundRule1.InterfaceTypes = "All";
                inboundRule1.Action = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                inboundRule1.Direction = rule;
                try
                {
                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy.Rules.Add(inboundRule1);
                }
                catch (Exception ex) {
                    VysorProAuto.Form1 _fo1m = new VysorProAuto.Form1();
                    _fo1m.messageBoxCaller(ex.Message, "Firewall rule adding error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                }
                

            }
        }
        void removerules(string name)
        {
            Type tNetFwPolicy2 = Type.GetTypeFromProgID("HNetCfg.FwPolicy2");
            INetFwPolicy2 fwPolicy2 = (INetFwPolicy2)Activator.CreateInstance(tNetFwPolicy2);
            var currentProfiles = fwPolicy2.CurrentProfileTypes;
            foreach (INetFwRule rule in fwPolicy2.Rules)
            {
                if (rule.Name.IndexOf(name) != -1)
                {
                    INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                    firewallPolicy.Rules.Remove(rule.Name);
                    Console.WriteLine(rule.Name + " has been deleted from the Firewall Policy");
                }
            }
        }

    }
}
