using System;

namespace XUtliPoolLib
{

	public interface ISeqListRef
	{

		void SetData(DataHandler dh, byte c, byte mask, ushort offset);
	}
}
