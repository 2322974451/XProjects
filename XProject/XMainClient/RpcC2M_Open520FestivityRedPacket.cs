using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_Open520FestivityRedPacket : Rpc
	{

		public override uint GetRpcType()
		{
			return 57488U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<Open520FestivityRedPacketArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<Open520FestivityRedPacketRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_Open520FestivityRedPacket.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_Open520FestivityRedPacket.OnTimeout(this.oArg);
		}

		public Open520FestivityRedPacketArg oArg = new Open520FestivityRedPacketArg();

		public Open520FestivityRedPacketRes oRes = null;
	}
}
