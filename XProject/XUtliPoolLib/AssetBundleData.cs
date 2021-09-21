using System;

namespace XUtliPoolLib
{
	// Token: 0x02000046 RID: 70
	public class AssetBundleData
	{
		// Token: 0x0400020D RID: 525
		public uint fullName;

		// Token: 0x0400020E RID: 526
		public string debugName;

		// Token: 0x0400020F RID: 527
		public AssetBundleExportType compositeType;

		// Token: 0x04000210 RID: 528
		public uint[] dependencies;

		// Token: 0x04000211 RID: 529
		public bool isAnalyzed;

		// Token: 0x04000212 RID: 530
		public AssetBundleData[] dependList;
	}
}
