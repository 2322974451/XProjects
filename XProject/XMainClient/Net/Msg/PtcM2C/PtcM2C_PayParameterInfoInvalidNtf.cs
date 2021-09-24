using System;
using System.IO;

namespace XMainClient
{

	internal class PtcM2C_PayParameterInfoInvalidNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 64504U;
		}

		public override void Serialize(MemoryStream stream)
		{
		}

		public override void DeSerialize(MemoryStream stream)
		{
		}

		public override void Process()
		{
			Process_PtcM2C_PayParameterInfoInvalidNtf.Process(this);
		}
	}
}
