using System;

namespace XMainClient
{

	internal class XEntityAttrChangeEventArgs : XEventArgs
	{

		public XEntityAttrChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_EntityAttributeChange;
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.Value = 0.0;
			this.Delta = 0.0;
			this.CasterID = 0UL;
			this.Entity = null;
		}

		public override void Recycle()
		{
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.Value = 0.0;
			this.Delta = 0.0;
			this.CasterID = 0UL;
			this.Entity = null;
			base.Recycle();
			XEventPool<XEntityAttrChangeEventArgs>.Recycle(this);
		}

		public XAttributeDefine AttrKey { get; set; }

		public double Value { get; set; }

		public double Delta { get; set; }

		public ulong CasterID { get; set; }

		public XEntity Entity { get; set; }
	}
}
