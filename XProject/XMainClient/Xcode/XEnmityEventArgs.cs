using System;

namespace XMainClient
{

	internal class XEnmityEventArgs : XEventArgs
	{

		public XObject Starter
		{
			get
			{
				return this._starter;
			}
			set
			{
				this._starter = value;
			}
		}

		public XEnmityEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Enmity;
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
		}

		public override void Recycle()
		{
			this.AttrKey = XAttributeDefine.XAttr_Invalid;
			this.DeltaValue = 0.0;
			this._starter = null;
			base.Recycle();
			XEventPool<XEnmityEventArgs>.Recycle(this);
		}

		public XAttributeDefine AttrKey { get; set; }

		public double DeltaValue { get; set; }

		public uint SkillId { get; set; }

		protected XObject _starter = null;
	}
}
