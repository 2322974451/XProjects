using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_DragonGuildUnBindGroup : Rpc
	{

		public override uint GetRpcType()
		{
			return 56553U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGuildUnBindGroupArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGuildUnBindGroupRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_DragonGuildUnBindGroup.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_DragonGuildUnBindGroup.OnTimeout(this.oArg);
		}

		public DragonGuildUnBindGroupArg oArg = new DragonGuildUnBindGroupArg();

		public DragonGuildUnBindGroupRes oRes = null;
	}
}
