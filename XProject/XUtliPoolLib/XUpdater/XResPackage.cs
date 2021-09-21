using System;

namespace XUpdater
{
	// Token: 0x0200000B RID: 11
	[Serializable]
	public class XResPackage
	{
		// Token: 0x04000020 RID: 32
		public string location;

		// Token: 0x04000021 RID: 33
		public string type;

		// Token: 0x04000022 RID: 34
		public string bundle;

		// Token: 0x04000023 RID: 35
		public ResourceType rtype = ResourceType.Assets;
	}
}
