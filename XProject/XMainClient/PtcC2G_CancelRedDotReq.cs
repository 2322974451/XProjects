using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x0200148A RID: 5258
	internal class PtcC2G_CancelRedDotReq : Protocol
	{
		// Token: 0x0600E72C RID: 59180 RVA: 0x0033FA34 File Offset: 0x0033DC34
		public override uint GetProtoType()
		{
			return 40873U;
		}

		// Token: 0x0600E72D RID: 59181 RVA: 0x0033FA4B File Offset: 0x0033DC4B
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<CancelRedDot>(stream, this.Data);
		}

		// Token: 0x0600E72E RID: 59182 RVA: 0x0033FA5B File Offset: 0x0033DC5B
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<CancelRedDot>(stream);
		}

		// Token: 0x0600E72F RID: 59183 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040064A1 RID: 25761
		public CancelRedDot Data = new CancelRedDot();
	}
}
