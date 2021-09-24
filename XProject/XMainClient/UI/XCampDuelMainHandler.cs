using System.Collections.Generic;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class XCampDuelMainHandler : DlgHandlerBase
	{

		public string CampName
		{
			get
			{
				bool flag = this.SelectID == 1;
				string result;
				if (flag)
				{
					result = XStringDefineProxy.GetString("CAMPDUEL_LEFT_NAME");
				}
				else
				{
					bool flag2 = this.SelectID == 2;
					if (flag2)
					{
						result = XStringDefineProxy.GetString("CAMPDUEL_RIGHT_NAME");
					}
					else
					{
						result = "";
					}
				}
				return result;
			}
		}

		protected override string FileName
		{
			get
			{
				return "OperatingActivity/CampDuelFrame";
			}
		}

		protected override void Init()
		{
			base.Init();
			this.doc = XDocuments.GetSpecificDocument<XCampDuelDocument>(XCampDuelDocument.uuID);
			this.doc.handler = this;
			this.m_JoinFrame = base.transform.FindChild("JoinFrame");
			this.m_MainFrame = base.transform.FindChild("MainFrame");
			this.m_TexLeft = (this.m_JoinFrame.FindChild("Left/Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_TexRight = (this.m_JoinFrame.FindChild("Right/Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_BtnSelectLeft = (this.m_JoinFrame.FindChild("Left/BtnSelect").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnSelectRight = (this.m_JoinFrame.FindChild("Right/BtnSelect").GetComponent("XUIButton") as IXUIButton);
			this.m_LeftName = (this.m_JoinFrame.FindChild("Left/T").GetComponent("XUILabel") as IXUILabel);
			this.m_RightName = (this.m_JoinFrame.FindChild("Right/T").GetComponent("XUILabel") as IXUILabel);
			this.m_Icon = (this.m_JoinFrame.FindChild("Detail/Avatar/Content").GetComponent("XUISprite") as IXUISprite);
			this.m_Intro = (this.m_JoinFrame.FindChild("Detail/Intro").GetComponent("XUILabel") as IXUILabel);
			this.m_Empty = this.m_JoinFrame.FindChild("Detail/CampSelect/Empty");
			this.m_Content = this.m_JoinFrame.FindChild("Detail/CampSelect/Content");
			this.m_BtnJoin = (this.m_JoinFrame.FindChild("Detail/CampSelect/BtnJoin").GetComponent("XUIButton") as IXUIButton);
			this.m_SelectReward = (this.m_JoinFrame.FindChild("Detail/CampSelect/Content/Reward").GetComponent("XUILabel") as IXUILabel);
			this.m_SelectName = (this.m_JoinFrame.FindChild("Detail/CampSelect/Content/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnJoinHelp = (this.m_JoinFrame.FindChild("Detail/CampSelect/Content/Help").GetComponent("XUISprite") as IXUISprite);
			this.m_MainTips = (this.m_MainFrame.FindChild("Intro").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCampTex = (this.m_MainFrame.FindChild("Camp/Tex").GetComponent("XUITexture") as IXUITexture);
			this.m_MainName = (this.m_MainFrame.FindChild("Camp/Name").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCondition = (this.m_MainFrame.FindChild("Camp/Condition").GetComponent("XUISprite") as IXUISprite);
			this.m_BtnMainHelp = (this.m_MainFrame.FindChild("Camp/Condition/Help").GetComponent("XUIButton") as IXUIButton);
			this.m_BtnMainHelpTips = (this.m_MainFrame.FindChild("Camp/Condition/Content").GetComponent("XUILabel") as IXUILabel);
			this.m_BtnMainHelpTips.gameObject.SetActive(false);
			this.m_MainBlah = (this.m_MainFrame.FindChild("Camp/Blah").GetComponent("XUILabel") as IXUILabel);
			this.m_MainBlah.gameObject.SetActive(false);
			this.m_MainPoint = (this.m_MainFrame.FindChild("Point").GetComponent("XUILabel") as IXUILabel);
			this.m_MainAddPointTween = (this.m_MainFrame.FindChild("Point/AddPoint").GetComponent("XUIPlayTween") as IXUITweenTool);
			this.m_MainAddPoint = (this.m_MainFrame.FindChild("Point/AddPoint").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCurRewardPoint = (this.m_MainFrame.FindChild("CurrnetReward/Point").GetComponent("XUILabel") as IXUILabel);
			this.m_MainAddPoint.gameObject.SetActive(false);
			this.m_MainCurRewardText = this.m_MainFrame.FindChild("CurrnetReward/ChestTpl/T");
			this.m_MainRewardItemList = this.m_MainFrame.FindChild("ItemIconList");
			this.m_MainCurRewardItemList = this.m_MainFrame.FindChild("CurrnetReward/ItemIconList");
			this.m_MainNextRewardItemList = this.m_MainFrame.FindChild("NextReward/ItemIconList");
			this.m_MainCurChest = (this.m_MainFrame.FindChild("CurrnetReward/ChestTpl").GetComponent("XUISprite") as IXUISprite);
			this.m_MainChestFx = this.m_MainFrame.FindChild("CurrnetReward/ChestTpl/Fx");
			this.m_MainBtnReward = (this.m_MainFrame.FindChild("BtnReward").GetComponent("XUIButton") as IXUIButton);
			this.m_MainBtnRank = (this.m_MainFrame.FindChild("BtnRank").GetComponent("XUIButton") as IXUIButton);
			this.m_MainEndTime = (this.m_MainFrame.FindChild("EndTime").GetComponent("XUILabel") as IXUILabel);
			Transform transform = this.m_MainFrame.FindChild("Operate/Contribute");
			this.m_MainItem = transform.FindChild("ItemTpl");
			this.m_MainItemIcon = (transform.FindChild("ItemTpl/Icon").GetComponent("XUISprite") as IXUISprite);
			this.m_MainBtnConfirm = (transform.FindChild("BtnSubmit").GetComponent("XUIButton") as IXUIButton);
			this.m_MainConfirmPoint = (transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			transform = this.m_MainFrame.FindChild("Operate/Courage");
			this.m_MainFreeCourageCount = (transform.FindChild("Detail/FreeNum").GetComponent("XUILabel") as IXUILabel);
			this.m_MainDragonCoinCourageCount = (transform.FindChild("Detail/DragonCoinNum").GetComponent("XUILabel") as IXUILabel);
			this.m_MainBtnCourage = (transform.FindChild("BtnCourage").GetComponent("XUIButton") as IXUIButton);
			this.m_MainBtnCourageRedPoint = transform.FindChild("BtnCourage/RedPoint");
			this.m_MainFree = transform.FindChild("BtnCourage/Free");
			this.m_MainDragonCoin = (transform.FindChild("BtnCourage/DragonCoin").GetComponent("XUILabel") as IXUILabel);
			this.m_MainCouragePoint = (transform.FindChild("Num").GetComponent("XUILabel") as IXUILabel);
			this.m_Help = (this.m_MainFrame.FindChild("Title/Help").GetComponent("XUIButton") as IXUIButton);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_BtnSelectLeft.ID = 1UL;
			this.m_BtnSelectLeft.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSelectClicked));
			this.m_BtnSelectRight.ID = 2UL;
			this.m_BtnSelectRight.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnSelectClicked));
			this.m_BtnJoin.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnJoinClicked));
			this.m_BtnJoinHelp.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnJoinHelpClicked));
			this.m_BtnMainHelp.RegisterPressEventHandler(new ButtonPressEventHandler(this.OnHelpBtnPress));
			this.m_MainBtnConfirm.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnConfirmClicked));
			this.m_MainBtnCourage.ID = (ulong)uint.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelInspireAddPoint"));
			this.m_MainBtnCourage.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCourageClicked));
			this.m_MainCurChest.ID = 1UL;
			this.m_MainCurChest.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnChestClicked));
			this.m_MainBtnReward.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRewardClicked));
			this.m_MainBtnRank.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRankClicked));
			this.m_MainItemIcon.ID = (ulong)((long)XCampDuelDocument.Doc.ConfirmItemID);
			this.m_MainItemIcon.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnItemClicked));
			this.m_Help.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnHelpClicked));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this.ShowUI();
		}

		protected override void OnHide()
		{
			this.m_TexLeft.SetTexturePath("");
			this.m_TexRight.SetTexturePath("");
			this.m_MainCampTex.SetTexturePath("");
			XSingleton<XTimerMgr>.singleton.KillTimer(this._AutoRefresheTimeID);
			this._AutoRefresheTimeID = 0U;
			XSingleton<XTimerMgr>.singleton.KillTimer(this._AutoCloseBlahTimeID);
			this._AutoCloseBlahTimeID = 0U;
			this.UnloadFx(this._BoxUpFx);
			this.UnloadFx(this._NPCFx);
			this.m_MainBlah.gameObject.SetActive(false);
			base.OnHide();
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
		}

		public override void OnUnload()
		{
			DlgHandlerBase.EnsureUnload<XCampDuelPointRewardHandler>(ref this._PointRewardHandler);
			this.doc.handler = null;
			base.OnUnload();
		}

		public void ShowUI()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this.doc.campID == 0;
				if (flag2)
				{
					this.m_JoinFrame.gameObject.SetActive(true);
					this.m_MainFrame.gameObject.SetActive(false);
					this.ShowJoin();
				}
				else
				{
					this.m_JoinFrame.gameObject.SetActive(false);
					this.m_MainFrame.gameObject.SetActive(true);
					bool flag3 = this._AutoRefresheTimeID == 0U;
					if (flag3)
					{
						this._AutoRefresh(null);
					}
					this.ShowMain();
				}
			}
		}

		private bool OnSelectClicked(IXUIButton btn)
		{
			this.SelectID = (int)btn.ID;
			this.m_TexLeft.SetColor((btn.ID == 1UL) ? Color.white : Color.gray);
			this.m_TexRight.SetColor((btn.ID == 1UL) ? Color.gray : Color.white);
			this.m_Icon.SetSprite((btn.ID == 1UL) ? XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelLeftIcon") : XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelRightIcon"));
			this.m_Empty.gameObject.SetActive(false);
			this.m_Content.gameObject.SetActive(true);
			this.m_SelectName.SetText(this.CampName);
			this.m_SelectReward.SetText((btn.ID == 1UL) ? XStringDefineProxy.GetString("CAMPDUEL_LEFT_REWARD") : XStringDefineProxy.GetString("CAMPDUEL_RIGHT_REWARD"));
			return true;
		}

		private bool OnJoinClicked(IXUIButton btn)
		{
			bool flag = this.SelectID == 0;
			bool result;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XSingleton<XStringTable>.singleton.GetString("CAMPDUEL_JOIN_TIP"), "fece00");
				result = true;
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowModalDialog(string.Format(XStringDefineProxy.GetString("CAMPDUEL_JOIN_CONFIRM"), this.CampName), XStringDefineProxy.GetString("COMMON_OK"), XStringDefineProxy.GetString("COMMON_CANCEL"), new ButtonClickEventHandler(this._Compose), null, false, XTempTipDefine.OD_START, 50);
				result = true;
			}
			return result;
		}

		private bool _Compose(IXUIButton button)
		{
			XCampDuelDocument.Doc.ReqCampDuel(2U, (uint)this.SelectID);
			XSingleton<UiUtility>.singleton.CloseModalDlg();
			return true;
		}

		private void OnJoinHelpClicked(IXUISprite btn)
		{
			DlgHandlerBase.EnsureCreate<XCampDuelPointRewardHandler>(ref this._PointRewardHandler, this.m_JoinFrame, false, null);
			this._PointRewardHandler.CampID = this.SelectID;
			this._PointRewardHandler.SetVisible(true);
		}

		public void ShowJoin()
		{
			this.SelectID = 0;
			string value = XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelLeftTex");
			this.m_TexLeft.SetTexturePath(value);
			this.m_TexLeft.SetColor(Color.gray);
			this.m_LeftName.SetText(XStringDefineProxy.GetString("CAMPDUEL_LEFT_NAME"));
			value = XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelRightTex");
			this.m_TexRight.SetTexturePath(value);
			this.m_TexRight.SetColor(Color.gray);
			this.m_RightName.SetText(XStringDefineProxy.GetString("CAMPDUEL_RIGHT_NAME"));
			this.m_Icon.SetSprite("");
			string arg = XTempActivityDocument.Doc.GetEndTime(XCampDuelDocument.Doc.ActInfo, 1).ToString(XStringDefineProxy.GetString("CAMPDUEL_JOIN_INTRO_TIME"));
			this.m_Intro.SetText(string.Format(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("CAMPDUEL_JOIN_INTRO")), arg));
			this.m_Empty.gameObject.SetActive(true);
			this.m_Content.gameObject.SetActive(false);
		}

		private bool OnHelpClicked(IXUIButton btn)
		{
			DlgBase<XCommonHelpTipView, XCommonHelpTipBehaviour>.singleton.ShowHelp(XSysDefine.XSys_CampDuel);
			return true;
		}

		private bool OnConfirmClicked(IXUIButton btn)
		{
			XCampDuelDocument.Doc.ReqCampDuel(3U, (uint)btn.ID);
			return true;
		}

		private bool OnCourageClicked(IXUIButton btn)
		{
			bool flag = XCampDuelDocument.Doc.FreeCourageCount != 0;
			if (flag)
			{
				XCampDuelDocument.Doc.ReqCampDuel(4U, (uint)btn.ID);
			}
			else
			{
				XCampDuelDocument.Doc.ReqCampDuel(5U, (uint)btn.ID);
			}
			return true;
		}

		private bool OnRewardClicked(IXUIButton btn)
		{
			DlgHandlerBase.EnsureCreate<XCampDuelPointRewardHandler>(ref this._PointRewardHandler, this.m_MainFrame, false, null);
			this._PointRewardHandler.CampID = XCampDuelDocument.Doc.campID;
			this._PointRewardHandler.SetVisible(true);
			return true;
		}

		private bool OnRankClicked(IXUIButton btn)
		{
			DlgBase<XRankView, XRankBehaviour>.singleton.ShowRank(XSysDefine.XSys_Rank_CampDuel);
			return true;
		}

		private void OnItemClicked(IXUISprite btn)
		{
			XSingleton<UiUtility>.singleton.ShowItemAccess((int)btn.ID, null);
		}

		private void OnChestClicked(IXUISprite btn)
		{
			CampDuelPointReward.RowData rowData = this.doc.GetPointReward(this.doc.point);
			bool flag = rowData == null;
			if (flag)
			{
				rowData = this.doc.GetNextPointReward(this.doc.point);
			}
			bool flag2 = rowData == null;
			if (!flag2)
			{
				this.itemid.Clear();
				this.itemCount.Clear();
				for (int i = 0; i < (int)rowData.Reward.count; i++)
				{
					this.itemid.Add((uint)rowData.Reward[i, 0]);
					this.itemCount.Add((uint)rowData.Reward[i, 1]);
				}
				this.itemid.Add((uint)rowData.EXReward[0]);
				this.itemCount.Add((uint)rowData.EXReward[1]);
				DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.Show(this.itemid, this.itemCount, true);
				DlgBase<ItemIconListDlg, ItemIconListDlgBehaviour>.singleton.SetGlobalPosition(btn.gameObject.transform.position);
			}
		}

		private void OnItemCloseClicked(IXUISprite btn)
		{
			this.m_MainRewardItemList.gameObject.SetActive(false);
		}

		private void OnHelpBtnPress(IXUIButton btn, bool state)
		{
			bool flag = this.m_BtnMainHelpTips.gameObject.activeInHierarchy != state;
			if (flag)
			{
				this.m_BtnMainHelpTips.gameObject.SetActive(state);
			}
		}

		public void ShowMain()
		{
			this.m_MainTips.SetText(XStringDefineProxy.GetString("CAMPDUEL_MAIN_TIP"));
			this.m_MainCampTex.SetTexturePath((this.doc.campID == 1) ? XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelLeftTex") : XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelRightTex"));
			this.m_MainName.SetText((this.doc.campID == 1) ? XStringDefineProxy.GetString("CAMPDUEL_LEFT_NAME") : XStringDefineProxy.GetString("CAMPDUEL_RIGHT_NAME"));
			this.m_MainCondition.SetSprite((this.doc.aheadCampID == this.doc.campID) ? "Spr_Ahead" : "Spr_Beyond");
			this.m_MainCondition.gameObject.SetActive(this.doc.aheadCampID != 0);
			this.m_BtnMainHelpTips.SetText(XSingleton<UiUtility>.singleton.ReplaceReturn(XStringDefineProxy.GetString("CAMPDUEL_MAIN_HELP")));
			this.RefreshPoint();
			int confirmItemID = XCampDuelDocument.Doc.ConfirmItemID;
			ulong num = XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(confirmItemID);
			this.m_MainBtnConfirm.ID = num;
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(this.m_MainItem.gameObject, confirmItemID, (int)num, true);
			this.m_MainConfirmPoint.SetText(((int)num * int.Parse(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelItemPoint"))).ToString());
			this.m_MainBtnConfirm.SetEnable(num > 0UL, false);
			this.RefresheCourage();
			this.m_MainCouragePoint.SetText(XSingleton<XGlobalConfig>.singleton.GetValue("CampDuelInspireAddPoint"));
			this.m_MainEndTime.SetText(XTempActivityDocument.Doc.GetEndTime(XCampDuelDocument.Doc.ActInfo, 1).ToString(XStringDefineProxy.GetString("CAMPDUEL_END_TIME")));
		}

		public void RefreshPoint()
		{
			this.m_MainPoint.SetText(this.doc.point.ToString());
			CampDuelPointReward.RowData pointReward = this.doc.GetPointReward(this.doc.point);
			CampDuelPointReward.RowData nextPointReward = this.doc.GetNextPointReward(this.doc.point);
			this.m_MainChestFx.gameObject.SetActive(pointReward != null);
			this.m_MainCurRewardText.gameObject.SetActive(pointReward != null);
			this.m_MainCurChest.SetColor((pointReward != null) ? Color.white : Color.gray);
			bool flag = pointReward == null && nextPointReward != null;
			if (flag)
			{
				this.m_MainCurChest.SetSprite(nextPointReward.Icon);
				this.m_MainCurRewardPoint.SetText(string.Format(XStringDefineProxy.GetString("CAMPDUEL_REWARD_FIRST"), nextPointReward.Point - this.doc.point));
			}
			else
			{
				bool flag2 = pointReward != null && nextPointReward == null;
				if (flag2)
				{
					this.m_MainCurChest.SetSprite(pointReward.Icon);
					this.m_MainCurRewardPoint.SetText(XStringDefineProxy.GetString("CAMPDUEL_REWARD_MAX"));
				}
				else
				{
					bool flag3 = pointReward != null && nextPointReward != null;
					if (flag3)
					{
						this.m_MainCurChest.SetSprite(pointReward.Icon);
						this.m_MainCurRewardPoint.SetText(string.Format(XStringDefineProxy.GetString("CAMPDUEL_REWARD_NEXT"), nextPointReward.Point - this.doc.point));
					}
				}
			}
		}

		public void RefresheCourage()
		{
			this.m_MainFreeCourageCount.SetText(string.Format("{0}/{1}", this.doc.FreeCourageCount, this.doc.FreeCourageMAX));
			this.m_MainDragonCoinCourageCount.SetText(string.Format("{0}/{1}", this.doc.DragonCoinCourageCount, this.doc.DragonCoinCourageCost.Length));
			this.m_MainFreeCourageCount.gameObject.SetActive(this.doc.FreeCourageCount != 0);
			this.m_MainDragonCoinCourageCount.gameObject.SetActive(this.doc.FreeCourageCount == 0);
			this.m_MainBtnCourageRedPoint.gameObject.SetActive(this.doc.IsRedPoint());
			bool flag = this.doc.FreeCourageCount > 0;
			if (flag)
			{
				this.m_MainFree.gameObject.SetActive(true);
				this.m_MainDragonCoin.gameObject.SetActive(false);
				this.m_MainBtnCourage.SetEnable(true, false);
			}
			else
			{
				this.m_MainFree.gameObject.SetActive(false);
				this.m_MainDragonCoin.gameObject.SetActive(true);
				this.m_MainBtnCourage.SetEnable(this.doc.DragonCoinCourageCount > 0, false);
				int num = Mathf.Clamp(this.doc.DragonCoinCourageCost.Length - this.doc.DragonCoinCourageCount, 0, this.doc.DragonCoinCourageCost.Length - 1);
				this.m_MainDragonCoin.SetText(this.doc.DragonCoinCourageCost[num]);
			}
		}

		private void _AutoRefresh(object param)
		{
			bool flag = base.IsVisible();
			if (flag)
			{
				XCampDuelDocument.Doc.ReqCampDuel(1U, 0U);
				this._AutoRefresheTimeID = XSingleton<XTimerMgr>.singleton.SetTimer(5f, new XTimerMgr.ElapsedEventHandler(this._AutoRefresh), null);
			}
		}

		private void _AutoCloseBlah(object param)
		{
			this.m_MainBlah.gameObject.SetActive(false);
		}

		public void ShowBlah()
		{
			int num = Random.Range(0, 5);
			this.m_MainBlah.gameObject.SetActive(true);
			this.m_MainBlah.SetText(XStringDefineProxy.GetString(XSingleton<XCommon>.singleton.StringCombine("CAMPDUEL_BLAH", num.ToString())));
			this._AutoCloseBlahTimeID = XSingleton<XTimerMgr>.singleton.SetTimer(3f, new XTimerMgr.ElapsedEventHandler(this._AutoCloseBlah), null);
		}

		public void AddNumPlayTween(int addPoint)
		{
			this.m_MainAddPoint.SetText(string.Format("+{0}", addPoint.ToString()));
			this.m_MainAddPointTween.PlayTween(true, -1f);
		}

		public void PlayBoxUpFx()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this._BoxUpFx != null && this._BoxUpFx.FxName == "Effects/FX_Particle/UIfx/UI_duelcampframe_Clip02";
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._BoxUpFx, true);
				}
				this._BoxUpFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_duelcampframe_Clip02", this.m_MainCurChest.transform, Vector3.zero, Vector3.one, 1f, true, 6f, true);
			}
		}

		public void PlayNPCFx()
		{
			bool flag = !base.IsVisible();
			if (!flag)
			{
				bool flag2 = this._NPCFx != null && this._NPCFx.FxName == "Effects/FX_Particle/UIfx/UI_duelcampframe_Clip03";
				if (flag2)
				{
					XSingleton<XFxMgr>.singleton.DestroyFx(this._NPCFx, true);
				}
				this._NPCFx = XSingleton<XFxMgr>.singleton.CreateAndPlay("Effects/FX_Particle/UIfx/UI_duelcampframe_Clip03", this.m_MainCampTex.gameObject.transform, Vector3.zero, Vector3.one, 1f, true, 6f, true);
			}
		}

		public void UnloadFx(XFx fx)
		{
			bool flag = fx != null;
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
				fx = null;
			}
		}

		private XCampDuelDocument doc = null;

		private XCampDuelPointRewardHandler _PointRewardHandler;

		private int SelectID;

		private uint _AutoRefresheTimeID;

		private uint _AutoCloseBlahTimeID;

		private Transform m_JoinFrame;

		private Transform m_MainFrame;

		private IXUITexture m_TexLeft;

		private IXUITexture m_TexRight;

		private IXUISprite m_Icon;

		private IXUIButton m_BtnSelectLeft;

		private IXUIButton m_BtnSelectRight;

		private IXUILabel m_Intro;

		private Transform m_Content;

		private Transform m_Empty;

		private IXUIButton m_BtnJoin;

		private IXUILabel m_SelectReward;

		private IXUILabel m_SelectName;

		private IXUISprite m_BtnJoinHelp;

		private IXUILabel m_LeftName;

		private IXUILabel m_RightName;

		private IXUILabel m_MainBlah;

		private IXUILabel m_MainTips;

		private IXUITexture m_MainCampTex;

		private IXUILabel m_MainName;

		private IXUISprite m_MainCondition;

		private IXUIButton m_BtnMainHelp;

		private IXUILabel m_BtnMainHelpTips;

		private IXUILabel m_MainPoint;

		private IXUILabel m_MainCurRewardPoint;

		private Transform m_MainCurRewardText;

		private Transform m_MainItem;

		private IXUISprite m_MainItemIcon;

		private IXUIButton m_MainBtnConfirm;

		private IXUILabel m_MainConfirmPoint;

		private IXUILabel m_MainFreeCourageCount;

		private IXUILabel m_MainDragonCoinCourageCount;

		private IXUIButton m_MainBtnCourage;

		private Transform m_MainBtnCourageRedPoint;

		private Transform m_MainFree;

		private IXUILabel m_MainDragonCoin;

		private IXUILabel m_MainCouragePoint;

		private Transform m_MainRewardItemList;

		private Transform m_MainCurRewardItemList;

		private Transform m_MainNextRewardItemList;

		private Transform m_MainChestFx;

		private IXUISprite m_MainCurChest;

		private IXUIButton m_MainBtnReward;

		private IXUIButton m_MainBtnRank;

		private IXUILabel m_MainEndTime;

		private XUIPool m_ItemPool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUITweenTool m_MainAddPointTween;

		private IXUILabel m_MainAddPoint;

		private IXUIButton m_Help;

		private List<uint> itemid = new List<uint>();

		private List<uint> itemCount = new List<uint>();

		private XFx _BoxUpFx;

		private XFx _NPCFx;
	}
}
