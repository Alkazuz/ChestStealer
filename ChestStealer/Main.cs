using AdvancedBot;
using AdvancedBot.client;
using AdvancedBot.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestStealer
{
    public class Main : IPlugin
    {
        private CMDChestSteal cMDChestSteal;

        public Main()
        {
            foreach(MinecraftClient client in Program.FrmMain.Clients)
            {
                if (client.CmdManager.GetCommand<CMDChestSteal>() == null)
                    cMDChestSteal = new CMDChestSteal(client);
                    client.CmdManager.Commands.Add(cMDChestSteal);
            }
        }
        public void onClientConnect(MinecraftClient client)
        {
            if (client.CmdManager.GetCommand<CMDChestSteal>() == null)
                cMDChestSteal = new CMDChestSteal(client);
                client.CmdManager.Commands.Add(cMDChestSteal);
        }

        public void onReceiveChat(string chat, byte pos, MinecraftClient client)
        {}

        public void OnReceivePacket(ReadBuffer pkt, MinecraftClient client)
        {}

        public void onSendChat(string chat, MinecraftClient client)
        {}

        public void OnSendPacket(IPacket packet, MinecraftClient client)
        {}

        public void Tick()
        {}

        public void Unload()
        {}
    }
}
