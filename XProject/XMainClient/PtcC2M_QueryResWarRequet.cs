using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_QueryResWarRequet : Protocol
	{

		public override uint GetProtoType()
		{
			return 53580U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<QueryResWarArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<QueryResWarArg>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public QueryResWarArg Data = new QueryResWarArg();
	}
}
