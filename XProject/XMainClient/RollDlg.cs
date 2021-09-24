using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{

	internal class RollDlg : DlgBase<RollDlg, RollDlgBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Battle/RollDlg";
			}
		}

		public override int layer
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

		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XRollDocument.uuID) as XRollDocument);
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_YesButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnYesButtonClicked));
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelButtonClicked));
		}

		public void ShowRollInfo()
		{
			this.SetVisibleWithAnimation(true, null);
			this.SetupRollItemInfo();
		}

		private bool OnYesButtonClicked(IXUIButton button)
		{
			this._doc.SendRollReq(1);
			this.SetVisible(false, true);
			return true;
		}

		private bool OnCancelButtonClicked(IXUIButton button)
		{
			this._doc.SendRollReq(2);
			this.SetVisible(false, true);
			return true;
		}

		private void SetupRollItemInfo()
		{
			XSingleton<XItemDrawerMgr>.singleton.normalItemDrawer.DrawItem(base.uiBehaviour.m_ItemTpl, (int)this._doc.RollItemID, (int)this._doc.RollItemCount, false);
			ItemList.RowData itemConf = XBagDocument.GetItemConf((int)this._doc.RollItemID);
			bool flag = itemConf == null;
			if (!flag)
			{
				base.uiBehaviour.m_Level.SetText(itemConf.ReqLevel.ToString());
				base.uiBehaviour.m_Prof.SetText(XSingleton<XProfessionSkillMgr>.singleton.GetProfName((int)itemConf.Profession));
			}
		}

		public override void OnUpdate()
		{
			base.OnUpdate();
			bool flag = Time.time - this._doc.LastRollTime > (float)this._doc.ClientRollTime;
			if (flag)
			{
				this.SetVisible(false, true);
			}
			else
			{
				base.uiBehaviour.m_TimeBar.Value = ((float)this._doc.ClientRollTime - Time.time + this._doc.LastRollTime) / (float)this._doc.ClientRollTime;
			}
		}

		private XRollDocument _doc;
	}
}
