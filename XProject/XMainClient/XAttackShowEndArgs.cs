using System;

namespace XMainClient
{
	// Token: 0x02000F76 RID: 3958
	internal class XAttackShowEndArgs : XEventArgs
	{
		// Token: 0x0600D086 RID: 53382 RVA: 0x0030490E File Offset: 0x00302B0E
		public XAttackShowEndArgs()
		{
			this._eDefine = XEventDefine.XEvent_AttackShowEnd;
		}

		// Token: 0x0600D087 RID: 53383 RVA: 0x00304927 File Offset: 0x00302B27
		public override void Recycle()
		{
			base.Recycle();
			this.ForceQuit = true;
			XEventPool<XAttackShowEndArgs>.Recycle(this);
		}

		// Token: 0x04005E4C RID: 24140
		public bool ForceQuit = true;
	}
}
