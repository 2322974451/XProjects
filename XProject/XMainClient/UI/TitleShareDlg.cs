using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{
	// Token: 0x0200186C RID: 6252
	internal class TitleShareDlg : DlgBase<TitleShareDlg, TitleShareBehaviour>
	{
		// Token: 0x170039A8 RID: 14760
		// (get) Token: 0x06010465 RID: 66661 RVA: 0x003F046C File Offset: 0x003EE66C
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170039A9 RID: 14761
		// (get) Token: 0x06010466 RID: 66662 RVA: 0x003F0480 File Offset: 0x003EE680
		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Title_Share);
			}
		}

		// Token: 0x170039AA RID: 14762
		// (get) Token: 0x06010467 RID: 66663 RVA: 0x003F049C File Offset: 0x003EE69C
		public override string fileName
		{
			get
			{
				return "GameSystem/TitleShareDlg";
			}
		}

		// Token: 0x170039AB RID: 14763
		// (get) Token: 0x06010468 RID: 66664 RVA: 0x003F04B4 File Offset: 0x003EE6B4
		public override bool pushstack
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039AC RID: 14764
		// (get) Token: 0x06010469 RID: 66665 RVA: 0x003F04C8 File Offset: 0x003EE6C8
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170039AD RID: 14765
		// (get) Token: 0x0601046A RID: 66666 RVA: 0x003F04DC File Offset: 0x003EE6DC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0601046B RID: 66667 RVA: 0x003F04EF File Offset: 0x003EE6EF
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickTitleShared));
		}

		// Token: 0x0601046C RID: 66668 RVA: 0x003F0528 File Offset: 0x003EE728
		protected override void OnShow()
		{
			base.OnShow();
			this.m_canClose = false;
			TitleTable.RowData currentTitle = this._Doc.CurrentTitle;
			base.uiBehaviour.m_closeTips.gameObject.SetActive(this.m_canClose);
			base.uiBehaviour.m_currentTitle.Set(currentTitle);
			bool flag = !string.IsNullOrEmpty(currentTitle.AffectRoute);
			if (flag)
			{
				XSingleton<XFxMgr>.singleton.CreateAndPlay(currentTitle.AffectRoute + "_Clip01", base.uiBehaviour.transform, Vector3.zero, Vector3.one, 1f, false, 1f, true);
			}
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(true, base.uiBehaviour.m_snapshotTransfrom);
			float interval = XSingleton<X3DAvatarMgr>.singleton.SetMainAnimationGetLength(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.Disappear);
			this.m_showTime = XSingleton<XTimerMgr>.singleton.SetTimer(interval, new XTimerMgr.ElapsedEventHandler(this.KillTimer), null);
			base.uiBehaviour.m_message.SetText(XStringDefineProxy.GetString("TITLE_NEW_GET", new object[]
			{
				currentTitle.RankName
			}));
		}

		// Token: 0x0601046D RID: 66669 RVA: 0x003F0650 File Offset: 0x003EE850
		private void KillTimer(object sender)
		{
			this.m_canClose = true;
			base.uiBehaviour.m_closeTips.gameObject.SetActive(this.m_canClose);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_showTime);
			XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
		}

		// Token: 0x0601046E RID: 66670 RVA: 0x003F06B6 File Offset: 0x003EE8B6
		protected override void OnHide()
		{
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, base.uiBehaviour.m_snapshotTransfrom);
			base.OnHide();
			this.m_showTime = 0U;
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
		}

		// Token: 0x0601046F RID: 66671 RVA: 0x003F06EC File Offset: 0x003EE8EC
		protected override void OnUnload()
		{
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_showTime);
			XSingleton<X3DAvatarMgr>.singleton.OnUIUnloadMainDummy(base.uiBehaviour.m_snapshotTransfrom);
			bool flag = base.uiBehaviour != null;
			if (flag)
			{
				base.uiBehaviour.m_currentTitle.Reset();
			}
			base.OnUnload();
		}

		// Token: 0x06010470 RID: 66672 RVA: 0x003F074C File Offset: 0x003EE94C
		private void ClickTitleShared(IXUISprite texture)
		{
			bool flag = !this.m_canClose;
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("TITILE_QUIKE"), "fece00");
			}
			else
			{
				this.SetVisibleWithAnimation(false, null);
			}
		}

		// Token: 0x0400750D RID: 29965
		private XTitleDocument _Doc;

		// Token: 0x0400750E RID: 29966
		private uint m_showTime;

		// Token: 0x0400750F RID: 29967
		private bool m_canClose;
	}
}
