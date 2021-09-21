using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020006A1 RID: 1697
	[ProtoContract(Name = "QAIDName")]
	[Serializable]
	public class QAIDName : IExtensible
	{
		// Token: 0x170022FA RID: 8954
		// (get) Token: 0x06006E84 RID: 28292 RVA: 0x000D3780 File Offset: 0x000D1980
		// (set) Token: 0x06006E85 RID: 28293 RVA: 0x000D37AD File Offset: 0x000D19AD
		[ProtoMember(1, IsRequired = false, Name = "uuid", DataFormat = DataFormat.TwosComplement)]
		public ulong uuid
		{
			get
			{
				return this._uuid ?? 0UL;
			}
			set
			{
				this._uuid = new ulong?(value);
			}
		}

		// Token: 0x170022FB RID: 8955
		// (get) Token: 0x06006E86 RID: 28294 RVA: 0x000D37BC File Offset: 0x000D19BC
		// (set) Token: 0x06006E87 RID: 28295 RVA: 0x000D37DC File Offset: 0x000D19DC
		[XmlIgnore]
		[Browsable(false)]
		public bool uuidSpecified
		{
			get
			{
				return this._uuid != null;
			}
			set
			{
				bool flag = value == (this._uuid == null);
				if (flag)
				{
					this._uuid = (value ? new ulong?(this.uuid) : null);
				}
			}
		}

		// Token: 0x06006E88 RID: 28296 RVA: 0x000D3820 File Offset: 0x000D1A20
		private bool ShouldSerializeuuid()
		{
			return this.uuidSpecified;
		}

		// Token: 0x06006E89 RID: 28297 RVA: 0x000D3838 File Offset: 0x000D1A38
		private void Resetuuid()
		{
			this.uuidSpecified = false;
		}

		// Token: 0x170022FC RID: 8956
		// (get) Token: 0x06006E8A RID: 28298 RVA: 0x000D3844 File Offset: 0x000D1A44
		// (set) Token: 0x06006E8B RID: 28299 RVA: 0x000D3865 File Offset: 0x000D1A65
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

		// Token: 0x170022FD RID: 8957
		// (get) Token: 0x06006E8C RID: 28300 RVA: 0x000D3870 File Offset: 0x000D1A70
		// (set) Token: 0x06006E8D RID: 28301 RVA: 0x000D388C File Offset: 0x000D1A8C
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

		// Token: 0x06006E8E RID: 28302 RVA: 0x000D38BC File Offset: 0x000D1ABC
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x06006E8F RID: 28303 RVA: 0x000D38D4 File Offset: 0x000D1AD4
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x06006E90 RID: 28304 RVA: 0x000D38E0 File Offset: 0x000D1AE0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A73 RID: 6771
		private ulong? _uuid;

		// Token: 0x04001A74 RID: 6772
		private string _name;

		// Token: 0x04001A75 RID: 6773
		private IExtension extensionObject;
	}
}
