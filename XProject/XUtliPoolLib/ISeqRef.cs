using System;

namespace XUtliPoolLib
{

	public interface ISeqRef
	{

		void Read(XBinaryReader stream, DataHandler dh);
	}
}
