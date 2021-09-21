using System;
using System.Collections.Generic;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000290 RID: 656
	[ProtoContract(Name = "SyncPlatFriend2MSData")]
	[Serializable]
	public class SyncPlatFriend2MSData : IExtensible
	{
		// Token: 0x17000B72 RID: 2930
		// (get) Token: 0x060024D2 RID: 9426 RVA: 0x00047D20 File Offset: 0x00045F20
		[ProtoMember(1, Name = "friendInfo", DataFormat = DataFormat.Default)]
		public List<PlatFriend> friendInfo
		{
			get
			{
				return this._friendInfo;
			}
		}

		// Token: 0x17000B73 RID: 2931
		// (get) Token: 0x060024D3 RID: 9427 RVA: 0x00047D38 File Offset: 0x00045F38
		// (set) Token: 0x060024D4 RID: 9428 RVA: 0x00047D50 File Offset: 0x00045F50
		[ProtoMember(2, IsRequired = false, Name = "selfInfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public PlatFriend selfInfo
		{
			get
			{
				return this._selfInfo;
			}
			set
			{
				this._selfInfo = value;
			}
		}

		// Token: 0x060024D5 RID: 9429 RVA: 0x00047D5C File Offset: 0x00045F5C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000917 RID: 2327
		private readonly List<PlatFriend> _friendInfo = new List<PlatFriend>();

		// Token: 0x04000918 RID: 2328
		private PlatFriend _selfInfo = null;

		// Token: 0x04000919 RID: 2329
		private IExtension extensionObject;
	}
}
