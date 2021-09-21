using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000346 RID: 838
	[ProtoContract(Name = "HeroBattleInCircle")]
	[Serializable]
	public class HeroBattleInCircle : IExtensible
	{
		// Token: 0x17000E3A RID: 3642
		// (get) Token: 0x06002DDA RID: 11738 RVA: 0x00058B54 File Offset: 0x00056D54
		[ProtoMember(1, Name = "roleInCircle", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> roleInCircle
		{
			get
			{
				return this._roleInCircle;
			}
		}

		// Token: 0x06002DDB RID: 11739 RVA: 0x00058B6C File Offset: 0x00056D6C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000B66 RID: 2918
		private readonly List<ulong> _roleInCircle = new List<ulong>();

		// Token: 0x04000B67 RID: 2919
		private IExtension extensionObject;
	}
}
