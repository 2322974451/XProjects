using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{
	// Token: 0x02001931 RID: 6449
	internal class CustomBattleChestHandler : DlgHandlerBase
	{
		// Token: 0x17003B26 RID: 15142
		// (get) Token: 0x06010F28 RID: 69416 RVA: 0x0044DB88 File Offset: 0x0044BD88
		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/ChestFrame";
			}
		}

		// Token: 0x06010F29 RID: 69417 RVA: 0x0044DBA0 File Offset: 0x0044BDA0
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XCustomBattleDocument>(XCustomBattleDocument.uuID);
			this._close = (base.transform.Find("Close").GetComponent("XUISprite") as IXUISprite);
			Transform transform = base.transform.Find("List/Item");
			this._item_pool.SetupPool(transform.parent.gameObject, transform.gameObject, 4U, false);
			this._fetch_btn = (base.transform.Find("FetchBtn").GetComponent("XUIButton") as IXUIButton);
			this._wait_open_frame = base.transform.Find("WaitFrame");
			this._open_now = (base.transform.Find("WaitFrame/OpenBtn").GetComponent("XUIButton") as IXUIButton);
			this._left_time = (base.transform.Find("WaitFrame/Time").GetComponent("XUILabel") as IXUILabel);
			this._boxCD = new XLeftTimeCounter(this._left_time, false);
			this._cost = (base.transform.Find("WaitFrame/OpenBtn/Cost").GetComponent("XUILabelSymbol") as IXUILabelSymbol);
			this._fx_point = base.transform.Find("Title/Box/Fx");
		}

		// Token: 0x06010F2A RID: 69418 RVA: 0x0044DCEC File Offset: 0x0044BEEC
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			this._fetch_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFetchButtonClicked));
			this._open_now.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOpenNowButtonClicked));
		}

		// Token: 0x06010F2B RID: 69419 RVA: 0x0044DD49 File Offset: 0x0044BF49
		protected override void OnHide()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnHide();
		}

		// Token: 0x06010F2C RID: 69420 RVA: 0x0044DD6C File Offset: 0x0044BF6C
		public override void OnUnload()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnUnload();
		}

		// Token: 0x06010F2D RID: 69421 RVA: 0x001A6C1F File Offset: 0x001A4E1F
		private void OnCloseClicked(IXUISprite sp)
		{
			base.SetVisible(false);
		}

		// Token: 0x06010F2E RID: 69422 RVA: 0x0044DD90 File Offset: 0x0044BF90
		private bool OnFetchButtonClicked(IXUIButton button)
		{
			bool flag = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler.IsVisible();
			if (flag)
			{
				this._doc.SendCustomBattleGetReward(this._doc.CurrentBountyData.gameID);
			}
			bool flag2 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeDetailHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeDetailHandler.IsVisible();
			if (flag2)
			{
				this._doc.SendCustomBattleGetReward(this._doc.CurrentCustomData.gameID);
			}
			return true;
		}

		// Token: 0x06010F2F RID: 69423 RVA: 0x0044DE24 File Offset: 0x0044C024
		private bool OnOpenNowButtonClicked(IXUIButton button)
		{
			bool flag = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler.IsVisible();
			if (flag)
			{
				this._doc.SendCustomBattleClearCD(this._doc.CurrentBountyData.gameID);
			}
			bool flag2 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeDetailHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeDetailHandler.IsVisible();
			if (flag2)
			{
				this._doc.SendCustomBattleClearCD(this._doc.CurrentCustomData.gameID);
			}
			return true;
		}

		// Token: 0x06010F30 RID: 69424 RVA: 0x001F8A12 File Offset: 0x001F6C12
		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

		// Token: 0x06010F31 RID: 69425 RVA: 0x0044DEB8 File Offset: 0x0044C0B8
		public override void RefreshData()
		{
			base.RefreshData();
			bool flag = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._BountyModeDetailHandler.IsVisible();
			if (flag)
			{
				this.RefreshBountyData();
			}
			bool flag2 = DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeDetailHandler != null && DlgBase<CustomBattleView, TabDlgBehaviour>.singleton._CustomModeDetailHandler.IsVisible();
			if (flag2)
			{
				this.RefreshCustomData();
			}
		}

		// Token: 0x06010F32 RID: 69426 RVA: 0x0044DF24 File Offset: 0x0044C124
		private void RefreshBountyData()
		{
			bool flag = this._doc.CurrentBountyData == null;
			if (!flag)
			{
				this._item_pool.ReturnAll(false);
				SeqListRef<uint> systemBattleReward = this._doc.GetSystemBattleReward((uint)this._doc.CurrentBountyData.gameID, this._doc.CurrentBountyData.winCount);
				for (int i = 0; i < systemBattleReward.Count; i++)
				{
					GameObject gameObject = this._item_pool.FetchGameObject(false);
					gameObject.transform.localPosition = this._item_pool.TplPos + new Vector3(((float)i - (float)(systemBattleReward.Count - 1) / 2f) * (float)this._item_pool.TplWidth, 0f);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)systemBattleReward[i, 0], (int)systemBattleReward[i, 1], false);
				}
				this._doc.DestoryFx(this._fx);
				this._fx = null;
				bool flag2 = this._doc.CurrentBountyData.boxLeftTime == 0U;
				if (flag2)
				{
					this._fetch_btn.SetVisible(true);
					this._wait_open_frame.gameObject.SetActive(false);
					this._boxCD.SetLeftTime(0f, -1);
					this._fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_BountyModeListFrame_Clip01", this._fx_point, false);
				}
				else
				{
					this._fetch_btn.SetVisible(false);
					this._wait_open_frame.gameObject.SetActive(true);
					this._boxCD.SetLeftTime(this._doc.CurrentBountyData.boxLeftTime, -1);
					SeqRef<uint> systemBattleQuickOpenCost = this._doc.GetSystemBattleQuickOpenCost((uint)this._doc.CurrentBountyData.gameID, this._doc.CurrentBountyData.winCount);
					this._cost.InputText = XLabelSymbolHelper.FormatSmallIcon((int)systemBattleQuickOpenCost[0]) + " " + systemBattleQuickOpenCost[1].ToString();
				}
			}
		}

		// Token: 0x06010F33 RID: 69427 RVA: 0x0044E140 File Offset: 0x0044C340
		private void RefreshCustomData()
		{
			bool flag = this._doc.CurrentCustomData == null;
			if (!flag)
			{
				this._item_pool.ReturnAll(false);
				SeqListRef<uint> customBattleRewardByRank = this._doc.GetCustomBattleRewardByRank(this._doc.CurrentCustomData.configID, this._doc.CurrentCustomData.selfRank);
				for (int i = 0; i < customBattleRewardByRank.Count; i++)
				{
					GameObject gameObject = this._item_pool.FetchGameObject(false);
					gameObject.transform.localPosition = this._item_pool.TplPos + new Vector3(((float)i - (float)(customBattleRewardByRank.Count - 1) / 2f) * (float)this._item_pool.TplWidth, 0f);
					XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(gameObject, (int)customBattleRewardByRank[i, 0], (int)customBattleRewardByRank[i, 1], false);
				}
				this._doc.DestoryFx(this._fx);
				this._fx = null;
				bool flag2 = this._doc.CurrentCustomData.boxLeftTime == 0U;
				if (flag2)
				{
					this._fetch_btn.SetVisible(true);
					this._wait_open_frame.gameObject.SetActive(false);
					this._boxCD.SetLeftTime(0f, -1);
					this._fx = XSingleton<XFxMgr>.singleton.CreateUIFx("Effects/FX_Particle/UIfx/UI_BountyModeListFrame_Clip01", this._fx_point, false);
				}
				else
				{
					this._fetch_btn.SetVisible(false);
					this._wait_open_frame.gameObject.SetActive(true);
					this._boxCD.SetLeftTime(this._doc.CurrentCustomData.boxLeftTime, -1);
					SeqRef<uint> customBattleQuickOpenCost = this._doc.GetCustomBattleQuickOpenCost(this._doc.CurrentCustomData.configID, this._doc.CurrentCustomData.selfRank);
					this._cost.InputText = XLabelSymbolHelper.FormatSmallIcon((int)customBattleQuickOpenCost[0]) + " " + customBattleQuickOpenCost[1].ToString();
				}
			}
		}

		// Token: 0x06010F34 RID: 69428 RVA: 0x0044E35C File Offset: 0x0044C55C
		public override void OnUpdate()
		{
			base.OnUpdate();
			bool activeInHierarchy = this._wait_open_frame.gameObject.activeInHierarchy;
			if (activeInHierarchy)
			{
				this._boxCD.Update();
			}
		}

		// Token: 0x04007CB0 RID: 31920
		private XCustomBattleDocument _doc = null;

		// Token: 0x04007CB1 RID: 31921
		private IXUISprite _close;

		// Token: 0x04007CB2 RID: 31922
		private XUIPool _item_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		// Token: 0x04007CB3 RID: 31923
		private IXUIButton _fetch_btn;

		// Token: 0x04007CB4 RID: 31924
		private Transform _wait_open_frame;

		// Token: 0x04007CB5 RID: 31925
		private IXUIButton _open_now;

		// Token: 0x04007CB6 RID: 31926
		private IXUILabel _left_time;

		// Token: 0x04007CB7 RID: 31927
		private IXUILabelSymbol _cost;

		// Token: 0x04007CB8 RID: 31928
		private XLeftTimeCounter _boxCD;

		// Token: 0x04007CB9 RID: 31929
		private Transform _fx_point;

		// Token: 0x04007CBA RID: 31930
		private XFx _fx = null;
	}
}
