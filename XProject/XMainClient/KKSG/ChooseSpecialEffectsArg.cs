using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000519 RID: 1305
	[ProtoContract(Name = "ChooseSpecialEffectsArg")]
	[Serializable]
	public class ChooseSpecialEffectsArg : IExtensible
	{
		// Token: 0x17001483 RID: 5251
		// (get) Token: 0x0600431B RID: 17179 RVA: 0x0007FAC8 File Offset: 0x0007DCC8
		// (set) Token: 0x0600431C RID: 17180 RVA: 0x0007FAF4 File Offset: 0x0007DCF4
		[ProtoMember(1, IsRequired = false, Name = "special_effects_id", DataFormat = DataFormat.TwosComplement)]
		public uint special_effects_id
		{
			get
			{
				return this._special_effects_id ?? 0U;
			}
			set
			{
				this._special_effects_id = new uint?(value);
			}
		}

		// Token: 0x17001484 RID: 5252
		// (get) Token: 0x0600431D RID: 17181 RVA: 0x0007FB04 File Offset: 0x0007DD04
		// (set) Token: 0x0600431E RID: 17182 RVA: 0x0007FB24 File Offset: 0x0007DD24
		[XmlIgnore]
		[Browsable(false)]
		public bool special_effects_idSpecified
		{
			get
			{
				return this._special_effects_id != null;
			}
			set
			{
				bool flag = value == (this._special_effects_id == null);
				if (flag)
				{
					this._special_effects_id = (value ? new uint?(this.special_effects_id) : null);
				}
			}
		}

		// Token: 0x0600431F RID: 17183 RVA: 0x0007FB68 File Offset: 0x0007DD68
		private bool ShouldSerializespecial_effects_id()
		{
			return this.special_effects_idSpecified;
		}

		// Token: 0x06004320 RID: 17184 RVA: 0x0007FB80 File Offset: 0x0007DD80
		private void Resetspecial_effects_id()
		{
			this.special_effects_idSpecified = false;
		}

		// Token: 0x06004321 RID: 17185 RVA: 0x0007FB8C File Offset: 0x0007DD8C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040010BB RID: 4283
		private uint? _special_effects_id;

		// Token: 0x040010BC RID: 4284
		private IExtension extensionObject;
	}
}
