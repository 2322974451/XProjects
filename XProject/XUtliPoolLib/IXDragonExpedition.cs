using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x0200007A RID: 122
	public interface IXDragonExpedition
	{
		// Token: 0x06000422 RID: 1058
		void Drag(float delta);

		// Token: 0x06000423 RID: 1059
		void Assign(float delta);

		// Token: 0x06000424 RID: 1060
		GameObject Click();

		// Token: 0x06000425 RID: 1061
		Transform GetGO(string name);

		// Token: 0x06000426 RID: 1062
		void SetLimitPos(float MinPos);

		// Token: 0x06000427 RID: 1063
		Camera GetDragonCamera();
	}
}
