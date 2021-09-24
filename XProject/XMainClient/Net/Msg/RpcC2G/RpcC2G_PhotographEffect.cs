using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_PhotographEffect : Rpc
	{

		public override uint GetRpcType()
		{
			return 14666U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<PhotographEffectArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<PhotographEffect>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_PhotographEffect.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_PhotographEffect.OnTimeout(this.oArg);
		}

		public PhotographEffectArg oArg = new PhotographEffectArg();

		public PhotographEffect oRes = null;
	}
}
