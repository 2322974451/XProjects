using System;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XCharacterDocument : XDocComponent
	{

		public override uint ID
		{
			get
			{
				return XCharacterDocument.uuID;
			}
		}

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

		protected override void EventSubscribe()
		{
			base.EventSubscribe();
			base.RegisterEvent(XEventDefine.XEvent_AttributeChange, new XComponent.XEventHandler(this.OnAttributeChange));
		}

		public static uint GetCharacterPPT()
		{
			return (uint)XSingleton<XAttributeMgr>.singleton.XPlayerData.GetAttr(XAttributeDefine.XAttr_POWER_POINT_Basic);
		}

		public static XAttributes GetCharacterAttr()
		{
			return XSingleton<XAttributeMgr>.singleton.XPlayerData;
		}

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

		protected override void OnReconnected(XReconnectedEventArgs arg)
		{
			bool flag = this.InfoView != null && this.InfoView.IsVisible();
			if (flag)
			{
				this._info_view.SetPowerpoint(true, XCharacterDocument.GetCharacterPPT());
			}
		}

		public new static readonly uint uuID = XSingleton<XCommon>.singleton.XHash("CharacterDocument");

		private XCharacterInfoView _info_view = null;
	}
}
