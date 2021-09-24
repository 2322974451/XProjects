using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_ThemeActivityHint : Rpc
	{

		public override uint GetRpcType()
		{
			return 39987U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ThemeActivityHintArg>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<ThemeActivityHintRes>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_ThemeActivityHint.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_ThemeActivityHint.OnTimeout(this.oArg);
		}

		public ThemeActivityHintArg oArg = new ThemeActivityHintArg();

		public ThemeActivityHintRes oRes = null;
	}
}
