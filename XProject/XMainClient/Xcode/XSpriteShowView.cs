using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XSpriteShowView : DlgBase<XSpriteShowView, XSpriteShowBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteShowDlg";
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SpriteSystem_Detail);
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this.m_AvatarHandler, base.uiBehaviour.m_AvatarRoot, true, this);
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			bool isShowedShare = this._isShowedShare;
			if (isShowedShare)
			{
				this._spriteID = 0;
				this._isShowedShare = false;
				this.OnCloseClicked(null);
			}
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		protected override void OnHide()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.token);
			this._doc.DestroyFx(this.m_Fx);
			this.m_Fx = null;
			this._spriteID = 0;
			this._isShowedShare = false;
			base.OnHide();
			this.m_AvatarHandler.SetVisible(false);
		}

		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.token);
			this._doc.DestroyFx(this.m_Fx);
			this.m_Fx = null;
			DlgHandlerBase.EnsureUnload<XSpriteAvatarHandler>(ref this.m_AvatarHandler);
			base.OnUnload();
		}

		public void ShowDetail(uint spriteID, uint ppt, bool fromLottery = false)
		{
			bool flag = !base.IsVisible();
			if (flag)
			{
				this.SetVisible(true, true);
			}
			this.m_AvatarHandler.SetVisible(true);
			this.m_AvatarHandler.SetSpriteInfo(spriteID, false, ppt);
			this.SetLotteryAnim();
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)spriteID);
			this.SetupFx((int)((itemConf != null) ? itemConf.ItemQuality : 0));
			this.SetupQuality((int)((itemConf != null) ? itemConf.ItemQuality : 0));
			this._from_lottery = fromLottery;
			this._spriteID = (int)spriteID;
		}

		private void SetLotteryAnim()
		{
			XEntityPresentation.RowData spritePresent = this.m_AvatarHandler.GetSpritePresent();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.token);
			float interval = this.m_AvatarHandler.SetSpriteAnim(spritePresent.AttackIdle);
			this.token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.ResetAvatarAnim), null);
		}

		private void SetupFx(int quality)
		{
			this._doc.DestroyFx(this.m_Fx);
			this.m_Fx = null;
			switch (quality)
			{
			case 3:
				this.m_Fx = this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_jl_05_orange", base.uiBehaviour.m_FxPoint);
				break;
			case 4:
				this.m_Fx = this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_jl_05_purple", base.uiBehaviour.m_FxPoint);
				break;
			case 5:
				this.m_Fx = this._doc.CreateAndPlayFx("Effects/FX_Particle/UIfx/UI_jl_05_red", base.uiBehaviour.m_FxPoint);
				break;
			}
		}

		private void SetupQuality(int quality)
		{
			switch (quality)
			{
			case 3:
				base.uiBehaviour.m_Quality.SetSprite("Fairy_Show_0");
				break;
			case 4:
				base.uiBehaviour.m_Quality.SetSprite("Fairy_Show_1");
				break;
			case 5:
				base.uiBehaviour.m_Quality.SetSprite("Fairy_Show_2");
				break;
			}
			base.uiBehaviour.m_QualityTween.PlayTween(true, -1f);
		}

		private void ResetAvatarAnim(object o)
		{
			this.m_AvatarHandler.ResetSpriteAnim();
		}

		public void OnCloseClicked(IXUISprite sp)
		{
			ItemList.RowData itemConf = XBagDocument.GetItemConf(this._spriteID);
			XScreenShotShareDocument specificDocument = XDocuments.GetSpecificDocument<XScreenShotShareDocument>(XScreenShotShareDocument.uuID);
			bool flag = itemConf != null && itemConf.ItemQuality == 4 && specificDocument.CurShareBgType == ShareBgType.LuckySpriteType && (ulong)specificDocument.SpriteID == (ulong)((long)this._spriteID);
			if (flag)
			{
				this._isShowedShare = true;
				XSingleton<PDatabase>.singleton.shareCallbackType = ShareCallBackType.GloryPic;
				DlgBase<DungeonShareView, DungeonShareBehavior>.singleton.SetVisibleWithAnimation(true, null);
			}
			else
			{
				bool flag2 = this._from_lottery && this._doc.AutoShowEpicSprite;
				if (flag2)
				{
					DlgBase<SpriteSystemDlg, TabDlgBehaviour>.singleton._SpriteLotteryHandler.OnOkButtonClicked(null);
				}
				else
				{
					this.SetVisible(false, true);
				}
			}
		}

		private XSpriteSystemDocument _doc = null;

		private XSpriteAvatarHandler m_AvatarHandler;

		private XFx m_Fx;

		private bool _from_lottery = false;

		private uint token = 0U;

		private int _spriteID = 0;

		private bool _isShowedShare = false;
	}
}
