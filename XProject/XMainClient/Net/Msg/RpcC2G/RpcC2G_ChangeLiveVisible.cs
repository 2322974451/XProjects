using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ChangeLiveVisible : Rpc
	{

		public override uint GetRpcType()
		{
			return 56831U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeLiveVisibleArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeLiveVisibleRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ChangeLiveVisible.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ChangeLiveVisible.OnTimeout(this.oArg);
		}

		public ChangeLiveVisibleArg oArg = new ChangeLiveVisibleArg();

		public ChangeLiveVisibleRes oRes = null;
	}
}
