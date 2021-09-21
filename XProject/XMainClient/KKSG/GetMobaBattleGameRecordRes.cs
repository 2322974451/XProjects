using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000430 RID: 1072
	[ProtoContract(Name = "GetMobaBattleGameRecordRes")]
	[Serializable]
	public class GetMobaBattleGameRecordRes : IExtensible
	{
		// Token: 0x17001172 RID: 4466
		// (get) Token: 0x060038CB RID: 14539 RVA: 0x0006CB4C File Offset: 0x0006AD4C
		// (set) Token: 0x060038CC RID: 14540 RVA: 0x0006CB64 File Offset: 0x0006AD64
		[ProtoMember(1, IsRequired = false, Name = "record", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public MobaBattleOneGame record
		{
			get
			{
				return this._record;
			}
			set
			{
				this._record = value;
			}
		}

		// Token: 0x060038CD RID: 14541 RVA: 0x0006CB70 File Offset: 0x0006AD70
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000E16 RID: 3606
		private MobaBattleOneGame _record = null;

		// Token: 0x04000E17 RID: 3607
		private IExtension extensionObject;
	}
}
