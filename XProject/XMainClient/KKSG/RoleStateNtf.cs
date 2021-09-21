using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000089 RID: 137
	[ProtoContract(Name = "RoleStateNtf")]
	[Serializable]
	public class RoleStateNtf : IExtensible
	{
		// Token: 0x170002F1 RID: 753
		// (get) Token: 0x060008F1 RID: 2289 RVA: 0x00013A8C File Offset: 0x00011C8C
		[ProtoMember(1, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x170002F2 RID: 754
		// (get) Token: 0x060008F2 RID: 2290 RVA: 0x00013AA4 File Offset: 0x00011CA4
		[ProtoMember(2, Name = "state", DataFormat = DataFormat.TwosComplement)]
		public List<uint> state
		{
			get
			{
				return this._state;
			}
		}

		// Token: 0x170002F3 RID: 755
		// (get) Token: 0x060008F3 RID: 2291 RVA: 0x00013ABC File Offset: 0x00011CBC
		[ProtoMember(3, Name = "timelastlogin", DataFormat = DataFormat.TwosComplement)]
		public List<uint> timelastlogin
		{
			get
			{
				return this._timelastlogin;
			}
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x00013AD4 File Offset: 0x00011CD4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000251 RID: 593
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x04000252 RID: 594
		private readonly List<uint> _state = new List<uint>();

		// Token: 0x04000253 RID: 595
		private readonly List<uint> _timelastlogin = new List<uint>();

		// Token: 0x04000254 RID: 596
		private IExtension extensionObject;
	}
}
