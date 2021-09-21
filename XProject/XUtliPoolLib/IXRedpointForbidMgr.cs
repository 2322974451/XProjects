using System;

namespace XUtliPoolLib
{
	// Token: 0x0200008D RID: 141
	internal interface IXRedpointForbidMgr
	{
		// Token: 0x060004A2 RID: 1186
		void AddForbid(int sys, bool bImmUpdateUI = true);

		// Token: 0x060004A3 RID: 1187
		void AddForbids(int[] systems, bool bImmUpdateUI = true);

		// Token: 0x060004A4 RID: 1188
		void RemoveForbid(int sys, bool bImmUpdateUI = true);

		// Token: 0x060004A5 RID: 1189
		void RemoveForbids(int[] systems, bool bImmUpdateUI = true);

		// Token: 0x060004A6 RID: 1190
		void ClearForbids(bool bImmUpdateUI = true);
	}
}
