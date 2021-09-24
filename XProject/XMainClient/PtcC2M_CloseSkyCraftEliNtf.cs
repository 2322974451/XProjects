using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_CloseSkyCraftEliNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 46239U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CloseSkyCraftEliNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CloseSkyCraftEliNtf>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public CloseSkyCraftEliNtf Data = new CloseSkyCraftEliNtf();
	}
}
