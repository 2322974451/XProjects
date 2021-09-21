using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000085 RID: 133
	public interface IXNormalItemDrawer : IXInterface
	{
		// Token: 0x0600047C RID: 1148
		void DrawItem(GameObject go, int itemID, int count, bool showCount);
	}
}
