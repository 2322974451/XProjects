using System;

namespace XUtliPoolLib
{

	public interface IXDummy
	{

		void ResetAnimation();

		uint TypeID { get; }

		ulong ID { get; }

		void SetupUIDummy(bool ui);

		bool Deprecated { get; set; }
	}
}
