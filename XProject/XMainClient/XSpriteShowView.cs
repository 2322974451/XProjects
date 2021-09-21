using System;
using UILib;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000CB7 RID: 3255
	internal class XSpriteShowView : DlgBase<XSpriteShowView, XSpriteShowBehaviour>
	{
		// Token: 0x1700325F RID: 12895
		// (get) Token: 0x0600B71A RID: 46874 RVA: 0x00246400 File Offset: 0x00244600
		public override string fileName
		{
			get
			{
				return "GameSystem/SpriteSystem/SpriteShowDlg";
			}
		}

		// Token: 0x17003260 RID: 12896
		// (get) Token: 0x0600B71B RID: 46875 RVA: 0x00246418 File Offset: 0x00244618
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_SpriteSystem_Detail);
			}
		}

		// Token: 0x17003261 RID: 12897
		// (get) Token: 0x0600B71C RID: 46876 RVA: 0x00246434 File Offset: 0x00244634
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003262 RID: 12898
		// (get) Token: 0x0600B71D RID: 46877 RVA: 0x00246448 File Offset: 0x00244648
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17003263 RID: 12899
		// (get) Token: 0x0600B71E RID: 46878 RVA: 0x0024645C File Offset: 0x0024465C
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600B71F RID: 46879 RVA: 0x0024646F File Offset: 0x0024466F
		protected override void Init()
		{
			base.Init();
			this._doc = XDocuments.GetSpecificDocument<XSpriteSystemDocument>(XSpriteSystemDocument.uuID);
			DlgHandlerBase.EnsureCreate<XSpriteAvatarHandler>(ref this.m_AvatarHandler, base.uiBehaviour.m_AvatarRoot, true, this);
		}

		// Token: 0x0600B720 RID: 46880 RVA: 0x002464A4 File Offset: 0x002446A4
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

		// Token: 0x0600B721 RID: 46881 RVA: 0x002464DB File Offset: 0x002446DB
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnCloseClicked));
		}

		// Token: 0x0600B722 RID: 46882 RVA: 0x00246504 File Offset: 0x00244704
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

		// Token: 0x0600B723 RID: 46883 RVA: 0x0024655E File Offset: 0x0024475E
		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.token);
			this._doc.DestroyFx(this.m_Fx);
			this.m_Fx = null;
			DlgHandlerBase.EnsureUnload<XSpriteAvatarHandler>(ref this.m_AvatarHandler);
			base.OnUnload();
		}

		// Token: 0x0600B724 RID: 46884 RVA: 0x002465A0 File Offset: 0x002447A0
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

		// Token: 0x0600B725 RID: 46885 RVA: 0x00246624 File Offset: 0x00244824
		private void SetLotteryAnim()
		{
			XEntityPresentation.RowData spritePresent = this.m_AvatarHandler.GetSpritePresent();
			XSingleton<XTimerMgr>.singleton.KillTimer(this.token);
			float interval = this.m_AvatarHandler.SetSpriteAnim(spritePresent.AttackIdle);
			this.token = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.ResetAvatarAnim), null);
		}

		// Token: 0x0600B726 RID: 46886 RVA: 0x00246680 File Offset: 0x00244880
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

		// Token: 0x0600B727 RID: 46887 RVA: 0x00246728 File Offset: 0x00244928
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

		// Token: 0x0600B728 RID: 46888 RVA: 0x002467AD File Offset: 0x002449AD
		private void ResetAvatarAnim(object o)
		{
			this.m_AvatarHandler.ResetSpriteAnim();
		}

		// Token: 0x0600B729 RID: 46889 RVA: 0x002467BC File Offset: 0x002449BC
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

		// Token: 0x040047CA RID: 18378
		private XSpriteSystemDocument _doc = null;

		// Token: 0x040047CB RID: 18379
		private XSpriteAvatarHandler m_AvatarHandler;

		// Token: 0x040047CC RID: 18380
		private XFx m_Fx;

		// Token: 0x040047CD RID: 18381
		private bool _from_lottery = false;

		// Token: 0x040047CE RID: 18382
		private uint token = 0U;

		// Token: 0x040047CF RID: 18383
		private int _spriteID = 0;

		// Token: 0x040047D0 RID: 18384
		private bool _isShowedShare = false;
	}
}
