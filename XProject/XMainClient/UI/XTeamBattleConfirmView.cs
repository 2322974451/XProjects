using System;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XTeamBattleConfirmView : DlgBase<XTeamBattleConfirmView, XTeamBattleConfirmBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Team/BattleBeginConfirmDlg";
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool isPopup
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			this.doc = XDocuments.GetSpecificDocument<XTeamDocument>(XTeamDocument.uuID);
			this.FIGHT_VOTE_TIME = (float)XSingleton<XGlobalConfig>.singleton.GetInt("TeamVoteTime");
		}

		public override void RegisterEvent()
		{
			base.uiBehaviour.m_OK.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnOKBtnClick));
			base.uiBehaviour.m_Cancel.RegisterClickEventHandler(new ButtonClickEventHandler(this._OnCancelBtnClick));
		}

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

		private bool _OnOKBtnClick(IXUIButton go)
		{
			return this.m_OKHandler(go);
		}

		private bool _OnCancelBtnClick(IXUIButton go)
		{
			return this.m_CancelHandler(go);
		}

		private bool _OnFightAgreeBtnClick(IXUIButton go)
		{
			this.doc.ReqTeamOp(TeamOperate.TEAM_START_BATTLE_AGREE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			return true;
		}

		private bool _OnFightRejectBtnClick(IXUIButton go)
		{
			this.SetVisibleWithAnimation(false, null);
			this.doc.ReqTeamOp(TeamOperate.TEAM_START_BATTLE_DISAGREE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
			return true;
		}

		protected override void OnPopupBlocked()
		{
			this.doc.ReqTeamOp(TeamOperate.TEAM_START_BATTLE_DISAGREE, 0UL, null, TeamMemberType.TMT_NORMAL, null);
		}

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

		private XTeamDocument doc;

		private ButtonClickEventHandler m_OKHandler;

		private ButtonClickEventHandler m_CancelHandler;

		private float FIGHT_VOTE_TIME = 5f;

		private float m_TargetTime;

		private float m_CurrentTime;
	}
}
