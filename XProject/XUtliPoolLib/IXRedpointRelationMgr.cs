using System;

namespace XUtliPoolLib
{
	// Token: 0x0200008C RID: 140
	internal interface IXRedpointRelationMgr
	{
		// Token: 0x0600049C RID: 1180
		void AddRelation(int child, int parent, bool bImmUpdateUI = false);

		// Token: 0x0600049D RID: 1181
		void AddRelations(int child, int[] parents, bool bImmUpdateUI = false);

		// Token: 0x0600049E RID: 1182
		void RemoveRelation(int child, int parent, bool bImmUpdateUI = false);

		// Token: 0x0600049F RID: 1183
		void RemoveRelations(int child, int[] parents, bool bImmUpdateUI = false);

		// Token: 0x060004A0 RID: 1184
		void RemoveAllRelations(int child, bool bImmUpdateUI = false);

		// Token: 0x060004A1 RID: 1185
		void ClearAllRelations(bool bImmUpdateUI = false);
	}
}
