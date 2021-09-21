using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200068A RID: 1674
	[ProtoContract(Name = "GuildSkillData")]
	[Serializable]
	public class GuildSkillData : IExtensible
	{
		// Token: 0x17002224 RID: 8740
		// (get) Token: 0x06006BDF RID: 27615 RVA: 0x000CE594 File Offset: 0x000CC794
		// (set) Token: 0x06006BE0 RID: 27616 RVA: 0x000CE5C0 File Offset: 0x000CC7C0
		[ProtoMember(1, IsRequired = false, Name = "SkillId", DataFormat = DataFormat.TwosComplement)]
		public int SkillId
		{
			get
			{
				return this._SkillId ?? 0;
			}
			set
			{
				this._SkillId = new int?(value);
			}
		}

		// Token: 0x17002225 RID: 8741
		// (get) Token: 0x06006BE1 RID: 27617 RVA: 0x000CE5D0 File Offset: 0x000CC7D0
		// (set) Token: 0x06006BE2 RID: 27618 RVA: 0x000CE5F0 File Offset: 0x000CC7F0
		[XmlIgnore]
		[Browsable(false)]
		public bool SkillIdSpecified
		{
			get
			{
				return this._SkillId != null;
			}
			set
			{
				bool flag = value == (this._SkillId == null);
				if (flag)
				{
					this._SkillId = (value ? new int?(this.SkillId) : null);
				}
			}
		}

		// Token: 0x06006BE3 RID: 27619 RVA: 0x000CE634 File Offset: 0x000CC834
		private bool ShouldSerializeSkillId()
		{
			return this.SkillIdSpecified;
		}

		// Token: 0x06006BE4 RID: 27620 RVA: 0x000CE64C File Offset: 0x000CC84C
		private void ResetSkillId()
		{
			this.SkillIdSpecified = false;
		}

		// Token: 0x17002226 RID: 8742
		// (get) Token: 0x06006BE5 RID: 27621 RVA: 0x000CE658 File Offset: 0x000CC858
		// (set) Token: 0x06006BE6 RID: 27622 RVA: 0x000CE684 File Offset: 0x000CC884
		[ProtoMember(2, IsRequired = false, Name = "MaxLvl", DataFormat = DataFormat.TwosComplement)]
		public int MaxLvl
		{
			get
			{
				return this._MaxLvl ?? 0;
			}
			set
			{
				this._MaxLvl = new int?(value);
			}
		}

		// Token: 0x17002227 RID: 8743
		// (get) Token: 0x06006BE7 RID: 27623 RVA: 0x000CE694 File Offset: 0x000CC894
		// (set) Token: 0x06006BE8 RID: 27624 RVA: 0x000CE6B4 File Offset: 0x000CC8B4
		[XmlIgnore]
		[Browsable(false)]
		public bool MaxLvlSpecified
		{
			get
			{
				return this._MaxLvl != null;
			}
			set
			{
				bool flag = value == (this._MaxLvl == null);
				if (flag)
				{
					this._MaxLvl = (value ? new int?(this.MaxLvl) : null);
				}
			}
		}

		// Token: 0x06006BE9 RID: 27625 RVA: 0x000CE6F8 File Offset: 0x000CC8F8
		private bool ShouldSerializeMaxLvl()
		{
			return this.MaxLvlSpecified;
		}

		// Token: 0x06006BEA RID: 27626 RVA: 0x000CE710 File Offset: 0x000CC910
		private void ResetMaxLvl()
		{
			this.MaxLvlSpecified = false;
		}

		// Token: 0x06006BEB RID: 27627 RVA: 0x000CE71C File Offset: 0x000CC91C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040019ED RID: 6637
		private int? _SkillId;

		// Token: 0x040019EE RID: 6638
		private int? _MaxLvl;

		// Token: 0x040019EF RID: 6639
		private IExtension extensionObject;
	}
}
