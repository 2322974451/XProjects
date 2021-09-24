using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DragonGroupRoleList : Rpc
	{

		public override uint GetRpcType()
		{
			return 29660U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGroupRoleListC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGroupRoleListS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DragonGroupRoleList.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DragonGroupRoleList.OnTimeout(this.oArg);
		}

		public DragonGroupRoleListC2S oArg = new DragonGroupRoleListC2S();

		public DragonGroupRoleListS2C oRes = null;
	}
}
