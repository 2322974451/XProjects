using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200013E RID: 318
	[ProtoContract(Name = "PvpBattleBeginData")]
	[Serializable]
	public class PvpBattleBeginData : IExtensible
	{
		// Token: 0x17000638 RID: 1592
		// (get) Token: 0x0600138B RID: 5003 RVA: 0x000277EC File Offset: 0x000259EC
		// (set) Token: 0x0600138C RID: 5004 RVA: 0x00027818 File Offset: 0x00025A18
		[ProtoMember(1, IsRequired = false, Name = "thisGameCount", DataFormat = DataFormat.TwosComplement)]
		public int thisGameCount
		{
			get
			{
				return this._thisGameCount ?? 0;
			}
			set
			{
				this._thisGameCount = new int?(value);
			}
		}

		// Token: 0x17000639 RID: 1593
		// (get) Token: 0x0600138D RID: 5005 RVA: 0x00027828 File Offset: 0x00025A28
		// (set) Token: 0x0600138E RID: 5006 RVA: 0x00027848 File Offset: 0x00025A48
		[XmlIgnore]
		[Browsable(false)]
		public bool thisGameCountSpecified
		{
			get
			{
				return this._thisGameCount != null;
			}
			set
			{
				bool flag = value == (this._thisGameCount == null);
				if (flag)
				{
					this._thisGameCount = (value ? new int?(this.thisGameCount) : null);
				}
			}
		}

		// Token: 0x0600138F RID: 5007 RVA: 0x0002788C File Offset: 0x00025A8C
		private bool ShouldSerializethisGameCount()
		{
			return this.thisGameCountSpecified;
		}

		// Token: 0x06001390 RID: 5008 RVA: 0x000278A4 File Offset: 0x00025AA4
		private void ResetthisGameCount()
		{
			this.thisGameCountSpecified = false;
		}

		// Token: 0x1700063A RID: 1594
		// (get) Token: 0x06001391 RID: 5009 RVA: 0x000278B0 File Offset: 0x00025AB0
		// (set) Token: 0x06001392 RID: 5010 RVA: 0x000278DC File Offset: 0x00025ADC
		[ProtoMember(2, IsRequired = false, Name = "allGameCount", DataFormat = DataFormat.TwosComplement)]
		public int allGameCount
		{
			get
			{
				return this._allGameCount ?? 0;
			}
			set
			{
				this._allGameCount = new int?(value);
			}
		}

		// Token: 0x1700063B RID: 1595
		// (get) Token: 0x06001393 RID: 5011 RVA: 0x000278EC File Offset: 0x00025AEC
		// (set) Token: 0x06001394 RID: 5012 RVA: 0x0002790C File Offset: 0x00025B0C
		[XmlIgnore]
		[Browsable(false)]
		public bool allGameCountSpecified
		{
			get
			{
				return this._allGameCount != null;
			}
			set
			{
				bool flag = value == (this._allGameCount == null);
				if (flag)
				{
					this._allGameCount = (value ? new int?(this.allGameCount) : null);
				}
			}
		}

		// Token: 0x06001395 RID: 5013 RVA: 0x00027950 File Offset: 0x00025B50
		private bool ShouldSerializeallGameCount()
		{
			return this.allGameCountSpecified;
		}

		// Token: 0x06001396 RID: 5014 RVA: 0x00027968 File Offset: 0x00025B68
		private void ResetallGameCount()
		{
			this.allGameCountSpecified = false;
		}

		// Token: 0x1700063C RID: 1596
		// (get) Token: 0x06001397 RID: 5015 RVA: 0x00027974 File Offset: 0x00025B74
		// (set) Token: 0x06001398 RID: 5016 RVA: 0x000279A1 File Offset: 0x00025BA1
		[ProtoMember(3, IsRequired = false, Name = "group1Leader", DataFormat = DataFormat.TwosComplement)]
		public ulong group1Leader
		{
			get
			{
				return this._group1Leader ?? 0UL;
			}
			set
			{
				this._group1Leader = new ulong?(value);
			}
		}

		// Token: 0x1700063D RID: 1597
		// (get) Token: 0x06001399 RID: 5017 RVA: 0x000279B0 File Offset: 0x00025BB0
		// (set) Token: 0x0600139A RID: 5018 RVA: 0x000279D0 File Offset: 0x00025BD0
		[XmlIgnore]
		[Browsable(false)]
		public bool group1LeaderSpecified
		{
			get
			{
				return this._group1Leader != null;
			}
			set
			{
				bool flag = value == (this._group1Leader == null);
				if (flag)
				{
					this._group1Leader = (value ? new ulong?(this.group1Leader) : null);
				}
			}
		}

		// Token: 0x0600139B RID: 5019 RVA: 0x00027A14 File Offset: 0x00025C14
		private bool ShouldSerializegroup1Leader()
		{
			return this.group1LeaderSpecified;
		}

		// Token: 0x0600139C RID: 5020 RVA: 0x00027A2C File Offset: 0x00025C2C
		private void Resetgroup1Leader()
		{
			this.group1LeaderSpecified = false;
		}

		// Token: 0x1700063E RID: 1598
		// (get) Token: 0x0600139D RID: 5021 RVA: 0x00027A38 File Offset: 0x00025C38
		// (set) Token: 0x0600139E RID: 5022 RVA: 0x00027A65 File Offset: 0x00025C65
		[ProtoMember(4, IsRequired = false, Name = "group2Leader", DataFormat = DataFormat.TwosComplement)]
		public ulong group2Leader
		{
			get
			{
				return this._group2Leader ?? 0UL;
			}
			set
			{
				this._group2Leader = new ulong?(value);
			}
		}

		// Token: 0x1700063F RID: 1599
		// (get) Token: 0x0600139F RID: 5023 RVA: 0x00027A74 File Offset: 0x00025C74
		// (set) Token: 0x060013A0 RID: 5024 RVA: 0x00027A94 File Offset: 0x00025C94
		[XmlIgnore]
		[Browsable(false)]
		public bool group2LeaderSpecified
		{
			get
			{
				return this._group2Leader != null;
			}
			set
			{
				bool flag = value == (this._group2Leader == null);
				if (flag)
				{
					this._group2Leader = (value ? new ulong?(this.group2Leader) : null);
				}
			}
		}

		// Token: 0x060013A1 RID: 5025 RVA: 0x00027AD8 File Offset: 0x00025CD8
		private bool ShouldSerializegroup2Leader()
		{
			return this.group2LeaderSpecified;
		}

		// Token: 0x060013A2 RID: 5026 RVA: 0x00027AF0 File Offset: 0x00025CF0
		private void Resetgroup2Leader()
		{
			this.group2LeaderSpecified = false;
		}

		// Token: 0x17000640 RID: 1600
		// (get) Token: 0x060013A3 RID: 5027 RVA: 0x00027AFC File Offset: 0x00025CFC
		// (set) Token: 0x060013A4 RID: 5028 RVA: 0x00027B28 File Offset: 0x00025D28
		[ProtoMember(5, IsRequired = false, Name = "contiTime", DataFormat = DataFormat.TwosComplement)]
		public uint contiTime
		{
			get
			{
				return this._contiTime ?? 0U;
			}
			set
			{
				this._contiTime = new uint?(value);
			}
		}

		// Token: 0x17000641 RID: 1601
		// (get) Token: 0x060013A5 RID: 5029 RVA: 0x00027B38 File Offset: 0x00025D38
		// (set) Token: 0x060013A6 RID: 5030 RVA: 0x00027B58 File Offset: 0x00025D58
		[XmlIgnore]
		[Browsable(false)]
		public bool contiTimeSpecified
		{
			get
			{
				return this._contiTime != null;
			}
			set
			{
				bool flag = value == (this._contiTime == null);
				if (flag)
				{
					this._contiTime = (value ? new uint?(this.contiTime) : null);
				}
			}
		}

		// Token: 0x060013A7 RID: 5031 RVA: 0x00027B9C File Offset: 0x00025D9C
		private bool ShouldSerializecontiTime()
		{
			return this.contiTimeSpecified;
		}

		// Token: 0x060013A8 RID: 5032 RVA: 0x00027BB4 File Offset: 0x00025DB4
		private void ResetcontiTime()
		{
			this.contiTimeSpecified = false;
		}

		// Token: 0x060013A9 RID: 5033 RVA: 0x00027BC0 File Offset: 0x00025DC0
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040004DB RID: 1243
		private int? _thisGameCount;

		// Token: 0x040004DC RID: 1244
		private int? _allGameCount;

		// Token: 0x040004DD RID: 1245
		private ulong? _group1Leader;

		// Token: 0x040004DE RID: 1246
		private ulong? _group2Leader;

		// Token: 0x040004DF RID: 1247
		private uint? _contiTime;

		// Token: 0x040004E0 RID: 1248
		private IExtension extensionObject;
	}
}
