using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcG2C_PlayDiceNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 50453U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlayDiceNtfData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PlayDiceNtfData>(stream);
		}

		public override void Process()
		{
			Process_PtcG2C_PlayDiceNtf.Process(this);
		}

		public PlayDiceNtfData Data = new PlayDiceNtfData();
	}
}
