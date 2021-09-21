using System;

namespace XUtliPoolLib
{
	// Token: 0x02000069 RID: 105
	public interface ILuaUIManager
	{
		// Token: 0x06000355 RID: 853
		bool IsUIShowed();

		// Token: 0x06000356 RID: 854
		bool Load(string name);

		// Token: 0x06000357 RID: 855
		bool Hide(string name);

		// Token: 0x06000358 RID: 856
		bool Destroy(string name);

		// Token: 0x06000359 RID: 857
		void Clear();
	}
}
