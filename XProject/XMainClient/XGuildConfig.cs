using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000E3C RID: 3644
	internal class XGuildConfig
	{
		// Token: 0x17003445 RID: 13381
		// (get) Token: 0x0600C3D2 RID: 50130 RVA: 0x002A9384 File Offset: 0x002A7584
		public uint MaxLevel
		{
			get
			{
				return this._MaxLevel;
			}
		}

		// Token: 0x0600C3D4 RID: 50132 RVA: 0x002A9464 File Offset: 0x002A7664
		public void Init(GuildConfigTable configTable)
		{
			this.m_BaseExp.Clear();
			this.m_TotalExp.Clear();
			this.m_SkillCount.Clear();
			this.m_ConfigTable = configTable;
			uint num = 0U;
			this._MaxLevel = (uint)this.m_ConfigTable.Table.Length;
			int num2 = 0;
			while ((long)num2 < (long)((ulong)this.MaxLevel))
			{
				GuildConfigTable.RowData rowData = this.m_ConfigTable.Table[num2];
				for (int i = 0; i < this._LockedSys.Length; i++)
				{
					bool flag = !this.m_UnlockLevel.ContainsKey(this._LockedSys[i]);
					if (flag)
					{
						int value = XGuildConfig.GetValue(rowData, this._LockedSys[i]);
						bool flag2 = value > 0;
						if (flag2)
						{
							this.m_UnlockLevel.Add(this._LockedSys[i], (uint)(num2 + 1));
						}
					}
				}
				this.m_BaseExp.Add(num);
				num += rowData.GuildExpNeed;
				this.m_TotalExp.Add(num);
				this.m_SkillCount.Add(rowData.StudySkillTimes);
				num2++;
			}
		}

		// Token: 0x0600C3D5 RID: 50133 RVA: 0x002A9584 File Offset: 0x002A7784
		public GuildConfigTable.RowData GetDataByLevel(uint level)
		{
			bool flag = level > this._MaxLevel || level == 0U;
			GuildConfigTable.RowData result;
			if (flag)
			{
				result = null;
			}
			else
			{
				result = this.m_ConfigTable.Table[(int)(level - 1U)];
			}
			return result;
		}

		// Token: 0x0600C3D6 RID: 50134 RVA: 0x002A95C0 File Offset: 0x002A77C0
		public static int GetValue(GuildConfigTable.RowData data, XSysDefine sys)
		{
			if (sys <= XSysDefine.XSys_GuildRelax_Joker)
			{
				if (sys <= XSysDefine.XSys_GuildHall_SignIn)
				{
					switch (sys)
					{
					case XSysDefine.XSys_GuildDragon:
						return (int)data.GuildDragon;
					case XSysDefine.XSys_GuildPvp:
						return data.GuildArena;
					case XSysDefine.XSys_GuildRedPacket:
						break;
					case XSysDefine.XSys_GuildMine:
						return data.GuildMine;
					case XSysDefine.XSys_CrossGVG:
						return data.CrossGVG;
					default:
						if (sys == XSysDefine.XSys_GuildHall_SignIn)
						{
							return data.GuildSign;
						}
						break;
					}
				}
				else
				{
					if (sys == XSysDefine.XSys_GuildHall_Skill)
					{
						return data.GuildSkill;
					}
					if (sys == XSysDefine.XSys_GuildRelax_Joker)
					{
						return data.PokerTimes;
					}
				}
			}
			else if (sys <= XSysDefine.XSys_GuildBoon_Salay)
			{
				if (sys == XSysDefine.XSys_GuildRelax_JokerMatch)
				{
					return data.GuildJokerMatch;
				}
				switch (sys)
				{
				case XSysDefine.XSys_GuildBoon_RedPacket:
					return data.GuildWelfare;
				case XSysDefine.XSys_GuildBoon_Shop:
					return data.GuildStore;
				case XSysDefine.XSys_GuildBoon_DailyActivity:
					return data.GuildActivity;
				case XSysDefine.XSys_GuildBoon_Salay:
					return data.GuildSalay;
				}
			}
			else
			{
				if (sys == XSysDefine.XSys_GuildChallenge)
				{
					return data.GuildChallenge;
				}
				if (sys == XSysDefine.XSys_GuildTerritory)
				{
					return data.GuildTerritory;
				}
			}
			return 0;
		}

		// Token: 0x0600C3D7 RID: 50135 RVA: 0x002A96F0 File Offset: 0x002A78F0
		public bool IsSysUnlock(XSysDefine sys, uint level)
		{
			uint num = 0U;
			bool flag = this.m_UnlockLevel.TryGetValue(sys, out num);
			bool result;
			if (flag)
			{
				bool flag2 = level >= num;
				result = flag2;
			}
			else
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0600C3D8 RID: 50136 RVA: 0x002A972C File Offset: 0x002A792C
		public uint GetUnlockLevel(XSysDefine sys)
		{
			uint num = 1U;
			bool flag = this.m_UnlockLevel.TryGetValue(sys, out num);
			uint result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 1U;
			}
			return result;
		}

		// Token: 0x0600C3D9 RID: 50137 RVA: 0x002A9758 File Offset: 0x002A7958
		public uint GetBaseExp(uint level)
		{
			bool flag = (ulong)level > (ulong)((long)this.m_BaseExp.Count) || level == 0U;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				result = this.m_BaseExp[(int)(level - 1U)];
			}
			return result;
		}

		// Token: 0x0600C3DA RID: 50138 RVA: 0x002A9798 File Offset: 0x002A7998
		public uint GetTotalStudyCount(int startLevel, int endLevel)
		{
			uint num = 0U;
			endLevel = Math.Min(endLevel, this.m_SkillCount.Count);
			startLevel = 1;
			bool flag = startLevel - 1 < endLevel;
			if (flag)
			{
				for (int i = startLevel - 1; i < endLevel; i++)
				{
					num += this.m_SkillCount[i];
				}
			}
			return num;
		}

		// Token: 0x0600C3DB RID: 50139 RVA: 0x002A97F4 File Offset: 0x002A79F4
		public uint GetTotalExp(uint level)
		{
			bool flag = (ulong)level > (ulong)((long)this.m_BaseExp.Count) || level == 0U;
			uint result;
			if (flag)
			{
				result = 0U;
			}
			else
			{
				result = this.m_TotalExp[(int)(level - 1U)];
			}
			return result;
		}

		// Token: 0x040054DC RID: 21724
		private GuildConfigTable m_ConfigTable;

		// Token: 0x040054DD RID: 21725
		private Dictionary<XSysDefine, uint> m_UnlockLevel = new Dictionary<XSysDefine, uint>(default(XFastEnumIntEqualityComparer<XSysDefine>));

		// Token: 0x040054DE RID: 21726
		private XSysDefine[] _LockedSys = new XSysDefine[]
		{
			XSysDefine.XSys_GuildHall_SignIn,
			XSysDefine.XSys_GuildHall_Skill,
			XSysDefine.XSys_GuildBoon_RedPacket,
			XSysDefine.XSys_GuildRelax_Joker,
			XSysDefine.XSys_GuildBoon_Shop,
			XSysDefine.XSys_GuildDragon,
			XSysDefine.XSys_GuildMine,
			XSysDefine.XSys_GuildPvp,
			XSysDefine.XSys_GuildBoon_DailyActivity,
			XSysDefine.XSys_GuildChallenge,
			XSysDefine.XSys_GuildRelax_JokerMatch,
			XSysDefine.XSys_GuildBoon_Salay,
			XSysDefine.XSys_GuildTerritory,
			XSysDefine.XSys_CrossGVG
		};

		// Token: 0x040054DF RID: 21727
		private uint _MaxLevel;

		// Token: 0x040054E0 RID: 21728
		private List<uint> m_TotalExp = new List<uint>();

		// Token: 0x040054E1 RID: 21729
		private List<uint> m_BaseExp = new List<uint>();

		// Token: 0x040054E2 RID: 21730
		private List<uint> m_SkillCount = new List<uint>();
	}
}
