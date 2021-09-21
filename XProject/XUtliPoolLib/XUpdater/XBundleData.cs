using System;

namespace XUpdater
{
	// Token: 0x0200000A RID: 10
	[Serializable]
	public class XBundleData
	{
		// Token: 0x0400001C RID: 28
		public string Name;

		// Token: 0x0400001D RID: 29
		public string MD5;

		// Token: 0x0400001E RID: 30
		public uint Size;

		// Token: 0x0400001F RID: 31
		public AssetLevel Level = AssetLevel.Memory;
	}
}
