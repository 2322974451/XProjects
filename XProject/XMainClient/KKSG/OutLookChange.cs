using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000127 RID: 295
	[ProtoContract(Name = "OutLookChange")]
	[Serializable]
	public class OutLookChange : IExtensible
	{
		// Token: 0x170005D3 RID: 1491
		// (get) Token: 0x06001235 RID: 4661 RVA: 0x00024FEC File Offset: 0x000231EC
		// (set) Token: 0x06001236 RID: 4662 RVA: 0x00025019 File Offset: 0x00023219
		[ProtoMember(1, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		// Token: 0x170005D4 RID: 1492
		// (get) Token: 0x06001237 RID: 4663 RVA: 0x00025028 File Offset: 0x00023228
		// (set) Token: 0x06001238 RID: 4664 RVA: 0x00025048 File Offset: 0x00023248
		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		// Token: 0x06001239 RID: 4665 RVA: 0x0002508C File Offset: 0x0002328C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x0600123A RID: 4666 RVA: 0x000250A4 File Offset: 0x000232A4
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x170005D5 RID: 1493
		// (get) Token: 0x0600123B RID: 4667 RVA: 0x000250B0 File Offset: 0x000232B0
		// (set) Token: 0x0600123C RID: 4668 RVA: 0x000250C8 File Offset: 0x000232C8
		[ProtoMember(2, IsRequired = false, Name = "outlook", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public OutLook outlook
		{
			get
			{
				return this._outlook;
			}
			set
			{
				this._outlook = value;
			}
		}

		// Token: 0x0600123D RID: 4669 RVA: 0x000250D4 File Offset: 0x000232D4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400048F RID: 1167
		private ulong? _roleid;

		// Token: 0x04000490 RID: 1168
		private OutLook _outlook = null;

		// Token: 0x04000491 RID: 1169
		private IExtension extensionObject;
	}
}
