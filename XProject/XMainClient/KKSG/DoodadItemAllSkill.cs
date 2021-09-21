using System;
using System.Collections.Generic;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000503 RID: 1283
	[ProtoContract(Name = "DoodadItemAllSkill")]
	[Serializable]
	public class DoodadItemAllSkill : IExtensible
	{
		// Token: 0x1700144B RID: 5195
		// (get) Token: 0x0600424E RID: 16974 RVA: 0x0007E3CC File Offset: 0x0007C5CC
		[ProtoMember(1, Name = "skills", DataFormat = DataFormat.Default)]
		public List<DoodadItemSkill> skills
		{
			get
			{
				return this._skills;
			}
		}

		// Token: 0x0600424F RID: 16975 RVA: 0x0007E3E4 File Offset: 0x0007C5E4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001087 RID: 4231
		private readonly List<DoodadItemSkill> _skills = new List<DoodadItemSkill>();

		// Token: 0x04001088 RID: 4232
		private IExtension extensionObject;
	}
}
