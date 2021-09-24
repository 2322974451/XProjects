using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2G_CloseHintNtf : Protocol
	{

		public override uint GetProtoType()
		{
			return 37802U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CloseHintNtf>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CloseHintNtf>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public CloseHintNtf Data = new CloseHintNtf();
	}
}
