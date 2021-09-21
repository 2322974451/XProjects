using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020003C4 RID: 964
	[ProtoContract(Name = "ModifyArg")]
	[Serializable]
	public class ModifyArg : IExtensible
	{
		// Token: 0x17000FDA RID: 4058
		// (get) Token: 0x06003372 RID: 13170 RVA: 0x00062C94 File Offset: 0x00060E94
		// (set) Token: 0x06003373 RID: 13171 RVA: 0x00062CB5 File Offset: 0x00060EB5
		[ProtoMember(1, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
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

		// Token: 0x17000FDB RID: 4059
		// (get) Token: 0x06003374 RID: 13172 RVA: 0x00062CC0 File Offset: 0x00060EC0
		// (set) Token: 0x06003375 RID: 13173 RVA: 0x00062CDC File Offset: 0x00060EDC
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

		// Token: 0x06003376 RID: 13174 RVA: 0x00062D0C File Offset: 0x00060F0C
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003377 RID: 13175 RVA: 0x00062D24 File Offset: 0x00060F24
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06003378 RID: 13176 RVA: 0x00062D30 File Offset: 0x00060F30
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000CCA RID: 3274
		private string _name;

		// Token: 0x04000CCB RID: 3275
		private IExtension extensionObject;
	}
}
