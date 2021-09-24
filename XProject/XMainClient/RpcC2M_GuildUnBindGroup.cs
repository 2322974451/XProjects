using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_GuildUnBindGroup : Rpc
	{

		public override uint GetRpcType()
		{
			return 28516U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildUnBindGroupReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildUnBindGroupRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildUnBindGroup.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildUnBindGroup.OnTimeout(this.oArg);
		}

		public GuildUnBindGroupReq oArg = new GuildUnBindGroupReq();

		public GuildUnBindGroupRes oRes = null;
	}
}
