using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PvpAllReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 57262U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PvpArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PvpRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PvpAllReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PvpAllReq.OnTimeout(this.oArg);
		}

		public PvpArg oArg = new PvpArg();

		public PvpRes oRes = new PvpRes();
	}
}
