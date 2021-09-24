using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient.UI
{

	internal class TitleShareDlg : DlgBase<TitleShareDlg, TitleShareBehaviour>
	{

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int sysid
		{
			get
			{
				return XFastEnumIntEqualityComparer<XSysDefine>.ToInt(XSysDefine.XSys_Title_Share);
			}
		}

		public override string fileName
		{
			get
			{
				return "GameSystem/TitleShareDlg";
			}
		}

		public override bool pushstack
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

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XTitleDocument>(XTitleDocument.uuID);
			base.uiBehaviour.m_Close.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.ClickTitleShared));
		}

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

		private void KillTimer(object sender)
		{
			this.m_canClose = true;
			base.uiBehaviour.m_closeTips.gameObject.SetActive(this.m_canClose);
			XSingleton<XTimerMgr>.singleton.KillTimer(this.m_showTime);
			XSingleton<X3DAvatarMgr>.singleton.SetMainAnimation(XSingleton<XEntityMgr>.singleton.Player.Present.PresentLib.AttackIdle);
		}

		protected override void OnHide()
		{
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, base.uiBehaviour.m_snapshotTransfrom);
			base.OnHide();
			this.m_showTime = 0U;
			XSingleton<X3DAvatarMgr>.singleton.EnableMainDummy(false, null);
		}

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

		private XTitleDocument _Doc;

		private uint m_showTime;

		private bool m_canClose;
	}
}
