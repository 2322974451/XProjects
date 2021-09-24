using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_SkyCraftMatchReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 26016U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SkyCraftMatchReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SkyCraftMatchRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_SkyCraftMatchReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_SkyCraftMatchReq.OnTimeout(this.oArg);
		}

		public SkyCraftMatchReq oArg = new SkyCraftMatchReq();

		public SkyCraftMatchRes oRes = null;
	}
}
