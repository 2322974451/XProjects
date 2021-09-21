using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000242 RID: 578
	[ProtoContract(Name = "GmfReadyArg")]
	[Serializable]
	public class GmfReadyArg : IExtensible
	{
		// Token: 0x17000A01 RID: 2561
		// (get) Token: 0x06002016 RID: 8214 RVA: 0x0003EDF0 File Offset: 0x0003CFF0
		// (set) Token: 0x06002017 RID: 8215 RVA: 0x0003EE1C File Offset: 0x0003D01C
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public GMFReadyType type
		{
			get
			{
				return this._type ?? GMFReadyType.GMF_READY_UP;
			}
			set
			{
				this._type = new GMFReadyType?(value);
			}
		}

		// Token: 0x17000A02 RID: 2562
		// (get) Token: 0x06002018 RID: 8216 RVA: 0x0003EE2C File Offset: 0x0003D02C
		// (set) Token: 0x06002019 RID: 8217 RVA: 0x0003EE4C File Offset: 0x0003D04C
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
					this._type = (value ? new GMFReadyType?(this.type) : null);
				}
			}
		}

		// Token: 0x0600201A RID: 8218 RVA: 0x0003EE90 File Offset: 0x0003D090
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x0600201B RID: 8219 RVA: 0x0003EEA8 File Offset: 0x0003D0A8
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x17000A03 RID: 2563
		// (get) Token: 0x0600201C RID: 8220 RVA: 0x0003EEB4 File Offset: 0x0003D0B4
		// (set) Token: 0x0600201D RID: 8221 RVA: 0x0003EEE1 File Offset: 0x0003D0E1
		[ProtoMember(2, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
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

		// Token: 0x17000A04 RID: 2564
		// (get) Token: 0x0600201E RID: 8222 RVA: 0x0003EEF0 File Offset: 0x0003D0F0
		// (set) Token: 0x0600201F RID: 8223 RVA: 0x0003EF10 File Offset: 0x0003D110
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

		// Token: 0x06002020 RID: 8224 RVA: 0x0003EF54 File Offset: 0x0003D154
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06002021 RID: 8225 RVA: 0x0003EF6C File Offset: 0x0003D16C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06002022 RID: 8226 RVA: 0x0003EF78 File Offset: 0x0003D178
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000803 RID: 2051
		private GMFReadyType? _type;

		// Token: 0x04000804 RID: 2052
		private ulong? _roleid;

		// Token: 0x04000805 RID: 2053
		private IExtension extensionObject;
	}
}
