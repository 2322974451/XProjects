using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000360 RID: 864
	[ProtoContract(Name = "DoodadItemUseNtf")]
	[Serializable]
	public class DoodadItemUseNtf : IExtensible
	{
		// Token: 0x17000EA1 RID: 3745
		// (get) Token: 0x06002F3A RID: 12090 RVA: 0x0005B2B0 File Offset: 0x000594B0
		// (set) Token: 0x06002F3B RID: 12091 RVA: 0x0005B2DC File Offset: 0x000594DC
		[ProtoMember(1, IsRequired = false, Name = "buffid", DataFormat = DataFormat.TwosComplement)]
		public uint buffid
		{
			get
			{
				return this._buffid ?? 0U;
			}
			set
			{
				this._buffid = new uint?(value);
			}
		}

		// Token: 0x17000EA2 RID: 3746
		// (get) Token: 0x06002F3C RID: 12092 RVA: 0x0005B2EC File Offset: 0x000594EC
		// (set) Token: 0x06002F3D RID: 12093 RVA: 0x0005B30C File Offset: 0x0005950C
		[XmlIgnore]
		[Browsable(false)]
		public bool buffidSpecified
		{
			get
			{
				return this._buffid != null;
			}
			set
			{
				bool flag = value == (this._buffid == null);
				if (flag)
				{
					this._buffid = (value ? new uint?(this.buffid) : null);
				}
			}
		}

		// Token: 0x06002F3E RID: 12094 RVA: 0x0005B350 File Offset: 0x00059550
		private bool ShouldSerializebuffid()
		{
			return this.buffidSpecified;
		}

		// Token: 0x06002F3F RID: 12095 RVA: 0x0005B368 File Offset: 0x00059568
		private void Resetbuffid()
		{
			this.buffidSpecified = false;
		}

		// Token: 0x17000EA3 RID: 3747
		// (get) Token: 0x06002F40 RID: 12096 RVA: 0x0005B374 File Offset: 0x00059574
		// (set) Token: 0x06002F41 RID: 12097 RVA: 0x0005B3A1 File Offset: 0x000595A1
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

		// Token: 0x17000EA4 RID: 3748
		// (get) Token: 0x06002F42 RID: 12098 RVA: 0x0005B3B0 File Offset: 0x000595B0
		// (set) Token: 0x06002F43 RID: 12099 RVA: 0x0005B3D0 File Offset: 0x000595D0
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

		// Token: 0x06002F44 RID: 12100 RVA: 0x0005B414 File Offset: 0x00059614
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06002F45 RID: 12101 RVA: 0x0005B42C File Offset: 0x0005962C
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06002F46 RID: 12102 RVA: 0x0005B438 File Offset: 0x00059638
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000BB6 RID: 2998
		private uint? _buffid;

		// Token: 0x04000BB7 RID: 2999
		private ulong? _roleid;

		// Token: 0x04000BB8 RID: 3000
		private IExtension extensionObject;
	}
}
