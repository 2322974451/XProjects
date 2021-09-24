using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_UpdateGuildArenaState : Protocol
	{

		public override uint GetProtoType()
		{
			return 21909U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<UpdateGuildArenaState>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<UpdateGuildArenaState>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_UpdateGuildArenaState.Process(this);
		}

		public UpdateGuildArenaState Data = new UpdateGuildArenaState();
	}
}
