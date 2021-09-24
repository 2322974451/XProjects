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

	internal class LevelRewardArenaHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "Battle/LevelReward/LevelRewardArenaFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XLevelRewardDocument>(XLevelRewardDocument.uuID);
			this.InitUI();
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_ArenaContinue.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnContinueClick));
			this.m_InvitePKAgain.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnInvitePKAgain));
			this.m_InvitePKReturn.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnContinueClick));
		}

		private void OnContinueClick(IXUISprite sp)
		{
			this._doc.SendLeaveScene();
		}

		private void OnInvitePKAgain(IXUISprite sp)
		{
			XPKInvitationDocument specificDocument = XDocuments.GetSpecificDocument<XPKInvitationDocument>(XPKInvitationDocument.uuID);
			specificDocument.AskInvitePKAgain();
		}

		private void ShowQualifying(IXUISprite sp)
		{
			base.SetVisible(false);
			DlgBase<XQualifyingView, XQualifyingBehaviour>.singleton.SetVisibleWithAnimation(true, null);
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowArenaFrame();
		}

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

		private XLevelRewardDocument _doc = null;

		private Transform m_ArenaWinFrame;

		private Transform m_ArenaDrawFrame;

		private Transform m_ArenaLoseFrame;

		private IXUISprite m_ArenaContinue;

		private IXUILabel m_ArenaReturnLabel;

		private IXUILabel m_ArenaRankUpNum;

		private IXUISprite m_ArenaRankUpArrow;

		private IXUISprite m_ArenaRankUp;

		private IXUILabel m_ArenaGemNum;

		private IXUILabel m_ArenaMissTip;

		private IXUILabel m_InvitePKResult;

		private GameObject m_InvitePK;

		private IXUISprite m_InvitePKReturn;

		private IXUISprite m_InvitePKAgain;

		private IXUISprite m_Qualifying;

		private IXUISprite m_QualifyRankUpArrow;

		private IXUILabel m_QualifyFirstRank;

		private GameObject m_QualifyRankTips;

		private IXUILabel m_QualifyRankUpNum;

		private IXUISprite m_QualifyPointUpArrow;

		private IXUILabel m_QualifyPointUpNum;

		private IXUILabel m_QualifyHonorNum;

		private XUIPool m_RewardPool;

		private IXUIList m_RewardList;

		private IXUILabel m_HonorUpTip2;

		private Vector3 m_itemScale = new Vector3(0.6f, 0.6f, 0.6f);
	}
}
