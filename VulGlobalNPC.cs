using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace VulnerableBeings.NPCs
{
	public class VulGlobalNPC : GlobalNPC
	{	
		public override void SetDefaults(NPC npc)
		{
			if (npc.type == 70)
			{
				npc.HitSound = SoundID.NPCHit2;       //Changes hurt sound of the enemy
				npc.DeathSound = SoundID.NPCDeath14;  //And the death sound
				if (Main.expertMode)
				{
					npc.lifeMax = 4000;
				}
				else
				{
					npc.lifeMax = 2000;
				}
				npc.knockBackResist = 0f;
				npc.value = (float)Item.buyPrice(0, 0, 40, 0);
				npc.defense = 30;
			}
			
			if (npc.type == 72)
			{
				npc.HitSound = SoundID.NPCHit5;
				npc.DeathSound = SoundID.NPCDeath3;
				if (Main.expertMode)
				{
					npc.lifeMax = 8000;
				}
				else
				{
					npc.lifeMax = 4000;
				}
				npc.value = (float)Item.buyPrice(0, 0, 70, 0);
				npc.defense = 0;
			}
			for (int i = 0; i < npc.buffImmune.Length; i++)
			{
				npc.buffImmune[i] = true;
			}
		}
		
		public override void AI(NPC npc)
		{
			if (npc.type == 70 || npc.type == 72) //Changes the spike ball and blazing wheel AIs so that they are vincible.
			{
				npc.dontTakeDamage = false;
			}
		}
		
		public override void NPCLoot(NPC npc)
		{
			if (npc.type == 70) //Spike Ball drops.
			{
				if (Main.rand.Next(20) == 7)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 42, 1, false, 0, false, false);
				}
				if (Main.rand.Next(20) == 9)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 161, Main.rand.Next(15,25), false, 0, false, false);
				}
			}
			
			if (npc.type == 72) //Blazing Wheel drops.
			{
				if (Main.rand.Next(10) == 7)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 265, Main.rand.Next(9,18), false, 0, false, false);
				}
				if (Main.rand.Next(100) == 4)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 1354, 1, false, 0, false, false);
				}
				if (Main.rand.Next(10) == 3)
				{
					Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, 288, 1, false, 0, false, false);
				}
			}
		}
	}
}