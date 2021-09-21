using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x02000ECF RID: 3791
	internal class PtcG2C_NotifyAccountData : Protocol
	{
		// Token: 0x0600C8EE RID: 51438 RVA: 0x002CFAEC File Offset: 0x002CDCEC
		public override uint GetProtoType()
		{
			return 29137U;
		}

		// Token: 0x0600C8EF RID: 51439 RVA: 0x002CFB03 File Offset: 0x002CDD03
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LoadAccountData>(stream, this.Data);
		}

		// Token: 0x0600C8F0 RID: 51440 RVA: 0x002CFB13 File Offset: 0x002CDD13
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LoadAccountData>(stream);
		}

		// Token: 0x0600C8F1 RID: 51441 RVA: 0x002CFB22 File Offset: 0x002CDD22
		public override void Process()
		{
			Process_PtcG2C_NotifyAccountData.Process(this);
		}

		// Token: 0x040058D6 RID: 22742
		public LoadAccountData Data = new LoadAccountData();
	}
}
