using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000078 RID: 120
	[ProtoContract(Name = "AddBlackListArg")]
	[Serializable]
	public class AddBlackListArg : IExtensible
	{
		// Token: 0x17000292 RID: 658
		// (get) Token: 0x060007EF RID: 2031 RVA: 0x00011BC8 File Offset: 0x0000FDC8
		// (set) Token: 0x060007F0 RID: 2032 RVA: 0x00011BF5 File Offset: 0x0000FDF5
		[ProtoMember(1, IsRequired = false, Name = "otherroleid", DataFormat = DataFormat.TwosComplement)]
		public ulong otherroleid
		{
			get
			{
				return this._otherroleid ?? 0UL;
			}
			set
			{
				this._otherroleid = new ulong?(value);
			}
		}

		// Token: 0x17000293 RID: 659
		// (get) Token: 0x060007F1 RID: 2033 RVA: 0x00011C04 File Offset: 0x0000FE04
		// (set) Token: 0x060007F2 RID: 2034 RVA: 0x00011C24 File Offset: 0x0000FE24
		[XmlIgnore]
		[Browsable(false)]
		public bool otherroleidSpecified
		{
			get
			{
				return this._otherroleid != null;
			}
			set
			{
				bool flag = value == (this._otherroleid == null);
				if (flag)
				{
					this._otherroleid = (value ? new ulong?(this.otherroleid) : null);
				}
			}
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x00011C68 File Offset: 0x0000FE68
		private bool ShouldSerializeotherroleid()
		{
			return this.otherroleidSpecified;
		}

		// Token: 0x060007F4 RID: 2036 RVA: 0x00011C80 File Offset: 0x0000FE80
		private void Resetotherroleid()
		{
			this.otherroleidSpecified = false;
		}

		// Token: 0x17000294 RID: 660
		// (get) Token: 0x060007F5 RID: 2037 RVA: 0x00011C8C File Offset: 0x0000FE8C
		// (set) Token: 0x060007F6 RID: 2038 RVA: 0x00011CAD File Offset: 0x0000FEAD
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

		// Token: 0x17000295 RID: 661
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x00011CB8 File Offset: 0x0000FEB8
		// (set) Token: 0x060007F8 RID: 2040 RVA: 0x00011CD4 File Offset: 0x0000FED4
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

		// Token: 0x060007F9 RID: 2041 RVA: 0x00011D04 File Offset: 0x0000FF04
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060007FA RID: 2042 RVA: 0x00011D1C File Offset: 0x0000FF1C
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x060007FB RID: 2043 RVA: 0x00011D28 File Offset: 0x0000FF28
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000201 RID: 513
		private ulong? _otherroleid;

		// Token: 0x04000202 RID: 514
		private string _name;

		// Token: 0x04000203 RID: 515
		private IExtension extensionObject;
	}
}
