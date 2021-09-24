using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ItemFindBackInfo : Rpc
	{

		public override uint GetRpcType()
		{
			return 11755U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemFindBackInfoArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemFindBackInfoRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemFindBackInfo.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemFindBackInfo.OnTimeout(this.oArg);
		}

		public ItemFindBackInfoArg oArg = new ItemFindBackInfoArg();

		public ItemFindBackInfoRes oRes = new ItemFindBackInfoRes();
	}
}
