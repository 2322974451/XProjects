using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x020004E7 RID: 1255
	[ProtoContract(Name = "GetCompeteDragonInfoRes")]
	[Serializable]
	public class GetCompeteDragonInfoRes : IExtensible
	{
		// Token: 0x170013D2 RID: 5074
		// (get) Token: 0x060040C8 RID: 16584 RVA: 0x0007B58C File Offset: 0x0007978C
		// (set) Token: 0x060040C9 RID: 16585 RVA: 0x0007B5B8 File Offset: 0x000797B8
		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		// Token: 0x170013D3 RID: 5075
		// (get) Token: 0x060040CA RID: 16586 RVA: 0x0007B5C8 File Offset: 0x000797C8
		// (set) Token: 0x060040CB RID: 16587 RVA: 0x0007B5E8 File Offset: 0x000797E8
		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		// Token: 0x060040CC RID: 16588 RVA: 0x0007B62C File Offset: 0x0007982C
		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		// Token: 0x060040CD RID: 16589 RVA: 0x0007B644 File Offset: 0x00079844
		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		// Token: 0x170013D4 RID: 5076
		// (get) Token: 0x060040CE RID: 16590 RVA: 0x0007B650 File Offset: 0x00079850
		// (set) Token: 0x060040CF RID: 16591 RVA: 0x0007B67C File Offset: 0x0007987C
		[ProtoMember(2, IsRequired = false, Name = "leftRewardCount", DataFormat = DataFormat.TwosComplement)]
		public int leftRewardCount
		{
			get
			{
				return this._leftRewardCount ?? 0;
			}
			set
			{
				this._leftRewardCount = new int?(value);
			}
		}

		// Token: 0x170013D5 RID: 5077
		// (get) Token: 0x060040D0 RID: 16592 RVA: 0x0007B68C File Offset: 0x0007988C
		// (set) Token: 0x060040D1 RID: 16593 RVA: 0x0007B6AC File Offset: 0x000798AC
		[XmlIgnore]
		[Browsable(false)]
		public bool leftRewardCountSpecified
		{
			get
			{
				return this._leftRewardCount != null;
			}
			set
			{
				bool flag = value == (this._leftRewardCount == null);
				if (flag)
				{
					this._leftRewardCount = (value ? new int?(this.leftRewardCount) : null);
				}
			}
		}

		// Token: 0x060040D2 RID: 16594 RVA: 0x0007B6F0 File Offset: 0x000798F0
		private bool ShouldSerializeleftRewardCount()
		{
			return this.leftRewardCountSpecified;
		}

		// Token: 0x060040D3 RID: 16595 RVA: 0x0007B708 File Offset: 0x00079908
		private void ResetleftRewardCount()
		{
			this.leftRewardCountSpecified = false;
		}

		// Token: 0x170013D6 RID: 5078
		// (get) Token: 0x060040D4 RID: 16596 RVA: 0x0007B714 File Offset: 0x00079914
		// (set) Token: 0x060040D5 RID: 16597 RVA: 0x0007B740 File Offset: 0x00079940
		[ProtoMember(3, IsRequired = false, Name = "totalRewardCount", DataFormat = DataFormat.TwosComplement)]
		public int totalRewardCount
		{
			get
			{
				return this._totalRewardCount ?? 0;
			}
			set
			{
				this._totalRewardCount = new int?(value);
			}
		}

		// Token: 0x170013D7 RID: 5079
		// (get) Token: 0x060040D6 RID: 16598 RVA: 0x0007B750 File Offset: 0x00079950
		// (set) Token: 0x060040D7 RID: 16599 RVA: 0x0007B770 File Offset: 0x00079970
		[XmlIgnore]
		[Browsable(false)]
		public bool totalRewardCountSpecified
		{
			get
			{
				return this._totalRewardCount != null;
			}
			set
			{
				bool flag = value == (this._totalRewardCount == null);
				if (flag)
				{
					this._totalRewardCount = (value ? new int?(this.totalRewardCount) : null);
				}
			}
		}

		// Token: 0x060040D8 RID: 16600 RVA: 0x0007B7B4 File Offset: 0x000799B4
		private bool ShouldSerializetotalRewardCount()
		{
			return this.totalRewardCountSpecified;
		}

		// Token: 0x060040D9 RID: 16601 RVA: 0x0007B7CC File Offset: 0x000799CC
		private void ResettotalRewardCount()
		{
			this.totalRewardCountSpecified = false;
		}

		// Token: 0x170013D8 RID: 5080
		// (get) Token: 0x060040DA RID: 16602 RVA: 0x0007B7D8 File Offset: 0x000799D8
		// (set) Token: 0x060040DB RID: 16603 RVA: 0x0007B804 File Offset: 0x00079A04
		[ProtoMember(4, IsRequired = false, Name = "canCanGetRewardCount", DataFormat = DataFormat.TwosComplement)]
		public int canCanGetRewardCount
		{
			get
			{
				return this._canCanGetRewardCount ?? 0;
			}
			set
			{
				this._canCanGetRewardCount = new int?(value);
			}
		}

		// Token: 0x170013D9 RID: 5081
		// (get) Token: 0x060040DC RID: 16604 RVA: 0x0007B814 File Offset: 0x00079A14
		// (set) Token: 0x060040DD RID: 16605 RVA: 0x0007B834 File Offset: 0x00079A34
		[XmlIgnore]
		[Browsable(false)]
		public bool canCanGetRewardCountSpecified
		{
			get
			{
				return this._canCanGetRewardCount != null;
			}
			set
			{
				bool flag = value == (this._canCanGetRewardCount == null);
				if (flag)
				{
					this._canCanGetRewardCount = (value ? new int?(this.canCanGetRewardCount) : null);
				}
			}
		}

		// Token: 0x060040DE RID: 16606 RVA: 0x0007B878 File Offset: 0x00079A78
		private bool ShouldSerializecanCanGetRewardCount()
		{
			return this.canCanGetRewardCountSpecified;
		}

		// Token: 0x060040DF RID: 16607 RVA: 0x0007B890 File Offset: 0x00079A90
		private void ResetcanCanGetRewardCount()
		{
			this.canCanGetRewardCountSpecified = false;
		}

		// Token: 0x170013DA RID: 5082
		// (get) Token: 0x060040E0 RID: 16608 RVA: 0x0007B89C File Offset: 0x00079A9C
		// (set) Token: 0x060040E1 RID: 16609 RVA: 0x0007B8C8 File Offset: 0x00079AC8
		[ProtoMember(5, IsRequired = false, Name = "curDNExpID", DataFormat = DataFormat.TwosComplement)]
		public uint curDNExpID
		{
			get
			{
				return this._curDNExpID ?? 0U;
			}
			set
			{
				this._curDNExpID = new uint?(value);
			}
		}

		// Token: 0x170013DB RID: 5083
		// (get) Token: 0x060040E2 RID: 16610 RVA: 0x0007B8D8 File Offset: 0x00079AD8
		// (set) Token: 0x060040E3 RID: 16611 RVA: 0x0007B8F8 File Offset: 0x00079AF8
		[XmlIgnore]
		[Browsable(false)]
		public bool curDNExpIDSpecified
		{
			get
			{
				return this._curDNExpID != null;
			}
			set
			{
				bool flag = value == (this._curDNExpID == null);
				if (flag)
				{
					this._curDNExpID = (value ? new uint?(this.curDNExpID) : null);
				}
			}
		}

		// Token: 0x060040E4 RID: 16612 RVA: 0x0007B93C File Offset: 0x00079B3C
		private bool ShouldSerializecurDNExpID()
		{
			return this.curDNExpIDSpecified;
		}

		// Token: 0x060040E5 RID: 16613 RVA: 0x0007B954 File Offset: 0x00079B54
		private void ResetcurDNExpID()
		{
			this.curDNExpIDSpecified = false;
		}

		// Token: 0x060040E6 RID: 16614 RVA: 0x0007B960 File Offset: 0x00079B60
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001026 RID: 4134
		private ErrorCode? _error;

		// Token: 0x04001027 RID: 4135
		private int? _leftRewardCount;

		// Token: 0x04001028 RID: 4136
		private int? _totalRewardCount;

		// Token: 0x04001029 RID: 4137
		private int? _canCanGetRewardCount;

		// Token: 0x0400102A RID: 4138
		private uint? _curDNExpID;

		// Token: 0x0400102B RID: 4139
		private IExtension extensionObject;
	}
}
