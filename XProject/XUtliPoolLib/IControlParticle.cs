using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000079 RID: 121
	public interface IControlParticle
	{
		// Token: 0x06000420 RID: 1056
		void RefreshRenderQueue(bool resetWidget);

		// Token: 0x06000421 RID: 1057
		void SetWidget(GameObject go);
	}
}
