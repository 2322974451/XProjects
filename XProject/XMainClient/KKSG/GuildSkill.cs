using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005FE RID: 1534
	[ProtoContract(Name = "GuildSkill")]
	[Serializable]
	public class GuildSkill : IExtensible
	{
		// Token: 0x17001CBF RID: 7359
		// (get) Token: 0x06005BD1 RID: 23505 RVA: 0x000AEE4C File Offset: 0x000AD04C
		// (set) Token: 0x06005BD2 RID: 23506 RVA: 0x000AEE78 File Offset: 0x000AD078
		[ProtoMember(1, IsRequired = false, Name = "skillId", DataFormat = DataFormat.TwosComplement)]
		public uint skillId
		{
			get
			{
				return this._skillId ?? 0U;
			}
			set
			{
				this._skillId = new uint?(value);
			}
		}

		// Token: 0x17001CC0 RID: 7360
		// (get) Token: 0x06005BD3 RID: 23507 RVA: 0x000AEE88 File Offset: 0x000AD088
		// (set) Token: 0x06005BD4 RID: 23508 RVA: 0x000AEEA8 File Offset: 0x000AD0A8
		[XmlIgnore]
		[Browsable(false)]
		public bool skillIdSpecified
		{
			get
			{
				return this._skillId != null;
			}
			set
			{
				bool flag = value == (this._skillId == null);
				if (flag)
				{
					this._skillId = (value ? new uint?(this.skillId) : null);
				}
			}
		}

		// Token: 0x06005BD5 RID: 23509 RVA: 0x000AEEEC File Offset: 0x000AD0EC
		private bool ShouldSerializeskillId()
		{
			return this.skillIdSpecified;
		}

		// Token: 0x06005BD6 RID: 23510 RVA: 0x000AEF04 File Offset: 0x000AD104
		private void ResetskillId()
		{
			this.skillIdSpecified = false;
		}

		// Token: 0x17001CC1 RID: 7361
		// (get) Token: 0x06005BD7 RID: 23511 RVA: 0x000AEF10 File Offset: 0x000AD110
		// (set) Token: 0x06005BD8 RID: 23512 RVA: 0x000AEF3C File Offset: 0x000AD13C
		[ProtoMember(2, IsRequired = false, Name = "skillLvl", DataFormat = DataFormat.TwosComplement)]
		public uint skillLvl
		{
			get
			{
				return this._skillLvl ?? 0U;
			}
			set
			{
				this._skillLvl = new uint?(value);
			}
		}

		// Token: 0x17001CC2 RID: 7362
		// (get) Token: 0x06005BD9 RID: 23513 RVA: 0x000AEF4C File Offset: 0x000AD14C
		// (set) Token: 0x06005BDA RID: 23514 RVA: 0x000AEF6C File Offset: 0x000AD16C
		[XmlIgnore]
		[Browsable(false)]
		public bool skillLvlSpecified
		{
			get
			{
				return this._skillLvl != null;
			}
			set
			{
				bool flag = value == (this._skillLvl == null);
				if (flag)
				{
					this._skillLvl = (value ? new uint?(this.skillLvl) : null);
				}
			}
		}

		// Token: 0x06005BDB RID: 23515 RVA: 0x000AEFB0 File Offset: 0x000AD1B0
		private bool ShouldSerializeskillLvl()
		{
			return this.skillLvlSpecified;
		}

		// Token: 0x06005BDC RID: 23516 RVA: 0x000AEFC8 File Offset: 0x000AD1C8
		private void ResetskillLvl()
		{
			this.skillLvlSpecified = false;
		}

		// Token: 0x06005BDD RID: 23517 RVA: 0x000AEFD4 File Offset: 0x000AD1D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001655 RID: 5717
		private uint? _skillId;

		// Token: 0x04001656 RID: 5718
		private uint? _skillLvl;

		// Token: 0x04001657 RID: 5719
		private IExtension extensionObject;
	}
}
