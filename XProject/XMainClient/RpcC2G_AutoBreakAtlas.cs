using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_AutoBreakAtlas : Rpc
	{

		public override uint GetRpcType()
		{
			return 23263U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AutoBreakAtlasArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AutoBreakAtlasRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AutoBreakAtlas.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AutoBreakAtlas.OnTimeout(this.oArg);
		}

		public AutoBreakAtlasArg oArg = new AutoBreakAtlasArg();

		public AutoBreakAtlasRes oRes = new AutoBreakAtlasRes();
	}
}
