using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02001656 RID: 5718
	internal class PtcC2M_MulActivityIconSysReq : Protocol
	{
		// Token: 0x0600EEA5 RID: 61093 RVA: 0x0034A19C File Offset: 0x0034839C
		public override uint GetProtoType()
		{
			return 64642U;
		}

		// Token: 0x0600EEA6 RID: 61094 RVA: 0x0034A1B3 File Offset: 0x003483B3
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<MulActivityIconSys>(stream, this.Data);
		}

		// Token: 0x0600EEA7 RID: 61095 RVA: 0x0034A1C3 File Offset: 0x003483C3
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<MulActivityIconSys>(stream);
		}

		// Token: 0x0600EEA8 RID: 61096 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x0400661F RID: 26143
		public MulActivityIconSys Data = new MulActivityIconSys();
	}
}
