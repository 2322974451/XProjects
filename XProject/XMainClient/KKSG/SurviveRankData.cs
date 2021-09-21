using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200058E RID: 1422
	[ProtoContract(Name = "SurviveRankData")]
	[Serializable]
	public class SurviveRankData : IExtensible
	{
		// Token: 0x17001729 RID: 5929
		// (get) Token: 0x06004B4B RID: 19275 RVA: 0x0008F2CC File Offset: 0x0008D4CC
		// (set) Token: 0x06004B4C RID: 19276 RVA: 0x0008F2F9 File Offset: 0x0008D4F9
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

		// Token: 0x1700172A RID: 5930
		// (get) Token: 0x06004B4D RID: 19277 RVA: 0x0008F308 File Offset: 0x0008D508
		// (set) Token: 0x06004B4E RID: 19278 RVA: 0x0008F328 File Offset: 0x0008D528
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

		// Token: 0x06004B4F RID: 19279 RVA: 0x0008F36C File Offset: 0x0008D56C
		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		// Token: 0x06004B50 RID: 19280 RVA: 0x0008F384 File Offset: 0x0008D584
		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		// Token: 0x1700172B RID: 5931
		// (get) Token: 0x06004B51 RID: 19281 RVA: 0x0008F390 File Offset: 0x0008D590
		// (set) Token: 0x06004B52 RID: 19282 RVA: 0x0008F3B1 File Offset: 0x0008D5B1
		[ProtoMember(2, IsRequired = false, Name = "rolename", DataFormat = DataFormat.Default)]
		public string rolename
		{
			get
			{
				return this._rolename ?? "";
			}
			set
			{
				this._rolename = value;
			}
		}

		// Token: 0x1700172C RID: 5932
		// (get) Token: 0x06004B53 RID: 19283 RVA: 0x0008F3BC File Offset: 0x0008D5BC
		// (set) Token: 0x06004B54 RID: 19284 RVA: 0x0008F3D8 File Offset: 0x0008D5D8
		[XmlIgnore]
		[Browsable(false)]
		public bool rolenameSpecified
		{
			get
			{
				return this._rolename != null;
			}
			set
			{
				bool flag = value == (this._rolename == null);
				if (flag)
				{
					this._rolename = (value ? this.rolename : null);
				}
			}
		}

		// Token: 0x06004B55 RID: 19285 RVA: 0x0008F408 File Offset: 0x0008D608
		private bool ShouldSerializerolename()
		{
			return this.rolenameSpecified;
		}

		// Token: 0x06004B56 RID: 19286 RVA: 0x0008F420 File Offset: 0x0008D620
		private void Resetrolename()
		{
			this.rolenameSpecified = false;
		}

		// Token: 0x1700172D RID: 5933
		// (get) Token: 0x06004B57 RID: 19287 RVA: 0x0008F42C File Offset: 0x0008D62C
		// (set) Token: 0x06004B58 RID: 19288 RVA: 0x0008F458 File Offset: 0x0008D658
		[ProtoMember(3, IsRequired = false, Name = "serverid", DataFormat = DataFormat.TwosComplement)]
		public uint serverid
		{
			get
			{
				return this._serverid ?? 0U;
			}
			set
			{
				this._serverid = new uint?(value);
			}
		}

		// Token: 0x1700172E RID: 5934
		// (get) Token: 0x06004B59 RID: 19289 RVA: 0x0008F468 File Offset: 0x0008D668
		// (set) Token: 0x06004B5A RID: 19290 RVA: 0x0008F488 File Offset: 0x0008D688
		[XmlIgnore]
		[Browsable(false)]
		public bool serveridSpecified
		{
			get
			{
				return this._serverid != null;
			}
			set
			{
				bool flag = value == (this._serverid == null);
				if (flag)
				{
					this._serverid = (value ? new uint?(this.serverid) : null);
				}
			}
		}

		// Token: 0x06004B5B RID: 19291 RVA: 0x0008F4CC File Offset: 0x0008D6CC
		private bool ShouldSerializeserverid()
		{
			return this.serveridSpecified;
		}

		// Token: 0x06004B5C RID: 19292 RVA: 0x0008F4E4 File Offset: 0x0008D6E4
		private void Resetserverid()
		{
			this.serveridSpecified = false;
		}

		// Token: 0x1700172F RID: 5935
		// (get) Token: 0x06004B5D RID: 19293 RVA: 0x0008F4F0 File Offset: 0x0008D6F0
		// (set) Token: 0x06004B5E RID: 19294 RVA: 0x0008F51C File Offset: 0x0008D71C
		[ProtoMember(4, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		// Token: 0x17001730 RID: 5936
		// (get) Token: 0x06004B5F RID: 19295 RVA: 0x0008F52C File Offset: 0x0008D72C
		// (set) Token: 0x06004B60 RID: 19296 RVA: 0x0008F54C File Offset: 0x0008D74C
		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		// Token: 0x06004B61 RID: 19297 RVA: 0x0008F590 File Offset: 0x0008D790
		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		// Token: 0x06004B62 RID: 19298 RVA: 0x0008F5A8 File Offset: 0x0008D7A8
		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		// Token: 0x06004B63 RID: 19299 RVA: 0x0008F5B4 File Offset: 0x0008D7B4
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012B7 RID: 4791
		private ulong? _roleid;

		// Token: 0x040012B8 RID: 4792
		private string _rolename;

		// Token: 0x040012B9 RID: 4793
		private uint? _serverid;

		// Token: 0x040012BA RID: 4794
		private uint? _point;

		// Token: 0x040012BB RID: 4795
		private IExtension extensionObject;
	}
}
