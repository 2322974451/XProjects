using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_QueryIBItem : Rpc
	{

		public override uint GetRpcType()
		{
			return 23880U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<IBQueryItemReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<IBQueryItemRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_QueryIBItem.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_QueryIBItem.OnTimeout(this.oArg);
		}

		public IBQueryItemReq oArg = new IBQueryItemReq();

		public IBQueryItemRes oRes = new IBQueryItemRes();
	}
}
