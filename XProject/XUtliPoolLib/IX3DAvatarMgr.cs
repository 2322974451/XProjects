using System;
using UILib;

namespace XUtliPoolLib
{

	public interface IX3DAvatarMgr : IXInterface
	{

		int AllocDummyPool(string user, int maxCount);

		void ReturnDummyPool(int index);

		void EnableMainDummy(bool enable, IUIDummy snapShot);

		void OnUIUnloadMainDummy(IUIDummy snapShot);

		void SetMainDummy(bool ui);

		void Clean(bool transfer);

		void RotateMain(float degree);

		void ResetMainAnimation();

		string CreateCommonDummy(int dummyPool, uint presentID, IUIDummy snapShot, IXDummy orig, float scale);

		void DestroyDummy(int dummyPool, string idStr);

		void SetDummyAnim(int dummyPool, string idStr, string anim);

		void SetMainDummyAnim(string anim);
	}
}
