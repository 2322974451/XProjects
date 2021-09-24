using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_DragonGuildBindGroupReq : Rpc
	{

		public override uint GetRpcType()
		{
			return 34774U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildBindReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildBindRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DragonGuildBindGroupReq.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DragonGuildBindGroupReq.OnTimeout(this.oArg);
		}

		public DragonGuildBindReq oArg = new DragonGuildBindReq();

		public DragonGuildBindRes oRes = null;
	}
}
