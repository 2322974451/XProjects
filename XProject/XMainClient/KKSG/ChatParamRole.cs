using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005A3 RID: 1443
	[ProtoContract(Name = "ChatParamRole")]
	[Serializable]
	public class ChatParamRole : IExtensible
	{
		// Token: 0x17001820 RID: 6176
		// (get) Token: 0x06004E2E RID: 20014 RVA: 0x00094BCC File Offset: 0x00092DCC
		// (set) Token: 0x06004E2F RID: 20015 RVA: 0x00094BF9 File Offset: 0x00092DF9
		[ProtoMember(1, IsRequired = false, Name = "uniqueid", DataFormat = DataFormat.TwosComplement)]
		public ulong uniqueid
		{
			get
			{
				return this._uniqueid ?? 0UL;
			}
			set
			{
				this._uniqueid = new ulong?(value);
			}
		}

		// Token: 0x17001821 RID: 6177
		// (get) Token: 0x06004E30 RID: 20016 RVA: 0x00094C08 File Offset: 0x00092E08
		// (set) Token: 0x06004E31 RID: 20017 RVA: 0x00094C28 File Offset: 0x00092E28
		[XmlIgnore]
		[Browsable(false)]
		public bool uniqueidSpecified
		{
			get
			{
				return this._uniqueid != null;
			}
			set
			{
				bool flag = value == (this._uniqueid == null);
				if (flag)
				{
					this._uniqueid = (value ? new ulong?(this.uniqueid) : null);
				}
			}
		}

		// Token: 0x06004E32 RID: 20018 RVA: 0x00094C6C File Offset: 0x00092E6C
		private bool ShouldSerializeuniqueid()
		{
			return this.uniqueidSpecified;
		}

		// Token: 0x06004E33 RID: 20019 RVA: 0x00094C84 File Offset: 0x00092E84
		private void Resetuniqueid()
		{
			this.uniqueidSpecified = false;
		}

		// Token: 0x17001822 RID: 6178
		// (get) Token: 0x06004E34 RID: 20020 RVA: 0x00094C90 File Offset: 0x00092E90
		// (set) Token: 0x06004E35 RID: 20021 RVA: 0x00094CB1 File Offset: 0x00092EB1
		[ProtoMember(2, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		// Token: 0x17001823 RID: 6179
		// (get) Token: 0x06004E36 RID: 20022 RVA: 0x00094CBC File Offset: 0x00092EBC
		// (set) Token: 0x06004E37 RID: 20023 RVA: 0x00094CD8 File Offset: 0x00092ED8
		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		// Token: 0x06004E38 RID: 20024 RVA: 0x00094D08 File Offset: 0x00092F08
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06004E39 RID: 20025 RVA: 0x00094D20 File Offset: 0x00092F20
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x17001824 RID: 6180
		// (get) Token: 0x06004E3A RID: 20026 RVA: 0x00094D2C File Offset: 0x00092F2C
		// (set) Token: 0x06004E3B RID: 20027 RVA: 0x00094D58 File Offset: 0x00092F58
		[ProtoMember(3, IsRequired = false, Name = "profession", DataFormat = DataFormat.TwosComplement)]
		public uint profession
		{
			get
			{
				return this._profession ?? 0U;
			}
			set
			{
				this._profession = new uint?(value);
			}
		}

		// Token: 0x17001825 RID: 6181
		// (get) Token: 0x06004E3C RID: 20028 RVA: 0x00094D68 File Offset: 0x00092F68
		// (set) Token: 0x06004E3D RID: 20029 RVA: 0x00094D88 File Offset: 0x00092F88
		[XmlIgnore]
		[Browsable(false)]
		public bool professionSpecified
		{
			get
			{
				return this._profession != null;
			}
			set
			{
				bool flag = value == (this._profession == null);
				if (flag)
				{
					this._profession = (value ? new uint?(this.profession) : null);
				}
			}
		}

		// Token: 0x06004E3E RID: 20030 RVA: 0x00094DCC File Offset: 0x00092FCC
		private bool ShouldSerializeprofession()
		{
			return this.professionSpecified;
		}

		// Token: 0x06004E3F RID: 20031 RVA: 0x00094DE4 File Offset: 0x00092FE4
		private void Resetprofession()
		{
			this.professionSpecified = false;
		}

		// Token: 0x06004E40 RID: 20032 RVA: 0x00094DF0 File Offset: 0x00092FF0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001357 RID: 4951
		private ulong? _uniqueid;

		// Token: 0x04001358 RID: 4952
		private string _name;

		// Token: 0x04001359 RID: 4953
		private uint? _profession;

		// Token: 0x0400135A RID: 4954
		private IExtension extensionObject;
	}
}
