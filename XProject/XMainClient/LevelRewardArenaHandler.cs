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
	// Token: 0x02000B9C RID: 2972
	internal class LevelRewardArenaHandler : DlgHandlerBase
	{
		// Token: 0x17003041 RID: 12353
		// (get) Token: 0x0600AA86 RID: 43654 RVA: 0x001E8C28 File Offset: 0x001E6E28
		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardArenaFrame";
			}
		}

		// Token: 0x0600AA87 RID: 43655 RVA: 0x001E8C3F File Offset: 0x001E6E3F
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

		// Token: 0x0600AA88 RID: 43656 RVA: 0x001E8C60 File Offset: 0x001E6E60
		private void InitUI()
		{
			this.m_ArenaWinFrame = base.transform.Find("Result/Win");
			this.m_ArenaDrawFrame = base.transform.Find("Result/Draw");
			this.m_ArenaLoseFrame = base.transform.Find("Result/Lose");
			this.m_ArenaContinue = (base.transform.FindChild("Continue").GetComponent("XUISprite") as IXUISprite);
			this.m_ArenaReturnLabel = (base.transform.FindChild("Continue/Text").GetComponent("XUILabel") as IXUILabel);
			this.m_ArenaRankUp = (base.transform.FindChild("ArenaUp").GetComponent("XUISprite") as IXUISprite);
			this.m_ArenaRankUpNum = (base.transform.FindChild("ArenaUp/ArenaRankUpNum").GetComponent("XUILabel") as IXUILabel);
			this.m_ArenaRankUpArrow = (base.transform.FindChild("ArenaUp/RankUpArrow").GetComponent("XUISprite") as IXUISprite);
			this.m_ArenaGemNum = (base.transform.Find("ArenaUp/GemUpNum").GetComponent("XUILabel") as IXUILabel);
			this.m_ArenaMissTip = (base.transform.Find("ArenaUp/ArenaMissTip").GetComponent("XUILabel") as IXUILabel);
			this.m_Qualifying = (base.transform.FindChild("Qualifying").GetComponent("XUISprite") as IXUISprite);
			this.m_QualifyFirstRank = (base.transform.FindChild("Qualifying/FirstRank").GetComponent("XUILabel") as IXUILabel);
			this.m_QualifyRankTips = base.transform.FindChild("Qualifying/RankUpTip").gameObject;
			this.m_QualifyRankUpNum = (base.transform.FindChild("Qualifying/RankUpNum").GetComponent("XUILabel") as IXUILabel);
			this.m_QualifyRankUpArrow = (base.transform.FindChild("Qualifying/RankUpArrow").GetComponent("XUISprite") as IXUISprite);
			this.m_QualifyPointUpNum = (base.transform.FindChild("Qualifying/PointUpNum").GetComponent("XUILabel") as IXUILabel);
			this.m_QualifyPointUpArrow = (base.transform.FindChild("Qualifying/PointUpArrow").GetComponent("XUISprite") as IXUISprite);
			this.m_QualifyHonorNum = (base.transform.FindChild("Qualifying/HonorUpNum").GetComponent("XUILabel") as IXUILabel);
			this.m_InvitePKResult = (base.transform.FindChild("InvitePK").GetComponent("XUILabel") as IXUILabel);
			this.m_InvitePK = base.transform.FindChild("InvitePKAgain").gameObject;
			this.m_InvitePKReturn = (base.transform.FindChild("InvitePKAgain/Return").GetComponent("XUISprite") as IXUISprite);
			this.m_InvitePKAgain = (base.transform.FindChild("InvitePKAgain/Again").GetComponent("XUISprite") as IXUISprite);
			this.m_RewardPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);
			Transform transform = base.transform.FindChild("Qualifying/HonorExtra/item");
			this.m_RewardPool.SetupPool(transform.parent.parent.gameObject, transform.gameObject, 3U, false);
			this.m_RewardList = (base.transform.FindChild("Qualifying/HonorExtra").GetComponent("XUIList") as IXUIList);
			this.m_HonorUpTip2 = (base.transform.FindChild("Qualifying/HonorUpTip2").GetComponent("XUILabel") as IXUILabel);
		}

		// Token: 0x0600AA89 RID: 43657 RVA: 0x001E8FF0 File Offset: 0x001E71F0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ArenaContinue.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnContinueClick));
			this.m_InvitePKAgain.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnInvitePKAgain));
			this.m_InvitePKReturn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnContinueClick));
		}

		// Token: 0x0600AA8A RID: 43658 RVA: 0x001E904D File Offset: 0x001E724D
		private void OnContinueClick(IXUISprite sp)
		{
			this._doc.SendLeaveScene();
		}

		// Token: 0x0600AA8B RID: 43659 RVA: 0x001E905C File Offset: 0x001E725C
		private void OnInvitePKAgain(IXUISprite sp)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.AskInvitePKAgain();
		}

		// Token: 0x0600AA8C RID: 43660 RVA: 0x001E907C File Offset: 0x001E727C
		private void ShowQualifying(IXUISprite sp)
		{
			base.SetVisible(false);
			DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		// Token: 0x0600AA8D RID: 43661 RVA: 0x001E9094 File Offset: 0x001E7294
		protected override void OnShow()
		{
			base.OnShow();
			this.ShowArenaFrame();
		}

		// Token: 0x0600AA8E RID: 43662 RVA: 0x001E90A8 File Offset: 0x001E72A8
		private void InitAwardList(List<ItemBrief> items)
		{
			bool flag = items == null || items.Count == 0;
			if (flag)
			{
				this.m_HonorUpTip2.Alpha = 0f;
				this.m_RewardList.SetVisible(false);
			}
			else
			{
				this.m_HonorUpTip2.Alpha = 1f;
				this.m_RewardList.SetVisible(true);
				this.m_RewardPool.FakeReturnAll();
				int i = 0;
				int count = items.Count;
				while (i < count)
				{
					GameObject gameObject = this.m_RewardPool.FetchGameObject(false);
					gameObject.transform.parent = this.m_RewardList.gameObject.transform;
					gameObject.transform.localPosition = new Vector3((float)(i * 60), 0f, 0f);
					gameObject.transform.localScale = this.m_itemScale;
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)items[i].itemID, (int)items[i].itemCount, false);
					IXUISprite ixuisprite = gameObject.transform.FindChild("Icon").GetComponent("XUISprite") as IXUISprite;
					ixuisprite.ID = (ulong)items[i].itemID;
					bool isbind = items[i].isbind;
					if (isbind)
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnBindItemClick));
					}
					else
					{
						ixuisprite.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(XSingleton<UiUtility>.singleton.OnItemClick));
					}
					i++;
				}
				this.m_RewardPool.ActualReturnAll(false);
				this.m_RewardList.Refresh();
			}
		}

		// Token: 0x0600AA8F RID: 43663 RVA: 0x001E9254 File Offset: 0x001E7454
		public void ShowArenaFrame()
		{
			SceneType currentStage = this._doc.CurrentStage;
			if (currentStage <= SceneType.SCENE_PK)
			{
				if (currentStage == SceneType.SCENE_ARENA)
				{
					this.m_ArenaRankUp.SetVisible(true);
					this.m_Qualifying.SetVisible(false);
					this.m_InvitePKResult.SetVisible(false);
					this.m_InvitePK.SetActive(false);
					this.m_ArenaContinue.SetVisible(true);
					this.m_ArenaRankUpNum.SetText(this._doc.ArenaRankUp.ToString());
					this.m_ArenaGemNum.SetText(this._doc.ArenaGemUp.ToString());
					this.SetBattleResultTitle(PkResultType.PkResult_Win);
					bool isArenaMiss = this._doc.IsArenaMiss;
					if (isArenaMiss)
					{
						this.m_ArenaMissTip.SetVisible(true);
						bool flag = this._doc.ArenaRankUp == 0;
						if (flag)
						{
							this.m_ArenaMissTip.SetText(XStringDefineProxy.GetString("ArenaTargetMissed"));
						}
						else
						{
							this.m_ArenaMissTip.SetText(XStringDefineProxy.GetString("ArenaTargetRankChanged", new object[]
							{
								this._doc.ArenaRankUp
							}));
						}
					}
					else
					{
						this.m_ArenaMissTip.SetVisible(false);
					}
					this.m_ArenaReturnLabel.SetText(XStringDefineProxy.GetString("LEVEL_REWARD_RETURN_ARENA"));
					return;
				}
				if (currentStage != SceneType.SCENE_PK)
				{
					return;
				}
			}
			else
			{
				if (currentStage == SceneType.SCENE_INVFIGHT)
				{
					this.m_ArenaRankUp.SetVisible(false);
					this.m_Qualifying.SetVisible(false);
					this.m_InvitePKResult.SetVisible(true);
					this.m_InvitePK.SetActive(true);
					this.m_ArenaContinue.SetVisible(false);
					bool isWin = this._doc.InvFightBattleData.isWin;
					if (isWin)
					{
						this.SetBattleResultTitle(PkResultType.PkResult_Win);
						this.m_InvitePKResult.SetText(XStringDefineProxy.GetString("PK_RESULT_WIN", new object[]
						{
							this._doc.InvFightBattleData.rivalName
						}));
					}
					else
					{
						this.SetBattleResultTitle(PkResultType.PkResult_Lose);
						this.m_InvitePKResult.SetText(XStringDefineProxy.GetString("PK_RESULT_LOSE", new object[]
						{
							this._doc.InvFightBattleData.rivalName
						}));
					}
					this.m_ArenaReturnLabel.SetText(XStringDefineProxy.GetString("LEVEL_REWARD_RETURN_ARENA"));
					return;
				}
				if (currentStage != SceneType.SCENE_PKTWO)
				{
					return;
				}
			}
			bool flag2 = this._doc.CurrentStage == SceneType.SCENE_PK;
			if (flag2)
			{
				this.m_ArenaContinue.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ShowQualifying));
			}
			this.m_ArenaRankUp.SetVisible(false);
			this.m_InvitePKResult.SetVisible(false);
			this.m_Qualifying.SetVisible(true);
			this.m_InvitePK.SetActive(false);
			this.m_ArenaContinue.SetVisible(true);
			this.SetBattleResultTitle(this._doc.QualifyingBattleData.QualifyingResult);
			switch (this._doc.QualifyingBattleData.QualifyingResult)
			{
			case PkResultType.PkResult_Win:
			{
				bool flag3 = this._doc.QualifyingBattleData.opState == KKVsRoleState.KK_VS_ROLE_UNLOAD;
				if (flag3)
				{
					XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(XSingleton<XStringTable>.singleton.GetString("LoadTimeOutWin"));
				}
				break;
			}
			case PkResultType.PkResult_Lose:
			{
				bool flag4 = this._doc.QualifyingBattleData.myState == KKVsRoleState.KK_VS_ROLE_UNLOAD;
				if (flag4)
				{
					XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(XSingleton<XStringTable>.singleton.GetString("LoadTimeOutLose"));
				}
				break;
			}
			case PkResultType.PkResult_Draw:
			{
				bool flag5 = this._doc.QualifyingBattleData.myState == KKVsRoleState.KK_VS_ROLE_UNLOAD || this._doc.QualifyingBattleData.opState == KKVsRoleState.KK_VS_ROLE_UNLOAD;
				if (flag5)
				{
					XSingleton<UiUtility>.singleton.ShowSystemNoticeTip(XSingleton<XStringTable>.singleton.GetString("LoadTimeOutDraw"));
				}
				break;
			}
			}
			this.m_ArenaReturnLabel.SetText(XStringDefineProxy.GetString("LEVEL_REWARD_RETURN_ARENA"));
			bool flag6 = this._doc.QualifyingBattleData.FirstRank == 0;
			if (flag6)
			{
				this.m_QualifyRankTips.SetActive(true);
				this.m_QualifyRankUpNum.SetVisible(true);
				this.m_QualifyRankUpArrow.SetVisible(true);
				this.m_QualifyFirstRank.SetVisible(false);
				this.m_QualifyRankUpNum.SetText(string.Format("{0}{1}", (this._doc.QualifyingBattleData.QualifyingRankChange >= 0) ? "+" : "", this._doc.QualifyingBattleData.QualifyingRankChange));
				this.m_QualifyRankUpArrow.SetSprite((this._doc.QualifyingBattleData.QualifyingRankChange >= 0) ? "hall_zljt_0" : "hall_zljt_1");
			}
			else
			{
				this.m_QualifyRankTips.SetActive(false);
				this.m_QualifyRankUpNum.SetVisible(false);
				this.m_QualifyRankUpArrow.SetVisible(false);
				this.m_QualifyFirstRank.SetVisible(true);
				this.m_QualifyFirstRank.SetText(string.Format(XStringDefineProxy.GetString("PVP_FIRSTRANK"), this._doc.QualifyingBattleData.FirstRank));
			}
			this.m_QualifyPointUpNum.SetText(string.Format("{0}{1}", (this._doc.QualifyingBattleData.QualifyingPointChange >= 0) ? "+" : "", this._doc.QualifyingBattleData.QualifyingPointChange));
			this.m_QualifyHonorNum.SetText(this._doc.QualifyingBattleData.QualifyingHonorChange.ToString());
			this.m_QualifyPointUpArrow.SetSprite((this._doc.QualifyingBattleData.QualifyingPointChange >= 0) ? "hall_zljt_0" : "hall_zljt_1");
			this.InitAwardList(this._doc.QualifyingBattleData.QualifyingHonorItems);
		}

		// Token: 0x0600AA90 RID: 43664 RVA: 0x001E981C File Offset: 0x001E7A1C
		private void SetBattleResultTitle(PkResultType state)
		{
			switch (state)
			{
			case PkResultType.PkResult_Win:
				this.m_ArenaWinFrame.gameObject.SetActive(true);
				this.m_ArenaDrawFrame.gameObject.SetActive(false);
				this.m_ArenaLoseFrame.gameObject.SetActive(false);
				break;
			case PkResultType.PkResult_Lose:
				this.m_ArenaWinFrame.gameObject.SetActive(false);
				this.m_ArenaDrawFrame.gameObject.SetActive(false);
				this.m_ArenaLoseFrame.gameObject.SetActive(true);
				break;
			case PkResultType.PkResult_Draw:
				this.m_ArenaWinFrame.gameObject.SetActive(false);
				this.m_ArenaDrawFrame.gameObject.SetActive(true);
				this.m_ArenaLoseFrame.gameObject.SetActive(false);
				break;
			}
		}

		// Token: 0x04003F41 RID: 16193
		private XLevelRewardDocument _doc = null;

		// Token: 0x04003F42 RID: 16194
		private Transform m_ArenaWinFrame;

		// Token: 0x04003F43 RID: 16195
		private Transform m_ArenaDrawFrame;

		// Token: 0x04003F44 RID: 16196
		private Transform m_ArenaLoseFrame;

		// Token: 0x04003F45 RID: 16197
		private IXUISprite m_ArenaContinue;

		// Token: 0x04003F46 RID: 16198
		private IXUILabel m_ArenaReturnLabel;

		// Token: 0x04003F47 RID: 16199
		private IXUILabel m_ArenaRankUpNum;

		// Token: 0x04003F48 RID: 16200
		private IXUISprite m_ArenaRankUpArrow;

		// Token: 0x04003F49 RID: 16201
		private IXUISprite m_ArenaRankUp;

		// Token: 0x04003F4A RID: 16202
		private IXUILabel m_ArenaGemNum;

		// Token: 0x04003F4B RID: 16203
		private IXUILabel m_ArenaMissTip;

		// Token: 0x04003F4C RID: 16204
		private IXUILabel m_InvitePKResult;

		// Token: 0x04003F4D RID: 16205
		private GameObject m_InvitePK;

		// Token: 0x04003F4E RID: 16206
		private IXUISprite m_InvitePKReturn;

		// Token: 0x04003F4F RID: 16207
		private IXUISprite m_InvitePKAgain;

		// Token: 0x04003F50 RID: 16208
		private IXUISprite m_Qualifying;

		// Token: 0x04003F51 RID: 16209
		private IXUISprite m_QualifyRankUpArrow;

		// Token: 0x04003F52 RID: 16210
		private IXUILabel m_QualifyFirstRank;

		// Token: 0x04003F53 RID: 16211
		private GameObject m_QualifyRankTips;

		// Token: 0x04003F54 RID: 16212
		private IXUILabel m_QualifyRankUpNum;

		// Token: 0x04003F55 RID: 16213
		private IXUISprite m_QualifyPointUpArrow;

		// Token: 0x04003F56 RID: 16214
		private IXUILabel m_QualifyPointUpNum;

		// Token: 0x04003F57 RID: 16215
		private IXUILabel m_QualifyHonorNum;

		// Token: 0x04003F58 RID: 16216
		private XUIPool m_RewardPool;

		// Token: 0x04003F59 RID: 16217
		private IXUIList m_RewardList;

		// Token: 0x04003F5A RID: 16218
		private IXUILabel m_HonorUpTip2;

		// Token: 0x04003F5B RID: 16219
		private Vector3 m_itemScale = new Vector3(0.6f, 0.6f, 0.6f);
	}
}
