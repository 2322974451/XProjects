using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_BuyDraw : Rpc
	{

		public override uint GetRpcType()
		{
			return 51925U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<BuyDrawReq>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<BuyDrawRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_BuyDraw.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_BuyDraw.OnTimeout(this.oArg);
		}

		public BuyDrawReq oArg = new BuyDrawReq();

		public BuyDrawRes oRes = null;
	}
}
