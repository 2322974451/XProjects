using System;

namespace XUtliPoolLib
{
	// Token: 0x0200006C RID: 108
	public interface INativePlugin
	{
		// Token: 0x0600038C RID: 908
		void InitializeHooks();

		// Token: 0x0600038D RID: 909
		void CloseHooks();

		// Token: 0x0600038E RID: 910
		void Init();

		// Token: 0x0600038F RID: 911
		void Update();

		// Token: 0x06000390 RID: 912
		void InputData(short tableID, short tableType, byte[] buffer, int length);
	}
}
