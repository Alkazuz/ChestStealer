using AdvancedBot.client;
using AdvancedBot.client.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChestStealer
{
    class CMDChestSteal : CommandBase
    {
        public MinecraftClient client;

        public MinecraftClient getClient()
        {
            return this.client;
        }
        public CMDChestSteal(MinecraftClient cli) : base(cli,
            "ChestStealer", //Titulo
            "Takes all items from an open chest for inventory", //Descrição
            new string[] {
                "cheststeal", "cheststealer" //Uso do comando, se usar algum desses será executado
            })
        {
            this.client = cli;
        }

        public override CommandResult Run(string alias, string[] args)
        {
            steal();
            return CommandResult.Success;
        }

        public async void steal()
        {
            Inventory invOpen = Client.OpenWindow;
            Inventory inv = Client.Inventory;   
            if (invOpen != null)
            {
                int slot = 9;
                for (int i = 0; i < invOpen.NumSlots; i++)
                {
                    ItemStack item = invOpen.Slots[i];
                    if (item != null)
                    {
                        invOpen.Click(Client, (short)i, false, true);
                        await Task.Delay(500);
                        ItemStack currentItemSlot = inv.Slots[slot];
                        while(currentItemSlot != null)
                        {
                            slot++;
                            if(slot > 35) { return; }
                            currentItemSlot = inv.Slots[slot];
                            
                        }
                        inv.Click(Client, (short)slot, true, true);
                        await Task.Delay(500);
                    }
                }
            }
        }

    }
}
