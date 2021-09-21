using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000593 RID: 1427
	[ProtoContract(Name = "ActivityRecord")]
	[Serializable]
	public class ActivityRecord : IExtensible
	{
		// Token: 0x17001757 RID: 5975
		// (get) Token: 0x06004BDB RID: 19419 RVA: 0x00090478 File Offset: 0x0008E678
		[ProtoMember(1, Name = "ActivityId", DataFormat = DataFormat.TwosComplement)]
		public List<uint> ActivityId
		{
			get
			{
				return this._ActivityId;
			}
		}

		// Token: 0x17001758 RID: 5976
		// (get) Token: 0x06004BDC RID: 19420 RVA: 0x00090490 File Offset: 0x0008E690
		[ProtoMember(2, Name = "FinishCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> FinishCount
		{
			get
			{
				return this._FinishCount;
			}
		}

		// Token: 0x17001759 RID: 5977
		// (get) Token: 0x06004BDD RID: 19421 RVA: 0x000904A8 File Offset: 0x0008E6A8
		// (set) Token: 0x06004BDE RID: 19422 RVA: 0x000904D4 File Offset: 0x0008E6D4
		[ProtoMember(3, IsRequired = false, Name = "ActivityAllValue", DataFormat = DataFormat.TwosComplement)]
		public uint ActivityAllValue
		{
			get
			{
				return this._ActivityAllValue ?? 0U;
			}
			set
			{
				this._ActivityAllValue = new uint?(value);
			}
		}

		// Token: 0x1700175A RID: 5978
		// (get) Token: 0x06004BDF RID: 19423 RVA: 0x000904E4 File Offset: 0x0008E6E4
		// (set) Token: 0x06004BE0 RID: 19424 RVA: 0x00090504 File Offset: 0x0008E704
		[XmlIgnore]
		[Browsable(false)]
		public bool ActivityAllValueSpecified
		{
			get
			{
				return this._ActivityAllValue != null;
			}
			set
			{
				bool flag = value == (this._ActivityAllValue == null);
				if (flag)
				{
					this._ActivityAllValue = (value ? new uint?(this.ActivityAllValue) : null);
				}
			}
		}

		// Token: 0x06004BE1 RID: 19425 RVA: 0x00090548 File Offset: 0x0008E748
		private bool ShouldSerializeActivityAllValue()
		{
			return this.ActivityAllValueSpecified;
		}

		// Token: 0x06004BE2 RID: 19426 RVA: 0x00090560 File Offset: 0x0008E760
		private void ResetActivityAllValue()
		{
			this.ActivityAllValueSpecified = false;
		}

		// Token: 0x1700175B RID: 5979
		// (get) Token: 0x06004BE3 RID: 19427 RVA: 0x0009056C File Offset: 0x0008E76C
		// (set) Token: 0x06004BE4 RID: 19428 RVA: 0x00090598 File Offset: 0x0008E798
		[ProtoMember(4, IsRequired = false, Name = "DoubleActivityId", DataFormat = DataFormat.TwosComplement)]
		public uint DoubleActivityId
		{
			get
			{
				return this._DoubleActivityId ?? 0U;
			}
			set
			{
				this._DoubleActivityId = new uint?(value);
			}
		}

		// Token: 0x1700175C RID: 5980
		// (get) Token: 0x06004BE5 RID: 19429 RVA: 0x000905A8 File Offset: 0x0008E7A8
		// (set) Token: 0x06004BE6 RID: 19430 RVA: 0x000905C8 File Offset: 0x0008E7C8
		[XmlIgnore]
		[Browsable(false)]
		public bool DoubleActivityIdSpecified
		{
			get
			{
				return this._DoubleActivityId != null;
			}
			set
			{
				bool flag = value == (this._DoubleActivityId == null);
				if (flag)
				{
					this._DoubleActivityId = (value ? new uint?(this.DoubleActivityId) : null);
				}
			}
		}

		// Token: 0x06004BE7 RID: 19431 RVA: 0x0009060C File Offset: 0x0008E80C
		private bool ShouldSerializeDoubleActivityId()
		{
			return this.DoubleActivityIdSpecified;
		}

		// Token: 0x06004BE8 RID: 19432 RVA: 0x00090624 File Offset: 0x0008E824
		private void ResetDoubleActivityId()
		{
			this.DoubleActivityIdSpecified = false;
		}

		// Token: 0x1700175D RID: 5981
		// (get) Token: 0x06004BE9 RID: 19433 RVA: 0x00090630 File Offset: 0x0008E830
		// (set) Token: 0x06004BEA RID: 19434 RVA: 0x0009065C File Offset: 0x0008E85C
		[ProtoMember(5, IsRequired = false, Name = "ChestGetInfo", DataFormat = DataFormat.TwosComplement)]
		public uint ChestGetInfo
		{
			get
			{
				return this._ChestGetInfo ?? 0U;
			}
			set
			{
				this._ChestGetInfo = new uint?(value);
			}
		}

		// Token: 0x1700175E RID: 5982
		// (get) Token: 0x06004BEB RID: 19435 RVA: 0x0009066C File Offset: 0x0008E86C
		// (set) Token: 0x06004BEC RID: 19436 RVA: 0x0009068C File Offset: 0x0008E88C
		[XmlIgnore]
		[Browsable(false)]
		public bool ChestGetInfoSpecified
		{
			get
			{
				return this._ChestGetInfo != null;
			}
			set
			{
				bool flag = value == (this._ChestGetInfo == null);
				if (flag)
				{
					this._ChestGetInfo = (value ? new uint?(this.ChestGetInfo) : null);
				}
			}
		}

		// Token: 0x06004BED RID: 19437 RVA: 0x000906D0 File Offset: 0x0008E8D0
		private bool ShouldSerializeChestGetInfo()
		{
			return this.ChestGetInfoSpecified;
		}

		// Token: 0x06004BEE RID: 19438 RVA: 0x000906E8 File Offset: 0x0008E8E8
		private void ResetChestGetInfo()
		{
			this.ChestGetInfoSpecified = false;
		}

		// Token: 0x1700175F RID: 5983
		// (get) Token: 0x06004BEF RID: 19439 RVA: 0x000906F4 File Offset: 0x0008E8F4
		[ProtoMember(6, Name = "NeedFinishCount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> NeedFinishCount
		{
			get
			{
				return this._NeedFinishCount;
			}
		}

		// Token: 0x17001760 RID: 5984
		// (get) Token: 0x06004BF0 RID: 19440 RVA: 0x0009070C File Offset: 0x0008E90C
		// (set) Token: 0x06004BF1 RID: 19441 RVA: 0x00090738 File Offset: 0x0008E938
		[ProtoMember(7, IsRequired = false, Name = "activityWeekValue", DataFormat = DataFormat.TwosComplement)]
		public uint activityWeekValue
		{
			get
			{
				return this._activityWeekValue ?? 0U;
			}
			set
			{
				this._activityWeekValue = new uint?(value);
			}
		}

		// Token: 0x17001761 RID: 5985
		// (get) Token: 0x06004BF2 RID: 19442 RVA: 0x00090748 File Offset: 0x0008E948
		// (set) Token: 0x06004BF3 RID: 19443 RVA: 0x00090768 File Offset: 0x0008E968
		[XmlIgnore]
		[Browsable(false)]
		public bool activityWeekValueSpecified
		{
			get
			{
				return this._activityWeekValue != null;
			}
			set
			{
				bool flag = value == (this._activityWeekValue == null);
				if (flag)
				{
					this._activityWeekValue = (value ? new uint?(this.activityWeekValue) : null);
				}
			}
		}

		// Token: 0x06004BF4 RID: 19444 RVA: 0x000907AC File Offset: 0x0008E9AC
		private bool ShouldSerializeactivityWeekValue()
		{
			return this.activityWeekValueSpecified;
		}

		// Token: 0x06004BF5 RID: 19445 RVA: 0x000907C4 File Offset: 0x0008E9C4
		private void ResetactivityWeekValue()
		{
			this.activityWeekValueSpecified = false;
		}

		// Token: 0x17001762 RID: 5986
		// (get) Token: 0x06004BF6 RID: 19446 RVA: 0x000907D0 File Offset: 0x0008E9D0
		// (set) Token: 0x06004BF7 RID: 19447 RVA: 0x000907FD File Offset: 0x0008E9FD
		[ProtoMember(8, IsRequired = false, Name = "LastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public ulong LastUpdateTime
		{
			get
			{
				return this._LastUpdateTime ?? 0UL;
			}
			set
			{
				this._LastUpdateTime = new ulong?(value);
			}
		}

		// Token: 0x17001763 RID: 5987
		// (get) Token: 0x06004BF8 RID: 19448 RVA: 0x0009080C File Offset: 0x0008EA0C
		// (set) Token: 0x06004BF9 RID: 19449 RVA: 0x0009082C File Offset: 0x0008EA2C
		[XmlIgnore]
		[Browsable(false)]
		public bool LastUpdateTimeSpecified
		{
			get
			{
				return this._LastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._LastUpdateTime == null);
				if (flag)
				{
					this._LastUpdateTime = (value ? new ulong?(this.LastUpdateTime) : null);
				}
			}
		}

		// Token: 0x06004BFA RID: 19450 RVA: 0x00090870 File Offset: 0x0008EA70
		private bool ShouldSerializeLastUpdateTime()
		{
			return this.LastUpdateTimeSpecified;
		}

		// Token: 0x06004BFB RID: 19451 RVA: 0x00090888 File Offset: 0x0008EA88
		private void ResetLastUpdateTime()
		{
			this.LastUpdateTimeSpecified = false;
		}

		// Token: 0x17001764 RID: 5988
		// (get) Token: 0x06004BFC RID: 19452 RVA: 0x00090894 File Offset: 0x0008EA94
		// (set) Token: 0x06004BFD RID: 19453 RVA: 0x000908C0 File Offset: 0x0008EAC0
		[ProtoMember(9, IsRequired = false, Name = "guildladdertime", DataFormat = DataFormat.TwosComplement)]
		public uint guildladdertime
		{
			get
			{
				return this._guildladdertime ?? 0U;
			}
			set
			{
				this._guildladdertime = new uint?(value);
			}
		}

		// Token: 0x17001765 RID: 5989
		// (get) Token: 0x06004BFE RID: 19454 RVA: 0x000908D0 File Offset: 0x0008EAD0
		// (set) Token: 0x06004BFF RID: 19455 RVA: 0x000908F0 File Offset: 0x0008EAF0
		[XmlIgnore]
		[Browsable(false)]
		public bool guildladdertimeSpecified
		{
			get
			{
				return this._guildladdertime != null;
			}
			set
			{
				bool flag = value == (this._guildladdertime == null);
				if (flag)
				{
					this._guildladdertime = (value ? new uint?(this.guildladdertime) : null);
				}
			}
		}

		// Token: 0x06004C00 RID: 19456 RVA: 0x00090934 File Offset: 0x0008EB34
		private bool ShouldSerializeguildladdertime()
		{
			return this.guildladdertimeSpecified;
		}

		// Token: 0x06004C01 RID: 19457 RVA: 0x0009094C File Offset: 0x0008EB4C
		private void Resetguildladdertime()
		{
			this.guildladdertimeSpecified = false;
		}

		// Token: 0x06004C02 RID: 19458 RVA: 0x00090958 File Offset: 0x0008EB58
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040012D4 RID: 4820
		private readonly List<uint> _ActivityId = new List<uint>();

		// Token: 0x040012D5 RID: 4821
		private readonly List<uint> _FinishCount = new List<uint>();

		// Token: 0x040012D6 RID: 4822
		private uint? _ActivityAllValue;

		// Token: 0x040012D7 RID: 4823
		private uint? _DoubleActivityId;

		// Token: 0x040012D8 RID: 4824
		private uint? _ChestGetInfo;

		// Token: 0x040012D9 RID: 4825
		private readonly List<uint> _NeedFinishCount = new List<uint>();

		// Token: 0x040012DA RID: 4826
		private uint? _activityWeekValue;

		// Token: 0x040012DB RID: 4827
		private ulong? _LastUpdateTime;

		// Token: 0x040012DC RID: 4828
		private uint? _guildladdertime;

		// Token: 0x040012DD RID: 4829
		private IExtension extensionObject;
	}
}
