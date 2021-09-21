using System;
using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BD9 RID: 3033
	internal class GroupMemberDisplay
	{
		// Token: 0x0600AD16 RID: 44310 RVA: 0x00200C1C File Offset: 0x001FEE1C
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

		// Token: 0x0600AD17 RID: 44311 RVA: 0x00200CC4 File Offset: 0x001FEEC4
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

		// Token: 0x0600AD18 RID: 44312 RVA: 0x00200CFC File Offset: 0x001FEEFC
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

		// Token: 0x0600AD19 RID: 44313 RVA: 0x00200D34 File Offset: 0x001FEF34
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

		// Token: 0x0600AD1A RID: 44314 RVA: 0x00200D70 File Offset: 0x001FEF70
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

		// Token: 0x0600AD1B RID: 44315 RVA: 0x00200FCC File Offset: 0x001FF1CC
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

		// Token: 0x0400412C RID: 16684
		private IXUILabel _UserNameLabel;

		// Token: 0x0400412D RID: 16685
		private IXUILabel _StageNameLabel;

		// Token: 0x0400412E RID: 16686
		private IXUILabel _GroupNameLabel;

		// Token: 0x0400412F RID: 16687
		private IXUILabel _FightLabel;

		// Token: 0x04004130 RID: 16688
		private IXUILabel _TypeLabel;

		// Token: 0x04004131 RID: 16689
		private IXUILabel _TimeLabel;

		// Token: 0x04004132 RID: 16690
		private IXUISprite _ProfessionSprite;

		// Token: 0x04004133 RID: 16691
		private IXUISprite _PortraitSprite;

		// Token: 0x04004134 RID: 16692
		private string timeFormat = "{0} - {1}";
	}
}
