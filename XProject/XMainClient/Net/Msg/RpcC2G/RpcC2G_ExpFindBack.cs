using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ExpFindBack : Rpc
	{

		public override uint GetRpcType()
		{
			return 38008U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ExpFindBackArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ExpFindBackRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ExpFindBack.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ExpFindBack.OnTimeout(this.oArg);
		}

		public ExpFindBackArg oArg = new ExpFindBackArg();

		public ExpFindBackRes oRes = new ExpFindBackRes();
	}
}
