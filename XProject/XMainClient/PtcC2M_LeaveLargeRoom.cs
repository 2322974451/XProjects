using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013B4 RID: 5044
	internal class PtcC2M_LeaveLargeRoom : Protocol
	{
		// Token: 0x0600E3CE RID: 58318 RVA: 0x0033ADE0 File Offset: 0x00338FE0
		public override uint GetProtoType()
		{
			return 55577U;
		}

		// Token: 0x0600E3CF RID: 58319 RVA: 0x0033ADF7 File Offset: 0x00338FF7
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LeaveLargeRoomParam>(stream, this.Data);
		}

		// Token: 0x0600E3D0 RID: 58320 RVA: 0x0033AE07 File Offset: 0x00339007
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LeaveLargeRoomParam>(stream);
		}

		// Token: 0x0600E3D1 RID: 58321 RVA: 0x001E09CA File Offset: 0x001DEBCA
		public override void Process()
		{
			throw new Exception("Send only protocol can not call process");
		}

		// Token: 0x04006401 RID: 25601
		public LeaveLargeRoomParam Data = new LeaveLargeRoomParam();
	}
}
