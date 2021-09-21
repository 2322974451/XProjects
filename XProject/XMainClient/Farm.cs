using System;
using System.Collections.Generic;

namespace XMainClient
{
	// Token: 0x02000C2C RID: 3116
	internal class Farm
	{
		// Token: 0x0600B078 RID: 45176 RVA: 0x0021B278 File Offset: 0x00219478
		public Farm()
		{
			this.m_homeFarmlandDic = new Dictionary<uint, Farmland>();
			uint num = 1U;
			while ((ulong)num <= (ulong)((long)this.m_m_homeFarmlandNum))
			{
				this.m_homeFarmlandDic.Add(num, new HomeFarmland(num));
				num += 1U;
			}
			this.m_guildFarmlandDic = new Dictionary<uint, Farmland>();
			uint num2 = 1U;
			while ((ulong)num2 <= (ulong)((long)this.m_guildFarmlandNum))
			{
				this.m_guildFarmlandDic.Add(num2, new GuildFarmland(num2));
				num2 += 1U;
			}
		}

		// Token: 0x1700311E RID: 12574
		// (get) Token: 0x0600B079 RID: 45177 RVA: 0x0021B310 File Offset: 0x00219510
		public Dictionary<uint, Farmland> HomeFarmlandDic
		{
			get
			{
				return this.m_homeFarmlandDic;
			}
		}

		// Token: 0x1700311F RID: 12575
		// (get) Token: 0x0600B07A RID: 45178 RVA: 0x0021B328 File Offset: 0x00219528
		public Dictionary<uint, Farmland> GuildFarmlandDic
		{
			get
			{
				return this.m_guildFarmlandDic;
			}
		}

		// Token: 0x0600B07B RID: 45179 RVA: 0x0021B340 File Offset: 0x00219540
		public Farmland GetHomeFarmland(uint farmlandId)
		{
			Farmland farmland;
			bool flag = this.m_homeFarmlandDic.TryGetValue(farmlandId, out farmland);
			Farmland result;
			if (flag)
			{
				result = farmland;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600B07C RID: 45180 RVA: 0x0021B36C File Offset: 0x0021956C
		public Farmland GetGuildFarmland(uint farmlandId)
		{
			Farmland farmland;
			bool flag = this.m_guildFarmlandDic.TryGetValue(farmlandId, out farmland);
			Farmland result;
			if (flag)
			{
				result = farmland;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600B07D RID: 45181 RVA: 0x0021B398 File Offset: 0x00219598
		public void ResetHomeFarmland()
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_homeFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					keyValuePair.Value.SetFarmlandFree();
					keyValuePair.Value.Destroy();
				}
			}
		}

		// Token: 0x0600B07E RID: 45182 RVA: 0x0021B414 File Offset: 0x00219614
		public void ResetGuildFarmland()
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_guildFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					keyValuePair.Value.SetFarmlandFree();
					keyValuePair.Value.Destroy();
				}
			}
		}

		// Token: 0x0600B07F RID: 45183 RVA: 0x0021B490 File Offset: 0x00219690
		public uint GetHomeFarmlandIdByNpcId(uint npcId)
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_homeFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					bool flag2 = keyValuePair.Value.NpcId == npcId;
					if (flag2)
					{
						return keyValuePair.Value.FarmlandID;
					}
				}
			}
			return 0U;
		}

		// Token: 0x0600B080 RID: 45184 RVA: 0x0021B51C File Offset: 0x0021971C
		public uint GetGuildFarmlandIdByNpcId(uint npcId)
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_guildFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					bool flag2 = keyValuePair.Value.NpcId == npcId;
					if (flag2)
					{
						return keyValuePair.Value.FarmlandID;
					}
				}
			}
			return 0U;
		}

		// Token: 0x0600B081 RID: 45185 RVA: 0x0021B5A8 File Offset: 0x002197A8
		public int GetBreakHomeFarmlandNum()
		{
			int num = 0;
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_homeFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					bool flag2 = !keyValuePair.Value.IsNeedBreak;
					if (flag2)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600B082 RID: 45186 RVA: 0x0021B62C File Offset: 0x0021982C
		public int GetBreakGuildFarmlandNum()
		{
			int num = 0;
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_guildFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					bool flag2 = !keyValuePair.Value.IsNeedBreak;
					if (flag2)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0600B083 RID: 45187 RVA: 0x0021B6B0 File Offset: 0x002198B0
		public void SetHomeFarmlandFxEffect()
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_homeFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					keyValuePair.Value.SetFxEffect();
				}
			}
		}

		// Token: 0x0600B084 RID: 45188 RVA: 0x0021B720 File Offset: 0x00219920
		public void SetGuildFarmlandFxEffect()
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_guildFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					keyValuePair.Value.SetFxEffect();
				}
			}
		}

		// Token: 0x0600B085 RID: 45189 RVA: 0x0021B790 File Offset: 0x00219990
		public void SetHomeFarmlandLock()
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_homeFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					keyValuePair.Value.SetLockStatus(true);
				}
			}
		}

		// Token: 0x0600B086 RID: 45190 RVA: 0x0021B800 File Offset: 0x00219A00
		public void SetGuildFarmlandLock()
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_guildFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					keyValuePair.Value.SetLockStatus(true);
				}
			}
		}

		// Token: 0x0600B087 RID: 45191 RVA: 0x0021B870 File Offset: 0x00219A70
		public void GetHomeNpcIds(ref List<uint> lst)
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_homeFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					lst.Add(keyValuePair.Value.NpcId);
				}
			}
		}

		// Token: 0x0600B088 RID: 45192 RVA: 0x0021B8E8 File Offset: 0x00219AE8
		public void GetGuildNpcIds(ref List<uint> lst)
		{
			foreach (KeyValuePair<uint, Farmland> keyValuePair in this.m_guildFarmlandDic)
			{
				bool flag = keyValuePair.Value != null;
				if (flag)
				{
					lst.Add(keyValuePair.Value.NpcId);
				}
			}
		}

		// Token: 0x040043DB RID: 17371
		public readonly int m_m_homeFarmlandNum = 6;

		// Token: 0x040043DC RID: 17372
		public readonly int m_guildFarmlandNum = 9;

		// Token: 0x040043DD RID: 17373
		private Dictionary<uint, Farmland> m_homeFarmlandDic;

		// Token: 0x040043DE RID: 17374
		private Dictionary<uint, Farmland> m_guildFarmlandDic;
	}
}
