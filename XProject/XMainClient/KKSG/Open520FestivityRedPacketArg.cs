using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000559 RID: 1369
	[ProtoContract(Name = "Open520FestivityRedPacketArg")]
	[Serializable]
	public class Open520FestivityRedPacketArg : IExtensible
	{
		// Token: 0x1700155A RID: 5466
		// (get) Token: 0x060045ED RID: 17901 RVA: 0x00084DAC File Offset: 0x00082FAC
		// (set) Token: 0x060045EE RID: 17902 RVA: 0x00084DD8 File Offset: 0x00082FD8
		[ProtoMember(1, IsRequired = false, Name = "num", DataFormat = DataFormat.TwosComplement)]
		public uint num
		{
			get
			{
				return this._num ?? 0U;
			}
			set
			{
				this._num = new uint?(value);
			}
		}

		// Token: 0x1700155B RID: 5467
		// (get) Token: 0x060045EF RID: 17903 RVA: 0x00084DE8 File Offset: 0x00082FE8
		// (set) Token: 0x060045F0 RID: 17904 RVA: 0x00084E08 File Offset: 0x00083008
		[XmlIgnore]
		[Browsable(false)]
		public bool numSpecified
		{
			get
			{
				return this._num != null;
			}
			set
			{
				bool flag = value == (this._num == null);
				if (flag)
				{
					this._num = (value ? new uint?(this.num) : null);
				}
			}
		}

		// Token: 0x060045F1 RID: 17905 RVA: 0x00084E4C File Offset: 0x0008304C
		private bool ShouldSerializenum()
		{
			return this.numSpecified;
		}

		// Token: 0x060045F2 RID: 17906 RVA: 0x00084E64 File Offset: 0x00083064
		private void Resetnum()
		{
			this.numSpecified = false;
		}

		// Token: 0x1700155C RID: 5468
		// (get) Token: 0x060045F3 RID: 17907 RVA: 0x00084E70 File Offset: 0x00083070
		// (set) Token: 0x060045F4 RID: 17908 RVA: 0x00084E91 File Offset: 0x00083091
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

		// Token: 0x1700155D RID: 5469
		// (get) Token: 0x060045F5 RID: 17909 RVA: 0x00084E9C File Offset: 0x0008309C
		// (set) Token: 0x060045F6 RID: 17910 RVA: 0x00084EB8 File Offset: 0x000830B8
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

		// Token: 0x060045F7 RID: 17911 RVA: 0x00084EE8 File Offset: 0x000830E8
		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		// Token: 0x060045F8 RID: 17912 RVA: 0x00084F00 File Offset: 0x00083100
		private void Resetname()
		{
			this.nameSpecified = false;
		}

		// Token: 0x060045F9 RID: 17913 RVA: 0x00084F0C File Offset: 0x0008310C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001175 RID: 4469
		private uint? _num;

		// Token: 0x04001176 RID: 4470
		private string _name;

		// Token: 0x04001177 RID: 4471
		private IExtension extensionObject;
	}
}
