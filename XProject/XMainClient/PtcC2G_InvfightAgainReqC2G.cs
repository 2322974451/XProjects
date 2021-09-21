using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020015E1 RID: 5601
	internal class PtcC2G_InvfightAgainReqC2G : Protocol
	{
		// Token: 0x0600ECAD RID: 60589 RVA: 0x003475D0 File Offset: 0x003457D0
		public override uint GetProtoType()
		{
			return 2055U;
		}

		// Token: 0x0600ECAE RID: 60590 RVA: 0x003475E7 File Offset: 0x003457E7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<InvFightAgainPara>(stream, this.Data);
		}

		// Token: 0x0600ECAF RID: 60591 RVA: 0x003475F7 File Offset: 0x003457F7
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<InvFightAgainPara>(stream);
		}

		// Token: 0x0600ECB0 RID: 60592 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040065B6 RID: 26038
		public InvFightAgainPara Data = new InvFightAgainPara();
	}
}
