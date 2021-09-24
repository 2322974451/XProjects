using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ActiveCookbook : Rpc
	{

		public override uint GetRpcType()
		{
			return 31076U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActiveCookbookArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActiveCookbookRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ActiveCookbook.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ActiveCookbook.OnTimeout(this.oArg);
		}

		public ActiveCookbookArg oArg = new ActiveCookbookArg();

		public ActiveCookbookRes oRes = null;
	}
}
