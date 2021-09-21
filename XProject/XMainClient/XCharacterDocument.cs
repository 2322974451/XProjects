using System;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x020009CA RID: 2506
	internal class XCharacterDocument : XDocComponent
	{
		// Token: 0x17002D9E RID: 11678
		// (get) Token: 0x060097E9 RID: 38889 RVA: 0x00174DB0 File Offset: 0x00172FB0
		public override uint ID
		{
			get
			{
				return XCharacterDocument.uuID;
			}
		}

		// Token: 0x17002D9F RID: 11679
		// (get) Token: 0x060097EA RID: 38890 RVA: 0x00174DC8 File Offset: 0x00172FC8
		// (set) Token: 0x060097EB RID: 38891 RVA: 0x00174DE0 File Offset: 0x00172FE0
		public XCharacterInfoView InfoView
		{
			get
			{
				return this._info_view;
			}
			set
			{
				this._info_view = value;
			}
		}

		// Token: 0x060097EC RID: 38892 RVA: 0x00174DEA File Offset: 0x00172FEA
		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
		}

		// Token: 0x060097ED RID: 38893 RVA: 0x00174E0C File Offset: 0x0017300C
		public static uint GetCharacterPPT()
		{
			return (uint)XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
		}

		// Token: 0x060097EE RID: 38894 RVA: 0x00174E34 File Offset: 0x00173034
		public static XAttributes GetCharacterAttr()
		{
			return XSingleton<XAttributeMgr>.singleton.XPlayerData;
		}

		// Token: 0x060097EF RID: 38895 RVA: 0x00174E50 File Offset: 0x00173050
		protected bool OnAttributeChange(XEventArgs e)
		{
			bool flag = this._info_view != null && this._info_view.active;
			if (flag)
			{
				XAttrChangeEventArgs xattrChangeEventArgs = e as XAttrChangeEventArgs;
				XAttributeDefine attrKey = xattrChangeEventArgs.AttrKey;
				if (attrKey == XAttributeDefine.XAttr_POWER_POINT_Basic)
				{
					this._info_view.SetPowerpoint(true, (uint)xattrChangeEventArgs.DeltaValue);
				}
			}
			return true;
		}

		// Token: 0x060097F0 RID: 38896 RVA: 0x00174EB0 File Offset: 0x001730B0
		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.InfoView != null && this.InfoView.IsVisible();
			if (flag)
			{
				this._info_view.SetPowerpoint(true, XCharacterDocument.GetCharacterPPT());
			}
		}

		// Token: 0x0400340B RID: 13323
		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CharacterDocument");

		// Token: 0x0400340C RID: 13324
		private XCharacterInfoView _info_view = null;
	}
}
