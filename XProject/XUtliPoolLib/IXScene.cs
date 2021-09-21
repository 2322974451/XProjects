using System;

namespace XUtliPoolLib
{
	// Token: 0x02000091 RID: 145
	public interface IXScene
	{
		// Token: 0x060004B3 RID: 1203
		bool XSceneLoadScene(string scenename, Action<float> progress);

		// Token: 0x060004B4 RID: 1204
		bool XSceneIsDone();

		// Token: 0x060004B5 RID: 1205
		bool XSceneEnable(string scenename);
	}
}
