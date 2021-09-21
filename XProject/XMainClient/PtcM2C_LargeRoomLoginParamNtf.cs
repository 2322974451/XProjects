using System;
using System.IO;
using KKSG;
using ProtoBuf;

namespace XMainClient
{
	// Token: 0x020013B7 RID: 5047
	internal class PtcM2C_LargeRoomLoginParamNtf : Protocol
	{
		// Token: 0x0600E3DA RID: 58330 RVA: 0x0033AEB8 File Offset: 0x003390B8
		public override uint GetProtoType()
		{
			return 51856U;
		}

		// Token: 0x0600E3DB RID: 58331 RVA: 0x0033AECF File Offset: 0x003390CF
		public override void Serialize(MemoryStream stream)
		{
			Serializer.Serialize<LargeRoomLoginParam>(stream, this.Data);
		}

		// Token: 0x0600E3DC RID: 58332 RVA: 0x0033AEDF File Offset: 0x003390DF
		public override void DeSerialize(MemoryStream stream)
		{
			this.Data = Serializer.Deserialize<LargeRoomLoginParam>(stream);
		}

		// Token: 0x0600E3DD RID: 58333 RVA: 0x0033AEEE File Offset: 0x003390EE
		public override void Process()
		{
			Process_PtcM2C_LargeRoomLoginParamNtf.Process(this);
		}

		// Token: 0x04006403 RID: 25603
		public LargeRoomLoginParam Data = new LargeRoomLoginParam();
	}
}
