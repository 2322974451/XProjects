using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_ClientOnlyBuffNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 35149U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuffList>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<BuffList>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_ClientOnlyBuffNotify.Process(this);
		}

		public BuffList Data = new BuffList();
	}
}
