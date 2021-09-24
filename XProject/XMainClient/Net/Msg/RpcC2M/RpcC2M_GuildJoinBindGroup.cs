using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildJoinBindGroup : Rpc
	{

		public override uint GetRpcType()
		{
			return 12928U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildJoinBindGroupReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildJoinBindGroupRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildJoinBindGroup.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildJoinBindGroup.OnTimeout(this.oArg);
		}

		public GuildJoinBindGroupReq oArg = new GuildJoinBindGroupReq();

		public GuildJoinBindGroupRes oRes = null;
	}
}
