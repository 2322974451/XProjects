using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class PtcC2M_HandleMicphone : Protocol
	{

		public override uint GetProtoType()
		{
			return 50175U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<HandleMicphoneArg>(stream, this.Data);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<HandleMicphoneArg>(stream);
		}

		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		public HandleMicphoneArg Data = new HandleMicphoneArg();
	}
}
