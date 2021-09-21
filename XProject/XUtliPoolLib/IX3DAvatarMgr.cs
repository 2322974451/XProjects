using System;
using UILib;

namespace XUtliPoolLib
{
	// Token: 0x0200007C RID: 124
	public interface IX3DAvatarMgr : IXInterface
	{
		// Token: 0x0600042E RID: 1070
		int AllocDummyPool(string user, int maxCount);

		// Token: 0x0600042F RID: 1071
		void ReturnDummyPool(int index);

		// Token: 0x06000430 RID: 1072
		void EnableMainDummy(bool enable, IUIDummy snapShot);

		// Token: 0x06000431 RID: 1073
		void OnUIUnloadMainDummy(IUIDummy snapShot);

		// Token: 0x06000432 RID: 1074
		void SetMainDummy(bool ui);

		// Token: 0x06000433 RID: 1075
		void Clean(bool transfer);

		// Token: 0x06000434 RID: 1076
		void RotateMain(float degree);

		// Token: 0x06000435 RID: 1077
		void ResetMainAnimation();

		// Token: 0x06000436 RID: 1078
		string CreateCommonDummy(int dummyPool, uint presentID, IUIDummy snapShot, IXDummy orig, float scale);

		// Token: 0x06000437 RID: 1079
		void DestroyDummy(int dummyPool, string idStr);

		// Token: 0x06000438 RID: 1080
		void SetDummyAnim(int dummyPool, string idStr, string anim);

		// Token: 0x06000439 RID: 1081
		void SetMainDummyAnim(string anim);
	}
}
