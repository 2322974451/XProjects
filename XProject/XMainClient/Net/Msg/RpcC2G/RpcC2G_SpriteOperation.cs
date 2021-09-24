using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_SpriteOperation : Rpc
	{

		public override uint GetRpcType()
		{
			return 62961U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SpriteOperationArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SpriteOperationRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_SpriteOperation.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_SpriteOperation.OnTimeout(this.oArg);
		}

		public SpriteOperationArg oArg = new SpriteOperationArg();

		public SpriteOperationRes oRes = new SpriteOperationRes();
	}
}
