using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200142D RID: 5165
	internal class RpcC2M_TryAlliance : Rpc
	{
		// Token: 0x0600E5BB RID: 58811 RVA: 0x0033D594 File Offset: 0x0033B794
		public override uint GetRpcType()
		{
			return 20216U;
		}

		// Token: 0x0600E5BC RID: 58812 RVA: 0x0033D5AB File Offset: 0x0033B7AB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<TryAllianceArg>(stream, this.oArg);
		}

		// Token: 0x0600E5BD RID: 58813 RVA: 0x0033D5BB File Offset: 0x0033B7BB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<TryAlliance>(stream);
		}

		// Token: 0x0600E5BE RID: 58814 RVA: 0x0033D5CA File Offset: 0x0033B7CA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_TryAlliance.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E5BF RID: 58815 RVA: 0x0033D5E6 File Offset: 0x0033B7E6
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_TryAlliance.OnTimeout(this.oArg);
		}

		// Token: 0x0400645E RID: 25694
		public TryAllianceArg oArg = new TryAllianceArg();

		// Token: 0x0400645F RID: 25695
		public TryAlliance oRes = null;
	}
}
