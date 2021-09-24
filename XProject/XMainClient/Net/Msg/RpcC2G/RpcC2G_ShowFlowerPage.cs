using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ShowFlowerPage : Rpc
	{

		public override uint GetRpcType()
		{
			return 47831U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ShowFlowerPageArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ShowFlowerPageRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ShowFlowerPage.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ShowFlowerPage.OnTimeout(this.oArg);
		}

		public ShowFlowerPageArg oArg = new ShowFlowerPageArg();

		public ShowFlowerPageRes oRes = new ShowFlowerPageRes();
	}
}
