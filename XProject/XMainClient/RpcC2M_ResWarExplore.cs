using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2M_ResWarExplore : Rpc
	{

		public override uint GetRpcType()
		{
			return 33965U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ResWarExploreArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ResWarExploreRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2M_ResWarExplore.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2M_ResWarExplore.OnTimeout(this.oArg);
		}

		public ResWarExploreArg oArg = new ResWarExploreArg();

		public ResWarExploreRes oRes = null;
	}
}
