using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_breakAtlas : Rpc
	{

		public override uint GetRpcType()
		{
			return 13728U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<breakAtlas>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<breakAtlasRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_breakAtlas.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_breakAtlas.OnTimeout(this.oArg);
		}

		public breakAtlas oArg = new breakAtlas();

		public breakAtlasRes oRes = new breakAtlasRes();
	}
}
