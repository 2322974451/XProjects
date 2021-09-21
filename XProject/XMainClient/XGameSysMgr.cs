using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000DCA RID: 3530
	internal class XGameSysMgr : XSingleton<XGameSysMgr>, IGameSysMgr, IXInterface
	{
		// Token: 0x170033C9 RID: 13257
		// (get) Token: 0x0600C01B RID: 49179 RVA: 0x002854E4 File Offset: 0x002836E4
		// (set) Token: 0x0600C01C RID: 49180 RVA: 0x002854EC File Offset: 0x002836EC
		public bool Deprecated { get; set; }

		// Token: 0x170033CA RID: 13258
		// (get) Token: 0x0600C01D RID: 49181 RVA: 0x002854F8 File Offset: 0x002836F8
		// (set) Token: 0x0600C01E RID: 49182 RVA: 0x00285510 File Offset: 0x00283710
		public bool bStopBlockRedPoint
		{
			get
			{
				return this.m_bStopBlockRedPoint;
			}
			set
			{
				this.m_bStopBlockRedPoint = value;
				this.optionsDoc.SetValue(XOptionsDefine.OD_STOP_BLOCK_REDPOINT, this.m_bStopBlockRedPoint ? 1 : 0, false);
			}
		}

		// Token: 0x170033CB RID: 13259
		// (get) Token: 0x0600C01F RID: 49183 RVA: 0x00285538 File Offset: 0x00283738
		// (set) Token: 0x0600C020 RID: 49184 RVA: 0x00285550 File Offset: 0x00283750
		public float GetFlowerRemainTime
		{
			get
			{
				return this._getFlowerRemainTime;
			}
			set
			{
				this._getFlowerRemainTime = value;
			}
		}

		// Token: 0x170033CC RID: 13260
		// (get) Token: 0x0600C021 RID: 49185 RVA: 0x0028555C File Offset: 0x0028375C
		// (set) Token: 0x0600C022 RID: 49186 RVA: 0x00285574 File Offset: 0x00283774
		public float OnlineRewardRemainTime
		{
			get
			{
				return this._onlineRewardRemainTime;
			}
			set
			{
				this._onlineRewardRemainTime = value;
				this.RecalculateRedPointState(XSysDefine.XSys_OnlineReward, true);
			}
		}

		// Token: 0x0600C023 RID: 49187 RVA: 0x00285588 File Offset: 0x00283788
		public override bool Init()
		{
			bool flag = this._async_loader == null;
			if (flag)
			{
				this._async_loader = new XTableAsyncLoader();
				this._async_loader.AddTask("Table/SystemList", this._openSystemTable, false);
				this._async_loader.AddTask("Table/SystemAnnounce", this._announceSystemTable, false);
				this._async_loader.Execute(null);
			}
			bool flag2 = !this._async_loader.IsDone;
			bool result;
			if (flag2)
			{
				result = false;
			}
			else
			{
				int num = 0;
				Type typeFromHandle = typeof(XSysDefine);
				for (XSysDefine xsysDefine = XSysDefine.XSys_None; xsysDefine < XSysDefine.XSys_Num; xsysDefine++)
				{
					bool flag3 = Enum.IsDefined(typeFromHandle, xsysDefine);
					if (flag3)
					{
						num++;
					}
				}
				this._allXSysDefines = new XSysDefine[num];
				int num2 = 0;
				for (XSysDefine xsysDefine2 = XSysDefine.XSys_None; xsysDefine2 < XSysDefine.XSys_Num; xsysDefine2++)
				{
					bool flag4 = Enum.IsDefined(typeFromHandle, xsysDefine2);
					if (flag4)
					{
						this._allXSysDefines[num2++] = xsysDefine2;
					}
				}
				this.redPointState.Clear();
				this._CheckSystemId();
				this._InitAlwaysOpenedSystems();
				this._InitNoRedPointLevel();
				this.SetupSysAnnounceTable();
				result = true;
			}
			return result;
		}

		// Token: 0x170033CD RID: 13261
		// (get) Token: 0x0600C024 RID: 49188 RVA: 0x002856C4 File Offset: 0x002838C4
		public HashSet<XSysDefine> SysH5
		{
			get
			{
				return this._sysH5;
			}
		}

		// Token: 0x0600C025 RID: 49189 RVA: 0x002856DC File Offset: 0x002838DC
		public string GetSystemName(XSysDefine define)
		{
			int sysID = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(define);
			return this.GetSystemName(sysID);
		}

		// Token: 0x0600C026 RID: 49190 RVA: 0x002856FC File Offset: 0x002838FC
		public string GetSystemName(int sysID)
		{
			OpenSystemTable.RowData bySystemID = this._openSystemTable.GetBySystemID(sysID);
			return (bySystemID == null) ? string.Empty : bySystemID.SystemDescription;
		}

		// Token: 0x0600C027 RID: 49191 RVA: 0x0028572C File Offset: 0x0028392C
		public int GetSystemOpenLevel(XSysDefine define)
		{
			int key = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(define);
			OpenSystemTable.RowData bySystemID = this._openSystemTable.GetBySystemID(key);
			return (bySystemID == null) ? 0 : bySystemID.PlayerLevel;
		}

		// Token: 0x0600C028 RID: 49192 RVA: 0x00285760 File Offset: 0x00283960
		public OpenSystemTable.RowData GetSystemOpen(XSysDefine define)
		{
			int key = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(define);
			return this._openSystemTable.GetBySystemID(key);
		}

		// Token: 0x0600C029 RID: 49193 RVA: 0x00285788 File Offset: 0x00283988
		public override void Uninit()
		{
			this.redPointState.Clear();
			this.m_AnnounceSys.Clear();
			this.alwaysOpen.Clear();
			for (int i = 0; i < this.noRedPointLevel.Length; i++)
			{
				bool flag = this.noRedPointLevel[i] != null;
				if (flag)
				{
					this.noRedPointLevel[i].Clear();
				}
			}
			this._async_loader = null;
		}

		// Token: 0x0600C02A RID: 49194 RVA: 0x002857F9 File Offset: 0x002839F9
		public void Reset()
		{
			this.OnlineTime = null;
		}

		// Token: 0x0600C02B RID: 49195 RVA: 0x00285804 File Offset: 0x00283A04
		public void InitWhenSelectRole(uint level)
		{
			string[] names = Enum.GetNames(typeof(XSysDefine));
			Type typeFromHandle = typeof(XSysDefine);
			for (int i = 0; i < names.Length; i++)
			{
				XSysDefine xsysDefine = (XSysDefine)Enum.Parse(typeFromHandle, names[i]);
				bool flag = xsysDefine == XSysDefine.XSys_Invalid;
				if (!flag)
				{
					this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(xsysDefine), false);
				}
			}
			this.m_PlayerLevel = level;
			this.optionsDoc = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			this.bStopBlockRedPoint = (this.optionsDoc.GetValue(XOptionsDefine.OD_STOP_BLOCK_REDPOINT) != 0);
		}

		// Token: 0x0600C02C RID: 49196 RVA: 0x002858A4 File Offset: 0x00283AA4
		private void _InitAlwaysOpenedSystems()
		{
			for (int i = 0; i < this._allXSysDefines.Length; i++)
			{
				this.alwaysOpen.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(this._allXSysDefines[i]), true);
			}
			for (int j = 0; j < this._openSystemTable.Table.Length; j++)
			{
				this.alwaysOpen.SetFlag(this._openSystemTable.Table[j].SystemID, false);
			}
		}

		// Token: 0x0600C02D RID: 49197 RVA: 0x00285924 File Offset: 0x00283B24
		private void _InitNoRedPointLevel()
		{
			for (int i = 0; i < this._openSystemTable.Table.Length; i++)
			{
				OpenSystemTable.RowData rowData = this._openSystemTable.Table[i];
				List<uint> list = new List<uint>();
				bool flag = rowData.NoRedPointLevel != null;
				if (flag)
				{
					for (int j = 0; j < rowData.NoRedPointLevel.Length; j++)
					{
						bool flag2 = !list.Contains(rowData.NoRedPointLevel[j]);
						if (flag2)
						{
							list.Add(rowData.NoRedPointLevel[j]);
						}
					}
					bool flag3 = list.Count != 0;
					if (flag3)
					{
						this.noRedPointLevel[rowData.SystemID] = list;
					}
				}
				bool inNotice = rowData.InNotice;
				if (inNotice)
				{
					this._sysH5.Add((XSysDefine)rowData.SystemID);
				}
			}
		}

		// Token: 0x0600C02E RID: 49198 RVA: 0x00285A04 File Offset: 0x00283C04
		private void _CheckSystemId()
		{
			HashSet<int> hashSet = new HashSet<int>();
			hashSet.Clear();
			for (int i = 0; i < this._openSystemTable.Table.Length; i++)
			{
				bool flag = hashSet.Contains(this._openSystemTable.Table[i].SystemID);
				if (flag)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("SystemID repeated from systemList!!! repeated ID = ", this._openSystemTable.Table[i].SystemID.ToString(), null, null, null, null);
				}
				else
				{
					hashSet.Add(this._openSystemTable.Table[i].SystemID);
				}
			}
		}

		// Token: 0x0600C02F RID: 49199 RVA: 0x00285AA0 File Offset: 0x00283CA0
		public void OnLevelChanged(uint newLevel)
		{
			this.m_PlayerLevel = newLevel;
			this.bStopBlockRedPoint = false;
			bool flag = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.InitRedPointsWhenShow();
			}
		}

		// Token: 0x0600C030 RID: 49200 RVA: 0x00285AD8 File Offset: 0x00283CD8
		public bool IsSystemOpen(int sys)
		{
			return this.IsSystemOpened((XSysDefine)sys);
		}

		// Token: 0x0600C031 RID: 49201 RVA: 0x00285AF4 File Offset: 0x00283CF4
		public bool IsSystemOpened(XSysDefine sys)
		{
			XPlayerAttributes xplayerData = XSingleton<XAttributeMgr>.singleton.XPlayerData;
			bool flag = xplayerData == null;
			return !flag && this.IsSystemOpened(sys, xplayerData);
		}

		// Token: 0x0600C032 RID: 49202 RVA: 0x00285B28 File Offset: 0x00283D28
		public bool IsSystemOpened(XSysDefine sys, XPlayerAttributes attr)
		{
			bool flag = sys == XSysDefine.XSys_Invalid || sys == XSysDefine.XSys_Num;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				bool flag2 = this.alwaysOpen.IsFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys));
				result = (flag2 || attr.IsSystemOpened((uint)XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys)));
			}
			return result;
		}

		// Token: 0x0600C033 RID: 49203 RVA: 0x00285B78 File Offset: 0x00283D78
		protected void SetupSysAnnounceTable()
		{
			SystemAnnounce.RowData[] table = this._announceSystemTable.Table;
			List<int> list = ListPool<int>.Get();
			for (int i = 0; i < table.Length; i++)
			{
				bool flag = table[i].OpenAnnounceLevel == 0;
				if (!flag)
				{
					int num = 0;
					for (int j = 0; j < list.Count; j++)
					{
						bool flag2 = list[j] < table[i].OpenAnnounceLevel;
						if (flag2)
						{
							num++;
						}
					}
					list.Insert(num, table[i].OpenAnnounceLevel);
					this.m_AnnounceSys.Insert(num, table[i].ID);
				}
			}
			ListPool<int>.Release(list);
		}

		// Token: 0x0600C034 RID: 49204 RVA: 0x00285C2C File Offset: 0x00283E2C
		public void GamePause(bool pause)
		{
			XSingleton<XDebug>.singleton.AddLog(pause ? "Game to BackGround." : "Game back to ForeGround.", null, null, null, null, null, XDebugColor.XDebug_None);
			XSingleton<XClientNetwork>.singleton.OnGamePause(pause);
			for (int i = 0; i < XSingleton<XGame>.singleton.Doc.Components.Count; i++)
			{
				(XSingleton<XGame>.singleton.Doc.Components[i] as XDocComponent).OnGamePause(pause);
			}
			bool flag = XSingleton<XEntityMgr>.singleton.Player != null;
			if (flag)
			{
				XSingleton<XEntityMgr>.singleton.Player.OnGamePause(pause);
			}
		}

		// Token: 0x0600C035 RID: 49205 RVA: 0x00285CD0 File Offset: 0x00283ED0
		public XSysDefine GetNextAnnounceSystem(out int level)
		{
			XPlayerAttributes xplayerAttributes = XSingleton<XEntityMgr>.singleton.Player.Attributes as XPlayerAttributes;
			for (int i = 0; i < this.m_AnnounceSys.Count; i++)
			{
				int openAnnounceLevel = this._announceSystemTable.GetByID(this.m_AnnounceSys[i]).OpenAnnounceLevel;
				int num = (i == 0) ? 0 : this._announceSystemTable.GetByID(this.m_AnnounceSys[i - 1]).OpenAnnounceLevel;
				bool flag = (ulong)xplayerAttributes.Level < (ulong)((long)openAnnounceLevel) && (ulong)xplayerAttributes.Level >= (ulong)((long)num);
				if (flag)
				{
					level = openAnnounceLevel;
					return (XSysDefine)this._announceSystemTable.GetByID(this.m_AnnounceSys[i]).SystemID;
				}
			}
			level = 0;
			return XSysDefine.XSys_Invalid;
		}

		// Token: 0x0600C036 RID: 49206 RVA: 0x00285DAC File Offset: 0x00283FAC
		public void Update(float fDeltaT)
		{
			float num = this.GetFlowerRemainTime;
			bool flag = this.GetFlowerRemainTime > 0f;
			if (flag)
			{
				num -= fDeltaT;
			}
			bool flag2 = num <= 0f;
			if (flag2)
			{
				num = 0f;
			}
			this.GetFlowerRemainTime = num;
			float num2 = this.OnlineRewardRemainTime;
			num2 -= fDeltaT;
			bool flag3 = num2 <= 0f;
			if (flag3)
			{
				num2 = 0f;
			}
			this.OnlineRewardRemainTime = num2;
		}

		// Token: 0x0600C037 RID: 49207 RVA: 0x00285E28 File Offset: 0x00284028
		public List<XSysDefine> GetChildSys(XSysDefine sys)
		{
			this._ReturnList.Clear();
			if (sys <= XSysDefine.XSys_Team)
			{
				if (sys <= XSysDefine.XSys_MobaAcitivity)
				{
					if (sys <= XSysDefine.XSys_Rank)
					{
						switch (sys)
						{
						case XSysDefine.XSys_Level:
							this._ReturnList.Add(XSysDefine.XSys_Level_Normal);
							this._ReturnList.Add(XSysDefine.XSys_Level_Elite);
							return this._ReturnList;
						case XSysDefine.XSys_Item:
							this._ReturnList.Add(XSysDefine.XSys_Item_Equip);
							this._ReturnList.Add(XSysDefine.XSys_Fashion);
							this._ReturnList.Add(XSysDefine.XSys_Char_Emblem);
							this._ReturnList.Add(XSysDefine.XSys_Item_Jade);
							this._ReturnList.Add(XSysDefine.XSys_Artifact);
							this._ReturnList.Add(XSysDefine.XSys_Bag_Item);
							this._ReturnList.Add(XSysDefine.XSys_Design_Designation);
							return this._ReturnList;
						case XSysDefine.XSys_Skill:
							this._ReturnList.Add(XSysDefine.XSys_Skill_Levelup);
							this._ReturnList.Add(XSysDefine.XSys_Skill_Promote);
							return this._ReturnList;
						case XSysDefine.XSys_Char:
							this._ReturnList.Add(XSysDefine.XSys_Char_Attr);
							return this._ReturnList;
						case XSysDefine.XSys_Horse:
						case XSysDefine.XSys_Guild:
						case XSysDefine.XSys_Confession:
						case XSysDefine.XSys_Auction:
						case XSysDefine.XSys_TShowRule:
						case XSysDefine.XSys_CardCollect:
						case XSysDefine.XSys_Wifi:
						case XSysDefine.XSys_SuperReward:
						case XSysDefine.XSys_Draw:
						case XSysDefine.XSys_Strong:
						case XSysDefine.XSys_Target:
							break;
						case XSysDefine.XSys_Fashion:
							this._ReturnList.Add(XSysDefine.XSys_Fashion_Fashion);
							this._ReturnList.Add(XSysDefine.XSys_Fashion_OutLook);
							break;
						case XSysDefine.XSys_Recycle:
							this._ReturnList.Add(XSysDefine.XSys_Recycle_Equip);
							this._ReturnList.Add(XSysDefine.XSys_Recycle_Jade);
							return this._ReturnList;
						case XSysDefine.XSys_Bag:
							return this._ReturnList;
						case XSysDefine.XSys_TShow:
							this._ReturnList.Add(XSysDefine.XSys_TShow_Vote);
							this._ReturnList.Add(XSysDefine.XSys_TShow_Main);
							return this._ReturnList;
						case XSysDefine.XSys_FlowerRank:
							this._ReturnList.Add(XSysDefine.XSys_Flower_Rank_Today);
							this._ReturnList.Add(XSysDefine.XSys_Flower_Rank_Yesterday);
							this._ReturnList.Add(XSysDefine.XSys_Flower_Rank_Week);
							this._ReturnList.Add(XSysDefine.XSys_Flower_Rank_History);
							this._ReturnList.Add(XSysDefine.XSys_Flower_Rank_Activity);
							return this._ReturnList;
						case XSysDefine.XSys_Camp:
							this._ReturnList.Add(XSysDefine.XSys_Camp_CampHall);
							return this._ReturnList;
						case XSysDefine.XSys_Mail:
							this._ReturnList.Add(XSysDefine.XSys_Mail_System);
							return this._ReturnList;
						case XSysDefine.XSys_Design:
							this._ReturnList.Add(XSysDefine.XSys_Design_Achieve);
							return this._ReturnList;
						case XSysDefine.XSys_Mall:
							this._ReturnList.Add(XSysDefine.XSys_Mall_Mall);
							this._ReturnList.Add(XSysDefine.XSys_Mall_MystShop);
							return this._ReturnList;
						case XSysDefine.XSys_Reward:
							this._ReturnList.Add(XSysDefine.XSys_Design_Achieve);
							this._ReturnList.Add(XSysDefine.XSys_LevelReward);
							this._ReturnList.Add(XSysDefine.XSys_Reward_Target);
							this._ReturnList.Add(XSysDefine.XSys_ServerActivity);
							this._ReturnList.Add(XSysDefine.XSys_WeekShareReward);
							this._ReturnList.Add(XSysDefine.XSys_Reward_Dragon);
							return this._ReturnList;
						default:
							if (sys == XSysDefine.XSys_Rank)
							{
								this._ReturnList.Add(XSysDefine.XSys_Rank_Qualifying);
								this._ReturnList.Add(XSysDefine.XSys_Rank_SkyArena);
								this._ReturnList.Add(XSysDefine.XSys_Rank_CampDuel);
								this._ReturnList.Add(XSysDefine.XSys_Rank_Guild);
								this._ReturnList.Add(XSysDefine.XSys_Rank_GuildBoss);
								this._ReturnList.Add(XSysDefine.XSys_Rank_WorldBoss);
								this._ReturnList.Add(XSysDefine.XSys_FlowerRank);
								this._ReturnList.Add(XSysDefine.XSys_Rank_DragonGuild);
								this._ReturnList.Add(XSysDefine.XSys_Rank_BigMelee);
								this._ReturnList.Add(XSysDefine.XSys_Rank_TeamTower);
								this._ReturnList.Add(XSysDefine.XSys_Rank_Rift);
								this._ReturnList.Add(XSysDefine.XSys_Rank_Sprite);
								this._ReturnList.Add(XSysDefine.XSys_Rank_Pet);
								return this._ReturnList;
							}
							break;
						}
					}
					else
					{
						if (sys == XSysDefine.XSys_EquipCreate)
						{
							this._ReturnList.Add(XSysDefine.XSys_EquipCreate_EquipSet);
							this._ReturnList.Add(XSysDefine.XSys_EquipCreate_EmblemSet);
							this._ReturnList.Add(XSysDefine.XSys_EquipCreate_ArtifactSet);
							return this._ReturnList;
						}
						if (sys == XSysDefine.XSys_Activity)
						{
							this._ReturnList.Add(XSysDefine.XSys_Activity_Nest);
							this._ReturnList.Add(XSysDefine.XSys_Activity_WorldBoss);
							this._ReturnList.Add(XSysDefine.XSys_Activity_DragonNest);
							this._ReturnList.Add(XSysDefine.XSys_Activity_ExpeditionFrame);
							this._ReturnList.Add(XSysDefine.XSys_Activity_TeamTower);
							return this._ReturnList;
						}
						switch (sys)
						{
						case XSysDefine.XSys_DailyAcitivity:
							this._ReturnList.Add(XSysDefine.XSys_Activity);
							this._ReturnList.Add(XSysDefine.XSys_Reward_Activity);
							return this._ReturnList;
						case XSysDefine.XSys_PVPAcitivity:
							this._ReturnList.Add(XSysDefine.XSys_Qualifying);
							this._ReturnList.Add(XSysDefine.XSys_HeroBattle);
							this._ReturnList.Add(XSysDefine.XSys_Activity_CaptainPVP);
							this._ReturnList.Add(XSysDefine.XSys_WeekNest);
							this._ReturnList.Add(XSysDefine.XSys_TeamLeague);
							this._ReturnList.Add(XSysDefine.XSys_CustomBattle);
							this._ReturnList.Add(XSysDefine.XSys_HallFame);
							return this._ReturnList;
						case XSysDefine.XSys_MobaAcitivity:
							this._ReturnList.Add(XSysDefine.XSys_PVPAcitivity);
							return this._ReturnList;
						}
					}
				}
				else if (sys <= XSysDefine.XSys_Carnival)
				{
					if (sys == XSysDefine.XSys_GameMall)
					{
						this._ReturnList.Add(XSysDefine.XSys_GameMall_Diamond);
						this._ReturnList.Add(XSysDefine.XSys_GameMall_Dragon);
						this._ReturnList.Add(XSysDefine.XSys_Mall);
						this._ReturnList.Add(XSysDefine.XSys_GameMall_Pay);
						return this._ReturnList;
					}
					if (sys == XSysDefine.XSys_Carnival)
					{
						this._ReturnList.Add(XSysDefine.XSys_Carnival_Content);
						this._ReturnList.Add(XSysDefine.XSys_Carnival_Rwd);
						this._ReturnList.Add(XSysDefine.XSys_Carnival_Tabs);
						return this._ReturnList;
					}
				}
				else
				{
					if (sys == XSysDefine.XSys_GuildHall)
					{
						this._ReturnList.Add(XSysDefine.XSys_GuildHall_SignIn);
						this._ReturnList.Add(XSysDefine.XSys_GuildHall_Approve);
						this._ReturnList.Add(XSysDefine.XSys_GuildHall_Skill);
						this._ReturnList.Add(XSysDefine.XSys_GuildHall_Member);
						this._ReturnList.Add(XSysDefine.XSys_GuildDungeon_SmallMonter);
						this._ReturnList.Add(XSysDefine.XSys_GuildBoon_Salay);
						this._ReturnList.Add(XSysDefine.XSys_GuildRelax_Joker);
						return this._ReturnList;
					}
					if (sys == XSysDefine.XSys_GuildRelax)
					{
						this._ReturnList.Add(XSysDefine.XSys_GuildRelax_VoiceQA);
						this._ReturnList.Add(XSysDefine.XSys_GuildRelax_JokerMatch);
						return this._ReturnList;
					}
					if (sys == XSysDefine.XSys_Team)
					{
						this._ReturnList.Add(XSysDefine.XSys_Team_TeamList);
						this._ReturnList.Add(XSysDefine.XSys_Team_MyTeam);
						return this._ReturnList;
					}
				}
			}
			else if (sys <= XSysDefine.Xsys_Backflow)
			{
				if (sys <= XSysDefine.XSys_CustomBattle)
				{
					if (sys == XSysDefine.XSys_Home)
					{
						this._ReturnList.Add(XSysDefine.XSys_Home_MyHome);
						this._ReturnList.Add(XSysDefine.XSys_Home_HomeFriends);
						this._ReturnList.Add(XSysDefine.XSys_Home_Cooking);
						this._ReturnList.Add(XSysDefine.XSys_Home_Feast);
						return this._ReturnList;
					}
					if (sys == XSysDefine.XSys_CustomBattle)
					{
						this._ReturnList.Add(XSysDefine.XSys_CustomBattle_BountyMode);
						this._ReturnList.Add(XSysDefine.XSys_CustomBattle_CustomMode);
						return this._ReturnList;
					}
				}
				else
				{
					if (sys == XSysDefine.XSys_Artifact_DeityStove)
					{
						this._ReturnList.Add(XSysDefine.XSys_Artifact_Comepose);
						this._ReturnList.Add(XSysDefine.XSys_Artifact_Recast);
						this._ReturnList.Add(XSysDefine.XSys_Artifact_Fuse);
						this._ReturnList.Add(XSysDefine.XSys_Artifact_Inscription);
						this._ReturnList.Add(XSysDefine.XSys_Artifact_Refined);
						return this._ReturnList;
					}
					if (sys == XSysDefine.XSys_Flower_Log)
					{
						this._ReturnList.Add(XSysDefine.XSys_Flower_Log_Send);
						this._ReturnList.Add(XSysDefine.XSys_Flower_Log_Receive);
						return this._ReturnList;
					}
					if (sys == XSysDefine.Xsys_Backflow)
					{
						this._ReturnList.Add(XSysDefine.XSys_BackFlowMall);
						this._ReturnList.Add(XSysDefine.XSys_BackFlowWelfare);
						this._ReturnList.Add(XSysDefine.Xsys_Backflow_LavishGift);
						this._ReturnList.Add(XSysDefine.Xsys_Backflow_NewServerReward);
						this._ReturnList.Add(XSysDefine.Xsys_Backflow_LavishGift);
						this._ReturnList.Add(XSysDefine.Xsys_Backflow_Target);
						this._ReturnList.Add(XSysDefine.Xsys_Backflow_Task);
						return this._ReturnList;
					}
				}
			}
			else if (sys <= XSysDefine.XSys_GuildBoon_RedPacket)
			{
				if (sys == XSysDefine.XSys_OperatingActivity)
				{
					this._ReturnList.Add(XSysDefine.XSys_FirstPass);
					this._ReturnList.Add(XSysDefine.XSys_CampDuel);
					this._ReturnList.Add(XSysDefine.XSys_MWCX);
					this._ReturnList.Add(XSysDefine.XSys_GHJC);
					this._ReturnList.Add(XSysDefine.XSys_Flower_Activity);
					this._ReturnList.Add(XSysDefine.XSys_CrushingSeal);
					this._ReturnList.Add(XSysDefine.XSys_LevelSeal);
					this._ReturnList.Add(XSysDefine.XSys_OldFriendsBack);
					this._ReturnList.Add(XSysDefine.XSys_Holiday);
					this._ReturnList.Add(XSysDefine.XSys_Announcement);
					this._ReturnList.Add(XSysDefine.XSys_Shanggu);
					this._ReturnList.Add(XSysDefine.XSys_LuckyTurntable);
					return this._ReturnList;
				}
				if (sys == XSysDefine.XSys_ThemeActivity)
				{
					this._ReturnList.Add(XSysDefine.XSys_ThemeActivity_HellDog);
					this._ReturnList.Add(XSysDefine.XSys_ThemeActivity_MadDuck);
					return this._ReturnList;
				}
				if (sys == XSysDefine.XSys_GuildBoon_RedPacket)
				{
					this._ReturnList.Add(XSysDefine.XSys_GuildBoon_FixedRedPacket);
					this._ReturnList.Add(XSysDefine.XSys_GuildRedPacket);
					return this._ReturnList;
				}
			}
			else
			{
				if (sys == XSysDefine.XSys_GuildChallenge)
				{
					this._ReturnList.Add(XSysDefine.XSys_GuildChallenge_MemberRank);
					this._ReturnList.Add(XSysDefine.XSys_GuildChallenge_GuildRank);
					return this._ReturnList;
				}
				if (sys == XSysDefine.XSys_SpriteSystem)
				{
					this._ReturnList.Add(XSysDefine.XSys_SpriteSystem_Main);
					this._ReturnList.Add(XSysDefine.XSys_SpriteSystem_Fight);
					this._ReturnList.Add(XSysDefine.XSys_SpriteSystem_Shop);
					this._ReturnList.Add(XSysDefine.XSys_SpriteSystem_Lottery);
					this._ReturnList.Add(XSysDefine.XSys_SpriteSystem_Resolve);
					return this._ReturnList;
				}
				if (sys == XSysDefine.XSys_GameCommunity)
				{
					this._ReturnList.Add(XSysDefine.XSys_GC_XinYueVIP);
					this._ReturnList.Add(XSysDefine.XSys_GC_XiaoYueGuanJia);
					this._ReturnList.Add(XSysDefine.XSys_GC_Reserve17);
					this._ReturnList.Add(XSysDefine.XSys_GC_Reserve18);
					this._ReturnList.Add(XSysDefine.XSys_GC_Reserve19);
					this._ReturnList.Add(XSysDefine.XSys_GC_Reserve20);
					this._ReturnList.Add(XSysDefine.XSys_GC_Reserve21);
					return this._ReturnList;
				}
			}
			this._ReturnList.Add(sys);
			return this._ReturnList;
		}

		// Token: 0x0600C038 RID: 49208 RVA: 0x00286A5C File Offset: 0x00284C5C
		public XSysDefine GetParentSys(XSysDefine sys)
		{
			XSysDefine result = sys;
			if (sys <= XSysDefine.XSys_PrerogativeShop)
			{
				if (sys <= XSysDefine.XSys_Char_Attr)
				{
					if (sys <= XSysDefine.XSys_WeekShareReward)
					{
						if (sys <= XSysDefine.XSys_Mall)
						{
							if (sys == XSysDefine.XSys_Fashion)
							{
								goto IL_5F6;
							}
							if (sys == XSysDefine.XSys_FlowerRank)
							{
								goto IL_63E;
							}
							if (sys != XSysDefine.XSys_Mall)
							{
								return result;
							}
							goto IL_62E;
						}
						else
						{
							switch (sys)
							{
							case XSysDefine.XSys_ServerActivity:
							case XSysDefine.XSys_LevelReward:
								break;
							case (XSysDefine)38:
							case XSysDefine.XSys_OnlineReward:
							case XSysDefine.XSys_Setting:
							case XSysDefine.XSys_Rank:
							case (XSysDefine)43:
							case XSysDefine.XSys_EquipCreate:
							case XSysDefine.XSys_SystemActivity:
							case (XSysDefine)53:
								return result;
							case XSysDefine.XSys_ReceiveEnergy:
								goto IL_697;
							case XSysDefine.XSys_LevelSeal:
								goto IL_6B9;
							case XSysDefine.XSys_BossRush:
							case XSysDefine.XSys_SuperRisk:
							case XSysDefine.XSys_DragonCrusade:
							case XSysDefine.XSys_Arena:
								goto IL_60E;
							case XSysDefine.XSys_Activity:
								goto IL_69F;
							case XSysDefine.XSys_Qualifying:
								goto IL_616;
							default:
								if (sys == XSysDefine.XSys_PVPAcitivity)
								{
									return XSysDefine.XSys_MobaAcitivity;
								}
								if (sys != XSysDefine.XSys_WeekShareReward)
								{
									return result;
								}
								break;
							}
						}
					}
					else if (sys <= XSysDefine.XSys_Level_Swap)
					{
						if (sys == XSysDefine.XSys_GuildRedPacket)
						{
							goto IL_67D;
						}
						if (sys == XSysDefine.XSys_HallFame)
						{
							goto IL_616;
						}
						if (sys - XSysDefine.XSys_Level_Normal > 2)
						{
							return result;
						}
						return XSysDefine.XSys_Level;
					}
					else if (sys <= XSysDefine.XSys_Item_Enchant)
					{
						if (sys - XSysDefine.XSys_Item_Equip > 2 && sys != XSysDefine.XSys_Item_Enchant)
						{
							return result;
						}
						goto IL_5F6;
					}
					else
					{
						if (sys - XSysDefine.XSys_Skill_Levelup <= 1)
						{
							return XSysDefine.XSys_Skill;
						}
						if (sys != XSysDefine.XSys_Char_Attr)
						{
							return result;
						}
						return XSysDefine.XSys_Char;
					}
				}
				else if (sys <= XSysDefine.XSys_CustomBattle_CustomMode)
				{
					if (sys <= XSysDefine.XSys_Recycle_Jade)
					{
						if (sys == XSysDefine.XSys_Char_Emblem)
						{
							goto IL_5F6;
						}
						switch (sys)
						{
						case XSysDefine.XSys_Home_Cooking:
						case XSysDefine.XSys_Home_Feast:
						case XSysDefine.XSys_Home_MyHome:
						case XSysDefine.XSys_Home_HomeFriends:
							return XSysDefine.XSys_Home;
						case XSysDefine.XSys_Home_Fishing:
						case XSysDefine.XSys_Home_Plant:
						case (XSysDefine)157:
						case (XSysDefine)158:
						case XSysDefine.XSys_Horse_LearnSkill:
							return result;
						case XSysDefine.XSys_Fashion_Fashion:
						case XSysDefine.XSys_Fashion_OutLook:
							return XSysDefine.XSys_Fashion;
						default:
							if (sys - XSysDefine.XSys_Recycle_Equip > 1)
							{
								return result;
							}
							return XSysDefine.XSys_Recycle;
						}
					}
					else
					{
						if (sys == XSysDefine.XSys_Bag_Item)
						{
							goto IL_5F6;
						}
						if (sys - XSysDefine.XSys_TShow_Vote <= 1)
						{
							return XSysDefine.XSys_TShow;
						}
						if (sys - XSysDefine.XSys_CustomBattle_BountyMode > 1)
						{
							return result;
						}
						return XSysDefine.XSys_CustomBattle;
					}
				}
				else if (sys <= XSysDefine.XSys_Mail_System)
				{
					if (sys - XSysDefine.XSys_Camp_CampHall <= 1 || sys == XSysDefine.XSys_Camp_Mission)
					{
						return XSysDefine.XSys_Camp;
					}
					if (sys != XSysDefine.XSys_Mail_System)
					{
						return result;
					}
					return XSysDefine.XSys_Mail;
				}
				else
				{
					if (sys > XSysDefine.XSys_Design_Achieve)
					{
						if (sys - XSysDefine.XSys_Mall_MystShop > 5)
						{
							switch (sys)
							{
							case XSysDefine.XSys_Reward_Activity:
								goto IL_69F;
							case (XSysDefine)352:
							case (XSysDefine)354:
							case XSysDefine.XSys_Prerogative:
								return result;
							case XSysDefine.XSys_Reward_Login:
								goto IL_697;
							case XSysDefine.XSys_Reward_Dragon:
							case XSysDefine.XSys_Reward_Target:
								goto IL_5FE;
							case XSysDefine.XSys_PrerogativeShop:
								break;
							default:
								return result;
							}
						}
						return XSysDefine.XSys_Mall;
					}
					if (sys == XSysDefine.XSys_Design_Designation)
					{
						goto IL_5F6;
					}
					if (sys != XSysDefine.XSys_Design_Achieve)
					{
						return result;
					}
				}
				IL_5FE:
				return XSysDefine.XSys_Reward;
				IL_69F:
				return XSysDefine.XSys_DailyAcitivity;
			}
			if (sys <= XSysDefine.XSys_GC_XiaoYueGuanJia)
			{
				if (sys <= XSysDefine.XSys_Welfare_NiceGirl)
				{
					if (sys <= XSysDefine.XSys_SystemActivity_Other)
					{
						switch (sys)
						{
						case XSysDefine.XSys_Artifact:
							goto IL_5F6;
						case XSysDefine.XSys_Artifact_Comepose:
						case XSysDefine.XSys_Artifact_Recast:
						case XSysDefine.XSys_Artifact_Fuse:
						case XSysDefine.XSys_Artifact_Inscription:
						case XSysDefine.XSys_Artifact_Refined:
							return XSysDefine.XSys_Artifact_DeityStove;
						case XSysDefine.XSys_Artifact_Atlas:
						case XSysDefine.XSys_Artifact_DeityStove:
							return result;
						default:
							switch (sys)
							{
							case XSysDefine.XSys_Rank_Rift:
							case XSysDefine.XSys_Rank_WorldBoss:
							case XSysDefine.XSys_Rank_Guild:
							case XSysDefine.XSys_Rank_Fashion:
							case XSysDefine.XSys_Rank_TeamTower:
							case XSysDefine.XSys_Rank_GuildBoss:
							case XSysDefine.XSys_Rank_Pet:
							case XSysDefine.XSys_Rank_Sprite:
							case XSysDefine.XSys_Rank_Qualifying:
							case XSysDefine.XSys_Rank_BigMelee:
							case XSysDefine.XSys_Rank_DragonGuild:
							case XSysDefine.XSys_Rank_SkyArena:
							case XSysDefine.XSys_Rank_CampDuel:
								goto IL_63E;
							case XSysDefine.XSys_Rank_PPT:
							case XSysDefine.XSys_Rank_Level:
							case XSysDefine.XSys_Flower_Log:
							case (XSysDefine)428:
							case (XSysDefine)429:
							case (XSysDefine)433:
							case (XSysDefine)434:
							case (XSysDefine)435:
							case (XSysDefine)436:
							case (XSysDefine)437:
							case (XSysDefine)438:
							case (XSysDefine)439:
							case XSysDefine.XSys_Yorozuya:
							case (XSysDefine)441:
							case (XSysDefine)442:
							case (XSysDefine)443:
							case (XSysDefine)444:
							case (XSysDefine)445:
							case (XSysDefine)446:
							case (XSysDefine)447:
							case (XSysDefine)448:
							case (XSysDefine)449:
								return result;
							case XSysDefine.XSys_Flower_Rank_Today:
							case XSysDefine.XSys_Flower_Rank_Yesterday:
							case XSysDefine.XSys_Flower_Rank_History:
							case XSysDefine.XSys_Flower_Rank_Week:
							case XSysDefine.XSys_Flower_Rank_Activity:
								return XSysDefine.XSys_FlowerRank;
							case XSysDefine.XSys_Flower_Log_Send:
							case XSysDefine.XSys_Flower_Log_Receive:
								return XSysDefine.XSys_Flower_Log;
							case XSysDefine.XSys_EquipCreate_EquipSet:
							case XSysDefine.XSys_EquipCreate_EmblemSet:
							case XSysDefine.XSys_EquipCreate_ArtifactSet:
								return XSysDefine.XSys_EquipCreate;
							default:
								if (sys != XSysDefine.XSys_SystemActivity_Other)
								{
									return result;
								}
								return XSysDefine.XSys_SystemActivity;
							}
							break;
						}
					}
					else
					{
						switch (sys)
						{
						case XSysDefine.XSys_Activity_Nest:
						case XSysDefine.XSys_Activity_SmallMonster:
						case XSysDefine.XSys_Activity_Fashion:
						case XSysDefine.XSys_Activity_WorldBoss:
						case XSysDefine.XSys_Activity_ExpeditionFrame:
						case XSysDefine.XSys_Activity_DragonNest:
						case XSysDefine.XSys_Activity_TeamTower:
						case XSysDefine.XSys_Activity_GoddessTrial:
						case XSysDefine.XSys_Activity_TeamTowerSingle:
						case XSysDefine.XSys_EndlessAbyss:
							goto IL_60E;
						case XSysDefine.XSys_Activity_BossRush:
						case XSysDefine.XSys_BigMelee:
						case XSysDefine.XSys_BigMeleeEnd:
						case XSysDefine.XSys_Battlefield:
						case (XSysDefine)534:
						case (XSysDefine)535:
						case (XSysDefine)536:
						case (XSysDefine)537:
						case (XSysDefine)538:
						case (XSysDefine)539:
							return result;
						case XSysDefine.XSys_Activity_CaptainPVP:
							goto IL_616;
						case XSysDefine.XSys_Shanggu:
							goto IL_6B9;
						default:
							if (sys - XSysDefine.XSys_Welfare_GiftBag > 3 && sys != XSysDefine.XSys_Welfare_NiceGirl)
							{
								return result;
							}
							goto IL_697;
						}
					}
				}
				else if (sys <= XSysDefine.XSys_LuckyTurntable)
				{
					switch (sys)
					{
					case XSysDefine.Xsys_Backflow_LavishGift:
					case XSysDefine.Xsys_Backflow_NewServerReward:
					case XSysDefine.Xsys_Backflow_LevelUp:
					case XSysDefine.Xsys_Backflow_Task:
					case XSysDefine.Xsys_Backflow_Target:
					case XSysDefine.Xsys_Backflow_Privilege:
						goto IL_6E1;
					case XSysDefine.Xsys_Backflow_Dailylogin:
					case XSysDefine.Xsys_Backflow_GiftBag:
					case XSysDefine.Xsys_Server_Two:
						return result;
					default:
						switch (sys)
						{
						case XSysDefine.XSys_FirstPass:
						case XSysDefine.XSys_MWCX:
						case XSysDefine.XSys_GHJC:
						case XSysDefine.XSys_Flower_Activity:
						case XSysDefine.XSys_CrushingSeal:
						case XSysDefine.XSys_Holiday:
						case XSysDefine.XSys_Announcement:
						case XSysDefine.XSys_OldFriendsBack:
						case XSysDefine.XSys_CampDuel:
							goto IL_6B9;
						case XSysDefine.XSys_GuildRank:
						case (XSysDefine)608:
						case XSysDefine.XSys_Patface:
						case XSysDefine.XSys_PandoraSDK:
							return result;
						case XSysDefine.XSys_WeekNest:
							goto IL_616;
						default:
							if (sys != XSysDefine.XSys_LuckyTurntable)
							{
								return result;
							}
							goto IL_6B9;
						}
						break;
					}
				}
				else if (sys <= XSysDefine.XSys_Carnival_Content)
				{
					if (sys - XSysDefine.XSys_GameMall_Diamond <= 2)
					{
						goto IL_62E;
					}
					if (sys - XSysDefine.XSys_Carnival_Tabs > 2)
					{
						return result;
					}
					return XSysDefine.XSys_Carnival;
				}
				else if (sys != XSysDefine.XSys_GC_XinYueVIP && sys != XSysDefine.XSys_GC_XiaoYueGuanJia)
				{
					return result;
				}
			}
			else
			{
				if (sys <= XSysDefine.XSys_GuildDungeon_SmallMonter)
				{
					if (sys <= XSysDefine.XSys_GuildRelax_JokerMatch)
					{
						if (sys - XSysDefine.XSys_GC_Reserve17 <= 4)
						{
							goto IL_6D9;
						}
						if (sys - XSysDefine.XSys_ThemeActivity_HellDog <= 1)
						{
							return XSysDefine.XSys_ThemeActivity;
						}
						switch (sys)
						{
						case XSysDefine.XSys_GuildHall_SignIn:
						case XSysDefine.XSys_GuildHall_Approve:
						case XSysDefine.XSys_GuildHall_Skill:
						case XSysDefine.XSys_GuildHall_Member:
						case XSysDefine.XSys_GuildRelax_Joker:
							break;
						case (XSysDefine)814:
						case (XSysDefine)815:
						case (XSysDefine)816:
						case (XSysDefine)817:
						case (XSysDefine)818:
						case (XSysDefine)819:
							return result;
						case XSysDefine.XSys_GuildRelax_VoiceQA:
						case XSysDefine.XSys_GuildRelax_JokerMatch:
							return XSysDefine.XSys_GuildRelax;
						default:
							return result;
						}
					}
					else if (sys != XSysDefine.XSys_GuildBoon_Salay)
					{
						if (sys == XSysDefine.XSys_GuildBoon_FixedRedPacket)
						{
							goto IL_67D;
						}
						if (sys != XSysDefine.XSys_GuildDungeon_SmallMonter)
						{
							return result;
						}
					}
					return XSysDefine.XSys_GuildHall;
				}
				if (sys <= XSysDefine.XSys_SpriteSystem_Resolve)
				{
					if (sys - XSysDefine.XSys_GuildChallenge_MemberRank <= 1)
					{
						return XSysDefine.XSys_GuildChallenge;
					}
					if (sys - XSysDefine.XSys_Team_TeamList <= 1)
					{
						return XSysDefine.XSys_Team;
					}
					if (sys - XSysDefine.XSys_SpriteSystem_Main > 3)
					{
						return result;
					}
				}
				else if (sys <= XSysDefine.XSys_HeroBattle)
				{
					if (sys != XSysDefine.XSys_SpriteSystem_Shop)
					{
						if (sys != XSysDefine.XSys_HeroBattle)
						{
							return result;
						}
						goto IL_616;
					}
				}
				else
				{
					if (sys == XSysDefine.XSys_TeamLeague)
					{
						goto IL_616;
					}
					if (sys != XSysDefine.XSys_BackFlowMall)
					{
						return result;
					}
					goto IL_6E1;
				}
				return XSysDefine.XSys_SpriteSystem;
			}
			IL_6D9:
			return XSysDefine.XSys_GameCommunity;
			IL_6E1:
			return XSysDefine.Xsys_Backflow;
			IL_5F6:
			return XSysDefine.XSys_Item;
			IL_60E:
			return XSysDefine.XSys_Activity;
			IL_616:
			return XSysDefine.XSys_PVPAcitivity;
			IL_62E:
			return XSysDefine.XSys_GameMall;
			IL_63E:
			return XSysDefine.XSys_Rank;
			IL_67D:
			return XSysDefine.XSys_GuildBoon_RedPacket;
			IL_697:
			return XSysDefine.XSys_Welfare;
			IL_6B9:
			result = XSysDefine.XSys_OperatingActivity;
			return result;
		}

		// Token: 0x0600C039 RID: 49209 RVA: 0x00287158 File Offset: 0x00285358
		public OpenSystemTable.RowData GetSysData(int sysid)
		{
			return this._openSystemTable.GetBySystemID(sysid);
		}

		// Token: 0x0600C03A RID: 49210 RVA: 0x00287178 File Offset: 0x00285378
		public SystemAnnounce.RowData GetSysAnnounceData(int sysid, int level)
		{
			for (int i = 0; i < this._announceSystemTable.Table.Length; i++)
			{
				bool flag = this._announceSystemTable.Table[i].SystemID == sysid && this._announceSystemTable.Table[i].OpenAnnounceLevel == level;
				if (flag)
				{
					return this._announceSystemTable.Table[i];
				}
			}
			return null;
		}

		// Token: 0x0600C03B RID: 49211 RVA: 0x002871EC File Offset: 0x002853EC
		public SystemAnnounce.RowData GetSysAnnounceData(uint level)
		{
			for (int i = 0; i < this._announceSystemTable.Table.Length; i++)
			{
				bool flag = (long)this._announceSystemTable.Table[i].OpenAnnounceLevel >= (long)((ulong)level);
				if (flag)
				{
					bool flag2 = (long)this._announceSystemTable.Table[i].OpenAnnounceLevel > (long)((ulong)level);
					SystemAnnounce.RowData result;
					if (flag2)
					{
						result = this._announceSystemTable.Table[i];
					}
					else
					{
						bool flag3 = !this.IsSystemOpen(this._announceSystemTable.Table[i].SystemID);
						if (!flag3)
						{
							goto IL_87;
						}
						result = this._announceSystemTable.Table[i];
					}
					return result;
				}
				IL_87:;
			}
			return null;
		}

		// Token: 0x0600C03C RID: 49212 RVA: 0x002872A4 File Offset: 0x002854A4
		public int GetSysOpenLevel(int sysid)
		{
			OpenSystemTable.RowData bySystemID = this._openSystemTable.GetBySystemID(sysid);
			bool flag = bySystemID != null;
			int result;
			if (flag)
			{
				result = bySystemID.PlayerLevel;
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600C03D RID: 49213 RVA: 0x002872D8 File Offset: 0x002854D8
		public int GetSysOpenServerDay(int sysid)
		{
			OpenSystemTable.RowData bySystemID = this._openSystemTable.GetBySystemID(sysid);
			bool flag = bySystemID != null;
			int result;
			if (flag)
			{
				bool flag2 = XSingleton<XAttributeMgr>.singleton.LoginExData != null && XSingleton<XAttributeMgr>.singleton.LoginExData.is_backflow_server;
				if (flag2)
				{
					bool flag3 = bySystemID.BackServerOpenDay.Count == 0;
					if (flag3)
					{
						result = 0;
					}
					else
					{
						for (int i = 0; i < bySystemID.BackServerOpenDay.Count; i++)
						{
							bool flag4 = XSingleton<XAttributeMgr>.singleton.LoginExData.backflow_level <= bySystemID.BackServerOpenDay[i, 0];
							if (flag4)
							{
								return (int)bySystemID.BackServerOpenDay[i, 1];
							}
						}
						result = (int)bySystemID.BackServerOpenDay[bySystemID.BackServerOpenDay.Count - 1, 1];
					}
				}
				else
				{
					result = (int)bySystemID.OpenDay;
				}
			}
			else
			{
				result = 0;
			}
			return result;
		}

		// Token: 0x0600C03E RID: 49214 RVA: 0x002873CC File Offset: 0x002855CC
		public int GetSysOpenLevel(XSysDefine sys)
		{
			return this.GetSysOpenLevel(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys));
		}

		// Token: 0x0600C03F RID: 49215 RVA: 0x002873EC File Offset: 0x002855EC
		public string GetSysName(int sysid)
		{
			OpenSystemTable.RowData bySystemID = this._openSystemTable.GetBySystemID(sysid);
			bool flag = bySystemID != null;
			string result;
			if (flag)
			{
				result = bySystemID.SystemDescription;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600C040 RID: 49216 RVA: 0x00287420 File Offset: 0x00285620
		public string GetSysIcon(int sysid)
		{
			OpenSystemTable.RowData bySystemID = this._openSystemTable.GetBySystemID(sysid);
			bool flag = bySystemID != null;
			string result;
			if (flag)
			{
				result = bySystemID.Icon;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x0600C041 RID: 49217 RVA: 0x00287454 File Offset: 0x00285654
		public string GetSysAnnounceIcon(int sysid)
		{
			for (int i = 0; i < this._announceSystemTable.Table.Length; i++)
			{
				bool flag = sysid == this._announceSystemTable.Table[i].SystemID;
				if (flag)
				{
					return this._announceSystemTable.Table[i].AnnounceIcon;
				}
			}
			return null;
		}

		// Token: 0x0600C042 RID: 49218 RVA: 0x002874B4 File Offset: 0x002856B4
		public void OnSysOpen(XSysDefine sys)
		{
			if (sys <= XSysDefine.XSys_Char)
			{
				if (sys != XSysDefine.XSys_Skill)
				{
					if (sys != XSysDefine.XSys_Char)
					{
					}
				}
			}
			else if (sys != XSysDefine.XSys_Draw)
			{
				if (sys != XSysDefine.XSys_Item_Equip)
				{
				}
			}
		}

		// Token: 0x0600C043 RID: 49219 RVA: 0x002874F0 File Offset: 0x002856F0
		public void RecalculateRedPointState(XSysDefine sys, bool bImmUpdateUI = true)
		{
			if (sys <= XSysDefine.XSys_GuildRelax_JokerMatch)
			{
				switch (sys)
				{
				case XSysDefine.XSys_GuildHall:
				case XSysDefine.XSys_GuildRelax:
				case XSysDefine.XSys_GuildDragon:
				case XSysDefine.XSys_GuildPvp:
				case XSysDefine.XSys_GuildMine:
					break;
				case (XSysDefine)83:
				case (XSysDefine)84:
				case XSysDefine.XSys_GuildRedPacket:
					goto IL_AC;
				default:
					if (sys - XSysDefine.XSys_Welfare_GiftBag > 9)
					{
						if (sys != XSysDefine.XSys_GuildRelax_JokerMatch)
						{
							goto IL_AC;
						}
					}
					else
					{
						bool flag = !this.IsSystemOpened(XSysDefine.XSys_Welfare);
						if (flag)
						{
							return;
						}
						goto IL_C3;
					}
					break;
				}
			}
			else if (sys <= XSysDefine.XSys_GuildBoon_FixedRedPacket)
			{
				if (sys != XSysDefine.XSys_GuildBoon_RedPacket && sys != XSysDefine.XSys_GuildBoon_FixedRedPacket)
				{
					goto IL_AC;
				}
			}
			else if (sys != XSysDefine.XSys_GuildDungeon_SmallMonter && sys != XSysDefine.XSys_GuildChallenge)
			{
				goto IL_AC;
			}
			bool flag2 = !this.IsSystemOpened(XSysDefine.XSys_Guild);
			if (flag2)
			{
				return;
			}
			goto IL_C3;
			IL_AC:
			bool flag3 = !this.IsSystemOpened(sys);
			if (flag3)
			{
				return;
			}
			IL_C3:
			if (sys <= XSysDefine.XSys_Fashion_Fashion)
			{
				if (sys <= XSysDefine.XSys_Arena)
				{
					if (sys <= XSysDefine.XSys_Strong)
					{
						if (sys <= XSysDefine.XSys_Horse)
						{
							if (sys != XSysDefine.XSys_Skill)
							{
								if (sys == XSysDefine.XSys_Horse)
								{
									XPetDocument specificDocument = XDocuments.GetSpecificDocument<XPetDocument>(XPetDocument.uuID);
									this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Horse), specificDocument.CanHasRedPoint && specificDocument.HasFood && specificDocument.FightPetHungry);
								}
							}
							else
							{
								XSkillTreeDocument specificDocument2 = XDocuments.GetSpecificDocument<XSkillTreeDocument>(XSkillTreeDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Skill), specificDocument2.RedPoint);
							}
						}
						else if (sys != XSysDefine.XSys_FlowerRank)
						{
							if (sys != XSysDefine.XSys_CardCollect)
							{
								if (sys == XSysDefine.XSys_Strong)
								{
									XFPStrengthenDocument specificDocument3 = XDocuments.GetSpecificDocument<XFPStrengthenDocument>(XFPStrengthenDocument.uuID);
									this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys), specificDocument3.IsHadRedot);
								}
							}
							else
							{
								XCardCollectDocument specificDocument4 = XDocuments.GetSpecificDocument<XCardCollectDocument>(XCardCollectDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CardCollect), specificDocument4.GetRedPoint());
							}
						}
						else
						{
							XFlowerRankDocument specificDocument5 = XDocuments.GetSpecificDocument<XFlowerRankDocument>(XFlowerRankDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_FlowerRank), specificDocument5.ShowRedPoint());
						}
					}
					else if (sys <= XSysDefine.XSys_LevelReward)
					{
						if (sys != XSysDefine.XSys_ServerActivity)
						{
							if (sys != XSysDefine.XSys_OnlineReward)
							{
								if (sys == XSysDefine.XSys_LevelReward)
								{
									XAchievementDocument specificDocument6 = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
									this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_LevelReward), specificDocument6.HasCompleteAchivement(XSysDefine.XSys_LevelReward));
								}
							}
							else
							{
								XOnlineRewardDocument specificDocument7 = XDocuments.GetSpecificDocument<XOnlineRewardDocument>(XOnlineRewardDocument.uuID);
								bool flag4 = specificDocument7.CheckOver();
								if (flag4)
								{
									this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_OnlineReward), this.OnlineRewardRemainTime <= 0f);
									bool flag5 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
									if (flag5)
									{
										bool flag6 = this.OnlineTime == null;
										if (flag6)
										{
											IXUIButton sysButton = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.uiBehaviour.GetSysButton(XSysDefine.XSys_OnlineReward);
											bool flag7 = sysButton != null;
											if (flag7)
											{
												Transform transform = sysButton.gameObject.transform.FindChild("Text");
												bool flag8 = transform != null;
												if (flag8)
												{
													this.OnlineTime = (transform.GetComponent("XUILabel") as IXUILabel);
												}
											}
										}
										bool flag9 = this.OnlineTime != null;
										if (flag9)
										{
											bool flag10 = this.OnlineRewardRemainTime <= 0f;
											if (flag10)
											{
												this.OnlineTime.SetVisible(false);
											}
											else
											{
												this.OnlineTime.SetVisible(true);
												this.OnlineTime.SetText(XSingleton<UiUtility>.singleton.TimeFormatString((int)this.OnlineRewardRemainTime, 2, 3, 4, false, true));
											}
										}
									}
								}
								else
								{
									this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_OnlineReward), false);
								}
							}
						}
						else
						{
							XAchievementDocument specificDocument8 = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_ServerActivity), specificDocument8.HasCompleteAchivement(XSysDefine.XSys_ServerActivity));
						}
					}
					else if (sys != XSysDefine.XSys_ReceiveEnergy)
					{
						if (sys != XSysDefine.XSys_LevelSeal)
						{
							if (sys == XSysDefine.XSys_Arena)
							{
								XArenaDocument specificDocument9 = XDocuments.GetSpecificDocument<XArenaDocument>(XArenaDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Arena), specificDocument9.RedPoint);
							}
						}
						else
						{
							XLevelSealDocument specificDocument10 = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_LevelSeal), specificDocument10.RedPoint);
						}
					}
					else
					{
						XSystemRewardDocument specificDocument11 = XDocuments.GetSpecificDocument<XSystemRewardDocument>(XSystemRewardDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_ReceiveEnergy), specificDocument11.HasReceiveEnergyCanFetchReward());
					}
				}
				else
				{
					if (sys <= XSysDefine.XSys_Level_Normal)
					{
						if (sys <= XSysDefine.XSys_WeekShareReward)
						{
							if (sys == XSysDefine.XSys_Qualifying)
							{
								int @int = XSingleton<XGlobalConfig>.singleton.GetInt("QualifyingFirstRewardCount");
								XQualifyingDocument specificDocument12 = XDocuments.GetSpecificDocument<XQualifyingDocument>(XQualifyingDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Qualifying), (ulong)specificDocument12.LeftFirstRewardCount < (ulong)((long)@int));
								goto IL_1389;
							}
							if (sys != XSysDefine.XSys_WeekShareReward)
							{
								goto IL_1389;
							}
							XAchievementDocument specificDocument13 = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_WeekShareReward), specificDocument13.HasWeekReward || !specificDocument13.Monday);
							goto IL_1389;
						}
						else
						{
							switch (sys)
							{
							case XSysDefine.XSys_GuildRelax:
							{
								XGuildRelaxGameDocument specificDocument14 = XDocuments.GetSpecificDocument<XGuildRelaxGameDocument>(XGuildRelaxGameDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildRelax), specificDocument14.RedPoint);
								goto IL_1389;
							}
							case (XSysDefine)83:
							case (XSysDefine)84:
							case XSysDefine.XSys_CrossGVG:
							case XSysDefine.XSys_Team:
							case XSysDefine.XSys_GayValley:
							case XSysDefine.XSys_GayValleyManager:
								goto IL_1389;
							case XSysDefine.XSys_GuildDragon:
							{
								bool flag11 = XSingleton<XGameSysMgr>.singleton.IsSystemOpened(XSysDefine.XSys_GuildDragon);
								if (flag11)
								{
									XGuildDragonDocument specificDocument15 = XDocuments.GetSpecificDocument<XGuildDragonDocument>(XGuildDragonDocument.uuID);
									this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildDragon), specificDocument15.bCanFight);
								}
								goto IL_1389;
							}
							case XSysDefine.XSys_GuildPvp:
							{
								XGuildArenaDocument specificDocument16 = XDocuments.GetSpecificDocument<XGuildArenaDocument>(XGuildArenaDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildPvp), specificDocument16.bHasAvailableArenaIcon);
								goto IL_1389;
							}
							case XSysDefine.XSys_GuildRedPacket:
							{
								XGuildRedPacketDocument specificDocument17 = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildRedPacket), specificDocument17.bHasAvailableRedPacket);
								goto IL_1389;
							}
							case XSysDefine.XSys_GuildMine:
							{
								XGuildDocument specificDocument18 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
								bool flag12 = XGuildDocument.GuildConfig.IsSysUnlock(XSysDefine.XSys_GuildMine, specificDocument18.Level);
								XGuildMineEntranceDocument specificDocument19 = XDocuments.GetSpecificDocument<XGuildMineEntranceDocument>(XGuildMineEntranceDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildMine), specificDocument19.MainInterfaceState && flag12);
								goto IL_1389;
							}
							case XSysDefine.XSys_SevenActivity:
							{
								XSevenLoginDocument specificDocument20 = XDocuments.GetSpecificDocument<XSevenLoginDocument>(XSevenLoginDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SevenActivity), specificDocument20.bHasAvailableRedPoint);
								goto IL_1389;
							}
							case XSysDefine.XSys_Title:
								break;
							default:
							{
								if (sys == XSysDefine.XSys_HallFame)
								{
									XCustomBattleDocument specificDocument21 = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
									this.SetSysRedPointState(XSysDefine.XSys_HallFame, XHallFameDocument.Doc.CanSupportType.Count > 0);
									goto IL_1389;
								}
								if (sys != XSysDefine.XSys_Level_Normal)
								{
									goto IL_1389;
								}
								XLevelDocument specificDocument22 = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Level_Normal), specificDocument22.HasDifficultAllChapterRedpoint(0));
								goto IL_1389;
							}
							}
						}
					}
					else if (sys <= XSysDefine.XSys_Char_Emblem)
					{
						if (sys == XSysDefine.XSys_Level_Elite)
						{
							XLevelDocument specificDocument23 = XDocuments.GetSpecificDocument<XLevelDocument>(XLevelDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Level_Normal), specificDocument23.HasDifficultAllChapterRedpoint(1));
							goto IL_1389;
						}
						switch (sys)
						{
						case XSysDefine.XSys_Item_Equip:
						case XSysDefine.XSys_Item_Enhance:
						case XSysDefine.XSys_Item_Enchant:
							break;
						case XSysDefine.XSys_Item_Jade:
						{
							XJadeDocument specificDocument24 = XDocuments.GetSpecificDocument<XJadeDocument>(XJadeDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Item_Jade), specificDocument24.bCanBePowerful);
							goto IL_1389;
						}
						case XSysDefine.XSys_Item_SlotAttr:
							goto IL_1389;
						case XSysDefine.XSys_Item_Smelting:
						case XSysDefine.XSys_Item_Reinforce:
						case XSysDefine.XSys_Emblem_Smelting:
							goto IL_1389;
						default:
						{
							if (sys != XSysDefine.XSys_Char_Emblem)
							{
								goto IL_1389;
							}
							XEmblemDocument specificDocument25 = XDocuments.GetSpecificDocument<XEmblemDocument>(XEmblemDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Char_Emblem), specificDocument25.bCanBePowerful || XSmeltDocument.Doc.EmblemCanBePower);
							goto IL_1389;
						}
						}
					}
					else
					{
						if (sys == XSysDefine.XSys_Home || sys == XSysDefine.XSys_Home_MyHome)
						{
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Home), HomeMainDocument.Doc.HomeMainRedDot);
							goto IL_1389;
						}
						if (sys != XSysDefine.XSys_Fashion_Fashion)
						{
							goto IL_1389;
						}
						XFashionDocument specificDocument26 = XDocuments.GetSpecificDocument<XFashionDocument>(XFashionDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Fashion_Fashion), specificDocument26.RedPoint);
						goto IL_1389;
					}
					XCharacterEquipDocument specificDocument27 = XDocuments.GetSpecificDocument<XCharacterEquipDocument>(XCharacterEquipDocument.uuID);
					XEnhanceDocument specificDocument28 = XDocuments.GetSpecificDocument<XEnhanceDocument>(XEnhanceDocument.uuID);
					XTitleDocument specificDocument29 = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
					bool flag13 = sys == XSysDefine.XSys_Title && specificDocument27.Handler != null;
					if (flag13)
					{
						specificDocument27.Handler.RefreshTitleRedPoint();
					}
					this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Item_Equip), specificDocument27.bCanBePowerful || (this.IsSystemOpened(XSysDefine.XSys_Item_Enhance) && specificDocument28.bCanBePowerful) || XSmeltDocument.Doc.EquipCanBePower || (this.IsSystemOpened(XSysDefine.XSys_Item_Enchant) && this.GetSysRedPointState(XSysDefine.XSys_Item_Enchant)) || (this.IsSystemOpened(XSysDefine.XSys_Title) && specificDocument29.bEnableTitleLevelUp));
				}
			}
			else if (sys <= XSysDefine.XSys_NPCFavor)
			{
				if (sys <= XSysDefine.XSys_Artifact)
				{
					if (sys <= XSysDefine.XSys_Bag_Item)
					{
						if (sys != XSysDefine.XSys_Fashion_OutLook)
						{
							if (sys == XSysDefine.XSys_Bag_Item)
							{
								XCharacterItemDocument specificDocument30 = XDocuments.GetSpecificDocument<XCharacterItemDocument>(XCharacterItemDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Bag_Item), specificDocument30.bHasAvailableItems);
							}
						}
						else
						{
							XFashionStorageDocument specificDocument31 = XDocuments.GetSpecificDocument<XFashionStorageDocument>(XFashionStorageDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Fashion_OutLook), specificDocument31.RedPoint);
						}
					}
					else
					{
						switch (sys)
						{
						case XSysDefine.XSys_CustomBattle:
						{
							XCustomBattleDocument specificDocument32 = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CustomBattle), specificDocument32.RedPoint);
							break;
						}
						case XSysDefine.XSys_CustomBattle_BountyMode:
						{
							XCustomBattleDocument specificDocument33 = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CustomBattle_BountyMode), specificDocument33.BountyModeRedPoint);
							break;
						}
						case XSysDefine.XSys_CustomBattle_CustomMode:
						{
							XCustomBattleDocument specificDocument34 = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CustomBattle_CustomMode), specificDocument34.CustomModeRedPoint);
							break;
						}
						default:
							switch (sys)
							{
							case XSysDefine.XSys_Reward_Achivement:
							{
								XAchievementDocument specificDocument35 = XDocuments.GetSpecificDocument<XAchievementDocument>(XAchievementDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Reward_Achivement), specificDocument35.HasCompleteAchivement(XSysDefine.XSys_Reward_Achivement));
								break;
							}
							case XSysDefine.XSys_Reward_Activity:
							{
								XDailyActivitiesDocument specificDocument36 = XDocuments.GetSpecificDocument<XDailyActivitiesDocument>(XDailyActivitiesDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Reward_Activity), specificDocument36.HasCanFetchReward());
								break;
							}
							case (XSysDefine)352:
							case (XSysDefine)354:
								break;
							case XSysDefine.XSys_Reward_Login:
							{
								XLoginRewardDocument specificDocument37 = XDocuments.GetSpecificDocument<XLoginRewardDocument>(XLoginRewardDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Reward_Login), !specificDocument37.IsTodayChecked());
								break;
							}
							case XSysDefine.XSys_Reward_Dragon:
							{
								XDragonRewardDocument specificDocument38 = XDocuments.GetSpecificDocument<XDragonRewardDocument>(XDragonRewardDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Reward_Dragon), specificDocument38.HasNewRed());
								this.UpdateRedPointOnHallUI(sys);
								break;
							}
							case XSysDefine.XSys_Prerogative:
							{
								XPrerogativeDocument specificDocument39 = XDocuments.GetSpecificDocument<XPrerogativeDocument>(XPrerogativeDocument.uuID);
								break;
							}
							case XSysDefine.XSys_Reward_Target:
							{
								XTargetRewardDocument specificDocument40 = XDocuments.GetSpecificDocument<XTargetRewardDocument>(XTargetRewardDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Reward_Target), specificDocument40.HasNewRed());
								break;
							}
							default:
								if (sys == XSysDefine.XSys_Artifact)
								{
									ArtifactBagDocument doc = ArtifactBagDocument.Doc;
									this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Artifact), doc.CanBePowerful);
								}
								break;
							}
							break;
						}
					}
				}
				else if (sys <= XSysDefine.XSys_Activity_DragonNest)
				{
					switch (sys)
					{
					case XSysDefine.XSys_EquipCreate_EquipSet:
					{
						XEquipCreateDocument specificDocument41 = XDocuments.GetSpecificDocument<XEquipCreateDocument>(XEquipCreateDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_EquipCreate_EquipSet), specificDocument41.RedPointEquip);
						break;
					}
					case XSysDefine.XSys_EquipCreate_EmblemSet:
					{
						XEquipCreateDocument specificDocument42 = XDocuments.GetSpecificDocument<XEquipCreateDocument>(XEquipCreateDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_EquipCreate_EmblemSet), specificDocument42.RedPointEmblem);
						break;
					}
					case XSysDefine.XSys_EquipCreate_ArtifactSet:
					{
						XArtifactCreateDocument doc2 = XArtifactCreateDocument.Doc;
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_EquipCreate_ArtifactSet), doc2.RedPointArtifact);
						break;
					}
					default:
						if (sys != XSysDefine.XSys_MentorshipMsg_Tip)
						{
							switch (sys)
							{
							case XSysDefine.XSys_Activity_WorldBoss:
								this.UpdateRedPointOnHallUI(sys);
								break;
							case XSysDefine.XSys_Activity_ExpeditionFrame:
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Activity_ExpeditionFrame), 0 < ActivityExpeditionHandler.GetDayLeftCount());
								break;
							}
						}
						else
						{
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_MentorshipMsg_Tip), XMentorshipDocument.Doc.TipIconHasRedPoint);
						}
						break;
					}
				}
				else
				{
					switch (sys)
					{
					case XSysDefine.XSys_Welfare_GiftBag:
					{
						XWelfareDocument specificDocument43 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Welfare_GiftBag), specificDocument43.GetRedPoint(XSysDefine.XSys_Welfare_GiftBag));
						break;
					}
					case XSysDefine.XSys_Welfare_StarFund:
					{
						XWelfareDocument specificDocument44 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Welfare_StarFund), specificDocument44.GetRedPoint(XSysDefine.XSys_Welfare_StarFund));
						break;
					}
					case XSysDefine.XSys_Welfare_FirstRechange:
					{
						XWelfareDocument specificDocument45 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Welfare_FirstRechange), specificDocument45.GetRedPoint(XSysDefine.XSys_Welfare_FirstRechange));
						this.UpdateRedPointOnHallUI(sys);
						break;
					}
					case XSysDefine.XSyS_Welfare_RewardBack:
					{
						XWelfareDocument specificDocument46 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSyS_Welfare_RewardBack), specificDocument46.GetRedPoint(XSysDefine.XSyS_Welfare_RewardBack));
						this.UpdateRedPointOnHallUI(sys);
						break;
					}
					case XSysDefine.XSys_Welfare_MoneyTree:
					{
						XWelfareDocument specificDocument47 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Welfare_MoneyTree), specificDocument47.GetRedPoint(XSysDefine.XSys_Welfare_MoneyTree));
						this.UpdateRedPointOnHallUI(sys);
						break;
					}
					case XSysDefine.XSys_Welfare_KingdomPrivilege:
					case XSysDefine.XSys_Welfare_YyMall:
					case (XSysDefine)573:
					case (XSysDefine)574:
					case (XSysDefine)575:
					case (XSysDefine)576:
					case (XSysDefine)577:
					case (XSysDefine)578:
					case (XSysDefine)579:
					case XSysDefine.Xsys_Backflow:
					case XSysDefine.Xsys_Backflow_Dailylogin:
					case XSysDefine.Xsys_Backflow_GiftBag:
					case XSysDefine.Xsys_Server_Two:
						break;
					case XSysDefine.XSys_Welfare_KingdomPrivilege_Court:
					{
						XWelfareDocument specificDocument48 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Welfare_KingdomPrivilege_Court), specificDocument48.GetRedPoint(XSysDefine.XSys_Welfare_KingdomPrivilege_Court));
						break;
					}
					case XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer:
					{
						XWelfareDocument specificDocument49 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer), specificDocument49.GetRedPoint(XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer));
						break;
					}
					case XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce:
					{
						XWelfareDocument specificDocument50 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce), specificDocument50.GetRedPoint(XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce));
						break;
					}
					case XSysDefine.XSys_Welfare_NiceGirl:
					{
						XWelfareDocument specificDocument51 = XDocuments.GetSpecificDocument<XWelfareDocument>(XWelfareDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Welfare_NiceGirl), specificDocument51.GetRedPoint(XSysDefine.XSys_Welfare_NiceGirl));
						break;
					}
					case XSysDefine.Xsys_Backflow_LavishGift:
					case XSysDefine.Xsys_Backflow_NewServerReward:
					case XSysDefine.Xsys_Backflow_LevelUp:
					case XSysDefine.Xsys_Backflow_Task:
					case XSysDefine.Xsys_Backflow_Target:
					case XSysDefine.Xsys_Backflow_Privilege:
					{
						bool add = XBackFlowDocument.Doc.GetRedPointState(sys);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys), add);
						break;
					}
					default:
						if (sys != XSysDefine.XSys_OperatingActivity)
						{
							if (sys == XSysDefine.XSys_NPCFavor)
							{
								XNPCFavorDocument specificDocument52 = XDocuments.GetSpecificDocument<XNPCFavorDocument>(XNPCFavorDocument.uuID);
								this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_NPCFavor), specificDocument52.IsNeedShowRedpoint);
								this.UpdateRedPointOnHallUI(sys);
							}
						}
						else
						{
							XOperatingActivityDocument doc3 = XOperatingActivityDocument.Doc;
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_OperatingActivity), doc3.IsHadRedDot());
						}
						break;
					}
				}
			}
			else if (sys <= XSysDefine.XSys_GuildRelax_JokerMatch)
			{
				if (sys <= XSysDefine.XSys_GuildHall_SignIn)
				{
					if (sys - XSysDefine.XSys_ThemeActivity > 2)
					{
						if (sys == XSysDefine.XSys_GuildHall_SignIn)
						{
							XGuildSignInDocument specificDocument53 = XDocuments.GetSpecificDocument<XGuildSignInDocument>(XGuildSignInDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildHall_SignIn), specificDocument53.bHasAvailableChest || specificDocument53.CanSignInSelection != 0);
						}
					}
					else
					{
						XThemeActivityDocument specificDocument54 = XDocuments.GetSpecificDocument<XThemeActivityDocument>(XThemeActivityDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_ThemeActivity), specificDocument54.IsHadRedPoint());
					}
				}
				else if (sys != XSysDefine.XSys_GuildHall_Skill)
				{
					if (sys != XSysDefine.XSys_GuildRelax_Joker)
					{
						if (sys == XSysDefine.XSys_GuildRelax_JokerMatch)
						{
							XGuildJockerMatchDocument specificDocument55 = XDocuments.GetSpecificDocument<XGuildJockerMatchDocument>(XGuildJockerMatchDocument.uuID);
							this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildRelax_JokerMatch), specificDocument55.bAvaiableIconWhenShow);
						}
					}
					else
					{
						XGuildJokerDocument specificDocument56 = XDocuments.GetSpecificDocument<XGuildJokerDocument>(XGuildJokerDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildRelax_Joker), specificDocument56.GameCount > 0);
					}
				}
				else
				{
					XGuildSkillDocument specificDocument57 = XDocuments.GetSpecificDocument<XGuildSkillDocument>(XGuildSkillDocument.uuID);
					this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildHall_Skill), specificDocument57.RedPoint);
				}
			}
			else if (sys <= XSysDefine.XSys_GuildChallenge)
			{
				if (sys != XSysDefine.XSys_GuildBoon_Salay)
				{
					if (sys != XSysDefine.XSys_GuildBoon_FixedRedPacket)
					{
						if (sys != XSysDefine.XSys_GuildChallenge)
						{
						}
					}
					else
					{
						XGuildRedPacketDocument specificDocument58 = XDocuments.GetSpecificDocument<XGuildRedPacketDocument>(XGuildRedPacketDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildBoon_FixedRedPacket), specificDocument58.bHasAvailableFixedRedPoint);
					}
				}
				else
				{
					XGuildSalaryDocument specificDocument59 = XDocuments.GetSpecificDocument<XGuildSalaryDocument>(XGuildSalaryDocument.uuID);
					this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildBoon_Salay), specificDocument59.HasRedPoint);
				}
			}
			else if (sys != XSysDefine.XSys_QQVIP)
			{
				if (sys != XSysDefine.XSys_HeroBattle)
				{
					if (sys == XSysDefine.XSys_Moba)
					{
						int int2 = XSingleton<XGlobalConfig>.singleton.GetInt("MobaStageNum");
						XMobaEntranceDocument specificDocument60 = XDocuments.GetSpecificDocument<XMobaEntranceDocument>(XMobaEntranceDocument.uuID);
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Moba), (ulong)specificDocument60.GetRewardStage < (ulong)((long)int2));
					}
				}
				else
				{
					int int3 = XSingleton<XGlobalConfig>.singleton.GetInt("HeroBattleSpecialNum");
					XHeroBattleDocument specificDocument61 = XDocuments.GetSpecificDocument<XHeroBattleDocument>(XHeroBattleDocument.uuID);
					this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_HeroBattle), (ulong)specificDocument61.JoinToday < (ulong)((long)int3));
				}
			}
			else
			{
				XPlatformAbilityDocument specificDocument62 = XDocuments.GetSpecificDocument<XPlatformAbilityDocument>(XPlatformAbilityDocument.uuID);
				this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_QQVIP), specificDocument62.QQVipRedPoint);
			}
			IL_1389:
			this.UpdateLevel1SystemState(sys);
			XSysDefine parentSys = this.GetParentSys(sys);
			if (bImmUpdateUI)
			{
				this.UpdateParentRedPoint(sys);
				this.sysRedPointHasRefreshed.Clear();
				int num = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys);
				bool flag14 = num >= 0 && num < this.sysRedPointRelative.Length;
				if (flag14)
				{
					List<XSysDefine> list = this.sysRedPointRelative[num];
					bool flag15 = list != null;
					if (flag15)
					{
						for (int i = 0; i < list.Count; i++)
						{
							XSysDefine xsysDefine = list[i];
							bool flag16 = !this.sysRedPointHasRefreshed.IsFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(xsysDefine));
							if (flag16)
							{
								parentSys = this.GetParentSys(xsysDefine);
								this.UpdateRedPointOnHallUI(parentSys);
								this.UpdateSubSysRedPointsUI(parentSys);
								this.UpdateRelativeSysRedPointsUI(xsysDefine);
								this.sysRedPointHasRefreshed.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(xsysDefine), true);
							}
						}
					}
				}
			}
		}

		// Token: 0x0600C044 RID: 49220 RVA: 0x00288974 File Offset: 0x00286B74
		private void UpdateParentRedPoint(XSysDefine define)
		{
			this.UpdateRedPointOnHallUI(define);
			this.UpdateSubSysRedPointsUI(define);
			this.UpdateRelativeSysRedPointsUI(define);
			XSysDefine parentSys = this.GetParentSys(define);
			bool flag = parentSys == define || parentSys == XSysDefine.XSys_None || parentSys == XSysDefine.XSys_Invalid;
			if (!flag)
			{
				this.UpdateParentRedPoint(parentSys);
			}
		}

		// Token: 0x0600C045 RID: 49221 RVA: 0x002889C0 File Offset: 0x00286BC0
		protected void UpdateLevel1SystemState(XSysDefine sys)
		{
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Bag), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Bag_Item));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Fashion), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Fashion_Fashion) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Fashion_OutLook));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Item), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Item_Equip) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Bag_Item) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Char_Emblem) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Item_Jade) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Fashion) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Design_Designation) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Artifact));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Reward), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Design_Achieve) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_LevelReward) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_ServerActivity) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Reward_Dragon) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Reward_Target) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_WeekShareReward));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildHall), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildHall_SignIn) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildHall_Skill) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildHall_Member) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildHall_Approve) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildDungeon_SmallMonter) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildBoon_Salay) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildRelax_Joker));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Guild), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildHall) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildRelax) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildMine) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildDragon) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildPvp) || !XGuildDocument.InGuild);
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Rank), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_FlowerRank));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GuildBoon_RedPacket), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildRedPacket) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GuildBoon_FixedRedPacket));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_EquipCreate), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_EquipCreate_EquipSet) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_EquipCreate_EmblemSet) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_EquipCreate_ArtifactSet));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GameCommunity), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GC_XinYueVIP) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GC_XiaoYueGuanJia) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GC_Reserve17) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GC_Reserve18) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GC_Reserve19) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GC_Reserve20) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GC_Reserve21) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Questionnaire));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Char), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Char_Attr) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Char_Emblem));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Character), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Char) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Bag) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Design));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Camp_CampHall), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Camp_Mission));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Camp), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Camp_CampHall) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Camp_MemberHall));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Level), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Level_Normal) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Level_Elite));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_DailyAcitivity), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Reward_Activity));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_CustomBattle), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_CustomBattle_BountyMode) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_CustomBattle_CustomMode));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_PVPAcitivity), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Qualifying) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_HeroBattle) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Activity_CaptainPVP) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_WeekNest) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_TeamLeague) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_CustomBattle) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_HallFame));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_MobaAcitivity), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_PVPAcitivity));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SystemActivity), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_SystemActivity_Other));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Welfare), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Welfare_GiftBag) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Welfare_StarFund) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Welfare_FirstRechange) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_ReceiveEnergy) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Reward_Login) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSyS_Welfare_RewardBack) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Welfare_KingdomPrivilege_Court) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Welfare_NiceGirl) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Welfare_MoneyTree));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SpriteSystem), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_SpriteSystem_Main) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_SpriteSystem_Fight) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_SpriteSystem_Resolve) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_SpriteSystem_Shop));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_GameMall), this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GameMall_Diamond) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GameMall_Dragon) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_GameMall_Pay) || this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Mall));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.Xsys_Backflow), this.GetSysRedPointStateConsiderBlock(XSysDefine.Xsys_Backflow_LavishGift) || this.GetSysRedPointStateConsiderBlock(XSysDefine.Xsys_Backflow_Target) || this.GetSysRedPointStateConsiderBlock(XSysDefine.Xsys_Backflow_Task));
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Friends), DlgBase<XFriendsView, XFriendsBehaviour>.singleton.Redpoint);
			for (int i = 0; i < this.sysRedPointRelative.Length; i++)
			{
				List<XSysDefine> list = this.sysRedPointRelative[i];
				bool flag = list != null;
				if (flag)
				{
					for (int j = 0; j < list.Count; j++)
					{
						XSysDefine xsysDefine = list[j];
						this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(xsysDefine), this.GetSysRedPointStateConsiderBlock(xsysDefine) || this.GetSysRedPointStateConsiderBlock((XSysDefine)i));
					}
				}
			}
			if (sys <= XSysDefine.XSys_GameMall)
			{
				if (sys <= XSysDefine.XSys_Strong)
				{
					if (sys <= XSysDefine.XSys_Horse)
					{
						if (sys - XSysDefine.XSys_Item > 1 && sys != XSysDefine.XSys_Horse)
						{
							return;
						}
					}
					else
					{
						if (sys == XSysDefine.XSys_Auction)
						{
							goto IL_7E3;
						}
						if (sys != XSysDefine.XSys_CardCollect)
						{
							if (sys != XSysDefine.XSys_Strong)
							{
								return;
							}
							goto IL_7E3;
						}
					}
				}
				else if (sys <= XSysDefine.XSys_Rank)
				{
					if (sys == XSysDefine.XSys_Reward)
					{
						goto IL_7E3;
					}
					if (sys != XSysDefine.XSys_Rank)
					{
						return;
					}
				}
				else if (sys != XSysDefine.XSys_EquipCreate)
				{
					if (sys != XSysDefine.XSys_Spectate && sys != XSysDefine.XSys_GameMall)
					{
						return;
					}
					goto IL_7E3;
				}
			}
			else if (sys <= XSysDefine.XSys_Welfare)
			{
				if (sys <= XSysDefine.XSys_Friends)
				{
					if (sys == XSysDefine.XSys_Carnival)
					{
						goto IL_7E3;
					}
					if (sys != XSysDefine.XSys_Friends)
					{
						return;
					}
				}
				else
				{
					if (sys == XSysDefine.XSys_SevenActivity)
					{
						goto IL_7E3;
					}
					if (sys != XSysDefine.XSys_Title)
					{
						if (sys != XSysDefine.XSys_Welfare)
						{
							return;
						}
						goto IL_7E3;
					}
				}
			}
			else if (sys <= XSysDefine.XSys_OperatingActivity)
			{
				if (sys != XSysDefine.XSys_Welfare_FirstRechange && sys != XSysDefine.Xsys_Backflow && sys != XSysDefine.XSys_OperatingActivity)
				{
					return;
				}
				goto IL_7E3;
			}
			else if (sys != XSysDefine.XSys_NPCFavor)
			{
				if (sys == XSysDefine.XSys_ThemeActivity)
				{
					goto IL_7E3;
				}
				if (sys != XSysDefine.XSys_SpriteSystem)
				{
					return;
				}
			}
			bool flag2 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag2)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.CalMenuSwitchBtnRedPointState();
			}
			return;
			IL_7E3:
			bool flag3 = DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (flag3)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.CalH2SwitchBtnRedPointState(null);
			}
		}

		// Token: 0x0600C046 RID: 49222 RVA: 0x002891D0 File Offset: 0x002873D0
		public void AttachSysRedPointRelative(int sys, int childSys, bool bImmCalculate)
		{
			int num = XFastEnumIntEqualityComparer<XSysDefine>.ToInt((XSysDefine)childSys);
			bool flag = num >= 0 && num < this.sysRedPointRelative.Length;
			if (flag)
			{
				List<XSysDefine> list = this.sysRedPointRelative[num];
				bool flag2 = list == null;
				if (flag2)
				{
					list = new List<XSysDefine>();
					this.sysRedPointRelative[num] = list;
				}
				bool flag3 = !list.Contains((XSysDefine)sys);
				if (flag3)
				{
					list.Add((XSysDefine)sys);
				}
			}
			if (bImmCalculate)
			{
				this.RecalculateRedPointState((XSysDefine)sys, true);
			}
		}

		// Token: 0x0600C047 RID: 49223 RVA: 0x00289258 File Offset: 0x00287458
		public void AttachSysRedPointRelativeUI(int sys, GameObject go)
		{
			this.sysRedPointRelativeUI[sys] = go;
			bool flag = null != go;
			if (flag)
			{
				go.SetActive(this.redPointState.IsFlag(sys));
			}
		}

		// Token: 0x0600C048 RID: 49224 RVA: 0x00289291 File Offset: 0x00287491
		public void DetachSysRedPointRelative(int sys)
		{
			this.sysRedPointRelative[sys] = null;
		}

		// Token: 0x0600C049 RID: 49225 RVA: 0x0028929D File Offset: 0x0028749D
		public void DetachSysRedPointRelativeUI(int sys)
		{
			this.sysRedPointRelativeUI[sys] = null;
		}

		// Token: 0x0600C04A RID: 49226 RVA: 0x002892AC File Offset: 0x002874AC
		public void ForceUpdateSysRedPointImmediately(int sys, bool redpoint)
		{
			this.redPointState.SetFlag(sys, redpoint);
			this.RecalculateRedPointState((XSysDefine)sys, true);
		}

		// Token: 0x0600C04B RID: 49227 RVA: 0x002892D4 File Offset: 0x002874D4
		public void UpdateRedPointOnHallUI(XSysDefine sys)
		{
			bool flag = !DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetSystemRedPointState(sys, this.GetSysRedPointStateConsiderBlock(sys));
				if (sys <= XSysDefine.XSys_SuperRisk)
				{
					if (sys <= XSysDefine.XSys_Bag)
					{
						if (sys != XSysDefine.XSys_Char && sys != XSysDefine.XSys_Bag)
						{
							return;
						}
					}
					else if (sys != XSysDefine.XSys_Design && sys != XSysDefine.XSys_EquipCreate)
					{
						if (sys != XSysDefine.XSys_SuperRisk)
						{
							return;
						}
						goto IL_159;
					}
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetSystemRedPointState(XSysDefine.XSys_Character, this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Character));
					return;
				}
				if (sys <= XSysDefine.XSys_Pet_Pairs)
				{
					if (sys != XSysDefine.XSys_PK)
					{
						switch (sys)
						{
						case XSysDefine.XSys_GuildHall:
						case XSysDefine.XSys_GuildRelax:
						case XSysDefine.XSys_GuildDragon:
						case XSysDefine.XSys_GuildPvp:
						case XSysDefine.XSys_GuildMine:
						{
							DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetSystemRedPointState(XSysDefine.XSys_Guild, this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Guild));
							bool flag2 = sys == XSysDefine.XSys_GuildDragon;
							if (flag2)
							{
								DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_GuildBossMainInterface, true);
							}
							return;
						}
						case (XSysDefine)83:
						case (XSysDefine)84:
						case XSysDefine.XSys_GuildRedPacket:
							return;
						default:
							if (sys != XSysDefine.XSys_Pet_Pairs)
							{
								return;
							}
							break;
						}
					}
				}
				else
				{
					if (sys == XSysDefine.XSys_Activity_WorldBoss)
					{
						DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(XSysDefine.XSys_Activity_WorldBoss, true);
						return;
					}
					if (sys != XSysDefine.XSys_Welfare && sys - XSysDefine.XSys_Welfare_GiftBag > 9)
					{
						return;
					}
					DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.SetSystemRedPointState(XSysDefine.XSys_Welfare, this.GetSysRedPointStateConsiderBlock(XSysDefine.XSys_Welfare));
					return;
				}
				IL_159:
				DlgBase<XMainInterface, XMainInterfaceBehaviour>.singleton.RefreshH5ButtonState(sys, true);
			}
		}

		// Token: 0x0600C04C RID: 49228 RVA: 0x0028944C File Offset: 0x0028764C
		public void UpdateSubSysRedPointsUI(XSysDefine sys)
		{
			int num = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys);
			bool flag = num >= 0 && num < this.subSysRedPoint.Length;
			if (flag)
			{
				XSubSysRedPointMgr xsubSysRedPointMgr = this.subSysRedPoint[XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys)];
				bool flag2 = xsubSysRedPointMgr != null;
				if (flag2)
				{
					xsubSysRedPointMgr.UpdateRedPointUI();
				}
			}
		}

		// Token: 0x0600C04D RID: 49229 RVA: 0x00289498 File Offset: 0x00287698
		public void UpdateRelativeSysRedPointsUI(XSysDefine sys)
		{
			int num = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys);
			bool flag = num >= 0 && num < this.sysRedPointRelativeUI.Length;
			if (flag)
			{
				GameObject gameObject = this.sysRedPointRelativeUI[num];
				bool flag2 = gameObject;
				if (flag2)
				{
					gameObject.SetActive(this.redPointState.IsFlag(num));
				}
			}
		}

		// Token: 0x0600C04E RID: 49230 RVA: 0x002894F0 File Offset: 0x002876F0
		public void RegisterSubSysRedPointMgr(XSysDefine sys, XSubSysRedPointMgr mgr)
		{
			int num = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys);
			bool flag = num >= 0 && num < this.sysRedPointRelativeUI.Length;
			if (flag)
			{
				this.subSysRedPoint[num] = mgr;
			}
		}

		// Token: 0x0600C04F RID: 49231 RVA: 0x00289528 File Offset: 0x00287728
		public void OnLeaveScene(bool transfer)
		{
			for (int i = 0; i < this.subSysRedPoint.Length; i++)
			{
				this.subSysRedPoint[i] = null;
			}
		}

		// Token: 0x0600C050 RID: 49232 RVA: 0x0028955C File Offset: 0x0028775C
		public bool GetSysRedPointStateConsiderBlock(XSysDefine sys)
		{
			int num = XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys);
			bool flag = num >= 0 && num < this.sysRedPointRelativeUI.Length;
			bool result;
			if (flag)
			{
				bool flag2 = this.redPointState.IsFlag(num);
				List<uint> list = this.noRedPointLevel[num];
				bool flag3 = list == null;
				if (flag3)
				{
					result = flag2;
				}
				else
				{
					result = (flag2 && (this.bStopBlockRedPoint || !list.Contains(this.m_PlayerLevel)));
				}
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x0600C051 RID: 49233 RVA: 0x002895DC File Offset: 0x002877DC
		public bool GetSysRedPointState(int sys)
		{
			return this.GetSysRedPointState((XSysDefine)sys);
		}

		// Token: 0x0600C052 RID: 49234 RVA: 0x002895F8 File Offset: 0x002877F8
		public bool GetSysRedPointState(XSysDefine sys)
		{
			return this.redPointState.IsFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys));
		}

		// Token: 0x0600C053 RID: 49235 RVA: 0x0028961C File Offset: 0x0028781C
		public void SetSysRedState(XSysDefine sys, bool bState)
		{
			bool flag = this.redPointState != null;
			if (flag)
			{
				this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys), bState);
			}
		}

		// Token: 0x0600C054 RID: 49236 RVA: 0x0028964C File Offset: 0x0028784C
		public void SetSysRedPointState(XSysDefine sys, bool bState)
		{
			bool flag = !this.IsSystemOpened(sys);
			if (flag)
			{
				bState = false;
			}
			this.redPointState.SetFlag(XFastEnumIntEqualityComparer<XSysDefine>.ToInt(sys), bState);
		}

		// Token: 0x0600C055 RID: 49237 RVA: 0x0028967E File Offset: 0x0028787E
		public void OpenSystem(int sys)
		{
			this.OpenSystem((XSysDefine)sys, 0UL);
		}

		// Token: 0x0600C056 RID: 49238 RVA: 0x0028968C File Offset: 0x0028788C
		public void OpenSystem(XSysDefine sys, ulong param = 0UL)
		{
			bool flag = !this.IsSystemOpened(sys);
			if (!flag)
			{
				XSysDefine xsysDefine = sys;
				if (xsysDefine <= XSysDefine.XSys_WeekNest)
				{
					if (xsysDefine <= XSysDefine.XSys_Bag_Item)
					{
						if (xsysDefine <= XSysDefine.XSys_Level_Elite)
						{
							if (xsysDefine <= XSysDefine.XSys_MilitaryRank)
							{
								switch (xsysDefine)
								{
								case XSysDefine.XSys_Level:
									DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.FadeShow();
									return;
								case XSysDefine.XSys_Item:
									goto IL_834;
								case XSysDefine.XSys_Skill:
									break;
								case XSysDefine.XSys_Char:
								case XSysDefine.XSys_Bag:
								case XSysDefine.XSys_TShow:
								case XSysDefine.XSys_TShowRule:
								case XSysDefine.XSys_Camp:
								case XSysDefine.XSys_Wifi:
								case XSysDefine.XSys_Design:
								case XSysDefine.XSys_SuperReward:
								case XSysDefine.XSys_Draw:
								case XSysDefine.XSys_Mall:
								case XSysDefine.XSys_Target:
								case (XSysDefine)36:
								case (XSysDefine)38:
								case XSysDefine.XSys_OnlineReward:
								case XSysDefine.XSys_Setting:
								case XSysDefine.XSys_Rank:
								case XSysDefine.XSys_LevelReward:
								case (XSysDefine)43:
								case XSysDefine.XSys_SystemActivity:
								case XSysDefine.XSys_LevelSeal:
								case XSysDefine.XSys_Arena:
								case (XSysDefine)53:
								case XSysDefine.XSys_MulActivity:
								case XSysDefine.XSys_ExcellentLive:
								case (XSysDefine)66:
								case XSysDefine.XSys_WeekShareReward:
								case XSysDefine.XSys_DungeonShareReward:
								case XSysDefine.XSys_OtherPlayerInfo:
								case XSysDefine.XSys_Chat:
								case XSysDefine.XSys_Maquee:
								case XSysDefine.XSys_SendFlower:
									goto IL_127F;
								case XSysDefine.XSys_Horse:
									DlgBase<XPetMainView, XPetMainBehaviour>.singleton.SetVisibleWithAnimation(true, null);
									return;
								case XSysDefine.XSys_Fashion:
									goto IL_C2B;
								case XSysDefine.XSys_Guild:
									goto IL_B85;
								case XSysDefine.XSys_Recycle:
									goto IL_A67;
								case XSysDefine.XSys_Confession:
									return;
								case XSysDefine.XSys_Auction:
									DlgBase<AuctionView, AuctionBehaviour>.singleton.SetVisibleWithAnimation(true, null);
									return;
								case XSysDefine.XSys_FlowerRank:
									DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(sys);
									return;
								case XSysDefine.XSys_CardCollect:
									DlgBase<CardCollectView, CardCollectBehaviour>.singleton.SetVisibleWithAnimation(true, null);
									return;
								case XSysDefine.XSys_Mail:
									DlgBase<MailSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Mail_System);
									return;
								case XSysDefine.XSys_Strong:
									DlgBase<XFpStrengthenView, XFPStrengthenBehaviour>.singleton.SetVisibleWithAnimation(true, null);
									return;
								case XSysDefine.XSys_Reward:
								case XSysDefine.XSys_ServerActivity:
									goto IL_C42;
								case XSysDefine.XSys_ReceiveEnergy:
									goto IL_10A0;
								case XSysDefine.XSys_EquipCreate:
									goto IL_7A1;
								case XSysDefine.XSys_BossRush:
								{
									XBossBushDocument xbossBushDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XBossBushDocument.uuID) as XBossBushDocument;
									xbossBushDocument.ParseRefresh();
									xbossBushDocument.SendQuery(BossRushReqStatus.BOSSRUSH_REQ_BASEDATA);
									return;
								}
								case XSysDefine.XSys_SuperRisk:
									DlgBase<SuperRiskDlg, SuperRiskDlgBehaviour>.singleton.Show(false, 0);
									return;
								case XSysDefine.XSys_DragonCrusade:
								{
									XDragonCrusadeDocument xdragonCrusadeDocument = XSingleton<XGame>.singleton.Doc.GetXComponent(XDragonCrusadeDocument.uuID) as XDragonCrusadeDocument;
									xdragonCrusadeDocument.ReadyOpen();
									return;
								}
								case XSysDefine.XSys_Activity:
								case XSysDefine.XSys_DailyAcitivity:
									goto IL_DF7;
								case XSysDefine.XSys_Qualifying:
									DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.SetVisibleWithAnimation(true, null);
									return;
								case XSysDefine.XSys_Spectate:
									DlgBase<SpectateView, SpectateBehaviour>.singleton.SetVisibleWithAnimation(true, null);
									return;
								case XSysDefine.XSys_PVPAcitivity:
								case XSysDefine.XSys_MobaAcitivity:
									DlgBase<MobaActivityDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
									return;
								case XSysDefine.XSys_Money:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowPurchase(ItemEnum.DIAMOND);
									return;
								case XSysDefine.XSys_Coin:
									DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.GOLD);
									return;
								case XSysDefine.XSys_Power:
									DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.FATIGUE);
									return;
								case XSysDefine.XSys_DragonCoin:
									DlgBase<XPurchaseView, XPurchaseBehaviour>.singleton.ReqQuickCommonPurchase(ItemEnum.DRAGON_COIN);
									return;
								case XSysDefine.XSys_GameMall:
									goto IL_E98;
								case XSysDefine.XSys_Carnival:
									DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.SetVisibleWithAnimation(true, null);
									return;
								case XSysDefine.XSys_Friends:
									DlgBase<XFriendsView, XFriendsBehaviour>.singleton.OnShowFriendDlg();
									return;
								case XSysDefine.XSys_Mentorship:
									DlgBase<XFriendsView, XFriendsBehaviour>.singleton.ShowTab(XSysDefine.XSys_Mentorship);
									return;
								default:
									switch (xsysDefine)
									{
									case XSysDefine.XSys_GuildHall:
										goto IL_BD0;
									case XSysDefine.XSys_GuildRelax:
									case XSysDefine.XSys_GuildDragon:
									case XSysDefine.XSys_GuildMine:
										goto IL_B85;
									case (XSysDefine)83:
									case (XSysDefine)84:
									case XSysDefine.XSys_GuildRedPacket:
									case XSysDefine.XSys_CrossGVG:
									case XSysDefine.XSys_GayValley:
									case XSysDefine.XSys_GayValleyManager:
									case XSysDefine.XSys_SevenActivity:
										goto IL_127F;
									case XSysDefine.XSys_GuildPvp:
										DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
										return;
									case XSysDefine.XSys_Team:
										DlgBase<XTeamView, TabDlgBehaviour>.singleton.ShowTeamView();
										return;
									case XSysDefine.XSys_Title:
										DlgBase<TitleDlg, TitleDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
										return;
									case XSysDefine.XSys_Task:
										DlgBase<XTaskView, XTaskBehaviour>.singleton.TryShowTaskView();
										return;
									default:
										if (xsysDefine != XSysDefine.XSys_MilitaryRank)
										{
											goto IL_127F;
										}
										DlgBase<MilitaryRankDlg, MilitaryRankBehaviour>.singleton.SetVisibleWithAnimation(true, null);
										return;
									}
									break;
								}
							}
							else
							{
								if (xsysDefine == XSysDefine.XSys_Recharge)
								{
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowPurchase(ItemEnum.DIAMOND);
									return;
								}
								if (xsysDefine == XSysDefine.XSys_Level_Normal)
								{
									DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.SetAutoSelectScene(0, 0, 0U);
									DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.FadeShow();
									return;
								}
								if (xsysDefine != XSysDefine.XSys_Level_Elite)
								{
									goto IL_127F;
								}
								DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.SetAutoSelectScene(0, 0, 1U);
								DlgBase<DungeonSelect, DungeonSelectBehaviour>.singleton.FadeShow();
								return;
							}
						}
						else if (xsysDefine <= XSysDefine.XSys_Char_Emblem)
						{
							switch (xsysDefine)
							{
							case XSysDefine.XSys_Item_Equip:
							case XSysDefine.XSys_Item_Jade:
								goto IL_834;
							case XSysDefine.XSys_Item_Enhance:
								DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Item_Equip);
								return;
							default:
								if (xsysDefine - XSysDefine.XSys_Skill_Levelup > 1)
								{
									if (xsysDefine != XSysDefine.XSys_Char_Emblem)
									{
										goto IL_127F;
									}
									goto IL_834;
								}
								break;
							}
						}
						else
						{
							switch (xsysDefine)
							{
							case XSysDefine.XSys_Home:
							case XSysDefine.XSys_Home_Cooking:
							case XSysDefine.XSys_Home_Fishing:
							case XSysDefine.XSys_Home_Feast:
							case XSysDefine.XSys_Home_MyHome:
							{
								DlgBase<HomeMainDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
								bool flag2 = XSingleton<XScene>.singleton.GameCamera != null && XSingleton<XScene>.singleton.GameCamera.UnityCamera != null;
								if (flag2)
								{
									XSingleton<XScene>.singleton.GameCamera.UnityCamera.enabled = true;
								}
								return;
							}
							case XSysDefine.XSys_Home_Plant:
							case XSysDefine.XSys_Home_HomeFriends:
							case (XSysDefine)157:
							case (XSysDefine)158:
							case XSysDefine.XSys_Horse_LearnSkill:
								goto IL_127F;
							case XSysDefine.XSys_Fashion_Fashion:
								goto IL_C2B;
							default:
								if (xsysDefine - XSysDefine.XSys_Recycle_Equip <= 1)
								{
									goto IL_A67;
								}
								if (xsysDefine != XSysDefine.XSys_Bag_Item)
								{
									goto IL_127F;
								}
								goto IL_834;
							}
						}
						DlgBase<XSkillTreeView, XSkillTreeBehaviour>.singleton.SetVisibleWithAnimation(true, null);
						return;
						IL_A67:
						DlgBase<RecycleSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
						return;
						IL_C2B:
						DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Fashion_Fashion);
						return;
					}
					if (xsysDefine <= XSysDefine.XSys_Artifact_Refined)
					{
						if (xsysDefine <= XSysDefine.XSys_Design_Designation)
						{
							if (xsysDefine - XSysDefine.XSys_CustomBattle <= 2)
							{
								DlgBase<CustomBattleView, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
								return;
							}
							if (xsysDefine == XSysDefine.XSys_WeekEndNest)
							{
								DlgBase<WeekEndNestDlg, WeekEndNestBehaviour>.singleton.SetVisible(true, true);
								return;
							}
							if (xsysDefine != XSysDefine.XSys_Design_Designation)
							{
								goto IL_127F;
							}
							goto IL_834;
						}
						else
						{
							if (xsysDefine == XSysDefine.XSys_Design_Achieve)
							{
								goto IL_C42;
							}
							switch (xsysDefine)
							{
							case XSysDefine.XSys_Strong_Brief:
								DlgBase<XBriefStrengthenView, XBriefStrengthenBehaviour>.singleton.SetVisible(true, true);
								return;
							case XSysDefine.XSys_Reward_Achivement:
							case (XSysDefine)352:
							case (XSysDefine)354:
							case (XSysDefine)359:
								goto IL_127F;
							case XSysDefine.XSys_Reward_Activity:
								goto IL_DF7;
							case XSysDefine.XSys_Reward_Login:
								goto IL_10A0;
							case XSysDefine.XSys_Reward_Dragon:
							case XSysDefine.XSys_Reward_Target:
								goto IL_C42;
							case XSysDefine.XSys_Prerogative:
								DlgBase<PrerogativeDlg, PrerogativeDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
								return;
							case XSysDefine.XSys_PrerogativeShop:
								DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(XSysDefine.XSys_PrerogativeShop, 0UL);
								return;
							case XSysDefine.XSys_AbyssParty:
								DlgBase<AbyssPartyEntranceView, AbyssPartyEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, null);
								return;
							default:
								switch (xsysDefine)
								{
								case XSysDefine.XSys_Artifact:
									goto IL_834;
								case XSysDefine.XSys_Artifact_Comepose:
								case XSysDefine.XSys_Artifact_Recast:
								case XSysDefine.XSys_Artifact_Fuse:
								case XSysDefine.XSys_Artifact_Inscription:
								case XSysDefine.XSys_Artifact_Refined:
									DlgBase<ArtifactDeityStoveDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
									return;
								case XSysDefine.XSys_Artifact_Atlas:
								case XSysDefine.XSys_Artifact_DeityStove:
									goto IL_127F;
								default:
									goto IL_127F;
								}
								break;
							}
						}
					}
					else if (xsysDefine <= XSysDefine.XSys_EquipCreate_ArtifactSet)
					{
						if (xsysDefine - XSysDefine.XSys_Flower_Rank_Today <= 3 || xsysDefine == XSysDefine.XSys_Flower_Rank_Activity)
						{
							DlgBase<XRankView, XRankBehaviour>.singleton.ShowFlowerRank(sys);
							return;
						}
						if (xsysDefine - XSysDefine.XSys_EquipCreate_EquipSet > 2)
						{
							goto IL_127F;
						}
					}
					else if (xsysDefine <= XSysDefine.XSys_InGameAD)
					{
						switch (xsysDefine)
						{
						case XSysDefine.XSys_Activity_Nest:
							DlgBase<TheExpView, TheExpBehaviour>.singleton.ShowView(-1);
							return;
						case XSysDefine.XSys_Activity_SmallMonster:
						case XSysDefine.XSys_Activity_Fashion:
						case XSysDefine.XSys_Activity_ExpeditionFrame:
							DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ShowSubSystem(XSysDefine.XSys_Activity);
							return;
						case XSysDefine.XSys_Activity_BossRush:
						case XSysDefine.XSys_BigMeleeEnd:
						case (XSysDefine)534:
						case (XSysDefine)535:
						case (XSysDefine)536:
						case (XSysDefine)537:
						case (XSysDefine)538:
						case (XSysDefine)539:
						case XSysDefine.XSys_Shanggu:
						case (XSysDefine)543:
						case (XSysDefine)544:
						case (XSysDefine)545:
						case (XSysDefine)546:
						case (XSysDefine)547:
						case (XSysDefine)548:
						case (XSysDefine)549:
						case (XSysDefine)550:
						case XSysDefine.XSys_MulActivity_SkyArenaEnd:
						case (XSysDefine)556:
						case (XSysDefine)557:
						case (XSysDefine)558:
						case (XSysDefine)559:
						case XSysDefine.XSys_Welfare:
						case (XSysDefine)561:
						case XSysDefine.XSys_Welfare_NiceGirl:
						case (XSysDefine)573:
						case (XSysDefine)574:
						case (XSysDefine)575:
						case (XSysDefine)576:
						case (XSysDefine)577:
						case (XSysDefine)578:
						case (XSysDefine)579:
						case XSysDefine.Xsys_Backflow_Dailylogin:
						case XSysDefine.Xsys_Backflow_GiftBag:
						case XSysDefine.Xsys_Server_Two:
							goto IL_127F;
						case XSysDefine.XSys_Activity_WorldBoss:
							DlgBase<XWorldBossView, XWorldBossBehaviour>.singleton.ShowView();
							return;
						case XSysDefine.XSys_Activity_DragonNest:
							DlgBase<XDragonNestView, XDragonNestBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_Activity_TeamTower:
							DlgBase<ActivityTeamTowerSingleDlg, ActivityTeamTowerSingleDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_Activity_CaptainPVP:
							DlgBase<XCaptainPVPView, XCaptainPVPBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_Activity_GoddessTrial:
						case XSysDefine.XSys_EndlessAbyss:
						{
							bool flag3 = sys == XSysDefine.XSys_EndlessAbyss;
							TeamLevelType type;
							if (flag3)
							{
								type = TeamLevelType.TeamLevelEndlessAbyss;
							}
							else
							{
								type = TeamLevelType.TeamLevelGoddessTrial;
							}
							XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
							List<ExpeditionTable.RowData> expeditionList = specificDocument.GetExpeditionList(type);
							bool flag4 = expeditionList != null && expeditionList.Count > 0;
							if (flag4)
							{
								XLevelSealDocument specificDocument2 = XDocuments.GetSpecificDocument<XLevelSealDocument>(XLevelSealDocument.uuID);
								for (int i = 0; i < expeditionList.Count; i++)
								{
									bool flag5 = specificDocument2.SealType == expeditionList[i].LevelSealType;
									if (flag5)
									{
										specificDocument.ExpeditionId = expeditionList[i].DNExpeditionID;
										break;
									}
								}
							}
							XTeamDocument specificDocument3 = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
							specificDocument3.SetAndMatch(specificDocument.ExpeditionId);
							return;
						}
						case XSysDefine.XSys_Activity_TeamTowerSingle:
							DlgBase<ActivityTeamTowerSingleDlg, ActivityTeamTowerSingleDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_BigMelee:
							DlgBase<BigMeleeEntranceView, BigMeleeEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_Battlefield:
							DlgBase<BattleFieldEntranceView, BattleFieldEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_Activity_WeekDragonNest:
							DlgBase<CompeteNestDlg, CompeteNestBehaviour>.singleton.SetVisible(true, true);
							return;
						case XSysDefine.XSys_MulActivity_MulVoiceQA:
							DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_Activity);
							return;
						case XSysDefine.XSys_MulActivity_SkyArena:
							DlgBase<SkyArenaEntranceView, SkyArenaEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_MulActivity_Race:
							DlgBase<RaceEntranceView, RaceEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_MulActivity_WeekendParty:
							DlgBase<ActivityWeekendPartyView, ActivityWeekendPartyBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_Welfare_GiftBag:
						case XSysDefine.XSys_Welfare_StarFund:
						case XSysDefine.XSys_Welfare_FirstRechange:
						case XSysDefine.XSyS_Welfare_RewardBack:
						case XSysDefine.XSys_Welfare_MoneyTree:
						case XSysDefine.XSys_Welfare_KingdomPrivilege:
						case XSysDefine.XSys_Welfare_KingdomPrivilege_Court:
						case XSysDefine.XSys_Welfare_KingdomPrivilege_Adventurer:
						case XSysDefine.XSys_Welfare_KingdomPrivilege_Commerce:
						case XSysDefine.XSys_Welfare_YyMall:
							goto IL_10A0;
						case XSysDefine.Xsys_Backflow:
						case XSysDefine.Xsys_Backflow_LavishGift:
						case XSysDefine.Xsys_Backflow_NewServerReward:
						case XSysDefine.Xsys_Backflow_LevelUp:
						case XSysDefine.Xsys_Backflow_Task:
						case XSysDefine.Xsys_Backflow_Target:
						case XSysDefine.Xsys_Backflow_Privilege:
							goto IL_1248;
						case XSysDefine.Xsys_TaJieHelp:
							DlgBase<TaJieHelpDlg, TaJieHelpBehaviour>.singleton.SetVisible(true, true);
							return;
						default:
						{
							if (xsysDefine != XSysDefine.XSys_InGameAD)
							{
								goto IL_127F;
							}
							bool flag6 = XCampDuelDocument.Doc.curStage == 1;
							if (flag6)
							{
								DlgBase<InGameADView, InGameADBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							}
							else
							{
								XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CAMPDUEL_END_TIP"), "fece00");
							}
							return;
						}
						}
					}
					else
					{
						if (xsysDefine - XSysDefine.XSys_OperatingActivity <= 1)
						{
							goto IL_A88;
						}
						if (xsysDefine != XSysDefine.XSys_WeekNest)
						{
							goto IL_127F;
						}
						DlgBase<WeekNestDlg, WeeknestBehaviour>.singleton.SetVisible(true, true);
						return;
					}
					IL_7A1:
					DlgBase<EquipCreateDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
					return;
					IL_834:
					DlgBase<ItemSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
					return;
					IL_C42:
					DlgBase<RewardSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
					return;
					IL_DF7:
					DlgBase<DailyActivityDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
					return;
					IL_10A0:
					DlgBase<XWelfareView, XWelfareBehaviour>.singleton.Show(sys);
					return;
				}
				if (xsysDefine <= XSysDefine.XSys_GuildQualifier)
				{
					if (xsysDefine <= XSysDefine.XSys_GuildHall_Member)
					{
						if (xsysDefine <= XSysDefine.XSys_NPCFavor)
						{
							if (xsysDefine != XSysDefine.XSys_CampDuel)
							{
								switch (xsysDefine)
								{
								case XSysDefine.XSys_GameMall_Diamond:
									goto IL_E98;
								case XSysDefine.XSys_GameMall_Dragon:
								{
									XGameMallDocument specificDocument4 = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
									specificDocument4.currItemID = (int)param;
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_GameMall_Dragon);
									return;
								}
								case XSysDefine.XSys_GameMall_Pay:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_GameMall_Pay);
									return;
								case XSysDefine.XSys_GameMall_DWeek:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.WEEK, param);
									return;
								case XSysDefine.XSys_GameMall_DCost:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.COST, param);
									return;
								case XSysDefine.XSys_GameMall_DLongyu:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.LONGYU, param);
									return;
								case XSysDefine.XSys_GameMall_DFashion:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.FASHION, param);
									return;
								case XSysDefine.XSys_GameMall_DRide:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.RIDE, param);
									return;
								case XSysDefine.XSys_GameMall_DGift:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.GIFT, param);
									return;
								case XSysDefine.XSys_GameMall_DVip:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.VIP, param);
									return;
								case XSysDefine.XSys_GameMall_GWeek:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Dragon, MallType.WEEK, param);
									return;
								case XSysDefine.XSys_GameMall_GCost:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Dragon, MallType.COST, param);
									return;
								case XSysDefine.XSys_GameMall_GLongyu:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Dragon, MallType.LONGYU, param);
									return;
								case XSysDefine.XSys_GameMall_GRide:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Dragon, MallType.RIDE, param);
									return;
								case XSysDefine.XSys_GameMall_GGift:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Dragon, MallType.GIFT, param);
									return;
								case XSysDefine.XSys_GameMall_GEquip:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Dragon, MallType.EQUIP, param);
									return;
								case XSysDefine.Xsys_GameMall_DEquip:
									DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowMall(XSysDefine.XSys_GameMall_Diamond, MallType.EQUIP, param);
									return;
								default:
									switch (xsysDefine)
									{
									case XSysDefine.XSys_Partner:
										DlgBase<XFriendsView, XFriendsBehaviour>.singleton.ShowTab(sys);
										return;
									case XSysDefine.XSys_Parner_Liveness:
										goto IL_127F;
									case XSysDefine.XSys_Wedding:
										DlgBase<XFriendsView, XFriendsBehaviour>.singleton.ShowTab(sys);
										return;
									case XSysDefine.XSys_NPCFavor:
										DlgBase<XNPCFavorDlg, XNPCFavorBehaviour>.singleton.SetVisibleWithAnimation(true, null);
										return;
									default:
										goto IL_127F;
									}
									break;
								}
							}
						}
						else
						{
							switch (xsysDefine)
							{
							case XSysDefine.XSys_Pandora730:
							case XSysDefine.XSys_Pandora731:
							case XSysDefine.XSys_Pandora732:
							case XSysDefine.XSys_Pandora733:
							case XSysDefine.XSys_Pandora734:
							case XSysDefine.XSys_Pandora735:
							case XSysDefine.XSys_Pandora736:
							case XSysDefine.XSys_Pandora737:
							case XSysDefine.XSys_Pandora738:
							case XSysDefine.XSys_Pandora739:
							case XSysDefine.XSys_Pandora740:
							case XSysDefine.XSys_Pandora741:
							case XSysDefine.XSys_Pandora742:
							case XSysDefine.XSys_Pandora743:
							case XSysDefine.XSys_Pandora744:
							case XSysDefine.XSys_Pandora745:
							case XSysDefine.XSys_Pandora746:
							case XSysDefine.XSys_Pandora747:
							case XSysDefine.XSys_Pandora748:
							case XSysDefine.XSys_Pandora749:
							case XSysDefine.XSys_PandoraTest:
								break;
							case (XSysDefine)751:
							case (XSysDefine)752:
							case (XSysDefine)753:
							case (XSysDefine)754:
							case (XSysDefine)755:
							case (XSysDefine)756:
							case (XSysDefine)757:
							case (XSysDefine)758:
							case (XSysDefine)759:
								goto IL_127F;
							case XSysDefine.XSys_GroupRecruit:
								DlgBase<RecruitView, RecruitBehaviour>.singleton.SetVisibleWithAnimation(true, null);
								return;
							case XSysDefine.XSys_GroupRecruitAuthorize:
								DlgBase<RecruitAuthorizeView, RecruitAuthorizeBehaviour>.singleton.SetVisibleWithAnimation(true, null);
								return;
							default:
								if (xsysDefine - XSysDefine.XSys_GuildHall_SignIn > 1 && xsysDefine != XSysDefine.XSys_GuildHall_Member)
								{
									goto IL_127F;
								}
								goto IL_BD0;
							}
						}
					}
					else if (xsysDefine <= XSysDefine.XSys_GuildDungeon_SmallMonter)
					{
						switch (xsysDefine)
						{
						case XSysDefine.XSys_GuildRelax_Joker:
							goto IL_BD0;
						case XSysDefine.XSys_GuildRelax_VoiceQA:
							goto IL_B85;
						case XSysDefine.XSys_GuildRelax_JokerMatch:
						case XSysDefine.XSys_GuildLab_Consider:
						case XSysDefine.XSys_GuildLab_Build:
							goto IL_127F;
						case XSysDefine.XSys_GuildGrowthHunting:
							DlgBase<XGuildGrowthBuildView, XGuildGrowthBuildBehavior>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_GuildGrowthDonate:
							DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.DonateType = GuildDonateType.GrowthDonate;
							DlgBase<XGuildDonateView, XGuildDonateBehavior>.singleton.SetVisibleWithAnimation(true, null);
							return;
						default:
						{
							if (xsysDefine == XSysDefine.XSys_GuildBoon_RedPacket)
							{
								goto IL_BD0;
							}
							if (xsysDefine != XSysDefine.XSys_GuildDungeon_SmallMonter)
							{
								goto IL_127F;
							}
							XGuildDocument specificDocument5 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
							bool flag7 = specificDocument5.CheckInGuild();
							if (flag7)
							{
								bool flag8 = XGuildDocument.GuildConfig.GetUnlockLevel(sys) <= specificDocument5.Level && this.IsSystemOpened(sys);
								if (flag8)
								{
									XGuildSmallMonsterDocument specificDocument6 = XDocuments.GetSpecificDocument<XGuildSmallMonsterDocument>(XGuildSmallMonsterDocument.uuID);
									bool flag9 = specificDocument6.CheckEnterLevel();
									if (flag9)
									{
										DlgBase<XGuildSmallMonsterView, XGuildSmallMonsterBehaviour>.singleton.SetVisibleWithAnimation(true, null);
									}
								}
							}
							else
							{
								bool flag10 = !DlgBase<XGuildListView, XGuildListBehaviour>.singleton.IsVisible();
								if (flag10)
								{
									DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
								}
							}
							return;
						}
						}
					}
					else
					{
						if (xsysDefine == XSysDefine.XSys_GuildChallenge)
						{
							goto IL_B85;
						}
						if (xsysDefine == XSysDefine.XSys_WorldBoss_EndRank)
						{
							DlgBase<XWorldBossEndRankView, XWorldBossEndRankBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						}
						if (xsysDefine != XSysDefine.XSys_GuildQualifier)
						{
							goto IL_127F;
						}
						DlgBase<GuildQualifierDlg, GuildQualifierBehavior>.singleton.SetVisibleWithAnimation(true, null);
						return;
					}
				}
				else if (xsysDefine <= XSysDefine.XSys_HeroBattle)
				{
					if (xsysDefine <= XSysDefine.XSys_GuildWeeklyBountyTask)
					{
						if (xsysDefine == XSysDefine.XSys_GuildMineMain)
						{
							DlgBase<GuildMineMainView, GuildMineMainBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						}
						switch (xsysDefine)
						{
						case XSysDefine.XSys_GuildDailyTask:
						{
							bool flag11 = !this.GoToTakeDailyTask();
							if (flag11)
							{
								DlgBase<XGuildDailyTaskView, XGuildDailyTaskBehavior>.singleton.SetVisibleWithAnimation(true, null);
							}
							else
							{
								XSingleton<UIManager>.singleton.CloseAllUI();
							}
							return;
						}
						case XSysDefine.XSys_GuildDialyDonate:
							XGuildDonateDocument.Doc.ShowViewWithType(GuildDonateType.DailyDonate);
							return;
						case XSysDefine.XSys_GuildWeeklyDonate:
							XGuildDonateDocument.Doc.ShowViewWithType(GuildDonateType.WeeklyDonate);
							return;
						case (XSysDefine)889:
							goto IL_127F;
						case XSysDefine.XSys_GuildInherit:
							goto IL_BD0;
						default:
							switch (xsysDefine)
							{
							case XSysDefine.XSys_JockerKing:
								DlgBase<JokerKingMainView, JokerKingMainBehavior>.singleton.SetVisibleWithAnimation(true, null);
								return;
							case XSysDefine.XSys_Team_TeamList:
							case XSysDefine.XSys_Team_MyTeam:
								goto IL_127F;
							case XSysDefine.XSys_Team_Invited:
								DlgBase<XTeamInvitedListView, XTeamInvitedListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
								return;
							case XSysDefine.XSys_GuildWeeklyBountyTask:
							{
								bool flag12 = !this.GoToTakeWeeklyTask();
								if (flag12)
								{
									DlgBase<XGuildWeeklyBountyView, XGuildWeeklyBountyBehavior>.singleton.SetVisibleWithAnimation(true, null);
								}
								else
								{
									XSingleton<UIManager>.singleton.CloseAllUI();
								}
								return;
							}
							default:
								goto IL_127F;
							}
							break;
						}
					}
					else
					{
						switch (xsysDefine)
						{
						case XSysDefine.xSys_Mysterious:
							DlgBase<ActivityRiftDlg, ActivityRiftBehaviour>.singleton.SetVisible(true, true);
							return;
						case (XSysDefine)928:
						case (XSysDefine)929:
						case XSysDefine.XSys_SpriteSystem_Detail:
							goto IL_127F;
						case XSysDefine.XSys_SpriteSystem:
						case XSysDefine.XSys_SpriteSystem_Main:
						case XSysDefine.XSys_SpriteSystem_Lottery:
						case XSysDefine.XSys_SpriteSystem_Fight:
						case XSysDefine.XSys_SpriteSystem_Resolve:
						case XSysDefine.XSys_SpriteSystem_Shop:
							DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(sys);
							return;
						default:
							if (xsysDefine == XSysDefine.XSys_Link_Share)
							{
								XScreenShotShareDocument.DoShowShare();
								return;
							}
							if (xsysDefine != XSysDefine.XSys_HeroBattle)
							{
								goto IL_127F;
							}
							DlgBase<HeroBattleDlg, HeroBattleBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						}
					}
				}
				else if (xsysDefine <= XSysDefine.XSys_Moba)
				{
					if (xsysDefine == XSysDefine.XSys_TeamLeague)
					{
						DlgBase<XFreeTeamLeagueMainView, XFreeTeamLeagueMainBehavior>.singleton.SetVisibleWithAnimation(true, null);
						return;
					}
					if (xsysDefine == XSysDefine.XSys_ProfessionChange)
					{
						DlgBase<ProfessionChangeDlg, ProfessionChangeBehaviour>.singleton.SetVisibleWithAnimation(true, null);
						return;
					}
					if (xsysDefine != XSysDefine.XSys_Moba)
					{
						goto IL_127F;
					}
					DlgBase<MobaEntranceView, MobaEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					return;
				}
				else if (xsysDefine <= XSysDefine.XSys_Rename_Guild)
				{
					if (xsysDefine == XSysDefine.XSys_Rename_Player)
					{
						DlgBase<RenameDlg, RenameBehaviour>.singleton.ShowRenameSystem(XRenameDocument.RenameType.PLAYER_NAME_VOLUME);
						return;
					}
					if (xsysDefine != XSysDefine.XSys_Rename_Guild)
					{
						goto IL_127F;
					}
					DlgBase<RenameDlg, RenameBehaviour>.singleton.ShowRenameSystem(XRenameDocument.RenameType.GUILD_NAME_VOLUME);
					return;
				}
				else
				{
					if (xsysDefine == XSysDefine.XSys_BackFlowMall)
					{
						goto IL_1248;
					}
					if (xsysDefine != XSysDefine.XSys_Rename_DragonGuild)
					{
						goto IL_127F;
					}
					DlgBase<RenameDlg, RenameBehaviour>.singleton.ShowRenameSystem(XRenameDocument.RenameType.DRAGON_GUILD_NAME_VOLUME);
					return;
				}
				IL_A88:
				DlgBase<XOperatingActivityView, XOperatingActivityBehaviour>.singleton.Show(sys, false);
				return;
				IL_B85:
				XGuildDocument specificDocument7 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				GuildSceneState guildSceneState = specificDocument7.TryEnterGuildScene();
				bool flag13 = guildSceneState == GuildSceneState.GSS_InGuildScene;
				if (flag13)
				{
					this.OpenGuildSystem(sys);
				}
				else
				{
					bool flag14 = guildSceneState == GuildSceneState.GSS_NotGuildScene;
					if (flag14)
					{
						XSingleton<XUICacheMgr>.singleton.CacheUI(sys, EXStage.Hall);
					}
				}
				return;
				IL_BD0:
				XGuildDocument specificDocument8 = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
				bool bInGuild = specificDocument8.bInGuild;
				if (bInGuild)
				{
					this.OpenGuildSystem(sys);
				}
				else
				{
					DlgBase<XGuildListView, XGuildListBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				}
				return;
				IL_E98:
				XGameMallDocument specificDocument9 = XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
				specificDocument9.currItemID = (int)param;
				DlgBase<GameMallDlg, TabDlgBehaviour>.singleton.ShowWorkGameSystem(XSysDefine.XSys_GameMall_Diamond);
				return;
				IL_1248:
				DlgBase<XBackFlowDlg, XBackFlowBehavior>.singleton.ShowHandler(sys);
				return;
				IL_127F:
				XNormalShopDocument specificDocument10 = XDocuments.GetSpecificDocument<XNormalShopDocument>(XNormalShopDocument.uuID);
				bool flag15 = specificDocument10.IsShop(sys);
				if (flag15)
				{
					DlgBase<MallSystemDlg, MallSystemBehaviour>.singleton.ShowShopSystem(sys, 0UL);
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog("System jump not finished: ", sys.ToString(), null, null, null, null);
				}
			}
		}

		// Token: 0x0600C057 RID: 49239 RVA: 0x0028A96C File Offset: 0x00288B6C
		public void OpenGuildSystem(XSysDefine sys)
		{
			if (sys <= XSysDefine.XSys_GuildRelax_JokerMatch)
			{
				if (sys <= XSysDefine.XSys_GuildHall_Member)
				{
					switch (sys)
					{
					case XSysDefine.XSys_GuildHall:
						DlgBase<XGuildHallView, XGuildHallBehaviour>.singleton.SetVisibleWithAnimation(true, null);
						return;
					case XSysDefine.XSys_GuildRelax:
						break;
					case (XSysDefine)83:
					case (XSysDefine)84:
					case XSysDefine.XSys_GuildRedPacket:
						return;
					case XSysDefine.XSys_GuildDragon:
						DlgBase<XGuildDragonView, XGuildDragonBehaviour>.singleton.ShowGuildBossView();
						return;
					case XSysDefine.XSys_GuildPvp:
						DlgBase<XGuildArenaDlg, TabDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
						return;
					case XSysDefine.XSys_GuildMine:
						DlgBase<GuildMineEntranceView, GuildMineEntranceBehaviour>.singleton.SetVisibleWithAnimation(true, null);
						return;
					case XSysDefine.XSys_CrossGVG:
						DlgBase<CrossGVGMainView, TabDlgBehaviour>.singleton.SetVisibleWithAnimation(true, null);
						return;
					default:
						switch (sys)
						{
						case XSysDefine.XSys_GuildHall_SignIn:
							DlgBase<XGuildSignInView, XGuildSignInBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_GuildHall_Approve:
							DlgBase<XGuildApproveView, XGuildApproveBehaviour>.singleton.SetVisibleWithAnimation(true, null);
							return;
						case XSysDefine.XSys_GuildHall_Skill:
							return;
						case XSysDefine.XSys_GuildHall_Member:
							goto IL_161;
						default:
							return;
						}
						break;
					}
				}
				else
				{
					if (sys == XSysDefine.XSys_GuildRelax_Joker)
					{
						DlgBase<XGuildJokerView, XGuildJokerBehaviour>.singleton.SetVisibleWithAnimation(true, null);
						return;
					}
					if (sys - XSysDefine.XSys_GuildRelax_VoiceQA > 1)
					{
						return;
					}
				}
				DlgBase<XGuildRelaxGameView, XGuildRelaxGameBehaviour>.singleton.SetVisibleWithAnimation(true, null);
				return;
			}
			if (sys <= XSysDefine.XSys_GuildChallenge)
			{
				if (sys == XSysDefine.XSys_GuildBoon_RedPacket)
				{
					DlgBase<XGuildSignRedPackageView, XGuildSignRedPackageBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					return;
				}
				if (sys != XSysDefine.XSys_GuildChallenge)
				{
					return;
				}
				return;
			}
			else
			{
				if (sys == XSysDefine.XSys_GuildQualifier)
				{
					DlgBase<GuildQualifierDlg, GuildQualifierBehavior>.singleton.SetVisibleWithAnimation(true, null);
					return;
				}
				if (sys != XSysDefine.XSys_GuildInherit)
				{
					if (sys != XSysDefine.XSys_GuildTerritory)
					{
						return;
					}
					DlgBase<GuildTerritoryMainDlg, GuildTerritoryMainBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					return;
				}
			}
			IL_161:
			DlgBase<XGuildMembersView, XGuildMembersBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0600C058 RID: 49240 RVA: 0x0028AB18 File Offset: 0x00288D18
		private bool GoToTakeDailyTask()
		{
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			XTaskRecord taskRecord = specificDocument.TaskRecord;
			for (int i = 0; i < taskRecord.Tasks.Count; i++)
			{
				bool flag = taskRecord.Tasks[i].Status == TaskStatus.TaskStatus_CanTake && taskRecord.Tasks[i].TableData.TaskType == 4U;
				if (flag)
				{
					specificDocument.DoTask(taskRecord.Tasks[i].ID);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600C059 RID: 49241 RVA: 0x0028ABB0 File Offset: 0x00288DB0
		private bool GoToTakeWeeklyTask()
		{
			XTaskDocument specificDocument = XDocuments.GetSpecificDocument<XTaskDocument>(XTaskDocument.uuID);
			XTaskRecord taskRecord = specificDocument.TaskRecord;
			for (int i = 0; i < taskRecord.Tasks.Count; i++)
			{
				bool flag = taskRecord.Tasks[i].Status == TaskStatus.TaskStatus_CanTake && taskRecord.Tasks[i].TableData.TaskType == 7U;
				if (flag)
				{
					specificDocument.DoTask(taskRecord.Tasks[i].ID);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0400504B RID: 20555
		private XTableAsyncLoader _async_loader = null;

		// Token: 0x0400504C RID: 20556
		private OpenSystemTable _openSystemTable = new OpenSystemTable();

		// Token: 0x0400504D RID: 20557
		private SystemAnnounce _announceSystemTable = new SystemAnnounce();

		// Token: 0x0400504E RID: 20558
		private uint m_PlayerLevel;

		// Token: 0x0400504F RID: 20559
		private XOptionsDocument optionsDoc;

		// Token: 0x04005050 RID: 20560
		private SysIntCache alwaysOpen = new SysIntCache(1024);

		// Token: 0x04005051 RID: 20561
		private SysIntCache redPointState = new SysIntCache(1024);

		// Token: 0x04005052 RID: 20562
		private List<uint>[] noRedPointLevel = new List<uint>[1024];

		// Token: 0x04005053 RID: 20563
		private List<XSysDefine>[] sysRedPointRelative = new List<XSysDefine>[1024];

		// Token: 0x04005054 RID: 20564
		private SysIntCache sysRedPointHasRefreshed = new SysIntCache(1024);

		// Token: 0x04005055 RID: 20565
		private HashSet<XSysDefine> _sysH5 = new HashSet<XSysDefine>(default(XFastEnumIntEqualityComparer<XSysDefine>));

		// Token: 0x04005056 RID: 20566
		private GameObject[] sysRedPointRelativeUI = new GameObject[1024];

		// Token: 0x04005057 RID: 20567
		private XSubSysRedPointMgr[] subSysRedPoint = new XSubSysRedPointMgr[1024];

		// Token: 0x04005058 RID: 20568
		public List<int> m_AnnounceSys = new List<int>();

		// Token: 0x04005059 RID: 20569
		private List<XSysDefine> _ReturnList = new List<XSysDefine>();

		// Token: 0x0400505B RID: 20571
		private bool m_bStopBlockRedPoint;

		// Token: 0x0400505C RID: 20572
		private float _getFlowerRemainTime;

		// Token: 0x0400505D RID: 20573
		private float _onlineRewardRemainTime;

		// Token: 0x0400505E RID: 20574
		private IXUILabel OnlineTime = null;

		// Token: 0x0400505F RID: 20575
		private XSysDefine[] _allXSysDefines;
	}
}
