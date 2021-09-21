using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001E9 RID: 489
	[ProtoContract(Name = "ClearPrivateChatListArg")]
	[Serializable]
	public class ClearPrivateChatListArg : IExtensible
	{
		// Token: 0x170008D1 RID: 2257
		// (get) Token: 0x06001C1C RID: 7196 RVA: 0x0003776C File Offset: 0x0003596C
		// (set) Token: 0x06001C1D RID: 7197 RVA: 0x00037798 File Offset: 0x00035998
		[ProtoMember(1, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public uint type
		{
			get
			{
				return this._type ?? 0U;
			}
			set
			{
				this._type = new uint?(value);
			}
		}

		// Token: 0x170008D2 RID: 2258
		// (get) Token: 0x06001C1E RID: 7198 RVA: 0x000377A8 File Offset: 0x000359A8
		// (set) Token: 0x06001C1F RID: 7199 RVA: 0x000377C8 File Offset: 0x000359C8
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
					this._type = (value ? new uint?(this.type) : null);
				}
			}
		}

		// Token: 0x06001C20 RID: 7200 RVA: 0x0003780C File Offset: 0x00035A0C
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001C21 RID: 7201 RVA: 0x00037824 File Offset: 0x00035A24
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170008D3 RID: 2259
		// (get) Token: 0x06001C22 RID: 7202 RVA: 0x00037830 File Offset: 0x00035A30
		// (set) Token: 0x06001C23 RID: 7203 RVA: 0x0003785D File Offset: 0x00035A5D
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

		// Token: 0x170008D4 RID: 2260
		// (get) Token: 0x06001C24 RID: 7204 RVA: 0x0003786C File Offset: 0x00035A6C
		// (set) Token: 0x06001C25 RID: 7205 RVA: 0x0003788C File Offset: 0x00035A8C
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

		// Token: 0x06001C26 RID: 7206 RVA: 0x000378D0 File Offset: 0x00035AD0
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06001C27 RID: 7207 RVA: 0x000378E8 File Offset: 0x00035AE8
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x06001C28 RID: 7208 RVA: 0x000378F4 File Offset: 0x00035AF4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040006FE RID: 1790
		private uint? _type;

		// Token: 0x040006FF RID: 1791
		private ulong? _roleid;

		// Token: 0x04000700 RID: 1792
		private IExtension extensionObject;
	}
}
