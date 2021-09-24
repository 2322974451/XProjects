using System;
using UILib;
using UnityEngine;
using XMainClient.UI.UICommon;

namespace XMainClient.UI
{

	internal class GuildInheritDlg : DlgBase<GuildInheritDlg, GuildInheritBehaviour>
	{

		public override string fileName
		{
			get
			{
				return "Guild/GuildInheritDlg";
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

		protected override void Init()
		{
			base.Init();
			this._Doc = XDocuments.GetSpecificDocument<XGuildInheritDocument>(XGuildInheritDocument.uuID);
			base.uiBehaviour.WrapContent.RegisterItemUpdateEventHandler(new WrapItemUpdateEventHandler(this.OnItemUpdateHandler));
		}

		public override void RegisterEvent()
		{
			base.RegisterEvent();
			base.uiBehaviour.OverLook.RegisterClickEventHandler(new ButtonClickEventHandler(this.CloseClick));
			base.uiBehaviour.Close.RegisterClickEventHandler(new ButtonClickEventHandler(this.CloseClick));
			base.uiBehaviour.NotAccept.RegisterClickEventHandler(new ButtonClickEventHandler(this.OverLookClick));
		}

		protected override void OnShow()
		{
			base.OnShow();
			this._Doc.SendInheritList();
		}

		public void RefreshData()
		{
			base.uiBehaviour.WrapContent.SetContentCount(this._Doc.InheritList.Count, false);
			base.uiBehaviour.ScrollView.ResetPosition();
		}

		private bool OverLookClick(IXUIButton btn)
		{
			this._Doc.SendDelInherit();
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

		private bool CloseClick(IXUIButton btn)
		{
			this.SetVisibleWithAnimation(false, null);
			return false;
		}

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

		private bool OnClickReceive(IXUIButton btn)
		{
			bool flag = btn.ID >= 0UL;
			if (flag)
			{
				this._Doc.SendAccpetInherit((int)btn.ID);
			}
			return true;
		}

		private XGuildInheritDocument _Doc;
	}
}
