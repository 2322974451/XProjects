using System;

namespace XMainClient
{
	// Token: 0x02000F74 RID: 3956
	internal class XAttackShowArgs : XEventArgs
	{
		// Token: 0x0600D082 RID: 53378 RVA: 0x003048B3 File Offset: 0x00302AB3
		public XAttackShowArgs()
		{
			this._eDefine = XEventDefine.XEvent_AttackShow;
		}

		// Token: 0x0600D083 RID: 53379 RVA: 0x003048C5 File Offset: 0x00302AC5
		public override void Recycle()
		{
			base.Recycle();
			this.name = null;
			XEventPool<XAttackShowArgs>.Recycle(this);
		}

		// Token: 0x04005E4A RID: 24138
		public string name;
	}
}
