using System;
using UnityEngine;

namespace UILib
{
	// Token: 0x02000015 RID: 21
	public interface IXUIDragDropItem : IXUIObject
	{
		// Token: 0x0600008D RID: 141
		void RegisterOnStartEventHandler(OnDropStartEventHandler eventHandler);

		// Token: 0x0600008E RID: 142
		void RegisterOnFinishEventHandler(OnDropReleaseEventHandler eventHandler);

		// Token: 0x0600008F RID: 143
		void SetCloneOnDrag(bool cloneOnDrag);

		// Token: 0x06000090 RID: 144
		void SetRestriction(int restriction);

		// Token: 0x06000091 RID: 145
		void SetParent(Transform parent, bool addPanel = false, int depth = 0);

		// Token: 0x06000092 RID: 146
		void SetActive(bool active);

		// Token: 0x06000093 RID: 147
		OnDropStartEventHandler GetStartEventHandler();

		// Token: 0x06000094 RID: 148
		OnDropReleaseEventHandler GetReleaseEventHandler();
	}
}
