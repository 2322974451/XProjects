using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ItemFindBack : Rpc
	{

		public override uint GetRpcType()
		{
			return 60242U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ItemFindBackArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ItemFindBackRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ItemFindBack.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ItemFindBack.OnTimeout(this.oArg);
		}

		public ItemFindBackArg oArg = new ItemFindBackArg();

		public ItemFindBackRes oRes = new ItemFindBackRes();
	}
}
