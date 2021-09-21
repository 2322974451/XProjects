using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x02001862 RID: 6242
	internal class XTeamBattleConfirmView : DlgBase<XTeamBattleConfirmView, XTeamBattleConfirmBehaviour>
	{
		// Token: 0x17003990 RID: 14736
		// (get) Token: 0x06010400 RID: 66560 RVA: 0x003EDB8C File Offset: 0x003EBD8C
		public override string fileName
		{
			get
			{
				return "Team/BattleBeginConfirmDlg";
			}
		}

		// Token: 0x17003991 RID: 14737
		// (get) Token: 0x06010401 RID: 66561 RVA: 0x003EDBA4 File Offset: 0x003EBDA4
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003992 RID: 14738
		// (get) Token: 0x06010402 RID: 66562 RVA: 0x003EDBB8 File Offset: 0x003EBDB8
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003993 RID: 14739
		// (get) Token: 0x06010403 RID: 66563 RVA: 0x003EDBCC File Offset: 0x003EBDCC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003994 RID: 14740
		// (get) Token: 0x06010404 RID: 66564 RVA: 0x003EDBE0 File Offset: 0x003EBDE0
		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06010405 RID: 66565 RVA: 0x003EDBF3 File Offset: 0x003EBDF3
		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.FIGHT_VOTE_TIME = (float)XSingleton<XGlobalConfig>.singleton.GetInt("TeamVoteTime");
		}

		// Token: 0x06010406 RID: 66566 RVA: 0x003EDC1C File Offset: 0x003EBE1C
		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClick));
			base.uiBehaviour.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClick));
		}

		// Token: 0x06010407 RID: 66567 RVA: 0x003EDC5C File Offset: 0x003EBE5C
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = this.m_TargetTime > 0f;
			if (flag)
			{
				bool flag2 = this.m_CurrentTime >= this.m_TargetTime;
				if (flag2)
				{
					this.m_TargetTime = -1f;
				}
				else
				{
					bool flag3 = this.m_CurrentTime < this.m_TargetTime;
					if (flag3)
					{
						this.m_CurrentTime += Time.deltaTime;
						base.uiBehaviour.m_Progress.value = this.m_CurrentTime / this.m_TargetTime;
					}
				}
			}
		}

		// Token: 0x06010408 RID: 66568 RVA: 0x003EDCEC File Offset: 0x003EBEEC
		public void StartFightVote()
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisibleWithAnimation(true, null);
			}
			this.m_OKHandler = new ButtonClickEventHandler(this._OnFightAgreeBtnClick);
			this.m_CancelHandler = new ButtonClickEventHandler(this._OnFightRejectBtnClick);
			this.m_TargetTime = this.FIGHT_VOTE_TIME;
			this.m_CurrentTime = 0f;
			base.uiBehaviour.m_Progress.value = 0f;
			base.uiBehaviour.m_Progress.ForceUpdate();
			this.RefreshFightVote();
		}

		// Token: 0x06010409 RID: 66569 RVA: 0x003EDD7C File Offset: 0x003EBF7C
		public void RefreshFightVote()
		{
			bool flag = !base.IsVisible() || !this.doc.bInTeam;
			if (!flag)
			{
				base.uiBehaviour.m_Pool.FakeReturnAll();
				bool flag2 = this.doc.currentDungeonType == TeamLevelType.TeamLevelPartner;
				if (flag2)
				{
					base.uiBehaviour.m_statLab.SetText(this.doc.currentDungeonName);
					base.uiBehaviour.m_DungeonName.SetText(string.Format(XSingleton<XStringTable>.singleton.GetString("GetPartnerNeedMoney"), XSingleton<XGlobalConfig>.singleton.GetInt("PartnerNeedDragonCoin")));
					base.uiBehaviour.m_tipsGo.SetActive(false);
					base.uiBehaviour.m_CommonTip.SetVisible(false);
				}
				else
				{
					bool flag3 = this.doc.currentDungeonType == TeamLevelType.TeamLevelTeamLeague;
					if (flag3)
					{
						base.uiBehaviour.m_statLab.SetText(XSingleton<XStringTable>.singleton.GetString("CREATE_TEAM_LEAGUE"));
						base.uiBehaviour.m_DungeonName.SetText(this.doc.teamLeagueName);
						base.uiBehaviour.m_tipsGo.SetActive(false);
						base.uiBehaviour.m_CommonTip.SetText(XSingleton<XStringTable>.singleton.GetString("CREATE_TEAM_LEAGUE_TIP"));
						base.uiBehaviour.m_CommonTip.SetVisible(true);
					}
					else
					{
						base.uiBehaviour.m_statLab.SetText(XSingleton<XStringTable>.singleton.GetString("START_FIGHT"));
						bool flag4 = this.doc.MyTeam.teamBrief.rift == null;
						if (flag4)
						{
							base.uiBehaviour.m_DungeonName.SetText(this.doc.currentDungeonName);
						}
						else
						{
							base.uiBehaviour.m_DungeonName.SetText(this.doc.MyTeam.teamBrief.rift.GetSceneName(this.doc.currentDungeonName));
						}
						bool flag5 = this.doc.currentDungeonType == TeamLevelType.TeamLevelWedding;
						if (flag5)
						{
							base.uiBehaviour.m_tipsGo.SetActive(false);
						}
						else
						{
							base.uiBehaviour.m_tipsGo.SetActive(true);
						}
						base.uiBehaviour.m_CommonTip.SetVisible(false);
					}
				}
				float num = (float)this.doc.MyTeam.members.Count * 0.5f - 0.5f;
				Vector3 tplPos = base.uiBehaviour.m_Pool.TplPos;
				for (int i = 0; i < this.doc.MyTeam.members.Count; i++)
				{
					GameObject gameObject = base.uiBehaviour.m_Pool.FetchGameObject(false);
					IXUISprite ixuisprite = gameObject.transform.Find("Avatar").GetComponent("XUISprite") as IXUISprite;
					IXUILabelSymbol ixuilabelSymbol = gameObject.transform.Find("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
					IXUISprite ixuisprite2 = gameObject.GetComponent("XUISprite") as IXUISprite;
					gameObject.transform.localPosition = new Vector3(((float)i - num) * (float)base.uiBehaviour.m_Pool.TplWidth, tplPos.y);
					XTeamMember xteamMember = this.doc.MyTeam.members[i];
					ixuisprite.SetSprite(XSingleton<XProfessionSkillMgr>.singleton.GetProfHeadIcon2(XFastEnumIntEqualityComparer<RoleType>.ToInt(xteamMember.profession)));
					ixuilabelSymbol.InputText = XSingleton<XCommon>.singleton.StringCombine(xteamMember.name, XRechargeDocument.GetVIPIconString(xteamMember.vip));
					bool flag6 = xteamMember.state != ExpTeamMemberState.EXPTEAM_READY;
					if (flag6)
					{
						ixuisprite2.SetEnabled(false);
					}
					else
					{
						bool flag7 = !ixuisprite2.IsEnabled();
						if (flag7)
						{
							ixuisprite2.SetEnabled(xteamMember.state == ExpTeamMemberState.EXPTEAM_READY);
						}
					}
				}
				base.uiBehaviour.m_Pool.ActualReturnAll(false);
				base.uiBehaviour.m_OK.SetVisible(this.doc.MyTeam.myData != null && this.doc.MyTeam.myData.state == ExpTeamMemberState.EXPTEAM_IDLE);
				base.uiBehaviour.m_Cancel.SetVisible(this.doc.MyTeam.myData != null && this.doc.MyTeam.myData.state == ExpTeamMemberState.EXPTEAM_IDLE);
				this.doc.MyTeam.teamBrief.goldGroup.SetUI(base.uiBehaviour.m_GoldGroup, true);
				this._SetRift(this.doc.MyTeam.teamBrief.rift);
			}
		}

		// Token: 0x0601040A RID: 66570 RVA: 0x003EE244 File Offset: 0x003EC444
		private bool _OnOKBtnClick(IXUIButton go)
		{
			return this.m_OKHandler(go);
		}

		// Token: 0x0601040B RID: 66571 RVA: 0x003EE264 File Offset: 0x003EC464
		private bool _OnCancelBtnClick(IXUIButton go)
		{
			return this.m_CancelHandler(go);
		}

		// Token: 0x0601040C RID: 66572 RVA: 0x003EE284 File Offset: 0x003EC484
		private bool _OnFightAgreeBtnClick(IXUIButton go)
		{
			this.doc.ReqTeamOp(TeamOperate.TEAM_START_BATTLE_AGREE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			return true;
		}

		// Token: 0x0601040D RID: 66573 RVA: 0x003EE2AC File Offset: 0x003EC4AC
		private bool _OnFightRejectBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			this.doc.ReqTeamOp(TeamOperate.TEAM_START_BATTLE_DISAGREE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			return true;
		}

		// Token: 0x0601040E RID: 66574 RVA: 0x003EE2DB File Offset: 0x003EC4DB
		protected override void OnPopupBlocked()
		{
			this.doc.ReqTeamOp(TeamOperate.TEAM_START_BATTLE_DISAGREE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
		}

		// Token: 0x0601040F RID: 66575 RVA: 0x003EE2F4 File Offset: 0x003EC4F4
		private void _SetRift(XTeamRift data)
		{
			bool flag = data == null;
			if (flag)
			{
				base.uiBehaviour.m_RiftPanel.SetActive(false);
			}
			else
			{
				XRiftDocument specificDocument = XDocuments.GetSpecificDocument<XRiftDocument>(XRiftDocument.uuID);
				Rift.RowData riftData = specificDocument.GetRiftData(data.floor, (int)data.id);
				bool flag2 = riftData == null;
				if (flag2)
				{
					XSingleton<XDebug>.singleton.AddErrorLog("Cant find rift data with floor ", data.floor.ToString(), null, null, null, null);
					base.uiBehaviour.m_RiftPanel.SetActive(false);
				}
				else
				{
					base.uiBehaviour.m_RiftPanel.SetActive(true);
					this._RefreshRiftBuff(base.uiBehaviour.m_RiftBuffs[0], string.Empty, XSingleton<XGlobalConfig>.singleton.GetValue("RiftAttr"), riftData.attack + "%");
					this._RefreshRiftBuff(base.uiBehaviour.m_RiftBuffs[1], string.Empty, XSingleton<XGlobalConfig>.singleton.GetValue("RiftHP"), riftData.hp + "%");
					int i = 2;
					while (i < base.uiBehaviour.m_RiftBuffs.Length && i < data.buffs.Count + 2)
					{
						base.uiBehaviour.m_RiftBuffs[i].SetActive(true);
						RiftBuffSuitMonsterType.RowData buffSuitRow = specificDocument.GetBuffSuitRow((uint)data.buffs[i - 2].BuffID, data.buffs[i - 2].BuffLevel);
						bool flag3 = buffSuitRow == null;
						if (flag3)
						{
							XDebug singleton = XSingleton<XDebug>.singleton;
							string log = "Cant find RiftSuit with buff [";
							BuffDesc buffDesc = data.buffs[i - 2];
							string log2 = buffDesc.BuffID.ToString();
							string log3 = ", ";
							buffDesc = data.buffs[i - 2];
							singleton.AddErrorLog(log, log2, log3, buffDesc.BuffLevel.ToString(), "]", null);
							this._RefreshRiftBuff(base.uiBehaviour.m_RiftBuffs[i], string.Empty, string.Empty, string.Empty);
						}
						else
						{
							this._RefreshRiftBuff(base.uiBehaviour.m_RiftBuffs[i], buffSuitRow.atlas, buffSuitRow.icon, string.Empty);
						}
						i++;
					}
					while (i < base.uiBehaviour.m_RiftBuffs.Length)
					{
						base.uiBehaviour.m_RiftBuffs[i].SetActive(false);
						i++;
					}
				}
			}
		}

		// Token: 0x06010410 RID: 66576 RVA: 0x003EE568 File Offset: 0x003EC768
		private void _RefreshRiftBuff(GameObject go, string atlas, string sp, string text)
		{
			IXUILabel ixuilabel = go.transform.FindChild("value").GetComponent("XUILabel") as IXUILabel;
			IXUISprite ixuisprite = go.transform.FindChild("P").GetComponent("XUISprite") as IXUISprite;
			ixuilabel.SetText(text);
			bool flag = string.IsNullOrEmpty(atlas);
			if (flag)
			{
				ixuisprite.SetSprite(sp);
			}
			else
			{
				ixuisprite.SetSprite(sp, atlas, false);
			}
		}

		// Token: 0x040074D3 RID: 29907
		private XTeamDocument doc;

		// Token: 0x040074D4 RID: 29908
		private ButtonClickEventHandler m_OKHandler;

		// Token: 0x040074D5 RID: 29909
		private ButtonClickEventHandler m_CancelHandler;

		// Token: 0x040074D6 RID: 29910
		private float FIGHT_VOTE_TIME = 5f;

		// Token: 0x040074D7 RID: 29911
		private float m_TargetTime;

		// Token: 0x040074D8 RID: 29912
		private float m_CurrentTime;
	}
}
