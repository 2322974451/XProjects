using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_SkyCraftEliRoomNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 6761U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCraftEliRoomNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<SkyCraftEliRoomNtf>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_SkyCraftEliRoomNtf.Process(this);
		}

		public SkyCraftEliRoomNtf Data = new SkyCraftEliRoomNtf();
	}
}
