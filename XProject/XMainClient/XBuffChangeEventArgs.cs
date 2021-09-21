using System;

namespace XMainClient
{
	// Token: 0x02000F66 RID: 3942
	internal class XBuffChangeEventArgs : XEventArgs
	{
		// Token: 0x0600D03B RID: 53307 RVA: 0x003042ED File Offset: 0x003024ED
		public XBuffChangeEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_BuffChange;
			this.addBuff = null;
			this.removeBuff = null;
			this.updateBuff = null;
			this.entity = null;
		}

		// Token: 0x0600D03C RID: 53308 RVA: 0x0030431E File Offset: 0x0030251E
		public override void Recycle()
		{
			base.Recycle();
			this.addBuff = null;
			this.removeBuff = null;
			this.updateBuff = null;
			this.entity = null;
			XEventPool<XBuffChangeEventArgs>.Recycle(this);
		}

		// Token: 0x0600D03D RID: 53309 RVA: 0x0030434C File Offset: 0x0030254C
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

		// Token: 0x04005E28 RID: 24104
		public UIBuffInfo addBuff;

		// Token: 0x04005E29 RID: 24105
		public UIBuffInfo removeBuff;

		// Token: 0x04005E2A RID: 24106
		public UIBuffInfo updateBuff;

		// Token: 0x04005E2B RID: 24107
		public XEntity entity;
	}
}
