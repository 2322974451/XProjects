using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GetDragonGuildBindInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 39788U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GetDragonGuildBindInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GetDragonGuildBindInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GetDragonGuildBindInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GetDragonGuildBindInfo.OnTimeout(this.oArg);
		}

		public GetDragonGuildBindInfoArg oArg = new GetDragonGuildBindInfoArg();

		public GetDragonGuildBindInfoRes oRes = null;
	}
}
