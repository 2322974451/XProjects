using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildBindGroup : Rpc
	{

		public override uint GetRpcType()
		{
			return 16003U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildBindGroupReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildBindGroupRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildBindGroup.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildBindGroup.OnTimeout(this.oArg);
		}

		public GuildBindGroupReq oArg = new GuildBindGroupReq();

		public GuildBindGroupRes oRes = null;
	}
}
