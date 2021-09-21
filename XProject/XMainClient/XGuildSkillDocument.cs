using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009AC RID: 2476
	internal class XGuildSkillDocument : XDocComponent
	{
		// Token: 0x17002D3D RID: 11581
		// (get) Token: 0x060095F2 RID: 38386 RVA: 0x00168F38 File Offset: 0x00167138
		public override uint ID
		{
			get
			{
				return XGuildSkillDocument.uuID;
			}
		}

		// Token: 0x17002D3E RID: 11582
		// (get) Token: 0x060095F3 RID: 38387 RVA: 0x00168F4F File Offset: 0x0016714F
		// (set) Token: 0x060095F4 RID: 38388 RVA: 0x00168F57 File Offset: 0x00167157
		public XPlayerAttributes Player { get; set; }

		// Token: 0x17002D3F RID: 11583
		// (get) Token: 0x060095F5 RID: 38389 RVA: 0x00168F60 File Offset: 0x00167160
		// (set) Token: 0x060095F6 RID: 38390 RVA: 0x00168F68 File Offset: 0x00167168
		public XBagDocument BagDoc { get; set; }

		// Token: 0x17002D40 RID: 11584
		// (get) Token: 0x060095F7 RID: 38391 RVA: 0x00168F71 File Offset: 0x00167171
		// (set) Token: 0x060095F8 RID: 38392 RVA: 0x00168F79 File Offset: 0x00167179
		public XGuildDocument GuildDoc { get; set; }

		// Token: 0x17002D41 RID: 11585
		// (get) Token: 0x060095F9 RID: 38393 RVA: 0x00168F82 File Offset: 0x00167182
		// (set) Token: 0x060095FA RID: 38394 RVA: 0x00168F8A File Offset: 0x0016718A
		public uint CurrentSkillID { get; set; }

		// Token: 0x17002D42 RID: 11586
		// (get) Token: 0x060095FC RID: 38396 RVA: 0x00168F9C File Offset: 0x0016719C
		// (set) Token: 0x060095FB RID: 38395 RVA: 0x00168F93 File Offset: 0x00167193
		public int LastGuildExp { get; set; }

		// Token: 0x17002D43 RID: 11587
		// (get) Token: 0x060095FD RID: 38397 RVA: 0x00168FA4 File Offset: 0x001671A4
		// (set) Token: 0x060095FE RID: 38398 RVA: 0x00168FBC File Offset: 0x001671BC
		public bool RedPoint
		{
			get
			{
				return this.m_RedPoint;
			}
			set
			{
				this.m_RedPoint = value;
			}
		}

		// Token: 0x060095FF RID: 38399 RVA: 0x00168FC8 File Offset: 0x001671C8
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.GuildPointChanged));
			base.RegisterEvent(XEventDefine.XEvent_GuildInfoChange, new XComponent.XEventHandler(this.GuildStatusChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnPlayerLeaveGuild));
		}

		// Token: 0x06009600 RID: 38400 RVA: 0x00169034 File Offset: 0x00167234
		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildSkillDocument.AsyncLoader.AddTask("Table/GuildSkill", XGuildSkillDocument.m_guidlSkillTable, false);
			XGuildSkillDocument.AsyncLoader.Execute(callback);
			XGuildSkillDocument.m_guildSkillMaxLevels.Clear();
			XGuildSkillDocument.m_guildSkillInitLevels.Clear();
			XGuildSkillDocument.GuildSkllDic.Clear();
		}

		// Token: 0x06009601 RID: 38401 RVA: 0x00169088 File Offset: 0x00167288
		public static void OnTableLoaded()
		{
			XGuildSkillDocument.GuildSkllDic.Clear();
			XGuildSkillDocument._labSkillMaxLevel.Clear();
			int i = 0;
			int num = XGuildSkillDocument.m_guidlSkillTable.Table.Length;
			while (i < num)
			{
				GuildSkillTable.RowData rowData = XGuildSkillDocument.m_guidlSkillTable.Table[i];
				bool flag = rowData.needtype == 2U;
				if (flag)
				{
					uint num2 = 0U;
					bool flag2 = XGuildSkillDocument._labSkillMaxLevel.TryGetValue(rowData.skillid, out num2);
					if (flag2)
					{
						bool flag3 = num2 < rowData.level;
						if (flag3)
						{
							XGuildSkillDocument._labSkillMaxLevel[rowData.skillid] = rowData.level;
						}
					}
					else
					{
						XGuildSkillDocument._labSkillMaxLevel.Add(rowData.skillid, rowData.level);
					}
				}
				Dictionary<uint, GuildSkillTable.RowData> dictionary;
				bool flag4 = !XGuildSkillDocument.GuildSkllDic.TryGetValue(rowData.skillid, out dictionary);
				if (flag4)
				{
					XGuildSkillDocument.GuildSkillIDs.Add(rowData.skillid);
					dictionary = new Dictionary<uint, GuildSkillTable.RowData>();
					XGuildSkillDocument.GuildSkllDic.Add(rowData.skillid, dictionary);
				}
				bool flag5 = !dictionary.ContainsKey(rowData.level);
				if (flag5)
				{
					dictionary.Add(rowData.level, rowData);
					bool flag6 = XGuildSkillDocument.m_guildSkillMaxLevels.ContainsKey(rowData.skillid);
					if (flag6)
					{
						XGuildSkillDocument.m_guildSkillMaxLevels[rowData.skillid] = Math.Max(rowData.level, XGuildSkillDocument.m_guildSkillMaxLevels[rowData.skillid]);
					}
					else
					{
						XGuildSkillDocument.m_guildSkillMaxLevels.Add(rowData.skillid, rowData.level);
					}
					bool flag7 = rowData.glevel > 0U;
					if (!flag7)
					{
						bool flag8 = XGuildSkillDocument.m_guildSkillInitLevels.ContainsKey(rowData.skillid);
						if (flag8)
						{
							XGuildSkillDocument.m_guildSkillInitLevels[rowData.skillid] = Math.Max(rowData.level, XGuildSkillDocument.m_guildSkillInitLevels[rowData.skillid]);
						}
						else
						{
							XGuildSkillDocument.m_guildSkillInitLevels.Add(rowData.skillid, rowData.level);
						}
					}
				}
				else
				{
					XSingleton<XDebug>.singleton.AddErrorLog(string.Format("the skill[{0}] has same level[{1}] in GuildSKill.txt", rowData.skillid, rowData.level), null, null, null, null, null);
				}
				i++;
			}
		}

		// Token: 0x06009602 RID: 38402 RVA: 0x001692B8 File Offset: 0x001674B8
		public uint GetGuildSkillInitLevel(uint skillID)
		{
			uint num = 0U;
			bool flag = XGuildSkillDocument.m_guildSkillInitLevels.TryGetValue(skillID, out num);
			uint result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x06009603 RID: 38403 RVA: 0x001692E4 File Offset: 0x001674E4
		public uint GetGuildSkillMaxLevel(uint skillID)
		{
			uint num = 0U;
			bool flag = XGuildSkillDocument.m_guildSkillMaxLevels.TryGetValue(skillID, out num);
			uint result;
			if (flag)
			{
				result = num;
			}
			else
			{
				result = 0U;
			}
			return result;
		}

		// Token: 0x06009604 RID: 38404 RVA: 0x00169310 File Offset: 0x00167510
		public bool TryGetGuildSkillMaxLevel(uint skillID, out uint maxLevel)
		{
			return XGuildSkillDocument.m_guildSkillMaxLevels.TryGetValue(skillID, out maxLevel);
		}

		// Token: 0x06009605 RID: 38405 RVA: 0x00169330 File Offset: 0x00167530
		public GuildSkillTable.RowData GetGuildSkill(uint skillID, uint level)
		{
			GuildSkillTable.RowData rowData;
			bool flag = this.TryGetGuildSkill(skillID, level, out rowData);
			GuildSkillTable.RowData result;
			if (flag)
			{
				result = rowData;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06009606 RID: 38406 RVA: 0x00169358 File Offset: 0x00167558
		public bool TryGetGuildSkill(uint skillID, uint level, out GuildSkillTable.RowData skillData)
		{
			Dictionary<uint, GuildSkillTable.RowData> dictionary;
			skillData = null;
			bool flag = XGuildSkillDocument.GuildSkllDic.TryGetValue(skillID, out dictionary) && dictionary.TryGetValue(level, out skillData);
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		// Token: 0x06009607 RID: 38407 RVA: 0x00169394 File Offset: 0x00167594
		public uint GetCurGuildSkillLevel(uint skillID)
		{
			uint result = 0U;
			this.m_curGuildSkillLevel.TryGetValue(skillID, out result);
			return result;
		}

		// Token: 0x06009608 RID: 38408 RVA: 0x001693B8 File Offset: 0x001675B8
		public void SendLearnGuildSkill()
		{
			RpcC2G_LearnGuildSkill rpcC2G_LearnGuildSkill = new RpcC2G_LearnGuildSkill();
			rpcC2G_LearnGuildSkill.oArg.skillId = this.CurrentSkillID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_LearnGuildSkill);
			this.m_SendPoint = true;
		}

		// Token: 0x06009609 RID: 38409 RVA: 0x001693F4 File Offset: 0x001675F4
		public void ReceiveLearnGuildSKill(LearnGuildSkillAgr oArg, LearnGuildSkillRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowErrorCode(oRes.errorcode);
			}
			else
			{
				bool sendPoint = this.m_SendPoint;
				if (sendPoint)
				{
					this.m_SendPoint = false;
					this.SetRedPointValid();
				}
				bool flag2 = this.m_curGuildSkillLevel.ContainsKey(oArg.skillId);
				if (flag2)
				{
					uint value = this.m_curGuildSkillLevel[oArg.skillId] + 1U;
					this.m_curGuildSkillLevel[oArg.skillId] = value;
				}
				else
				{
					this.m_curGuildSkillLevel.Add(oArg.skillId, 1U);
				}
				this.Refresh();
			}
		}

		// Token: 0x0600960A RID: 38410 RVA: 0x0016949C File Offset: 0x0016769C
		public void GetSkillList()
		{
			RpcC2M_AskGuildSkillInfoNew rpc = new RpcC2M_AskGuildSkillInfoNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

		// Token: 0x0600960B RID: 38411 RVA: 0x001694BC File Offset: 0x001676BC
		public void OnSkillList(AskGuildSkillInfoReq org)
		{
			bool flag = org.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(org.errorcode, "fece00");
			}
			else
			{
				this.LastGuildExp = org.LastGuildExp;
				this.m_guildSkillDataDic.Clear();
				int i = 0;
				int count = org.SkillLel.Count;
				while (i < count)
				{
					this.m_guildSkillDataDic[(uint)org.SkillLel[i].SkillId] = (uint)org.SkillLel[i].MaxLvl;
					i++;
				}
				this.m_curGuildSkillLevel.Clear();
				i = 0;
				count = org.roleSkills.Count;
				while (i < count)
				{
					this.m_curGuildSkillLevel[(uint)org.roleSkills[i].SkillId] = (uint)org.roleSkills[i].MaxLvl;
					i++;
				}
				this.Refresh();
			}
		}

		// Token: 0x0600960C RID: 38412 RVA: 0x001695BC File Offset: 0x001677BC
		public void OnUpdateGuildSkillData(GuildSkillAllData org)
		{
			this.LastGuildExp = org.lastGuildExp;
			int i = 0;
			int count = org.skillLevel.Count;
			while (i < count)
			{
				this.m_guildSkillDataDic[(uint)org.skillLevel[i].SkillId] = (uint)org.skillLevel[i].MaxLvl;
				i++;
			}
			this.Refresh();
		}

		// Token: 0x0600960D RID: 38413 RVA: 0x0016962C File Offset: 0x0016782C
		public void GetStudyGuildSkill(uint skillID)
		{
			RpcC2M_StudyGuildSkillNew rpcC2M_StudyGuildSkillNew = new RpcC2M_StudyGuildSkillNew();
			rpcC2M_StudyGuildSkillNew.oArg.skillId = skillID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_StudyGuildSkillNew);
		}

		// Token: 0x0600960E RID: 38414 RVA: 0x0016965C File Offset: 0x0016785C
		public void OnStudyGuildSkill(StudyGuildSkillRes oRes)
		{
			bool flag = oRes.errorcode > ErrorCode.ERR_SUCCESS;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(oRes.errorcode, "fece00");
			}
			else
			{
				this.m_guildSkillDataDic[oRes.skillId] = oRes.skillLel;
				this.LastGuildExp = (int)oRes.lastExp;
				bool flag2 = DlgBase<XGuildSkillView, XGuildSkillBehaviour>.singleton.IsVisible() && DlgBase<XGuildSkillView, XGuildSkillBehaviour>.singleton._StudyHandle.active;
				if (flag2)
				{
					DlgBase<XGuildSkillView, XGuildSkillBehaviour>.singleton._StudyHandle.ShowEffectDetailInfo();
				}
				bool flag3 = DlgBase<XGuildGrowthLabView, XGuildGrowthLabBehavior>.singleton.IsVisible();
				if (flag3)
				{
					DlgBase<XGuildGrowthLabView, XGuildGrowthLabBehavior>.singleton.RefreshList(true);
				}
			}
		}

		// Token: 0x0600960F RID: 38415 RVA: 0x00169704 File Offset: 0x00167904
		public uint GetSkillMaxLevel(uint skillID)
		{
			uint result = 0U;
			this.m_guildSkillDataDic.TryGetValue(skillID, out result);
			return result;
		}

		// Token: 0x06009610 RID: 38416 RVA: 0x00169728 File Offset: 0x00167928
		public uint GetLabSkillMaxLevel(uint skillID)
		{
			uint result = 0U;
			XGuildSkillDocument._labSkillMaxLevel.TryGetValue(skillID, out result);
			return result;
		}

		// Token: 0x06009611 RID: 38417 RVA: 0x0016974C File Offset: 0x0016794C
		public override void OnEnterScene()
		{
			base.OnEnterScene();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
			}
		}

		// Token: 0x06009612 RID: 38418 RVA: 0x0016977C File Offset: 0x0016797C
		public bool GuildPointChanged(XEventArgs args)
		{
			XVirtualItemChangedEventArgs xvirtualItemChangedEventArgs = args as XVirtualItemChangedEventArgs;
			ItemEnum itemID = (ItemEnum)xvirtualItemChangedEventArgs.itemID;
			bool flag = itemID != ItemEnum.GUILD_CONTRIBUTE;
			bool result;
			if (flag)
			{
				result = true;
			}
			else
			{
				this.RefreshRedPoint();
				result = true;
			}
			return result;
		}

		// Token: 0x06009613 RID: 38419 RVA: 0x001697B4 File Offset: 0x001679B4
		public bool GuildStatusChanged(XEventArgs args)
		{
			this.RefreshRedPoint();
			return true;
		}

		// Token: 0x06009614 RID: 38420 RVA: 0x001697D0 File Offset: 0x001679D0
		public void Refresh()
		{
			this.RefreshRedPoint();
			bool flag = !DlgBase<XGuildSkillView, XGuildSkillBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildSkillView, XGuildSkillBehaviour>.singleton.SetupSkillList(false, false);
			}
		}

		// Token: 0x06009615 RID: 38421 RVA: 0x00169808 File Offset: 0x00167A08
		public void RefreshRedPoint()
		{
			XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
			this.m_RedPoint = false;
			bool flag = !specificDocument.bInGuild;
			if (flag)
			{
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_Skill, true);
			}
			else
			{
				int num = (int)XDocuments.GetSpecificDocument<XBagDocument>(XBagDocument.uuID).VirtualItems[22];
				for (int i = 0; i < XGuildSkillDocument.GuildSkillIDs.Count; i++)
				{
					uint curGuildSkillLevel = this.GetCurGuildSkillLevel(XGuildSkillDocument.GuildSkillIDs[i]);
					GuildSkillTable.RowData rowData;
					bool flag2 = this.TryGetGuildSkill(XGuildSkillDocument.GuildSkillIDs[i], curGuildSkillLevel, out rowData);
					if (flag2)
					{
						uint skillMaxLevel = this.GetSkillMaxLevel(XGuildSkillDocument.GuildSkillIDs[i]);
						bool flag3 = this.GetRedPointValid() && curGuildSkillLevel < skillMaxLevel && (ulong)rowData.need[0, 1] <= (ulong)((long)num) && rowData.roleLevel <= XSingleton<XAttributeMgr>.singleton.XPlayerData.Level && rowData.glevel <= specificDocument.Level;
						if (flag3)
						{
							this.m_RedPoint = true;
							break;
						}
						bool flag4 = specificDocument.IHavePermission(GuildPermission.GPEM_STUDY_SKILL) && this.CanMaxLevelUp(XGuildSkillDocument.GuildSkillIDs[i], skillMaxLevel);
						if (flag4)
						{
							this.m_RedPoint = true;
							break;
						}
					}
				}
				XSingleton<XGameSysMgr>.singleton.RecalculateRedPointState(XSysDefine.XSys_GuildHall_Skill, true);
			}
		}

		// Token: 0x06009616 RID: 38422 RVA: 0x00169970 File Offset: 0x00167B70
		public bool GetRedPointValid()
		{
			return XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID).GetValue(XOptionsDefine.OD_GUILD_SKILL_LOCK) == 1;
		}

		// Token: 0x06009617 RID: 38423 RVA: 0x0016999C File Offset: 0x00167B9C
		public void SetRedPointValid()
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			bool flag = specificDocument.GetValue(XOptionsDefine.OD_GUILD_SKILL_LOCK) == 1;
			if (flag)
			{
				specificDocument.SetValue(XOptionsDefine.OD_GUILD_SKILL_LOCK, 0, false);
			}
		}

		// Token: 0x06009618 RID: 38424 RVA: 0x001699D8 File Offset: 0x00167BD8
		public bool CanMaxLevelUp(uint skillId, uint skillLevel)
		{
			uint num;
			bool flag = !this.TryGetGuildSkillMaxLevel(skillId, out num) || num <= skillLevel;
			bool result;
			if (flag)
			{
				result = false;
			}
			else
			{
				GuildSkillTable.RowData rowData;
				bool flag2 = !this.TryGetGuildSkill(skillId, num, out rowData);
				if (flag2)
				{
					result = false;
				}
				else
				{
					XGuildDocument specificDocument = XDocuments.GetSpecificDocument<XGuildDocument>(XGuildDocument.uuID);
					uint num2 = XGuildDocument.GuildConfig.GetTotalStudyCount((int)rowData.glevel, (int)specificDocument.Level) + this.GetGuildSkillInitLevel(skillId);
					result = (num2 > num && (ulong)rowData.rexp <= (ulong)((long)this.LastGuildExp));
				}
			}
			return result;
		}

		// Token: 0x06009619 RID: 38425 RVA: 0x00169A68 File Offset: 0x00167C68
		private bool OnPlayerLevelChange(XEventArgs args)
		{
			this.RefreshRedPoint();
			return true;
		}

		// Token: 0x0600961A RID: 38426 RVA: 0x00169A84 File Offset: 0x00167C84
		private bool OnPlayerLeaveGuild(XEventArgs args)
		{
			XInGuildStateChangedEventArgs xinGuildStateChangedEventArgs = args as XInGuildStateChangedEventArgs;
			bool bIsEnter = xinGuildStateChangedEventArgs.bIsEnter;
			if (bIsEnter)
			{
				RpcC2M_AskGuildSkillInfoNew rpc = new RpcC2M_AskGuildSkillInfoNew();
				XSingleton<XClientNetwork>.singleton.Send(rpc);
			}
			return true;
		}

		// Token: 0x0600961B RID: 38427 RVA: 0x000FEEFC File Offset: 0x000FD0FC
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		// Token: 0x040032EC RID: 13036
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildSkillDocument");

		// Token: 0x040032ED RID: 13037
		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		// Token: 0x040032EE RID: 13038
		public static GuildSkillTable m_guidlSkillTable = new GuildSkillTable();

		// Token: 0x040032EF RID: 13039
		public static Dictionary<uint, Dictionary<uint, GuildSkillTable.RowData>> GuildSkllDic = new Dictionary<uint, Dictionary<uint, GuildSkillTable.RowData>>();

		// Token: 0x040032F0 RID: 13040
		private static Dictionary<uint, uint> m_guildSkillMaxLevels = new Dictionary<uint, uint>();

		// Token: 0x040032F1 RID: 13041
		private static Dictionary<uint, uint> m_guildSkillInitLevels = new Dictionary<uint, uint>();

		// Token: 0x040032F2 RID: 13042
		public static List<uint> GuildSkillIDs = new List<uint>();

		// Token: 0x040032F3 RID: 13043
		private Dictionary<uint, uint> m_guildSkillDataDic = new Dictionary<uint, uint>();

		// Token: 0x040032F4 RID: 13044
		private Dictionary<uint, uint> m_curGuildSkillLevel = new Dictionary<uint, uint>();

		// Token: 0x040032F5 RID: 13045
		private static Dictionary<uint, uint> _labSkillMaxLevel = new Dictionary<uint, uint>();

		// Token: 0x040032FB RID: 13051
		private bool m_RedPoint = true;

		// Token: 0x040032FC RID: 13052
		private bool m_SendPoint = false;

		// Token: 0x040032FD RID: 13053
		public XGuildSkillView SKillView = null;

		// Token: 0x040032FE RID: 13054
		public XGuildGrowthLabView LabView = null;
	}
}
