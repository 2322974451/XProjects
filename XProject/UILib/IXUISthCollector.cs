using System;
using System.Collections.Generic;
using UnityEngine;

namespace UILib
{
	// Token: 0x0200004D RID: 77
	public interface IXUISthCollector : IXUIObject
	{
		// Token: 0x0600020A RID: 522
		void SetPosition(Vector3 srcGlobalPos, Vector3 desGlobalPos);

		// Token: 0x0600020B RID: 523
		void SetSth(string name);

		// Token: 0x0600020C RID: 524
		void SetSth(List<GameObject> goes);

		// Token: 0x0600020D RID: 525
		void Emit();

		// Token: 0x0600020E RID: 526
		void RegisterSthArrivedEventHandler(SthArrivedEventHandler eventHandler);

		// Token: 0x0600020F RID: 527
		void RegisterCollectFinishEventHandler(CollectFinishEventHandler eventHandler);
	}
}
