using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000184 RID: 388
	[ProtoContract(Name = "AskGuildBossInfoRes")]
	[Serializable]
	public class AskGuildBossInfoRes : IExtensible
	{
		// Token: 0x1700075F RID: 1887
		// (get) Token: 0x06001750 RID: 5968 RVA: 0x0002E964 File Offset: 0x0002CB64
		// (set) Token: 0x06001751 RID: 5969 RVA: 0x0002E990 File Offset: 0x0002CB90
		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		// Token: 0x17000760 RID: 1888
		// (get) Token: 0x06001752 RID: 5970 RVA: 0x0002E9A0 File Offset: 0x0002CBA0
		// (set) Token: 0x06001753 RID: 5971 RVA: 0x0002E9C0 File Offset: 0x0002CBC0
		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		// Token: 0x06001754 RID: 5972 RVA: 0x0002EA04 File Offset: 0x0002CC04
		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		// Token: 0x06001755 RID: 5973 RVA: 0x0002EA1C File Offset: 0x0002CC1C
		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		// Token: 0x17000761 RID: 1889
		// (get) Token: 0x06001756 RID: 5974 RVA: 0x0002EA28 File Offset: 0x0002CC28
		// (set) Token: 0x06001757 RID: 5975 RVA: 0x0002EA54 File Offset: 0x0002CC54
		[ProtoMember(2, IsRequired = false, Name = "bossId", DataFormat = DataFormat.TwosComplement)]
		public uint bossId
		{
			get
			{
				return this._bossId ?? 0U;
			}
			set
			{
				this._bossId = new uint?(value);
			}
		}

		// Token: 0x17000762 RID: 1890
		// (get) Token: 0x06001758 RID: 5976 RVA: 0x0002EA64 File Offset: 0x0002CC64
		// (set) Token: 0x06001759 RID: 5977 RVA: 0x0002EA84 File Offset: 0x0002CC84
		[XmlIgnore]
		[Browsable(false)]
		public bool bossIdSpecified
		{
			get
			{
				return this._bossId != null;
			}
			set
			{
				bool flag = value == (this._bossId == null);
				if (flag)
				{
					this._bossId = (value ? new uint?(this.bossId) : null);
				}
			}
		}

		// Token: 0x0600175A RID: 5978 RVA: 0x0002EAC8 File Offset: 0x0002CCC8
		private bool ShouldSerializebossId()
		{
			return this.bossIdSpecified;
		}

		// Token: 0x0600175B RID: 5979 RVA: 0x0002EAE0 File Offset: 0x0002CCE0
		private void ResetbossId()
		{
			this.bossIdSpecified = false;
		}

		// Token: 0x17000763 RID: 1891
		// (get) Token: 0x0600175C RID: 5980 RVA: 0x0002EAEC File Offset: 0x0002CCEC
		// (set) Token: 0x0600175D RID: 5981 RVA: 0x0002EB18 File Offset: 0x0002CD18
		[ProtoMember(3, IsRequired = false, Name = "needKillBossId", DataFormat = DataFormat.TwosComplement)]
		public uint needKillBossId
		{
			get
			{
				return this._needKillBossId ?? 0U;
			}
			set
			{
				this._needKillBossId = new uint?(value);
			}
		}

		// Token: 0x17000764 RID: 1892
		// (get) Token: 0x0600175E RID: 5982 RVA: 0x0002EB28 File Offset: 0x0002CD28
		// (set) Token: 0x0600175F RID: 5983 RVA: 0x0002EB48 File Offset: 0x0002CD48
		[XmlIgnore]
		[Browsable(false)]
		public bool needKillBossIdSpecified
		{
			get
			{
				return this._needKillBossId != null;
			}
			set
			{
				bool flag = value == (this._needKillBossId == null);
				if (flag)
				{
					this._needKillBossId = (value ? new uint?(this.needKillBossId) : null);
				}
			}
		}

		// Token: 0x06001760 RID: 5984 RVA: 0x0002EB8C File Offset: 0x0002CD8C
		private bool ShouldSerializeneedKillBossId()
		{
			return this.needKillBossIdSpecified;
		}

		// Token: 0x06001761 RID: 5985 RVA: 0x0002EBA4 File Offset: 0x0002CDA4
		private void ResetneedKillBossId()
		{
			this.needKillBossIdSpecified = false;
		}

		// Token: 0x17000765 RID: 1893
		// (get) Token: 0x06001762 RID: 5986 RVA: 0x0002EBB0 File Offset: 0x0002CDB0
		// (set) Token: 0x06001763 RID: 5987 RVA: 0x0002EBDC File Offset: 0x0002CDDC
		[ProtoMember(4, IsRequired = false, Name = "isFirstKill", DataFormat = DataFormat.Default)]
		public bool isFirstKill
		{
			get
			{
				return this._isFirstKill ?? false;
			}
			set
			{
				this._isFirstKill = new bool?(value);
			}
		}

		// Token: 0x17000766 RID: 1894
		// (get) Token: 0x06001764 RID: 5988 RVA: 0x0002EBEC File Offset: 0x0002CDEC
		// (set) Token: 0x06001765 RID: 5989 RVA: 0x0002EC0C File Offset: 0x0002CE0C
		[XmlIgnore]
		[Browsable(false)]
		public bool isFirstKillSpecified
		{
			get
			{
				return this._isFirstKill != null;
			}
			set
			{
				bool flag = value == (this._isFirstKill == null);
				if (flag)
				{
					this._isFirstKill = (value ? new bool?(this.isFirstKill) : null);
				}
			}
		}

		// Token: 0x06001766 RID: 5990 RVA: 0x0002EC50 File Offset: 0x0002CE50
		private bool ShouldSerializeisFirstKill()
		{
			return this.isFirstKillSpecified;
		}

		// Token: 0x06001767 RID: 5991 RVA: 0x0002EC68 File Offset: 0x0002CE68
		private void ResetisFirstKill()
		{
			this.isFirstKillSpecified = false;
		}

		// Token: 0x17000767 RID: 1895
		// (get) Token: 0x06001768 RID: 5992 RVA: 0x0002EC74 File Offset: 0x0002CE74
		// (set) Token: 0x06001769 RID: 5993 RVA: 0x0002ECA0 File Offset: 0x0002CEA0
		[ProtoMember(5, IsRequired = false, Name = "isLeader", DataFormat = DataFormat.Default)]
		public bool isLeader
		{
			get
			{
				return this._isLeader ?? false;
			}
			set
			{
				this._isLeader = new bool?(value);
			}
		}

		// Token: 0x17000768 RID: 1896
		// (get) Token: 0x0600176A RID: 5994 RVA: 0x0002ECB0 File Offset: 0x0002CEB0
		// (set) Token: 0x0600176B RID: 5995 RVA: 0x0002ECD0 File Offset: 0x0002CED0
		[XmlIgnore]
		[Browsable(false)]
		public bool isLeaderSpecified
		{
			get
			{
				return this._isLeader != null;
			}
			set
			{
				bool flag = value == (this._isLeader == null);
				if (flag)
				{
					this._isLeader = (value ? new bool?(this.isLeader) : null);
				}
			}
		}

		// Token: 0x0600176C RID: 5996 RVA: 0x0002ED14 File Offset: 0x0002CF14
		private bool ShouldSerializeisLeader()
		{
			return this.isLeaderSpecified;
		}

		// Token: 0x0600176D RID: 5997 RVA: 0x0002ED2C File Offset: 0x0002CF2C
		private void ResetisLeader()
		{
			this.isLeaderSpecified = false;
		}

		// Token: 0x17000769 RID: 1897
		// (get) Token: 0x0600176E RID: 5998 RVA: 0x0002ED38 File Offset: 0x0002CF38
		// (set) Token: 0x0600176F RID: 5999 RVA: 0x0002ED64 File Offset: 0x0002CF64
		[ProtoMember(6, IsRequired = false, Name = "needguildlvl", DataFormat = DataFormat.TwosComplement)]
		public uint needguildlvl
		{
			get
			{
				return this._needguildlvl ?? 0U;
			}
			set
			{
				this._needguildlvl = new uint?(value);
			}
		}

		// Token: 0x1700076A RID: 1898
		// (get) Token: 0x06001770 RID: 6000 RVA: 0x0002ED74 File Offset: 0x0002CF74
		// (set) Token: 0x06001771 RID: 6001 RVA: 0x0002ED94 File Offset: 0x0002CF94
		[XmlIgnore]
		[Browsable(false)]
		public bool needguildlvlSpecified
		{
			get
			{
				return this._needguildlvl != null;
			}
			set
			{
				bool flag = value == (this._needguildlvl == null);
				if (flag)
				{
					this._needguildlvl = (value ? new uint?(this.needguildlvl) : null);
				}
			}
		}

		// Token: 0x06001772 RID: 6002 RVA: 0x0002EDD8 File Offset: 0x0002CFD8
		private bool ShouldSerializeneedguildlvl()
		{
			return this.needguildlvlSpecified;
		}

		// Token: 0x06001773 RID: 6003 RVA: 0x0002EDF0 File Offset: 0x0002CFF0
		private void Resetneedguildlvl()
		{
			this.needguildlvlSpecified = false;
		}

		// Token: 0x06001774 RID: 6004 RVA: 0x0002EDFC File Offset: 0x0002CFFC
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040005C5 RID: 1477
		private ErrorCode? _errorcode;

		// Token: 0x040005C6 RID: 1478
		private uint? _bossId;

		// Token: 0x040005C7 RID: 1479
		private uint? _needKillBossId;

		// Token: 0x040005C8 RID: 1480
		private bool? _isFirstKill;

		// Token: 0x040005C9 RID: 1481
		private bool? _isLeader;

		// Token: 0x040005CA RID: 1482
		private uint? _needguildlvl;

		// Token: 0x040005CB RID: 1483
		private IExtension extensionObject;
	}
}
