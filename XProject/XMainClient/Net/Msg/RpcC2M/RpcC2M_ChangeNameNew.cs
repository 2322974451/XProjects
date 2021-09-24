using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ChangeNameNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 46227U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeNameArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ChangeNameRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ChangeNameNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ChangeNameNew.OnTimeout(this.oArg);
		}

		public ChangeNameArg oArg = new ChangeNameArg();

		public ChangeNameRes oRes = null;
	}
}
