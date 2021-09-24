using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ShowFlowerPageNew : Rpc
	{

		public override uint GetRpcType()
		{
			return 49446U;
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
			Process_RpcC2M_ShowFlowerPageNew.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ShowFlowerPageNew.OnTimeout(this.oArg);
		}

		public ShowFlowerPageArg oArg = new ShowFlowerPageArg();

		public ShowFlowerPageRes oRes = null;
	}
}
