using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_PlayDiceOver : Protocol
	{

		public override uint GetProtoType()
		{
			return 2064U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PlayDiceOverData>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<PlayDiceOverData>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public PlayDiceOverData Data = new PlayDiceOverData();
	}
}
