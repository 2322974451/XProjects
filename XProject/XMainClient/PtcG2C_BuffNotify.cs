using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_BuffNotify : Protocol
	{

		public override uint GetProtoType()
		{
			return 18520U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<buffInfo>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<buffInfo>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_BuffNotify.Process(this);
		}

		public buffInfo Data = new buffInfo();
	}
}
