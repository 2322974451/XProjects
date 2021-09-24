using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{

	internal class RpcC2G_DragonGroupRecord : Rpc
	{

		public override uint GetRpcType()
		{
			return 62181U;
		}

		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<DragonGroupRecordC2S>(stream, this.oArg);
		}

		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<DragonGroupRecordS2C>(stream);
		}

		public override void Process()
		{
			base.Process();
			Process_RpcC2G_DragonGroupRecord.OnReply(this.oArg, this.oRes);
		}

		public override void OnTimeout(object args)
		{
			Process_RpcC2G_DragonGroupRecord.OnTimeout(this.oArg);
		}

		public DragonGroupRecordC2S oArg = new DragonGroupRecordC2S();

		public DragonGroupRecordS2C oRes = null;
	}
}
