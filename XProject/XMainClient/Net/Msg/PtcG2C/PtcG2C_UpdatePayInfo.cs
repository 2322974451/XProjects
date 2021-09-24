using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_UpdatePayInfo : Protocol
	{

		public override uint GetProtoType()
		{
			return 22775U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PayInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PayInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_UpdatePayInfo.Process(this);
		}

		public PayInfo Data = new PayInfo();
	}
}
