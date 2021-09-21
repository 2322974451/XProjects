using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001035 RID: 4149
	internal class RpcC2G_JadeOperation : Rpc
	{
		// Token: 0x0600D580 RID: 54656 RVA: 0x00324374 File Offset: 0x00322574
		public override uint GetRpcType()
		{
			return 55991U;
		}

		// Token: 0x0600D581 RID: 54657 RVA: 0x0032438B File Offset: 0x0032258B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<JadeOperationArg>(stream, this.oArg);
		}

		// Token: 0x0600D582 RID: 54658 RVA: 0x0032439B File Offset: 0x0032259B
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<JadeOperationRes>(stream);
		}

		// Token: 0x0600D583 RID: 54659 RVA: 0x003243AA File Offset: 0x003225AA
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_JadeOperation.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D584 RID: 54660 RVA: 0x003243C6 File Offset: 0x003225C6
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_JadeOperation.OnTimeout(this.oArg);
		}

		// Token: 0x04006125 RID: 24869
		public JadeOperationArg oArg = new JadeOperationArg();

		// Token: 0x04006126 RID: 24870
		public JadeOperationRes oRes = new JadeOperationRes();
	}
}
