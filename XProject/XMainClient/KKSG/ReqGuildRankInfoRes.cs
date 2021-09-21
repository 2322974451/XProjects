using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000256 RID: 598
	[ProtoContract(Name = "ReqGuildRankInfoRes")]
	[Serializable]
	public class ReqGuildRankInfoRes : IExtensible
	{
		// Token: 0x17000A68 RID: 2664
		// (get) Token: 0x06002163 RID: 8547 RVA: 0x00041598 File Offset: 0x0003F798
		// (set) Token: 0x06002164 RID: 8548 RVA: 0x000415C4 File Offset: 0x0003F7C4
		[ProtoMember(1, IsRequired = false, Name = "endTime", DataFormat = DataFormat.TwosComplement)]
		public uint endTime
		{
			get
			{
				return this._endTime ?? 0U;
			}
			set
			{
				this._endTime = new uint?(value);
			}
		}

		// Token: 0x17000A69 RID: 2665
		// (get) Token: 0x06002165 RID: 8549 RVA: 0x000415D4 File Offset: 0x0003F7D4
		// (set) Token: 0x06002166 RID: 8550 RVA: 0x000415F4 File Offset: 0x0003F7F4
		[XmlIgnore]
		[Browsable(false)]
		public bool endTimeSpecified
		{
			get
			{
				return this._endTime != null;
			}
			set
			{
				bool flag = value == (this._endTime == null);
				if (flag)
				{
					this._endTime = (value ? new uint?(this.endTime) : null);
				}
			}
		}

		// Token: 0x06002167 RID: 8551 RVA: 0x00041638 File Offset: 0x0003F838
		private bool ShouldSerializeendTime()
		{
			return this.endTimeSpecified;
		}

		// Token: 0x06002168 RID: 8552 RVA: 0x00041650 File Offset: 0x0003F850
		private void ResetendTime()
		{
			this.endTimeSpecified = false;
		}

		// Token: 0x17000A6A RID: 2666
		// (get) Token: 0x06002169 RID: 8553 RVA: 0x0004165C File Offset: 0x0003F85C
		// (set) Token: 0x0600216A RID: 8554 RVA: 0x00041688 File Offset: 0x0003F888
		[ProtoMember(2, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public uint rank
		{
			get
			{
				return this._rank ?? 0U;
			}
			set
			{
				this._rank = new uint?(value);
			}
		}

		// Token: 0x17000A6B RID: 2667
		// (get) Token: 0x0600216B RID: 8555 RVA: 0x00041698 File Offset: 0x0003F898
		// (set) Token: 0x0600216C RID: 8556 RVA: 0x000416B8 File Offset: 0x0003F8B8
		[XmlIgnore]
		[Browsable(false)]
		public bool rankSpecified
		{
			get
			{
				return this._rank != null;
			}
			set
			{
				bool flag = value == (this._rank == null);
				if (flag)
				{
					this._rank = (value ? new uint?(this.rank) : null);
				}
			}
		}

		// Token: 0x0600216D RID: 8557 RVA: 0x000416FC File Offset: 0x0003F8FC
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x0600216E RID: 8558 RVA: 0x00041714 File Offset: 0x0003F914
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17000A6C RID: 2668
		// (get) Token: 0x0600216F RID: 8559 RVA: 0x00041720 File Offset: 0x0003F920
		// (set) Token: 0x06002170 RID: 8560 RVA: 0x0004174C File Offset: 0x0003F94C
		[ProtoMember(3, IsRequired = false, Name = "keepTime", DataFormat = DataFormat.TwosComplement)]
		public uint keepTime
		{
			get
			{
				return this._keepTime ?? 0U;
			}
			set
			{
				this._keepTime = new uint?(value);
			}
		}

		// Token: 0x17000A6D RID: 2669
		// (get) Token: 0x06002171 RID: 8561 RVA: 0x0004175C File Offset: 0x0003F95C
		// (set) Token: 0x06002172 RID: 8562 RVA: 0x0004177C File Offset: 0x0003F97C
		[XmlIgnore]
		[Browsable(false)]
		public bool keepTimeSpecified
		{
			get
			{
				return this._keepTime != null;
			}
			set
			{
				bool flag = value == (this._keepTime == null);
				if (flag)
				{
					this._keepTime = (value ? new uint?(this.keepTime) : null);
				}
			}
		}

		// Token: 0x06002173 RID: 8563 RVA: 0x000417C0 File Offset: 0x0003F9C0
		private bool ShouldSerializekeepTime()
		{
			return this.keepTimeSpecified;
		}

		// Token: 0x06002174 RID: 8564 RVA: 0x000417D8 File Offset: 0x0003F9D8
		private void ResetkeepTime()
		{
			this.keepTimeSpecified = false;
		}

		// Token: 0x17000A6E RID: 2670
		// (get) Token: 0x06002175 RID: 8565 RVA: 0x000417E4 File Offset: 0x0003F9E4
		// (set) Token: 0x06002176 RID: 8566 RVA: 0x00041810 File Offset: 0x0003FA10
		[ProtoMember(4, IsRequired = false, Name = "nowTime", DataFormat = DataFormat.TwosComplement)]
		public uint nowTime
		{
			get
			{
				return this._nowTime ?? 0U;
			}
			set
			{
				this._nowTime = new uint?(value);
			}
		}

		// Token: 0x17000A6F RID: 2671
		// (get) Token: 0x06002177 RID: 8567 RVA: 0x00041820 File Offset: 0x0003FA20
		// (set) Token: 0x06002178 RID: 8568 RVA: 0x00041840 File Offset: 0x0003FA40
		[XmlIgnore]
		[Browsable(false)]
		public bool nowTimeSpecified
		{
			get
			{
				return this._nowTime != null;
			}
			set
			{
				bool flag = value == (this._nowTime == null);
				if (flag)
				{
					this._nowTime = (value ? new uint?(this.nowTime) : null);
				}
			}
		}

		// Token: 0x06002179 RID: 8569 RVA: 0x00041884 File Offset: 0x0003FA84
		private bool ShouldSerializenowTime()
		{
			return this.nowTimeSpecified;
		}

		// Token: 0x0600217A RID: 8570 RVA: 0x0004189C File Offset: 0x0003FA9C
		private void ResetnowTime()
		{
			this.nowTimeSpecified = false;
		}

		// Token: 0x0600217B RID: 8571 RVA: 0x000418A8 File Offset: 0x0003FAA8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x0400084F RID: 2127
		private uint? _endTime;

		// Token: 0x04000850 RID: 2128
		private uint? _rank;

		// Token: 0x04000851 RID: 2129
		private uint? _keepTime;

		// Token: 0x04000852 RID: 2130
		private uint? _nowTime;

		// Token: 0x04000853 RID: 2131
		private IExtension extensionObject;
	}
}
