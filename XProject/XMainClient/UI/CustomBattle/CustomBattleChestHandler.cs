using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI.CustomBattle
{

	internal class CustomBattleChestHandler : DlgHandlerBase
	{

		protected override string FileName
		{
			get
			{
				return "GameSystem/CustomBattle/ChestFrame";
			}
		}

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

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this._close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
			this._fetch_btn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnFetchButtonClicked));
			this._open_now.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnOpenNowButtonClicked));
		}

		protected override void OnHide()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnHide();
		}

		public override void OnUnload()
		{
			this._doc.DestoryFx(this._fx);
			this._fx = null;
			base.OnUnload();
		}

		private void OnCloseClicked(IXUISprite sp)
		{
			base.SetVisible(false);
		}

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

		protected override void OnShow()
		{
			base.OnShow();
			this.RefreshData();
		}

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

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool activeInHierarchy = this._wait_open_frame.gameObject.activeInHierarchy;
			if (activeInHierarchy)
			{
				this._boxCD.Update();
			}
		}

		private XCustomBattleDocument _doc = null;

		private IXUISprite _close;

		private XUIPool _item_pool = new XUIPool(XSingleton<XGameUI>.singleton.m_uiTool);

		private IXUIButton _fetch_btn;

		private Transform _wait_open_frame;

		private IXUIButton _open_now;

		private IXUILabel _left_time;

		private IXUILabelSymbol _cost;

		private XLeftTimeCounter _boxCD;

		private Transform _fx_point;

		private XFx _fx = null;
	}
}
