using System;

namespace ProtoBuf.Meta
{
	// Token: 0x02000889 RID: 2185
	public sealed class LockContentedEventArgs : EventArgs
	{
		// Token: 0x0600853B RID: 34107 RVA: 0x0010823E File Offset: 0x0010643E
		internal LockContentedEventArgs(string ownerStackTrace)
		{
			this.ownerStackTrace = ownerStackTrace;
		}

		// Token: 0x17002A10 RID: 10768
		// (get) Token: 0x0600853C RID: 34108 RVA: 0x00108250 File Offset: 0x00106450
		public string OwnerStackTrace
		{
			get
			{
				return this.ownerStackTrace;
			}
		}

		// Token: 0x0400295E RID: 10590
		private readonly string ownerStackTrace;
	}
}
