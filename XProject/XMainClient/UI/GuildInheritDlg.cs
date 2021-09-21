using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{
	// Token: 0x02001761 RID: 5985
	internal class GuildInheritDlg : DlgBase<GuildInheritDlg, GuildInheritBehaviour>
	{
		// Token: 0x17003808 RID: 14344
		// (get) Token: 0x0600F724 RID: 63268 RVA: 0x00383128 File Offset: 0x00381328
		public override string fileName
		{
			get
			{
				return "Guild/GuildInheritDlg";
			}
		}

		// Token: 0x17003809 RID: 14345
		// (get) Token: 0x0600F725 RID: 63269 RVA: 0x00383140 File Offset: 0x00381340
		public override int layer
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700380A RID: 14346
		// (get) Token: 0x0600F726 RID: 63270 RVA: 0x00383154 File Offset: 0x00381354
		public override int group
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700380B RID: 14347
		// (get) Token: 0x0600F727 RID: 63271 RVA: 0x00383168 File Offset: 0x00381368
		public override bool autoload
		{
			get
			{
				return true;
			}
		}

		// Token: 0x0600F728 RID: 63272 RVA: 0x0038317B File Offset: 0x0038137B
		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnItemUpdateHandler));
		}

		// Token: 0x0600F729 RID: 63273 RVA: 0x003831B4 File Offset: 0x003813B4
		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.OverLook.RegisterClickEventHandler(new ButtonClickEventHandler(this.CloseClick));
			base.uiBehaviour.Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.CloseClick));
			base.uiBehaviour.NotAccept.RegisterClickEventHandler(new ButtonClickEventHandler(this.OverLookClick));
		}

		// Token: 0x0600F72A RID: 63274 RVA: 0x00383220 File Offset: 0x00381420
		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendInheritList();
		}

		// Token: 0x0600F72B RID: 63275 RVA: 0x00383236 File Offset: 0x00381436
		public void RefreshData()
		{
			base.uiBehaviour.WrapContent.SetContentCount(this._Doc.InheritList.Count, false);
			base.uiBehaviour.ScrollView.ResetPosition();
		}

		// Token: 0x0600F72C RID: 63276 RVA: 0x0038326C File Offset: 0x0038146C
		private bool OverLookClick(IXUIButton btn)
		{
			this._Doc.SendDelInherit();
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x0600F72D RID: 63277 RVA: 0x00383294 File Offset: 0x00381494
		private bool CloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		// Token: 0x0600F72E RID: 63278 RVA: 0x003832B0 File Offset: 0x003814B0
		private void OnItemUpdateHandler(Transform t, int index)
		{
			bool flag = index >= this._Doc.InheritList.Count;
			if (!flag)
			{
				IXUILabelSymbol ixuilabelSymbol = t.FindChild("Name").GetComponent("XUILabelSymbol") as IXUILabelSymbol;
				IXUILabel ixuilabel = t.FindChild("Level").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel2 = t.FindChild("Position").GetComponent("XUILabel") as IXUILabel;
				IXUILabel ixuilabel3 = t.FindChild("LastLoginTime").GetComponent("XUILabel") as IXUILabel;
				IXUIButton ixuibutton = t.FindChild("BtnReceive").GetComponent("XUIButton") as IXUIButton;
				GuildInheritInfo guildInheritInfo = this._Doc.InheritList[index];
				ixuibutton.ID = (ulong)((long)index);
				ixuibutton.RegisterClickEventHandler(new ButtonClickEventHandler(this.OnClickReceive));
				ixuilabel.SetText(guildInheritInfo.GetLevelString());
				ixuilabel2.SetText(guildInheritInfo.GetSceneName());
				ixuilabel3.SetText(guildInheritInfo.GetTimeString());
				ixuilabelSymbol.InputText = guildInheritInfo.name;
			}
		}

		// Token: 0x0600F72F RID: 63279 RVA: 0x003833D0 File Offset: 0x003815D0
		private bool OnClickReceive(IXUIButton btn)
		{
			bool flag = btn.ID >= 0UL;
			if (flag)
			{
				this._Doc.SendAccpetInherit((int)btn.ID);
			}
			return true;
		}

		// Token: 0x04006B7A RID: 27514
		private XGuildInheritDocument _Doc;
	}
}
