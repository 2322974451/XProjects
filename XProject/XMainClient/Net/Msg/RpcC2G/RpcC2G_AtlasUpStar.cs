using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_AtlasUpStar : Rpc
	{

		public override uint GetRpcType()
		{
			return 41051U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AtlasUpStarArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AtlasUpStarRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_AtlasUpStar.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_AtlasUpStar.OnTimeout(this.oArg);
		}

		public AtlasUpStarArg oArg = new AtlasUpStarArg();

		public AtlasUpStarRes oRes = null;
	}
}
