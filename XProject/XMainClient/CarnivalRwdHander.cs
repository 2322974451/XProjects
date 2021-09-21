using System;
using UILib;
using UnityEngine;
using XMainClient.UI;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BB8 RID: 3000
	internal class CarnivalRwdHander : DlgHandlerBase
	{
		// Token: 0x0600ABB9 RID: 43961 RVA: 0x001F6E98 File Offset: 0x001F5098
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

		// Token: 0x0600ABBA RID: 43962 RVA: 0x001F6FD0 File Offset: 0x001F51D0
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			this.m_rwdBtn.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnRwdbtnClick));
			this.m_sprIntro.RegisterSpriteClickEventHandler(new SpriteClickEventHandler(this.OnIntroClick));
			this.m_sprRBg.RegisterSpriteDragEventHandler(new SpriteDragEventHandler(this.OnAvatarDrag));
		}

		// Token: 0x0600ABBB RID: 43963 RVA: 0x001F702D File Offset: 0x001F522D
		private void OnIntroClick(IXUISprite sp)
		{
			XSingleton<XDebug>.singleton.AddLog("intro click", null, null, null, null, null, XDebugColor.XDebug_None);
		}

		// Token: 0x0600ABBC RID: 43964 RVA: 0x001F7048 File Offset: 0x001F5248
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

		// Token: 0x0600ABBD RID: 43965 RVA: 0x001F714C File Offset: 0x001F534C
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

		// Token: 0x0600ABBE RID: 43966 RVA: 0x001F72AC File Offset: 0x001F54AC
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

		// Token: 0x0600ABBF RID: 43967 RVA: 0x001F7360 File Offset: 0x001F5560
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

		// Token: 0x0600ABC0 RID: 43968 RVA: 0x001F740C File Offset: 0x001F560C
		public override void StackRefresh()
		{
			base.StackRefresh();
			base.Alloc3DAvatarPool("CarnivalRwdHander", 1);
			this.m_Dummy = XSingleton<X3DAvatarMgr>.singleton.CreateCommonEntityDummy(this.m_dummPool, this.present, this.m_Snapshot, this.m_Dummy, 1f);
		}

		// Token: 0x0600ABC1 RID: 43969 RVA: 0x001F745B File Offset: 0x001F565B
		public override void LeaveStackTop()
		{
			base.LeaveStackTop();
			XSingleton<X3DAvatarMgr>.singleton.DestroyDummy(this.m_dummPool, this.m_Dummy);
			this.m_Dummy = null;
		}

		// Token: 0x0600ABC2 RID: 43970 RVA: 0x001F7483 File Offset: 0x001F5683
		protected override void OnHide()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnHide();
		}

		// Token: 0x0600ABC3 RID: 43971 RVA: 0x001F749B File Offset: 0x001F569B
		public override void OnUnload()
		{
			base.Return3DAvatarPool();
			this.m_Dummy = null;
			base.OnUnload();
		}

		// Token: 0x0600ABC4 RID: 43972 RVA: 0x001F74B4 File Offset: 0x001F56B4
		protected bool OnAvatarDrag(Vector2 delta)
		{
			bool flag = this.m_Dummy != null;
			if (flag)
			{
				this.m_Dummy.EngineObject.Rotate(Vector3.up, -delta.x / 2f);
			}
			return true;
		}

		// Token: 0x04004079 RID: 16505
		private IXUIButton m_rwdBtn;

		// Token: 0x0400407A RID: 16506
		private IXUILabel m_rwdLbl;

		// Token: 0x0400407B RID: 16507
		private IXUISlider m_slider;

		// Token: 0x0400407C RID: 16508
		private IXUILabel m_lblProgress;

		// Token: 0x0400407D RID: 16509
		private IXUISprite m_sprIntro;

		// Token: 0x0400407E RID: 16510
		public IXUISprite m_sprRBg;

		// Token: 0x0400407F RID: 16511
		private XDummy m_Dummy;

		// Token: 0x04004080 RID: 16512
		private IUIDummy m_Snapshot;

		// Token: 0x04004081 RID: 16513
		private uint present;
	}
}
