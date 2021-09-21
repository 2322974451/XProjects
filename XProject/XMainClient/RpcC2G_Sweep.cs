using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200104D RID: 4173
	internal class RpcC2G_Sweep : Rpc
	{
		// Token: 0x0600D5E9 RID: 54761 RVA: 0x003251D0 File Offset: 0x003233D0
		public override uint GetRpcType()
		{
			return 6019U;
		}

		// Token: 0x0600D5EA RID: 54762 RVA: 0x003251E7 File Offset: 0x003233E7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<SweepArg>(stream, this.oArg);
		}

		// Token: 0x0600D5EB RID: 54763 RVA: 0x003251F7 File Offset: 0x003233F7
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<SweepRes>(stream);
		}

		// Token: 0x0600D5EC RID: 54764 RVA: 0x00325206 File Offset: 0x00323406
		public override void Process()
		{
			base.Process();
			Process_RpcC2G_Sweep.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600D5ED RID: 54765 RVA: 0x00325222 File Offset: 0x00323422
		public override void OnTimeout(object args)
		{
			Process_RpcC2G_Sweep.OnTimeout(this.oArg);
		}

		// Token: 0x04006158 RID: 24920
		public SweepArg oArg = new SweepArg();

		// Token: 0x04006159 RID: 24921
		public SweepRes oRes = new SweepRes();
	}
}
