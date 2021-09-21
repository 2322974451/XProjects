using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000E7 RID: 231
	[ProtoContract(Name = "SceneDamageRankNtf")]
	[Serializable]
	public class SceneDamageRankNtf : IExtensible
	{
		// Token: 0x170004CF RID: 1231
		// (get) Token: 0x06000EE6 RID: 3814 RVA: 0x0001ED18 File Offset: 0x0001CF18
		[ProtoMember(1, Name = "name", DataFormat = DataFormat.Default)]
		public List<string> name
		{
			get
			{
				return this._name;
			}
		}

		// Token: 0x170004D0 RID: 1232
		// (get) Token: 0x06000EE7 RID: 3815 RVA: 0x0001ED30 File Offset: 0x0001CF30
		[ProtoMember(2, Name = "damage", DataFormat = DataFormat.FixedSize)]
		public List<float> damage
		{
			get
			{
				return this._damage;
			}
		}

		// Token: 0x170004D1 RID: 1233
		// (get) Token: 0x06000EE8 RID: 3816 RVA: 0x0001ED48 File Offset: 0x0001CF48
		[ProtoMember(3, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleid
		{
			get
			{
				return this._roleid;
			}
		}

		// Token: 0x06000EE9 RID: 3817 RVA: 0x0001ED60 File Offset: 0x0001CF60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003BB RID: 955
		private readonly List<string> _name = new List<string>();

		// Token: 0x040003BC RID: 956
		private readonly List<float> _damage = new List<float>();

		// Token: 0x040003BD RID: 957
		private readonly List<ulong> _roleid = new List<ulong>();

		// Token: 0x040003BE RID: 958
		private IExtension extensionObject;
	}
}
