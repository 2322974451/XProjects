using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020000FF RID: 255
	[ProtoContract(Name = "FetchMailRes")]
	[Serializable]
	public class FetchMailRes : IExtensible
	{
		// Token: 0x1700054B RID: 1355
		// (get) Token: 0x0600106C RID: 4204 RVA: 0x00021B20 File Offset: 0x0001FD20
		// (set) Token: 0x0600106D RID: 4205 RVA: 0x00021B4C File Offset: 0x0001FD4C
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

		// Token: 0x1700054C RID: 1356
		// (get) Token: 0x0600106E RID: 4206 RVA: 0x00021B5C File Offset: 0x0001FD5C
		// (set) Token: 0x0600106F RID: 4207 RVA: 0x00021B7C File Offset: 0x0001FD7C
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

		// Token: 0x06001070 RID: 4208 RVA: 0x00021BC0 File Offset: 0x0001FDC0
		private bool ShouldSerializepage()
		{
			return this.pageSpecified;
		}

		// Token: 0x06001071 RID: 4209 RVA: 0x00021BD8 File Offset: 0x0001FDD8
		private void Resetpage()
		{
			this.pageSpecified = false;
		}

		// Token: 0x1700054D RID: 1357
		// (get) Token: 0x06001072 RID: 4210 RVA: 0x00021BE4 File Offset: 0x0001FDE4
		// (set) Token: 0x06001073 RID: 4211 RVA: 0x00021C10 File Offset: 0x0001FE10
		[ProtoMember(2, IsRequired = false, Name = "pagecount", DataFormat = DataFormat.TwosComplement)]
		public uint pagecount
		{
			get
			{
				return this._pagecount ?? 0U;
			}
			set
			{
				this._pagecount = new uint?(value);
			}
		}

		// Token: 0x1700054E RID: 1358
		// (get) Token: 0x06001074 RID: 4212 RVA: 0x00021C20 File Offset: 0x0001FE20
		// (set) Token: 0x06001075 RID: 4213 RVA: 0x00021C40 File Offset: 0x0001FE40
		[XmlIgnore]
		[Browsable(false)]
		public bool pagecountSpecified
		{
			get
			{
				return this._pagecount != null;
			}
			set
			{
				bool flag = value == (this._pagecount == null);
				if (flag)
				{
					this._pagecount = (value ? new uint?(this.pagecount) : null);
				}
			}
		}

		// Token: 0x06001076 RID: 4214 RVA: 0x00021C84 File Offset: 0x0001FE84
		private bool ShouldSerializepagecount()
		{
			return this.pagecountSpecified;
		}

		// Token: 0x06001077 RID: 4215 RVA: 0x00021C9C File Offset: 0x0001FE9C
		private void Resetpagecount()
		{
			this.pagecountSpecified = false;
		}

		// Token: 0x1700054F RID: 1359
		// (get) Token: 0x06001078 RID: 4216 RVA: 0x00021CA8 File Offset: 0x0001FEA8
		[ProtoMember(3, Name = "mails", DataFormat = DataFormat.Default)]
		public List<SMail> mails
		{
			get
			{
				return this._mails;
			}
		}

		// Token: 0x06001079 RID: 4217 RVA: 0x00021CC0 File Offset: 0x0001FEC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400041A RID: 1050
		private uint? _page;

		// Token: 0x0400041B RID: 1051
		private uint? _pagecount;

		// Token: 0x0400041C RID: 1052
		private readonly List<SMail> _mails = new List<SMail>();

		// Token: 0x0400041D RID: 1053
		private IExtension extensionObject;
	}
}
