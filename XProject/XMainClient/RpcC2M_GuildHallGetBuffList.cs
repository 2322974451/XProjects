using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200168C RID: 5772
	internal class RpcC2M_GuildHallGetBuffList : Rpc
	{
		// Token: 0x0600EF83 RID: 61315 RVA: 0x0034B65C File Offset: 0x0034985C
		public override uint GetRpcType()
		{
			return 38816U;
		}

		// Token: 0x0600EF84 RID: 61316 RVA: 0x0034B673 File Offset: 0x00349873
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<GuildHallGetBuffList_C2M>(stream, this.oArg);
		}

		// Token: 0x0600EF85 RID: 61317 RVA: 0x0034B683 File Offset: 0x00349883
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<GuildHallGetBuffList_M2C>(stream);
		}

		// Token: 0x0600EF86 RID: 61318 RVA: 0x0034B692 File Offset: 0x00349892
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_GuildHallGetBuffList.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600EF87 RID: 61319 RVA: 0x0034B6AE File Offset: 0x003498AE
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_GuildHallGetBuffList.OnTimeout(this.oArg);
		}

		// Token: 0x04006651 RID: 26193
		public GuildHallGetBuffList_C2M oArg = new GuildHallGetBuffList_C2M();

		// Token: 0x04006652 RID: 26194
		public GuildHallGetBuffList_M2C oRes = null;
	}
}
