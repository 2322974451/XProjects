using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GroupMemberDisplay
	{

		public void Init(Transform t)
		{
			this.Setup(t, "Name", ref this._UserNameLabel);
			this.Setup(t, "DungeonName", ref this._StageNameLabel);
			this.Setup(t, "GroupName", ref this._GroupNameLabel);
			this.Setup(t, "Fight", ref this._FightLabel);
			this.Setup(t, "Job", ref this._TypeLabel);
			this.Setup(t, "Time", ref this._TimeLabel);
			this.Setup(t, "Profession", ref this._ProfessionSprite);
			this.Setup(t, "Portrait", ref this._PortraitSprite);
		}

		private void Setup(Transform t, string targetName, ref IXUILabel label)
		{
			Transform transform = t.Find(targetName);
			bool flag = transform != null;
			if (flag)
			{
				label = (transform.GetComponent("XUILabel") as IXUILabel);
			}
			else
			{
				label = null;
			}
		}

		private void Setup(Transform t, string targetName, ref IXUISprite sprite)
		{
			Transform transform = t.Find(targetName);
			bool flag = transform != null;
			if (flag)
			{
				sprite = (transform.GetComponent("XUISprite") as IXUISprite);
			}
			else
			{
				sprite = null;
			}
		}

		public void Release()
		{
			this._UserNameLabel = null;
			this._StageNameLabel = null;
			this._GroupNameLabel = null;
			this._FightLabel = null;
			this._TypeLabel = null;
			this._TimeLabel = null;
			this._ProfessionSprite = null;
			this._PortraitSprite = null;
		}

		public void Setup(GroupMember member)
		{
			bool flag = this._ProfessionSprite != null;
			if (flag)
			{
				this._ProfessionSprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfIcon(member.profession));
			}
			bool flag2 = this._PortraitSprite != null;
			if (flag2)
			{
				this._PortraitSprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(member.profession));
				this._PortraitSprite.ID = member.userID;
				this._PortraitSprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnPlayerClick));
			}
			bool flag3 = this._UserNameLabel != null;
			if (flag3)
			{
				this._UserNameLabel.SetText(member.userName);
			}
			bool flag4 = this._StageNameLabel != null && member.stageID > 0U;
			if (flag4)
			{
				XExpeditionDocument specificDocument = XDocuments.GetSpecificDocument<XExpeditionDocument>(XExpeditionDocument.uuID);
				ExpeditionTable.RowData expeditionDataByID = specificDocument.GetExpeditionDataByID((int)member.stageID);
				this._StageNameLabel.SetText((expeditionDataByID != null) ? XExpeditionDocument.GetFullName(expeditionDataByID) : "");
			}
			bool flag5 = this._GroupNameLabel != null;
			if (flag5)
			{
				this._GroupNameLabel.SetText(string.IsNullOrEmpty(member.groupName) ? "" : member.groupName);
			}
			bool flag6 = this._FightLabel != null;
			if (flag6)
			{
				this._FightLabel.SetText(member.fightValue.ToString());
			}
			bool flag7 = this._TypeLabel != null;
			if (flag7)
			{
				string key = XSingleton<XCommon>.singleton.StringCombine("GroupMember_Type", member.type.ToString());
				this._TypeLabel.SetText(XStringDefineProxy.GetString(key));
			}
			bool flag8 = this._TimeLabel != null;
			if (flag8)
			{
				int @int = XSingleton<XGlobalConfig>.singleton.GetInt("RecruitPublishTimeLimit");
				int num = 86400 / @int;
				bool flag9 = member.timeIndex == 0U;
				string text;
				if (flag9)
				{
					text = string.Format(this.timeFormat, "0:00", XSingleton<UiUtility>.singleton.TimeFormatString((int)((ulong)member.timeIndex + (ulong)((long)num)), 0, 3, 3, false, true));
				}
				else
				{
					text = string.Format(this.timeFormat, XSingleton<UiUtility>.singleton.TimeFormatString((int)member.timeIndex, 0, 3, 3, false, true), XSingleton<UiUtility>.singleton.TimeFormatString((int)((ulong)member.timeIndex + (ulong)((long)num)), 0, 3, 3, false, true));
				}
				this._TimeLabel.SetText(text);
			}
		}

		private void OnPlayerClick(IXUISprite label)
		{
			ulong id = label.ID;
			bool flag = id == XSingleton<XAttributeMgr>.singleton.XPlayerData.RoleID || id == 0UL;
			if (!flag)
			{
				bool flag2 = this._UserNameLabel == null;
				if (!flag2)
				{
					string text = this._UserNameLabel.GetText();
					DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetPlayerInfo(id, text, new List<uint>(), 0U, 1U);
					DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.SetVisibleWithAnimation(true, null);
					DlgBase<XOtherPlayerInfoView, XOtherPlayerInfoBehaviour>.singleton.ShowTab(Player_Info.Equip, 0UL, 0UL);
				}
			}
		}

		private IXUILabel _UserNameLabel;

		private IXUILabel _StageNameLabel;

		private IXUILabel _GroupNameLabel;

		private IXUILabel _FightLabel;

		private IXUILabel _TypeLabel;

		private IXUILabel _TimeLabel;

		private IXUISprite _ProfessionSprite;

		private IXUISprite _PortraitSprite;

		private string timeFormat = "{0} - {1}";
	}
}
