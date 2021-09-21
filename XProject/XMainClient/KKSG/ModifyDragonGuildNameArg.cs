using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B7 RID: 1207
	[ProtoContract(Name = "ModifyDragonGuildNameArg")]
	[Serializable]
	public class ModifyDragonGuildNameArg : IExtensible
	{
		// Token: 0x17001345 RID: 4933
		// (get) Token: 0x06003EE6 RID: 16102 RVA: 0x00077F50 File Offset: 0x00076150
		// (set) Token: 0x06003EE7 RID: 16103 RVA: 0x00077F71 File Offset: 0x00076171
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

		// Token: 0x17001346 RID: 4934
		// (get) Token: 0x06003EE8 RID: 16104 RVA: 0x00077F7C File Offset: 0x0007617C
		// (set) Token: 0x06003EE9 RID: 16105 RVA: 0x00077F98 File Offset: 0x00076198
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

		// Token: 0x06003EEA RID: 16106 RVA: 0x00077FC8 File Offset: 0x000761C8
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003EEB RID: 16107 RVA: 0x00077FE0 File Offset: 0x000761E0
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06003EEC RID: 16108 RVA: 0x00077FEC File Offset: 0x000761EC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FA6 RID: 4006
		private string _name;

		// Token: 0x04000FA7 RID: 4007
		private IExtension extensionObject;
	}
}
