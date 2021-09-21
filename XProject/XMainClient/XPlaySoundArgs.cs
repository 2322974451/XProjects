using System;
using UnityEngine;
using XUtliPoolLib;

namespace XMainClient
{
	// Token: 0x02000F72 RID: 3954
	internal class XPlaySoundArgs : XEventArgs
	{
		// Token: 0x0600D076 RID: 53366 RVA: 0x003047EB File Offset: 0x003029EB
		public XPlaySoundArgs()
		{
			this._eDefine = XEventDefine.XEvent_PlaySound;
			this.SoundChannel = AudioChannel.Motion;
		}

		// Token: 0x0600D077 RID: 53367 RVA: 0x00304810 File Offset: 0x00302A10
		public override void Recycle()
		{
			base.Recycle();
			this.SoundAction = XPlaySoundArgs.Action.Stop;
			this.SoundChannel = AudioChannel.Motion;
			this.EventName = null;
			this.Position = Vector3.zero;
			this.ExParam = null;
			XEventPool<XPlaySoundArgs>.Recycle(this);
		}

		// Token: 0x1700369B RID: 13979
		// (get) Token: 0x0600D078 RID: 53368 RVA: 0x0030484C File Offset: 0x00302A4C
		// (set) Token: 0x0600D079 RID: 53369 RVA: 0x00304854 File Offset: 0x00302A54
		public XPlaySoundArgs.Action SoundAction { get; set; }

		// Token: 0x1700369C RID: 13980
		// (get) Token: 0x0600D07A RID: 53370 RVA: 0x0030485D File Offset: 0x00302A5D
		// (set) Token: 0x0600D07B RID: 53371 RVA: 0x00304865 File Offset: 0x00302A65
		public AudioChannel SoundChannel { get; set; }

		// Token: 0x1700369D RID: 13981
		// (get) Token: 0x0600D07C RID: 53372 RVA: 0x0030486E File Offset: 0x00302A6E
		// (set) Token: 0x0600D07D RID: 53373 RVA: 0x00304876 File Offset: 0x00302A76
		public string EventName { get; set; }

		// Token: 0x1700369E RID: 13982
		// (get) Token: 0x0600D07E RID: 53374 RVA: 0x0030487F File Offset: 0x00302A7F
		// (set) Token: 0x0600D07F RID: 53375 RVA: 0x00304887 File Offset: 0x00302A87
		public XAudioExParam ExParam { get; set; }

		// Token: 0x04005E48 RID: 24136
		public Vector3 Position = Vector3.zero;

		// Token: 0x020019F5 RID: 6645
		public enum Action
		{
			// Token: 0x040080B9 RID: 32953
			Play,
			// Token: 0x040080BA RID: 32954
			Pause,
			// Token: 0x040080BB RID: 32955
			Stop
		}
	}
}
