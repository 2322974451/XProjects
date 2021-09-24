using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_FetchChapterChest : Rpc
	{

		public override uint GetRpcType()
		{
			return 21099U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<FetchChapterChestArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<FetchChapterChestRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_FetchChapterChest.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_FetchChapterChest.OnTimeout(this.oArg);
		}

		public FetchChapterChestArg oArg = new FetchChapterChestArg();

		public FetchChapterChestRes oRes = new FetchChapterChestRes();
	}
}
