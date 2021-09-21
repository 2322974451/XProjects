using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000FE RID: 254
	[ProtoContract(Name = "FetchMailArg")]
	[Serializable]
	public class FetchMailArg : IExtensible
	{
		// Token: 0x17000547 RID: 1351
		// (get) Token: 0x0600105E RID: 4190 RVA: 0x00021964 File Offset: 0x0001FB64
		// (set) Token: 0x0600105F RID: 4191 RVA: 0x00021990 File Offset: 0x0001FB90
		[ProtoMember(1, IsRequired = false, Name = "page", DataFormat = DataFormat.TwosComplement)]
		public uint page
		{
			get
			{
				return this._page ?? 0U;
			}
			set
			{
				this._page = new uint?(value);
			}
		}

		// Token: 0x17000548 RID: 1352
		// (get) Token: 0x06001060 RID: 4192 RVA: 0x000219A0 File Offset: 0x0001FBA0
		// (set) Token: 0x06001061 RID: 4193 RVA: 0x000219C0 File Offset: 0x0001FBC0
		[XmlIgnore]
		[Browsable(false)]
		public bool pageSpecified
		{
			get
			{
				return this._page != null;
			}
			set
			{
				bool flag = value == (this._page == null);
				if (flag)
				{
					this._page = (value ? new uint?(this.page) : null);
				}
			}
		}

		// Token: 0x06001062 RID: 4194 RVA: 0x00021A04 File Offset: 0x0001FC04
		private bool ShouldSerializepage()
		{
			return this.pageSpecified;
		}

		// Token: 0x06001063 RID: 4195 RVA: 0x00021A1C File Offset: 0x0001FC1C
		private void Resetpage()
		{
			this.pageSpecified = false;
		}

		// Token: 0x17000549 RID: 1353
		// (get) Token: 0x06001064 RID: 4196 RVA: 0x00021A28 File Offset: 0x0001FC28
		// (set) Token: 0x06001065 RID: 4197 RVA: 0x00021A54 File Offset: 0x0001FC54
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

		// Token: 0x1700054A RID: 1354
		// (get) Token: 0x06001066 RID: 4198 RVA: 0x00021A64 File Offset: 0x0001FC64
		// (set) Token: 0x06001067 RID: 4199 RVA: 0x00021A84 File Offset: 0x0001FC84
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

		// Token: 0x06001068 RID: 4200 RVA: 0x00021AC8 File Offset: 0x0001FCC8
		private bool ShouldSerializecount()
		{
			return this.countSpecified;
		}

		// Token: 0x06001069 RID: 4201 RVA: 0x00021AE0 File Offset: 0x0001FCE0
		private void Resetcount()
		{
			this.countSpecified = false;
		}

		// Token: 0x0600106A RID: 4202 RVA: 0x00021AEC File Offset: 0x0001FCEC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000417 RID: 1047
		private uint? _page;

		// Token: 0x04000418 RID: 1048
		private uint? _count;

		// Token: 0x04000419 RID: 1049
		private IExtension extensionObject;
	}
}
