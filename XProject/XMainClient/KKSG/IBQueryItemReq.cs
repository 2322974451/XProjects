using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020001F5 RID: 501
	[ProtoContract(Name = "IBQueryItemReq")]
	[Serializable]
	public class IBQueryItemReq : IExtensible
	{
		// Token: 0x170008F0 RID: 2288
		// (get) Token: 0x06001C8C RID: 7308 RVA: 0x00038408 File Offset: 0x00036608
		// (set) Token: 0x06001C8D RID: 7309 RVA: 0x00038434 File Offset: 0x00036634
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

		// Token: 0x170008F1 RID: 2289
		// (get) Token: 0x06001C8E RID: 7310 RVA: 0x00038444 File Offset: 0x00036644
		// (set) Token: 0x06001C8F RID: 7311 RVA: 0x00038464 File Offset: 0x00036664
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

		// Token: 0x06001C90 RID: 7312 RVA: 0x000384A8 File Offset: 0x000366A8
		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		// Token: 0x06001C91 RID: 7313 RVA: 0x000384C0 File Offset: 0x000366C0
		private void Resettype()
		{
			this.typeSpecified = false;
		}

		// Token: 0x170008F2 RID: 2290
		// (get) Token: 0x06001C92 RID: 7314 RVA: 0x000384CC File Offset: 0x000366CC
		// (set) Token: 0x06001C93 RID: 7315 RVA: 0x000384F8 File Offset: 0x000366F8
		[ProtoMember(2, IsRequired = false, Name = "subtype", DataFormat = DataFormat.TwosComplement)]
		public uint subtype
		{
			get
			{
				return this._subtype ?? 0U;
			}
			set
			{
				this._subtype = new uint?(value);
			}
		}

		// Token: 0x170008F3 RID: 2291
		// (get) Token: 0x06001C94 RID: 7316 RVA: 0x00038508 File Offset: 0x00036708
		// (set) Token: 0x06001C95 RID: 7317 RVA: 0x00038528 File Offset: 0x00036728
		[XmlIgnore]
		[Browsable(false)]
		public bool subtypeSpecified
		{
			get
			{
				return this._subtype != null;
			}
			set
			{
				bool flag = value == (this._subtype == null);
				if (flag)
				{
					this._subtype = (value ? new uint?(this.subtype) : null);
				}
			}
		}

		// Token: 0x06001C96 RID: 7318 RVA: 0x0003856C File Offset: 0x0003676C
		private bool ShouldSerializesubtype()
		{
			return this.subtypeSpecified;
		}

		// Token: 0x06001C97 RID: 7319 RVA: 0x00038584 File Offset: 0x00036784
		private void Resetsubtype()
		{
			this.subtypeSpecified = false;
		}

		// Token: 0x06001C98 RID: 7320 RVA: 0x00038590 File Offset: 0x00036790
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400071B RID: 1819
		private uint? _type;

		// Token: 0x0400071C RID: 1820
		private uint? _subtype;

		// Token: 0x0400071D RID: 1821
		private IExtension extensionObject;
	}
}
