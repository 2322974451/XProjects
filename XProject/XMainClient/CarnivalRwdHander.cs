using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class CarnivalRwdHander : DlgHandlerBase
	{

		protected override void Init()
		{
			base.Init();
			this.m_Snapshot = (base.transform.Find("snapshot").GetComponent("UIDummy") as IUIDummy);
			this.m_rwdBtn = (base.transform.Find("btn").GetComponent("XUIButton") as IXUIButton);
			this.m_rwdLbl = (this.m_rwdBtn.gameObject.transform.Find("MoneyCost").GetComponent("XUILabel") as IXUILabel);
			this.m_sprIntro = (base.transform.Find("Help").GetComponent("XUISprite") as IXUISprite);
			this.m_slider = (base.transform.Find("slider").GetComponent("XUISlider") as IXUISlider);
			this.m_lblProgress = (base.transform.Find("slider/PLabel").GetComponent("XUILabel") as IXUILabel);
			this.m_sprRBg = (base.transform.Find("Bg").GetComponent("XUISprite") as IXUISprite);
			this.present = (uint)XSingleton<XGlobalConfig>.singleton.GetInt("CarnivalPresent");
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_rwdBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRwdbtnClick));
			this.m_sprIntro.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnIntroClick));
			this.m_sprRBg.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnAvatarDrag));
		}

		private void OnIntroClick(IXUISprite sp)
		{
			XSingleton<XDebug>.singleton.AddLog("intro click", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		public void Refresh()
		{
			bool flag = this.m_Dummy == null;
			if (flag)
			{
				this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, this.present, this.m_Snapshot, this.m_Dummy, 1f);
			}
			bool flag2 = !XSingleton<XAttributeMgr>.singleton.XPlayerData.CarnivalClaimed;
			this.m_rwdBtn.SetEnable(flag2 && !DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.IsActivityClosed(), false);
			this.m_rwdLbl.SetText((!flag2) ? XStringDefineProxy.GetString("carnival_after") : XStringDefineProxy.GetString("carnival_befor"));
			uint needPoint = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.needPoint;
			uint point = XSingleton<XAttributeMgr>.singleton.XPlayerData.point;
			this.m_slider.Value = Mathf.Min(needPoint, point) / needPoint;
			this.m_lblProgress.SetText(point + "/" + needPoint);
		}

		private bool OnRwdbtnClick(IXUIButton btn)
		{
			uint needPoint = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.needPoint;
			uint point = XSingleton<XAttributeMgr>.singleton.XPlayerData.point;
			bool flag = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.IsActivityClosed();
			if (flag)
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalLast"), "fece00");
			}
			else
			{
				bool flag2 = point >= needPoint;
				if (flag2)
				{
					DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.ExchangePoint();
				}
				else
				{
					bool flag3 = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.IsActivityExpire();
					if (flag3)
					{
						int num = Convert.ToInt32(Math.Round((double)((needPoint - point) * DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.rate)));
						DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(true, true);
						DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetSingleButtonMode(false);
						string @string = XStringDefineProxy.GetString("CarnivalPrice", new object[]
						{
							num,
							needPoint - point
						});
						string string2 = XStringDefineProxy.GetString(XStringDefine.COMMON_OK);
						string string3 = XStringDefineProxy.GetString(XStringDefine.COMMON_CANCEL);
						DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetLabelsWithSymbols(@string, string2, string3);
						DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetModalCallback(new ButtonClickEventHandler(this.OnModalDlgOK), null);
					}
					else
					{
						XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalLess"), "fece00");
					}
				}
			}
			return true;
		}

		private bool OnModalDlgOK(IXUIButton btn)
		{
			DlgBase<ModalDlg, ModalDlgBehaviour>.singleton.SetVisible(false, true);
			uint needPoint = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.needPoint;
			int num = (int)XSingleton<XGame>.singleton.Doc.XBagDoc.GetItemCount(7);
			uint point = XSingleton<XAttributeMgr>.singleton.XPlayerData.point;
			int num2 = Convert.ToInt32(Math.Round((double)((needPoint - point) * DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.rate)));
			bool flag = num > num2;
			if (flag)
			{
				DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.ExchangePoint();
			}
			else
			{
				XSingleton<UiUtility>.singleton.ShowSystemTip(XStringDefineProxy.GetString("CarnivalPay"), "fece00");
			}
			return true;
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.Alloc3DAvatarPool("CarnivalRwdHander", 1);
			this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, this.present, this.m_Snapshot, this.m_Dummy, 1f);
			uint needPoint = DlgBase<CarnivalDlg, CarnivalBehavior>.singleton.doc.needPoint;
			uint point = XSingleton<XAttributeMgr>.singleton.XPlayerData.point;
			this.m_slider.Value = Mathf.Min(needPoint, point) / needPoint;
			this.m_lblProgress.SetText(point + "/" + needPoint);
		}

		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("CarnivalRwdHander", 1);
			this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, this.present, this.m_Snapshot, this.m_Dummy, 1f);
		}

		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
			XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
			this.m_Dummy = null;
		}

		protected override void OnHide()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnHide();
		}

		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnUnload();
		}

		protected bool OnAvatarDrag(Vector2 delta)
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				this.m_Dummy.EngineObject.Rotate(Vector3.up, -delta.x / 2f);
			}
			return true;
		}

		private IXUIButton m_rwdBtn;

		private IXUILabel m_rwdLbl;

		private IXUISlider m_slider;

		private IXUILabel m_lblProgress;

		private IXUISprite m_sprIntro;

		public IXUISprite m_sprRBg;

		private XDummy m_Dummy;

		private IUIDummy m_Snapshot;

		private uint present;
	}
}
