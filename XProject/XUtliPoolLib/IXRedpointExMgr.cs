using System;

namespace XUtliPoolLib
{
	// Token: 0x02000090 RID: 144
	internal interface IXRedpointExMgr : IXRedpointMgr, IXRedpointRelationMgr, IXRedpointForbidMgr
	{
		// Token: 0x060004B0 RID: 1200
		void SetCurrentLevel(uint level);

		// Token: 0x060004B1 RID: 1201
		void AddSysForbidLevels(int sys, uint level);

		// Token: 0x060004B2 RID: 1202
		void RemoveSysForbidLevels(int sys, uint level);
	}
}
