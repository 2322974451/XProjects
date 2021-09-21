using System;
using UnityEngine;

namespace XMainClient.UI
{
	// Token: 0x020016E3 RID: 5859
	internal interface IGVGBattleMember
	{
		// Token: 0x0600F1D6 RID: 61910
		void Setup(GameObject sv, int index);

		// Token: 0x0600F1D7 RID: 61911
		void ReFreshData(GVGBattleInfo battleInfo);

		// Token: 0x0600F1D8 RID: 61912
		void SetActive(bool active);

		// Token: 0x0600F1D9 RID: 61913
		bool IsActive();

		// Token: 0x0600F1DA RID: 61914
		void OnUpdate();

		// Token: 0x0600F1DB RID: 61915
		void Recycle();
	}
}
