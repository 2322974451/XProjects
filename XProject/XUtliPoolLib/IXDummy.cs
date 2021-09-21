using System;

namespace XUtliPoolLib
{
	// Token: 0x0200007B RID: 123
	public interface IXDummy
	{
		// Token: 0x06000428 RID: 1064
		void ResetAnimation();

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000429 RID: 1065
		uint TypeID { get; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600042A RID: 1066
		ulong ID { get; }

		// Token: 0x0600042B RID: 1067
		void SetupUIDummy(bool ui);

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600042C RID: 1068
		// (set) Token: 0x0600042D RID: 1069
		bool Deprecated { get; set; }
	}
}
