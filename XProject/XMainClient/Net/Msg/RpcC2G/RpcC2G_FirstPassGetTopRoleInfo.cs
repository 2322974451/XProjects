using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_FirstPassGetTopRoleInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 37076U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FirstPassGetTopRoleInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FirstPassGetTopRoleInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FirstPassGetTopRoleInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FirstPassGetTopRoleInfo.OnTimeout(this.oArg);
		}

		public FirstPassGetTopRoleInfoArg oArg = new FirstPassGetTopRoleInfoArg();

		public FirstPassGetTopRoleInfoRes oRes = new FirstPassGetTopRoleInfoRes();
	}
}
