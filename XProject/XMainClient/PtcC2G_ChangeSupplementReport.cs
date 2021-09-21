using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020010CA RID: 4298
	internal class PtcC2G_ChangeSupplementReport : Protocol
	{
		// Token: 0x0600D7DF RID: 55263 RVA: 0x00328C10 File Offset: 0x00326E10
		public override uint GetProtoType()
		{
			return 42193U;
		}

		// Token: 0x0600D7E0 RID: 55264 RVA: 0x00328C27 File Offset: 0x00326E27
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<ChangeSupplementReport>(stream, this.Data);
		}

		// Token: 0x0600D7E1 RID: 55265 RVA: 0x00328C37 File Offset: 0x00326E37
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<ChangeSupplementReport>(stream);
		}

		// Token: 0x0600D7E2 RID: 55266 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x040061B8 RID: 25016
		public ChangeSupplementReport Data = new ChangeSupplementReport();
	}
}
