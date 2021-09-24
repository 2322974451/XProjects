using System;

namespace XMainClient
{

	internal class XBuffChangeEventArgs : XEventArgs
	{

		public XBuffChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffChange;
			this.addBuff = null;
			this.removeBuff = null;
			this.updateBuff = null;
			this.entity = null;
		}

		public override void Recycle()
		{
			base.Recycle();
			this.addBuff = null;
			this.removeBuff = null;
			this.updateBuff = null;
			this.entity = null;
			XEventPool<XBuffChangeEventArgs>.Recycle(this);
		}

		public UIBuffInfo GetActive()
		{
			bool flag = this.addBuff != null;
			UIBuffInfo result;
			if (flag)
			{
				result = this.addBuff;
			}
			else
			{
				bool flag2 = this.removeBuff != null;
				if (flag2)
				{
					result = this.removeBuff;
				}
				else
				{
					bool flag3 = this.updateBuff != null;
					if (flag3)
					{
						result = this.updateBuff;
					}
					else
					{
						result = null;
					}
				}
			}
			return result;
		}

		public UIBuffInfo addBuff;

		public UIBuffInfo removeBuff;

		public UIBuffInfo updateBuff;

		public XEntity entity;
	}
}
