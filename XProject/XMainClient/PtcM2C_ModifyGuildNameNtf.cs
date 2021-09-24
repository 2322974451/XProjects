using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcM2C_ModifyGuildNameNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 18518U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ModifyArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ModifyArg>(stream);
		}

		public override void Process()
		{
			Process_PtcM2C_ModifyGuildNameNtf.Process(this);
		}

		public ModifyArg Data = new ModifyArg();
	}
}
