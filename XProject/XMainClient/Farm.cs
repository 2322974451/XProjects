using System;
using System.Collections.Generic;

namespace XMainClient
{

	internal class Farm
	{

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

		public Dictionary<uint, Farmland> HomeFarmlandDic
		{
			get
			{
				return this.m_homeFarmlandDic;
			}
		}

		public Dictionary<uint, Farmland> GuildFarmlandDic
		{
			get
			{
				return this.m_guildFarmlandDic;
			}
		}

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

		public readonly int m_m_homeFarmlandNum = 6;

		public readonly int m_guildFarmlandNum = 9;

		private Dictionary<uint, Farmland> m_homeFarmlandDic;

		private Dictionary<uint, Farmland> m_guildFarmlandDic;
	}
}
