using System;

namespace XMainClient
{
	// Token: 0x02000F6C RID: 3948
	internal class XHUDAddEventArgs : XEventArgs
	{
		// Token: 0x0600D05C RID: 53340 RVA: 0x00304628 File Offset: 0x00302828
		public XHUDAddEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_HUDAdd;
			this.caster = null;
		}

		// Token: 0x0600D05D RID: 53341 RVA: 0x00304642 File Offset: 0x00302842
		public override void Recycle()
		{
			this.damageResult = null;
			this.caster = null;
			base.Recycle();
			XEventPool<XHUDAddEventArgs>.Recycle(this);
		}

		// Token: 0x17003694 RID: 13972
		// (get) Token: 0x0600D05E RID: 53342 RVA: 0x00304663 File Offset: 0x00302863
		// (set) Token: 0x0600D05F RID: 53343 RVA: 0x0030466B File Offset: 0x0030286B
		public ProjectDamageResult damageResult { get; set; }

		// Token: 0x17003695 RID: 13973
		// (get) Token: 0x0600D060 RID: 53344 RVA: 0x00304674 File Offset: 0x00302874
		// (set) Token: 0x0600D061 RID: 53345 RVA: 0x0030467C File Offset: 0x0030287C
		public XEntity caster { get; set; }
	}
}
