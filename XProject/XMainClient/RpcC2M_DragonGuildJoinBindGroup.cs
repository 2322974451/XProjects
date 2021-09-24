using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_DragonGuildJoinBindGroup : Rpc
	{

		public override uint GetRpcType()
		{
			return 33949U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildJoinBindGroupArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildJoinBindGroupRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DragonGuildJoinBindGroup.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DragonGuildJoinBindGroup.OnTimeout(this.oArg);
		}

		public DragonGuildJoinBindGroupArg oArg = new DragonGuildJoinBindGroupArg();

		public DragonGuildJoinBindGroupRes oRes = null;
	}
}
