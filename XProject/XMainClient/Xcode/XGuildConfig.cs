using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildConfig
	{

		public uint MaxLevel
		{
			get
			{
				return this._MaxLevel;
			}
		}

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

		private GuildConfigTable m_ConfigTable;

		private Dictionary<XSysDefine, uint> m_UnlockLevel = new Dictionary<XSysDefine, uint>(default(XFastEnumIntEqualityComparer<XSysDefine>));

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

		private uint _MaxLevel;

		private List<uint> m_TotalExp = new List<uint>();

		private List<uint> m_BaseExp = new List<uint>();

		private List<uint> m_SkillCount = new List<uint>();
	}
}
