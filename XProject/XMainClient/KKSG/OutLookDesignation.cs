using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000572 RID: 1394
	[ProtoContract(Name = "OutLookDesignation")]
	[Serializable]
	public class OutLookDesignation : IExtensible
	{
		// Token: 0x1700160A RID: 5642
		// (get) Token: 0x060047ED RID: 18413 RVA: 0x00088A34 File Offset: 0x00086C34
		// (set) Token: 0x060047EE RID: 18414 RVA: 0x00088A60 File Offset: 0x00086C60
		[ProtoMember(1, IsRequired = false, Name = "id", DataFormat = DataFormat.TwosComplement)]
		public uint id
		{
			get
			{
				return this._id ?? 0U;
			}
			set
			{
				this._id = new uint?(value);
			}
		}

		// Token: 0x1700160B RID: 5643
		// (get) Token: 0x060047EF RID: 18415 RVA: 0x00088A70 File Offset: 0x00086C70
		// (set) Token: 0x060047F0 RID: 18416 RVA: 0x00088A90 File Offset: 0x00086C90
		[XmlIgnore]
		[Browsable(false)]
		public bool idSpecified
		{
			get
			{
				return this._id != null;
			}
			set
			{
				bool flag = value == (this._id == null);
				if (flag)
				{
					this._id = (value ? new uint?(this.id) : null);
				}
			}
		}

		// Token: 0x060047F1 RID: 18417 RVA: 0x00088AD4 File Offset: 0x00086CD4
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x060047F2 RID: 18418 RVA: 0x00088AEC File Offset: 0x00086CEC
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x1700160C RID: 5644
		// (get) Token: 0x060047F3 RID: 18419 RVA: 0x00088AF8 File Offset: 0x00086CF8
		// (set) Token: 0x060047F4 RID: 18420 RVA: 0x00088B19 File Offset: 0x00086D19
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

		// Token: 0x1700160D RID: 5645
		// (get) Token: 0x060047F5 RID: 18421 RVA: 0x00088B24 File Offset: 0x00086D24
		// (set) Token: 0x060047F6 RID: 18422 RVA: 0x00088B40 File Offset: 0x00086D40
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

		// Token: 0x060047F7 RID: 18423 RVA: 0x00088B70 File Offset: 0x00086D70
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060047F8 RID: 18424 RVA: 0x00088B88 File Offset: 0x00086D88
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x060047F9 RID: 18425 RVA: 0x00088B94 File Offset: 0x00086D94
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040011FB RID: 4603
		private uint? _id;

		// Token: 0x040011FC RID: 4604
		private string _name;

		// Token: 0x040011FD RID: 4605
		private IExtension extensionObject;
	}
}
