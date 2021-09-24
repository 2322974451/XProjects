using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ActivatAtlas : Rpc
	{

		public override uint GetRpcType()
		{
			return 15919U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ActivatAtlasArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ActivatAtlasRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ActivatAtlas.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ActivatAtlas.OnTimeout(this.oArg);
		}

		public ActivatAtlasArg oArg = new ActivatAtlasArg();

		public ActivatAtlasRes oRes = new ActivatAtlasRes();
	}
}
