using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004B9 RID: 1209
	[ProtoContract(Name = "DragonGuildNameNtf")]
	[Serializable]
	public class DragonGuildNameNtf : IExtensible
	{
		// Token: 0x17001349 RID: 4937
		// (get) Token: 0x06003EF6 RID: 16118 RVA: 0x000780F0 File Offset: 0x000762F0
		// (set) Token: 0x06003EF7 RID: 16119 RVA: 0x00078111 File Offset: 0x00076311
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

		// Token: 0x1700134A RID: 4938
		// (get) Token: 0x06003EF8 RID: 16120 RVA: 0x0007811C File Offset: 0x0007631C
		// (set) Token: 0x06003EF9 RID: 16121 RVA: 0x00078138 File Offset: 0x00076338
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

		// Token: 0x06003EFA RID: 16122 RVA: 0x00078168 File Offset: 0x00076368
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06003EFB RID: 16123 RVA: 0x00078180 File Offset: 0x00076380
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06003EFC RID: 16124 RVA: 0x0007818C File Offset: 0x0007638C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000FAA RID: 4010
		private string _name;

		// Token: 0x04000FAB RID: 4011
		private IExtension extensionObject;
	}
}
