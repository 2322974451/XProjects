using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ReturnSmeltStone : Rpc
	{

		public override uint GetRpcType()
		{
			return 16978U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ReturnSmeltStoneArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ReturnSmeltStoneRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ReturnSmeltStone.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ReturnSmeltStone.OnTimeout(this.oArg);
		}

		public ReturnSmeltStoneArg oArg = new ReturnSmeltStoneArg();

		public ReturnSmeltStoneRes oRes = null;
	}
}
