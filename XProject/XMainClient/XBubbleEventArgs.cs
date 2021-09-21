using System;

namespace XMainClient
{
	// Token: 0x02000F6D RID: 3949
	internal class XBubbleEventArgs : XEventArgs
	{
		// Token: 0x0600D062 RID: 53346 RVA: 0x00304685 File Offset: 0x00302885
		public XBubbleEventArgs()
		{
			this._eDefine = XEventDefine.XEvent_Bubble;
		}

		// Token: 0x0600D063 RID: 53347 RVA: 0x00304697 File Offset: 0x00302897
		public override void Recycle()
		{
			this.bubbletext = null;
			this.existtime = 0f;
			base.Recycle();
			XEventPool<XBubbleEventArgs>.Recycle(this);
		}

		// Token: 0x17003696 RID: 13974
		// (get) Token: 0x0600D064 RID: 53348 RVA: 0x003046BC File Offset: 0x003028BC
		// (set) Token: 0x0600D065 RID: 53349 RVA: 0x003046C4 File Offset: 0x003028C4
		public string bubbletext { get; set; }

		// Token: 0x17003697 RID: 13975
		// (get) Token: 0x0600D066 RID: 53350 RVA: 0x003046CD File Offset: 0x003028CD
		// (set) Token: 0x0600D067 RID: 53351 RVA: 0x003046D5 File Offset: 0x003028D5
		public float existtime { get; set; }

		// Token: 0x17003698 RID: 13976
		// (get) Token: 0x0600D068 RID: 53352 RVA: 0x003046DE File Offset: 0x003028DE
		// (set) Token: 0x0600D069 RID: 53353 RVA: 0x003046E6 File Offset: 0x003028E6
		public string speaker { get; set; }
	}
}
