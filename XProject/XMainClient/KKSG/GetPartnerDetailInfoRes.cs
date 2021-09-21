using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200031A RID: 794
	[ProtoContract(Name = "GetPartnerDetailInfoRes")]
	[Serializable]
	public class GetPartnerDetailInfoRes : IExtensible
	{
		// Token: 0x17000D78 RID: 3448
		// (get) Token: 0x06002B7A RID: 11130 RVA: 0x0005439C File Offset: 0x0005259C
		// (set) Token: 0x06002B7B RID: 11131 RVA: 0x000543C8 File Offset: 0x000525C8
		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		// Token: 0x17000D79 RID: 3449
		// (get) Token: 0x06002B7C RID: 11132 RVA: 0x000543D8 File Offset: 0x000525D8
		// (set) Token: 0x06002B7D RID: 11133 RVA: 0x000543F8 File Offset: 0x000525F8
		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		// Token: 0x06002B7E RID: 11134 RVA: 0x0005443C File Offset: 0x0005263C
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06002B7F RID: 11135 RVA: 0x00054454 File Offset: 0x00052654
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000D7A RID: 3450
		// (get) Token: 0x06002B80 RID: 11136 RVA: 0x00054460 File Offset: 0x00052660
		[ProtoMember(2, Name = "members", DataFormat = DataFormat.Default)]
		public List<PartnerMemberDetail> members
		{
			get
			{
				return this._members;
			}
		}

		// Token: 0x17000D7B RID: 3451
		// (get) Token: 0x06002B81 RID: 11137 RVA: 0x00054478 File Offset: 0x00052678
		// (set) Token: 0x06002B82 RID: 11138 RVA: 0x000544A4 File Offset: 0x000526A4
		[ProtoMember(3, IsRequired = false, Name = "shop_redpoint", DataFormat = DataFormat.Default)]
		public bool shop_redpoint
		{
			get
			{
				return this._shop_redpoint ?? false;
			}
			set
			{
				this._shop_redpoint = new bool?(value);
			}
		}

		// Token: 0x17000D7C RID: 3452
		// (get) Token: 0x06002B83 RID: 11139 RVA: 0x000544B4 File Offset: 0x000526B4
		// (set) Token: 0x06002B84 RID: 11140 RVA: 0x000544D4 File Offset: 0x000526D4
		[XmlIgnore]
		[Browsable(false)]
		public bool shop_redpointSpecified
		{
			get
			{
				return this._shop_redpoint != null;
			}
			set
			{
				bool flag = value == (this._shop_redpoint == null);
				if (flag)
				{
					this._shop_redpoint = (value ? new bool?(this.shop_redpoint) : null);
				}
			}
		}

		// Token: 0x06002B85 RID: 11141 RVA: 0x00054518 File Offset: 0x00052718
		private bool ShouldSerializeshop_redpoint()
		{
			return this.shop_redpointSpecified;
		}

		// Token: 0x06002B86 RID: 11142 RVA: 0x00054530 File Offset: 0x00052730
		private void Resetshop_redpoint()
		{
			this.shop_redpointSpecified = false;
		}

		// Token: 0x17000D7D RID: 3453
		// (get) Token: 0x06002B87 RID: 11143 RVA: 0x0005453C File Offset: 0x0005273C
		// (set) Token: 0x06002B88 RID: 11144 RVA: 0x00054568 File Offset: 0x00052768
		[ProtoMember(4, IsRequired = false, Name = "liveness_redpoint", DataFormat = DataFormat.Default)]
		public bool liveness_redpoint
		{
			get
			{
				return this._liveness_redpoint ?? false;
			}
			set
			{
				this._liveness_redpoint = new bool?(value);
			}
		}

		// Token: 0x17000D7E RID: 3454
		// (get) Token: 0x06002B89 RID: 11145 RVA: 0x00054578 File Offset: 0x00052778
		// (set) Token: 0x06002B8A RID: 11146 RVA: 0x00054598 File Offset: 0x00052798
		[XmlIgnore]
		[Browsable(false)]
		public bool liveness_redpointSpecified
		{
			get
			{
				return this._liveness_redpoint != null;
			}
			set
			{
				bool flag = value == (this._liveness_redpoint == null);
				if (flag)
				{
					this._liveness_redpoint = (value ? new bool?(this.liveness_redpoint) : null);
				}
			}
		}

		// Token: 0x06002B8B RID: 11147 RVA: 0x000545DC File Offset: 0x000527DC
		private bool ShouldSerializeliveness_redpoint()
		{
			return this.liveness_redpointSpecified;
		}

		// Token: 0x06002B8C RID: 11148 RVA: 0x000545F4 File Offset: 0x000527F4
		private void Resetliveness_redpoint()
		{
			this.liveness_redpointSpecified = false;
		}

		// Token: 0x17000D7F RID: 3455
		// (get) Token: 0x06002B8D RID: 11149 RVA: 0x00054600 File Offset: 0x00052800
		// (set) Token: 0x06002B8E RID: 11150 RVA: 0x0005462C File Offset: 0x0005282C
		[ProtoMember(5, IsRequired = false, Name = "degree", DataFormat = DataFormat.TwosComplement)]
		public uint degree
		{
			get
			{
				return this._degree ?? 0U;
			}
			set
			{
				this._degree = new uint?(value);
			}
		}

		// Token: 0x17000D80 RID: 3456
		// (get) Token: 0x06002B8F RID: 11151 RVA: 0x0005463C File Offset: 0x0005283C
		// (set) Token: 0x06002B90 RID: 11152 RVA: 0x0005465C File Offset: 0x0005285C
		[XmlIgnore]
		[Browsable(false)]
		public bool degreeSpecified
		{
			get
			{
				return this._degree != null;
			}
			set
			{
				bool flag = value == (this._degree == null);
				if (flag)
				{
					this._degree = (value ? new uint?(this.degree) : null);
				}
			}
		}

		// Token: 0x06002B91 RID: 11153 RVA: 0x000546A0 File Offset: 0x000528A0
		private bool ShouldSerializedegree()
		{
			return this.degreeSpecified;
		}

		// Token: 0x06002B92 RID: 11154 RVA: 0x000546B8 File Offset: 0x000528B8
		private void Resetdegree()
		{
			this.degreeSpecified = false;
		}

		// Token: 0x17000D81 RID: 3457
		// (get) Token: 0x06002B93 RID: 11155 RVA: 0x000546C4 File Offset: 0x000528C4
		// (set) Token: 0x06002B94 RID: 11156 RVA: 0x000546F0 File Offset: 0x000528F0
		[ProtoMember(6, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		// Token: 0x17000D82 RID: 3458
		// (get) Token: 0x06002B95 RID: 11157 RVA: 0x00054700 File Offset: 0x00052900
		// (set) Token: 0x06002B96 RID: 11158 RVA: 0x00054720 File Offset: 0x00052920
		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		// Token: 0x06002B97 RID: 11159 RVA: 0x00054764 File Offset: 0x00052964
		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		// Token: 0x06002B98 RID: 11160 RVA: 0x0005477C File Offset: 0x0005297C
		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		// Token: 0x17000D83 RID: 3459
		// (get) Token: 0x06002B99 RID: 11161 RVA: 0x00054788 File Offset: 0x00052988
		// (set) Token: 0x06002B9A RID: 11162 RVA: 0x000547B5 File Offset: 0x000529B5
		[ProtoMember(7, IsRequired = false, Name = "partnerid", DataFormat = DataFormat.TwosComplement)]
		public ulong partnerid
		{
			get
			{
				return this._partnerid ?? 0UL;
			}
			set
			{
				this._partnerid = new ulong?(value);
			}
		}

		// Token: 0x17000D84 RID: 3460
		// (get) Token: 0x06002B9B RID: 11163 RVA: 0x000547C4 File Offset: 0x000529C4
		// (set) Token: 0x06002B9C RID: 11164 RVA: 0x000547E4 File Offset: 0x000529E4
		[XmlIgnore]
		[Browsable(false)]
		public bool partneridSpecified
		{
			get
			{
				return this._partnerid != null;
			}
			set
			{
				bool flag = value == (this._partnerid == null);
				if (flag)
				{
					this._partnerid = (value ? new ulong?(this.partnerid) : null);
				}
			}
		}

		// Token: 0x06002B9D RID: 11165 RVA: 0x00054828 File Offset: 0x00052A28
		private bool ShouldSerializepartnerid()
		{
			return this.partneridSpecified;
		}

		// Token: 0x06002B9E RID: 11166 RVA: 0x00054840 File Offset: 0x00052A40
		private void Resetpartnerid()
		{
			this.partneridSpecified = false;
		}

		// Token: 0x06002B9F RID: 11167 RVA: 0x0005484C File Offset: 0x00052A4C
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000AC8 RID: 2760
		private ErrorCode? _result;

		// Token: 0x04000AC9 RID: 2761
		private readonly List<PartnerMemberDetail> _members = new List<PartnerMemberDetail>();

		// Token: 0x04000ACA RID: 2762
		private bool? _shop_redpoint;

		// Token: 0x04000ACB RID: 2763
		private bool? _liveness_redpoint;

		// Token: 0x04000ACC RID: 2764
		private uint? _degree;

		// Token: 0x04000ACD RID: 2765
		private uint? _level;

		// Token: 0x04000ACE RID: 2766
		private ulong? _partnerid;

		// Token: 0x04000ACF RID: 2767
		private IExtension extensionObject;
	}
}
