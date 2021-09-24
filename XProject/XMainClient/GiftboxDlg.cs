using System;
using System.Collections.Generic;
using KKSG;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class GiftboxDlg : DlgBase<GiftboxDlg, GiftboxBehaviour>
	{

		private XGameMallDocument doc
		{
			get
			{
				return XDocuments.GetSpecificDocument<XGameMallDocument>(XGameMallDocument.uuID);
			}
		}

		public override int layer
		{
			get
			{
				return 1;
			}
		}

		public override int group
		{
			get
			{
				return 1;
			}
		}

		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		public override bool fullscreenui
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

		public override string fileName
		{
			get
			{
				return "GameSystem/GiftBoxDlg";
			}
		}

		protected override void Init()
		{
			base.Init();
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_btnClose.RegisterClickEventHandler(new ButtonClickEventHandler(this.Close));
			base.uiBehaviour.m_checkbox1.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.TogglePresent));
			base.uiBehaviour.m_checkbox2.RegisterOnCheckEventHandler(new CheckBoxOnCheckEventHandler(this.ToggleRecv));
			base.uiBehaviour.m_wrap.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.WrapContentItemUpdated));
		}

		protected override void OnShow()
		{
			base.OnShow();
			base.uiBehaviour.m_checkbox1.bChecked = true;
			this.TogglePresent(base.uiBehaviour.m_checkbox1);
		}

		protected override void OnHide()
		{
			this.doc.ClearGiftItems();
			base.OnHide();
		}

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

		private bool Close(IXUIButton btn)
		{
			this.SetVisible(false, true);
			return true;
		}

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

		private void RefreshRecv()
		{
			bool flag = this.doc.recvList != null;
			if (flag)
			{
				base.uiBehaviour.m_scroll.ResetPosition();
				base.uiBehaviour.m_wrap.SetContentCount(this.doc.recvList.Count, false);
			}
		}

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

		private void ToggleTip(GiftboxDlg.State state)
		{
			base.uiBehaviour.m_tip0.SetActive(state == GiftboxDlg.State.Recv);
			base.uiBehaviour.m_tip1.SetActive(state == GiftboxDlg.State.Present);
		}

		private void RefreshPresent()
		{
			bool flag = this.doc.presentList != null;
			if (flag)
			{
				base.uiBehaviour.m_scroll.ResetPosition();
				base.uiBehaviour.m_wrap.SetContentCount(this.doc.presentList.Count, false);
			}
		}

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

		private DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));

		private List<IBGiftHistItem> currItems;

		public GiftboxDlg.State state = GiftboxDlg.State.Present;

		public enum State
		{

			Present,

			Recv
		}
	}
}
