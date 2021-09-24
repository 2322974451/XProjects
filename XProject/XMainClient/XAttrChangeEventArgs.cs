using System;

namespace XMainClient
{

	internal class XAttrChangeEventArgs : XEventArgs
	{

		public XAttrChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_AttributeChange;
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.DeltaValue = 0.0;
			this.bShowHUD = false;
			this.CasterID = 0UL;
		}

		public override void Recycle()
		{
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.DeltaValue = 0.0;
			this.bShowHUD = false;
			this.CasterID = 0UL;
			base.Recycle();
			XEventPool<XAttrChangeEventArgs>.Recycle(this);
		}

		public XAttributeDefine AttrKey { get; set; }

		public double DeltaValue { get; set; }

		public ulong CasterID { get; set; }

		public bool bShowHUD { get; set; }
	}
}
