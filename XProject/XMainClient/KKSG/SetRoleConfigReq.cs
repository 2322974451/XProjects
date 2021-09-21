using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000ED RID: 237
	[ProtoContract(Name = "SetRoleConfigReq")]
	[Serializable]
	public class SetRoleConfigReq : IExtensible
	{
		// Token: 0x170004E0 RID: 1248
		// (get) Token: 0x06000F1B RID: 3867 RVA: 0x0001F310 File Offset: 0x0001D510
		// (set) Token: 0x06000F1C RID: 3868 RVA: 0x0001F331 File Offset: 0x0001D531
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.Default)]
		public string type
		{
			get
			{
				return this._type ?? "";
			}
			set
			{
				this._type = value;
			}
		}

		// Token: 0x170004E1 RID: 1249
		// (get) Token: 0x06000F1D RID: 3869 RVA: 0x0001F33C File Offset: 0x0001D53C
		// (set) Token: 0x06000F1E RID: 3870 RVA: 0x0001F358 File Offset: 0x0001D558
		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? this.type : null);
				}
			}
		}

		// Token: 0x06000F1F RID: 3871 RVA: 0x0001F388 File Offset: 0x0001D588
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06000F20 RID: 3872 RVA: 0x0001F3A0 File Offset: 0x0001D5A0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170004E2 RID: 1250
		// (get) Token: 0x06000F21 RID: 3873 RVA: 0x0001F3AC File Offset: 0x0001D5AC
		// (set) Token: 0x06000F22 RID: 3874 RVA: 0x0001F3CD File Offset: 0x0001D5CD
		[ProtoMember(2, IsRequired = false, Name = "value", DataFormat = DataFormat.Default)]
		public string value
		{
			get
			{
				return this._value ?? "";
			}
			set
			{
				this._value = value;
			}
		}

		// Token: 0x170004E3 RID: 1251
		// (get) Token: 0x06000F23 RID: 3875 RVA: 0x0001F3D8 File Offset: 0x0001D5D8
		// (set) Token: 0x06000F24 RID: 3876 RVA: 0x0001F3F4 File Offset: 0x0001D5F4
		[XmlIgnore]
		[Browsable(false)]
		public bool valueSpecified
		{
			get
			{
				return this._value != null;
			}
			set
			{
				bool flag = value == (this._value == null);
				if (flag)
				{
					this._value = (value ? this.value : null);
				}
			}
		}

		// Token: 0x06000F25 RID: 3877 RVA: 0x0001F424 File Offset: 0x0001D624
		private bool ShouldSerializevalue()
		{
			return this.valueSpecified;
		}

		// Token: 0x06000F26 RID: 3878 RVA: 0x0001F43C File Offset: 0x0001D63C
		private void Resetvalue()
		{
			this.valueSpecified = false;
		}

		// Token: 0x06000F27 RID: 3879 RVA: 0x0001F448 File Offset: 0x0001D648
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040003CC RID: 972
		private string _type;

		// Token: 0x040003CD RID: 973
		private string _value;

		// Token: 0x040003CE RID: 974
		private IExtension extensionObject;
	}
}
