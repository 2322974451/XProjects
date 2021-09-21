using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BFE RID: 3070
	internal class GiftboxDlg : DlgBase<GiftboxDlg, GiftboxBehaviour>
	{
		// Token: 0x170030C4 RID: 12484
		// (get) Token: 0x0600AE99 RID: 44697 RVA: 0x0020E0A4 File Offset: 0x0020C2A4
		private XGameMallDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
		}

		// Token: 0x170030C5 RID: 12485
		// (get) Token: 0x0600AE9A RID: 44698 RVA: 0x0020E0C0 File Offset: 0x0020C2C0
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030C6 RID: 12486
		// (get) Token: 0x0600AE9B RID: 44699 RVA: 0x0020E0D4 File Offset: 0x0020C2D4
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x170030C7 RID: 12487
		// (get) Token: 0x0600AE9C RID: 44700 RVA: 0x0020E0E8 File Offset: 0x0020C2E8
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030C8 RID: 12488
		// (get) Token: 0x0600AE9D RID: 44701 RVA: 0x0020E0FC File Offset: 0x0020C2FC
		public override bool fullscreenui
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030C9 RID: 12489
		// (get) Token: 0x0600AE9E RID: 44702 RVA: 0x0020E110 File Offset: 0x0020C310
		public override bool hideMainMenu
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170030CA RID: 12490
		// (get) Token: 0x0600AE9F RID: 44703 RVA: 0x0020E124 File Offset: 0x0020C324
		public override string fileName
		{
			get
			{
				return "GameSystem/GiftBoxDlg";
			}
		}

		// Token: 0x0600AEA0 RID: 44704 RVA: 0x0020E13B File Offset: 0x0020C33B
		protected override void Init()
		{
			base.Init();
		}

		// Token: 0x0600AEA1 RID: 44705 RVA: 0x0020E148 File Offset: 0x0020C348
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.Close));
			base.uiBehaviour.m_checkbox1.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.TogglePresent));
			base.uiBehaviour.m_checkbox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.ToggleRecv));
			base.uiBehaviour.m_wrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		// Token: 0x0600AEA2 RID: 44706 RVA: 0x0020E1D1 File Offset: 0x0020C3D1
		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_checkbox1.bChecked = true;
			this.TogglePresent(base.uiBehaviour.m_checkbox1);
		}

		// Token: 0x0600AEA3 RID: 44707 RVA: 0x0020E1FF File Offset: 0x0020C3FF
		protected override void OnHide()
		{
			this.doc.ClearGiftItems();
			base.OnHide();
		}

		// Token: 0x0600AEA4 RID: 44708 RVA: 0x0020E218 File Offset: 0x0020C418
		public void Refresh()
		{
			this.currItems = ((this.state == GiftboxDlg.State.Present) ? this.doc.presentList : this.doc.recvList);
			bool flag = this.currItems != null;
			if (flag)
			{
				bool flag2 = this.state == GiftboxDlg.State.Present;
				if (flag2)
				{
					this.RefreshPresent();
				}
				else
				{
					bool flag3 = this.state == GiftboxDlg.State.Recv;
					if (flag3)
					{
						this.RefreshRecv();
					}
				}
			}
		}

		// Token: 0x0600AEA5 RID: 44709 RVA: 0x0020E288 File Offset: 0x0020C488
		private bool Close(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600AEA6 RID: 44710 RVA: 0x0020E2A4 File Offset: 0x0020C4A4
		private bool ToggleRecv(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			if (bChecked)
			{
				this.state = GiftboxDlg.State.Recv;
				this.ToggleTip(this.state);
				this.doc.SendQueryGiftItems(1U);
			}
			return true;
		}

		// Token: 0x0600AEA7 RID: 44711 RVA: 0x0020E2E4 File Offset: 0x0020C4E4
		private void RefreshRecv()
		{
			bool flag = this.doc.recvList != null;
			if (flag)
			{
				base.uiBehaviour.m_scroll.ResetPosition();
				base.uiBehaviour.m_wrap.SetContentCount(this.doc.recvList.Count, false);
			}
		}

		// Token: 0x0600AEA8 RID: 44712 RVA: 0x0020E33C File Offset: 0x0020C53C
		private bool TogglePresent(IXUICheckBox box)
		{
			bool bChecked = box.bChecked;
			if (bChecked)
			{
				this.state = GiftboxDlg.State.Present;
				this.ToggleTip(this.state);
				this.doc.SendQueryGiftItems(0U);
			}
			return true;
		}

		// Token: 0x0600AEA9 RID: 44713 RVA: 0x0020E37C File Offset: 0x0020C57C
		private void ToggleTip(GiftboxDlg.State state)
		{
			base.uiBehaviour.m_tip0.SetActive(state == GiftboxDlg.State.Recv);
			base.uiBehaviour.m_tip1.SetActive(state == GiftboxDlg.State.Present);
		}

		// Token: 0x0600AEAA RID: 44714 RVA: 0x0020E3AC File Offset: 0x0020C5AC
		private void RefreshPresent()
		{
			bool flag = this.doc.presentList != null;
			if (flag)
			{
				base.uiBehaviour.m_scroll.ResetPosition();
				base.uiBehaviour.m_wrap.SetContentCount(this.doc.presentList.Count, false);
			}
		}

		// Token: 0x0600AEAB RID: 44715 RVA: 0x0020E404 File Offset: 0x0020C604
		private void WrapContentItemUpdated(Transform t, int index)
		{
			bool flag = this.currItems == null || this.currItems.Count <= index;
			if (!flag)
			{
				IBGiftHistItem ibgiftHistItem = this.currItems[index];
				IXUILabel ixuilabel = t.Find("Label").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.Find("Recv").GetComponent("XUILabel") as IXUILabel;
				ixuilabel.SetText(this.startTime.AddSeconds(ibgiftHistItem.time).ToString("yyyy-MM-dd"));
				ixuilabel2.SetText(ibgiftHistItem.name);
				XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(t.gameObject, (int)ibgiftHistItem.item.itemID, (int)ibgiftHistItem.item.itemCount, false);
			}
		}

		// Token: 0x0400425C RID: 16988
		private DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

		// Token: 0x0400425D RID: 16989
		private List<IBGiftHistItem> currItems;

		// Token: 0x0400425E RID: 16990
		public GiftboxDlg.State state = GiftboxDlg.State.Present;

		// Token: 0x020019A2 RID: 6562
		public enum State
		{
			// Token: 0x04007F53 RID: 32595
			Present,
			// Token: 0x04007F54 RID: 32596
			Recv
		}
	}
}
