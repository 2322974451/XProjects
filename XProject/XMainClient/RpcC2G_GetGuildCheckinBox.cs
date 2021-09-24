using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GetGuildCheckinBox : Rpc
	{

		public override uint GetRpcType()
		{
			return 19269U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetGuildCheckinBoxArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetGuildCheckinBoxRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GetGuildCheckinBox.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GetGuildCheckinBox.OnTimeout(this.oArg);
		}

		public GetGuildCheckinBoxArg oArg = new GetGuildCheckinBoxArg();

		public GetGuildCheckinBoxRes oRes = new GetGuildCheckinBoxRes();
	}
}
