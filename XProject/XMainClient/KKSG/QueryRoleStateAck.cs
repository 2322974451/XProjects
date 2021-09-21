using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200036D RID: 877
	[ProtoContract(Name = "QueryRoleStateAck")]
	[Serializable]
	public class QueryRoleStateAck : IExtensible
	{
		// Token: 0x17000EBE RID: 3774
		// (get) Token: 0x06002FA2 RID: 12194 RVA: 0x0005BE84 File Offset: 0x0005A084
		[ProtoMember(1, Name = "roleids", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleids
		{
			get
			{
				return this._roleids;
			}
		}

		// Token: 0x17000EBF RID: 3775
		// (get) Token: 0x06002FA3 RID: 12195 RVA: 0x0005BE9C File Offset: 0x0005A09C
		[ProtoMember(2, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public List<uint> state
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x06002FA4 RID: 12196 RVA: 0x0005BEB4 File Offset: 0x0005A0B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BD4 RID: 3028
		private readonly List<ulong> _roleids = new List<ulong>();

		// Token: 0x04000BD5 RID: 3029
		private readonly List<uint> _state = new List<uint>();

		// Token: 0x04000BD6 RID: 3030
		private IExtension extensionObject;
	}
}
