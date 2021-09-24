using System;
using System.Collections.Generic;
using KKSG;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XGuildSkillDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XGuildSkillDocument.uuID;
			}
		}

		public XPlayerAttributes Player { get; set; }

		public XBagDocument BagDoc { get; set; }

		public XGuildDocument GuildDoc { get; set; }

		public uint CurrentSkillID { get; set; }

		public int LastGuildExp { get; set; }

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

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_VirtualItemChanged, new XComponent.XEventHandler(this.GuildPointChanged));
			base.RegisterEvent(XEventDefine.XEvent_GuildInfoChange, new XComponent.XEventHandler(this.GuildStatusChanged));
			base.RegisterEvent(XEventDefine.XEvent_PlayerLevelChange, new XComponent.XEventHandler(this.OnPlayerLevelChange));
			base.RegisterEvent(XEventDefine.XEvent_InGuildStateChanged, new XComponent.XEventHandler(this.OnPlayerLeaveGuild));
		}

		public static void Execute(OnLoadedCallback callback = null)
		{
			XGuildSkillDocument.AsyncLoader.AddTask("Table/GuildSkill", XGuildSkillDocument.m_guidlSkillTable, false);
			XGuildSkillDocument.AsyncLoader.Execute(callback);
			XGuildSkillDocument.m_guildSkillMaxLevels.Clear();
			XGuildSkillDocument.m_guildSkillInitLevels.Clear();
			XGuildSkillDocument.GuildSkllDic.Clear();
		}

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

		public bool TryGetGuildSkillMaxLevel(uint skillID, out uint maxLevel)
		{
			return XGuildSkillDocument.m_guildSkillMaxLevels.TryGetValue(skillID, out maxLevel);
		}

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

		public uint GetCurGuildSkillLevel(uint skillID)
		{
			uint result = 0U;
			this.m_curGuildSkillLevel.TryGetValue(skillID, out result);
			return result;
		}

		public void SendLearnGuildSkill()
		{
			RpcC2G_LearnGuildSkill rpcC2G_LearnGuildSkill = new RpcC2G_LearnGuildSkill();
			rpcC2G_LearnGuildSkill.oArg.skillId = this.CurrentSkillID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2G_LearnGuildSkill);
			this.m_SendPoint = true;
		}

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

		public void GetSkillList()
		{
			RpcC2M_AskGuildSkillInfoNew rpc = new RpcC2M_AskGuildSkillInfoNew();
			XSingleton<XClientNetwork>.singleton.Send(rpc);
		}

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

		public void GetStudyGuildSkill(uint skillID)
		{
			RpcC2M_StudyGuildSkillNew rpcC2M_StudyGuildSkillNew = new RpcC2M_StudyGuildSkillNew();
			rpcC2M_StudyGuildSkillNew.oArg.skillId = skillID;
			XSingleton<XClientNetwork>.singleton.Send(rpcC2M_StudyGuildSkillNew);
		}

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

		public uint GetSkillMaxLevel(uint skillID)
		{
			uint result = 0U;
			this.m_guildSkillDataDic.TryGetValue(skillID, out result);
			return result;
		}

		public uint GetLabSkillMaxLevel(uint skillID)
		{
			uint result = 0U;
			XGuildSkillDocument._labSkillMaxLevel.TryGetValue(skillID, out result);
			return result;
		}

		public override void OnEnterScene()
		{
			base.OnEnterScene();
			bool flag = XSingleton<XGame>.singleton.CurrentStage.Stage == EXStage.Hall;
			if (flag)
			{
			}
		}

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

		public bool GuildStatusChanged(XEventArgs args)
		{
			this.RefreshRedPoint();
			return true;
		}

		public void Refresh()
		{
			this.RefreshRedPoint();
			bool flag = !DlgBase<XGuildSkillView, XGuildSkillBehaviour>.singleton.IsVisible();
			if (!flag)
			{
				DlgBase<XGuildSkillView, XGuildSkillBehaviour>.singleton.SetupSkillList(false, false);
			}
		}

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

		public bool GetRedPointValid()
		{
			return XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID).GetValue(XOptionsDefine.OD_GUILD_SKILL_LOCK) == 1;
		}

		public void SetRedPointValid()
		{
			XOptionsDocument specificDocument = XDocuments.GetSpecificDocument<XOptionsDocument>(XOptionsDocument.uuID);
			bool flag = specificDocument.GetValue(XOptionsDefine.OD_GUILD_SKILL_LOCK) == 1;
			if (flag)
			{
				specificDocument.SetValue(XOptionsDefine.OD_GUILD_SKILL_LOCK, 0, false);
			}
		}

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

		private bool OnPlayerLevelChange(XEventArgs args)
		{
			this.RefreshRedPoint();
			return true;
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("GuildSkillDocument");

		public static XTableAsyncLoader AsyncLoader = new XTableAsyncLoader();

		public static GuildSkillTable m_guidlSkillTable = new GuildSkillTable();

		public static Dictionary<uint, Dictionary<uint, GuildSkillTable.RowData>> GuildSkllDic = new Dictionary<uint, Dictionary<uint, GuildSkillTable.RowData>>();

		private static Dictionary<uint, uint> m_guildSkillMaxLevels = new Dictionary<uint, uint>();

		private static Dictionary<uint, uint> m_guildSkillInitLevels = new Dictionary<uint, uint>();

		public static List<uint> GuildSkillIDs = new List<uint>();

		private Dictionary<uint, uint> m_guildSkillDataDic = new Dictionary<uint, uint>();

		private Dictionary<uint, uint> m_curGuildSkillLevel = new Dictionary<uint, uint>();

		private static Dictionary<uint, uint> _labSkillMaxLevel = new Dictionary<uint, uint>();

		private bool m_RedPoint = true;

		private bool m_SendPoint = false;

		public XGuildSkillView SKillView = null;

		public XGuildGrowthLabView LabView = null;
	}
}
