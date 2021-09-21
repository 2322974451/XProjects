using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001420 RID: 5152
	internal class RpcC2M_AllianceGuildTerr : Rpc
	{
		// Token: 0x0600E586 RID: 58758 RVA: 0x0033D1C4 File Offset: 0x0033B3C4
		public override uint GetRpcType()
		{
			return 10041U;
		}

		// Token: 0x0600E587 RID: 58759 RVA: 0x0033D1DB File Offset: 0x0033B3DB
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<AllianceGuildTerrArg>(stream, this.oArg);
		}

		// Token: 0x0600E588 RID: 58760 RVA: 0x0033D1EB File Offset: 0x0033B3EB
		public override void DeSerialize(MemoryStream stream)
		{
			this.oRes = Serializer.Deserialize<AllianceGuildTerrRes>(stream);
		}

		// Token: 0x0600E589 RID: 58761 RVA: 0x0033D1FA File Offset: 0x0033B3FA
		public override void Process()
		{
			base.Process();
			Process_RpcC2M_AllianceGuildTerr.OnReply(this.oArg, this.oRes);
		}

		// Token: 0x0600E58A RID: 58762 RVA: 0x0033D216 File Offset: 0x0033B416
		public override void OnTimeout(object args)
		{
			Process_RpcC2M_AllianceGuildTerr.OnTimeout(this.oArg);
		}

		// Token: 0x04006455 RID: 25685
		public AllianceGuildTerrArg oArg = new AllianceGuildTerrArg();

		// Token: 0x04006456 RID: 25686
		public AllianceGuildTerrRes oRes = null;
	}
}
