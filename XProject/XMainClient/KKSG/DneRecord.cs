using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020005F6 RID: 1526
	[ProtoContract(Name = "DneRecord")]
	[Serializable]
	public class DneRecord : IExtensible
	{
		// Token: 0x17001C63 RID: 7267
		// (get) Token: 0x06005ACC RID: 23244 RVA: 0x000ACE10 File Offset: 0x000AB010
		// (set) Token: 0x06005ACD RID: 23245 RVA: 0x000ACE3C File Offset: 0x000AB03C
		[ProtoMember(1, IsRequired = false, Name = "dneid", DataFormat = DataFormat.TwosComplement)]
		public uint dneid
		{
			get
			{
				return this._dneid ?? 0U;
			}
			set
			{
				this._dneid = new uint?(value);
			}
		}

		// Token: 0x17001C64 RID: 7268
		// (get) Token: 0x06005ACE RID: 23246 RVA: 0x000ACE4C File Offset: 0x000AB04C
		// (set) Token: 0x06005ACF RID: 23247 RVA: 0x000ACE6C File Offset: 0x000AB06C
		[XmlIgnore]
		[Browsable(false)]
		public bool dneidSpecified
		{
			get
			{
				return this._dneid != null;
			}
			set
			{
				bool flag = value == (this._dneid == null);
				if (flag)
				{
					this._dneid = (value ? new uint?(this.dneid) : null);
				}
			}
		}

		// Token: 0x06005AD0 RID: 23248 RVA: 0x000ACEB0 File Offset: 0x000AB0B0
		private bool ShouldSerializedneid()
		{
			return this.dneidSpecified;
		}

		// Token: 0x06005AD1 RID: 23249 RVA: 0x000ACEC8 File Offset: 0x000AB0C8
		private void Resetdneid()
		{
			this.dneidSpecified = false;
		}

		// Token: 0x17001C65 RID: 7269
		// (get) Token: 0x06005AD2 RID: 23250 RVA: 0x000ACED4 File Offset: 0x000AB0D4
		// (set) Token: 0x06005AD3 RID: 23251 RVA: 0x000ACF00 File Offset: 0x000AB100
		[ProtoMember(2, IsRequired = false, Name = "count", DataFormat = DataFormat.TwosComplement)]
		public uint count
		{
			get
			{
				return this._count ?? 0U;
			}
			set
			{
				this._count = new uint?(value);
			}
		}

		// Token: 0x17001C66 RID: 7270
		// (get) Token: 0x06005AD4 RID: 23252 RVA: 0x000ACF10 File Offset: 0x000AB110
		// (set) Token: 0x06005AD5 RID: 23253 RVA: 0x000ACF30 File Offset: 0x000AB130
		[XmlIgnore]
		[Browsable(false)]
		public bool countSpecified
		{
			get
			{
				return this._count != null;
			}
			set
			{
				bool flag = value == (this._count == null);
				if (flag)
				{
					this._count = (value ? new uint?(this.count) : null);
				}
			}
		}

		// Token: 0x06005AD6 RID: 23254 RVA: 0x000ACF74 File Offset: 0x000AB174
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06005AD7 RID: 23255 RVA: 0x000ACF8C File Offset: 0x000AB18C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x06005AD8 RID: 23256 RVA: 0x000ACF98 File Offset: 0x000AB198
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001617 RID: 5655
		private uint? _dneid;

		// Token: 0x04001618 RID: 5656
		private uint? _count;

		// Token: 0x04001619 RID: 5657
		private IExtension extensionObject;
	}
}
