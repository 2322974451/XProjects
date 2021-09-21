using System;
using UnityEngine;

namespace XUtliPoolLib
{
	// Token: 0x02000084 RID: 132
	public interface IXNGUICallback
	{
		// Token: 0x0600047A RID: 1146
		void RegisterClickEventHandler(IXNGUIClickEventHandler handler);

		// Token: 0x0600047B RID: 1147
		GameObject SetXUILable(string name, string content);
	}
}
