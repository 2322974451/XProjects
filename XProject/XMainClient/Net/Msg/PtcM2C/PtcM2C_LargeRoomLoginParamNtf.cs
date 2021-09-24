using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_LargeRoomLoginParamNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 51856U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LargeRoomLoginParam>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LargeRoomLoginParam>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_LargeRoomLoginParamNtf.Process(this);
		}

		public LargeRoomLoginParam Data = new LargeRoomLoginParam();
	}
}
