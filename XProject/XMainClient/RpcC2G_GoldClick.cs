using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_GoldClick : Rpc
	{

		public override uint GetRpcType()
		{
			return 12917U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GoldClickArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GoldClickRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_GoldClick.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_GoldClick.OnTimeout(this.oArg);
		}

		public GoldClickArg oArg = new GoldClickArg();

		public GoldClickRes oRes = null;
	}
}
