using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000BAF RID: 2991
	internal class RollDlg : DlgBase<RollDlg, RollDlgBehaviour>
	{
		// Token: 0x17003054 RID: 12372
		// (get) Token: 0x0600AB72 RID: 43890 RVA: 0x001F4AD0 File Offset: 0x001F2CD0
		public override string fileName
		{
			get
			{
				return "Battle/RollDlg";
			}
		}

		// Token: 0x17003055 RID: 12373
		// (get) Token: 0x0600AB73 RID: 43891 RVA: 0x001F4AE8 File Offset: 0x001F2CE8
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x17003056 RID: 12374
		// (get) Token: 0x0600AB74 RID: 43892 RVA: 0x001F4AFC File Offset: 0x001F2CFC
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600AB75 RID: 43893 RVA: 0x001F4B0F File Offset: 0x001F2D0F
		protected override void Init()
		{
			base.Init();
			this._doc = (XSingleton<XGame>.singleton.Doc.GetXComponent(XRollDocument.uuID) as XRollDocument);
		}

		// Token: 0x0600AB76 RID: 43894 RVA: 0x001F4B38 File Offset: 0x001F2D38
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.m_YesButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnYesButtonClicked));
			base.uiBehaviour.m_CancelButton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnCancelButtonClicked));
		}

		// Token: 0x0600AB77 RID: 43895 RVA: 0x001F4B87 File Offset: 0x001F2D87
		public void ShowRollInfo()
		{
			this.SetVisibleWithAnimation(true, null);
			this.SetupRollItemInfo();
		}

		// Token: 0x0600AB78 RID: 43896 RVA: 0x001F4B9C File Offset: 0x001F2D9C
		private bool OnYesButtonClicked(IXUIButton button)
		{
			this._doc.SendRollReq(1);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600AB79 RID: 43897 RVA: 0x001F4BC8 File Offset: 0x001F2DC8
		private bool OnCancelButtonClicked(IXUIButton button)
		{
			this._doc.SendRollReq(2);
			this.SetVisible(false, true);
			return true;
		}

		// Token: 0x0600AB7A RID: 43898 RVA: 0x001F4BF4 File Offset: 0x001F2DF4
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

		// Token: 0x0600AB7B RID: 43899 RVA: 0x001F4C8C File Offset: 0x001F2E8C
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

		// Token: 0x0400403A RID: 16442
		private XRollDocument _doc;
	}
}
