using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020002D6 RID: 726
	[ProtoContract(Name = "DonateMemberItemArg")]
	[Serializable]
	public class DonateMemberItemArg : IExtensible
	{
		// Token: 0x17000C70 RID: 3184
		// (get) Token: 0x06002801 RID: 10241 RVA: 0x0004DC10 File Offset: 0x0004BE10
		// (set) Token: 0x06002802 RID: 10242 RVA: 0x0004DC3C File Offset: 0x0004BE3C
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

		// Token: 0x17000C71 RID: 3185
		// (get) Token: 0x06002803 RID: 10243 RVA: 0x0004DC4C File Offset: 0x0004BE4C
		// (set) Token: 0x06002804 RID: 10244 RVA: 0x0004DC6C File Offset: 0x0004BE6C
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

		// Token: 0x06002805 RID: 10245 RVA: 0x0004DCB0 File Offset: 0x0004BEB0
		private bool ShouldSerializeid()
		{
			return this.idSpecified;
		}

		// Token: 0x06002806 RID: 10246 RVA: 0x0004DCC8 File Offset: 0x0004BEC8
		private void Resetid()
		{
			this.idSpecified = false;
		}

		// Token: 0x17000C72 RID: 3186
		// (get) Token: 0x06002807 RID: 10247 RVA: 0x0004DCD4 File Offset: 0x0004BED4
		// (set) Token: 0x06002808 RID: 10248 RVA: 0x0004DD00 File Offset: 0x0004BF00
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

		// Token: 0x17000C73 RID: 3187
		// (get) Token: 0x06002809 RID: 10249 RVA: 0x0004DD10 File Offset: 0x0004BF10
		// (set) Token: 0x0600280A RID: 10250 RVA: 0x0004DD30 File Offset: 0x0004BF30
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

		// Token: 0x0600280B RID: 10251 RVA: 0x0004DD74 File Offset: 0x0004BF74
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x0600280C RID: 10252 RVA: 0x0004DD8C File Offset: 0x0004BF8C
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x17000C74 RID: 3188
		// (get) Token: 0x0600280D RID: 10253 RVA: 0x0004DD98 File Offset: 0x0004BF98
		[ProtoMember(3, Name = "itemuid", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> itemuid
		{
			get
			{
				return this._itemuid;
			}
		}

		// Token: 0x0600280E RID: 10254 RVA: 0x0004DDB0 File Offset: 0x0004BFB0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040009F5 RID: 2549
		private uint? _id;

		// Token: 0x040009F6 RID: 2550
		private uint? _count;

		// Token: 0x040009F7 RID: 2551
		private readonly List<ulong> _itemuid = new List<ulong>();

		// Token: 0x040009F8 RID: 2552
		private IExtension extensionObject;
	}
}
