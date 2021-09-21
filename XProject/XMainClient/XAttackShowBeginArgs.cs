using System;
using UnityEngine;

namespace XMainClient
{
	// Token: 0x02000F75 RID: 3957
	internal class XAttackShowBeginArgs : XEventArgs
	{
		// Token: 0x0600D084 RID: 53380 RVA: 0x003048DD File Offset: 0x00302ADD
		public XAttackShowBeginArgs()
		{
			this._eDefine = XEventDefine.XEvent_AttackShowBegin;
		}

		// Token: 0x0600D085 RID: 53381 RVA: 0x003048F6 File Offset: 0x00302AF6
		public override void Recycle()
		{
			base.Recycle();
			this.XCamera = null;
			XEventPool<XAttackShowBeginArgs>.Recycle(this);
		}

		// Token: 0x04005E4B RID: 24139
		public GameObject XCamera = null;
	}
}
