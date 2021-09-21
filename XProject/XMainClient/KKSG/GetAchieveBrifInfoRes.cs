using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000113 RID: 275
	[ProtoContract(Name = "GetAchieveBrifInfoRes")]
	[Serializable]
	public class GetAchieveBrifInfoRes : IExtensible
	{
		// Token: 0x1700058E RID: 1422
		// (get) Token: 0x0600114B RID: 4427 RVA: 0x000234E8 File Offset: 0x000216E8
		// (set) Token: 0x0600114C RID: 4428 RVA: 0x00023514 File Offset: 0x00021714
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

		// Token: 0x1700058F RID: 1423
		// (get) Token: 0x0600114D RID: 4429 RVA: 0x00023524 File Offset: 0x00021724
		// (set) Token: 0x0600114E RID: 4430 RVA: 0x00023544 File Offset: 0x00021744
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

		// Token: 0x0600114F RID: 4431 RVA: 0x00023588 File Offset: 0x00021788
		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		// Token: 0x06001150 RID: 4432 RVA: 0x000235A0 File Offset: 0x000217A0
		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		// Token: 0x17000590 RID: 1424
		// (get) Token: 0x06001151 RID: 4433 RVA: 0x000235AC File Offset: 0x000217AC
		// (set) Token: 0x06001152 RID: 4434 RVA: 0x000235D8 File Offset: 0x000217D8
		[ProtoMember(2, IsRequired = false, Name = "achievePoint", DataFormat = DataFormat.TwosComplement)]
		public uint achievePoint
		{
			get
			{
				return this._achievePoint ?? 0U;
			}
			set
			{
				this._achievePoint = new uint?(value);
			}
		}

		// Token: 0x17000591 RID: 1425
		// (get) Token: 0x06001153 RID: 4435 RVA: 0x000235E8 File Offset: 0x000217E8
		// (set) Token: 0x06001154 RID: 4436 RVA: 0x00023608 File Offset: 0x00021808
		[XmlIgnore]
		[Browsable(false)]
		public bool achievePointSpecified
		{
			get
			{
				return this._achievePoint != null;
			}
			set
			{
				bool flag = value == (this._achievePoint == null);
				if (flag)
				{
					this._achievePoint = (value ? new uint?(this.achievePoint) : null);
				}
			}
		}

		// Token: 0x06001155 RID: 4437 RVA: 0x0002364C File Offset: 0x0002184C
		private bool ShouldSerializeachievePoint()
		{
			return this.achievePointSpecified;
		}

		// Token: 0x06001156 RID: 4438 RVA: 0x00023664 File Offset: 0x00021864
		private void ResetachievePoint()
		{
			this.achievePointSpecified = false;
		}

		// Token: 0x17000592 RID: 1426
		// (get) Token: 0x06001157 RID: 4439 RVA: 0x00023670 File Offset: 0x00021870
		// (set) Token: 0x06001158 RID: 4440 RVA: 0x0002369C File Offset: 0x0002189C
		[ProtoMember(3, IsRequired = false, Name = "maxAchievePoint", DataFormat = DataFormat.TwosComplement)]
		public uint maxAchievePoint
		{
			get
			{
				return this._maxAchievePoint ?? 0U;
			}
			set
			{
				this._maxAchievePoint = new uint?(value);
			}
		}

		// Token: 0x17000593 RID: 1427
		// (get) Token: 0x06001159 RID: 4441 RVA: 0x000236AC File Offset: 0x000218AC
		// (set) Token: 0x0600115A RID: 4442 RVA: 0x000236CC File Offset: 0x000218CC
		[XmlIgnore]
		[Browsable(false)]
		public bool maxAchievePointSpecified
		{
			get
			{
				return this._maxAchievePoint != null;
			}
			set
			{
				bool flag = value == (this._maxAchievePoint == null);
				if (flag)
				{
					this._maxAchievePoint = (value ? new uint?(this.maxAchievePoint) : null);
				}
			}
		}

		// Token: 0x0600115B RID: 4443 RVA: 0x00023710 File Offset: 0x00021910
		private bool ShouldSerializemaxAchievePoint()
		{
			return this.maxAchievePointSpecified;
		}

		// Token: 0x0600115C RID: 4444 RVA: 0x00023728 File Offset: 0x00021928
		private void ResetmaxAchievePoint()
		{
			this.maxAchievePointSpecified = false;
		}

		// Token: 0x17000594 RID: 1428
		// (get) Token: 0x0600115D RID: 4445 RVA: 0x00023734 File Offset: 0x00021934
		[ProtoMember(4, Name = "dataList", DataFormat = DataFormat.Default)]
		public List<AchieveBriefInfo> dataList
		{
			get
			{
				return this._dataList;
			}
		}

		// Token: 0x17000595 RID: 1429
		// (get) Token: 0x0600115E RID: 4446 RVA: 0x0002374C File Offset: 0x0002194C
		// (set) Token: 0x0600115F RID: 4447 RVA: 0x00023778 File Offset: 0x00021978
		[ProtoMember(5, IsRequired = false, Name = "rewardId", DataFormat = DataFormat.TwosComplement)]
		public uint rewardId
		{
			get
			{
				return this._rewardId ?? 0U;
			}
			set
			{
				this._rewardId = new uint?(value);
			}
		}

		// Token: 0x17000596 RID: 1430
		// (get) Token: 0x06001160 RID: 4448 RVA: 0x00023788 File Offset: 0x00021988
		// (set) Token: 0x06001161 RID: 4449 RVA: 0x000237A8 File Offset: 0x000219A8
		[XmlIgnore]
		[Browsable(false)]
		public bool rewardIdSpecified
		{
			get
			{
				return this._rewardId != null;
			}
			set
			{
				bool flag = value == (this._rewardId == null);
				if (flag)
				{
					this._rewardId = (value ? new uint?(this.rewardId) : null);
				}
			}
		}

		// Token: 0x06001162 RID: 4450 RVA: 0x000237EC File Offset: 0x000219EC
		private bool ShouldSerializerewardId()
		{
			return this.rewardIdSpecified;
		}

		// Token: 0x06001163 RID: 4451 RVA: 0x00023804 File Offset: 0x00021A04
		private void ResetrewardId()
		{
			this.rewardIdSpecified = false;
		}

		// Token: 0x06001164 RID: 4452 RVA: 0x00023810 File Offset: 0x00021A10
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04000454 RID: 1108
		private ErrorCode? _result;

		// Token: 0x04000455 RID: 1109
		private uint? _achievePoint;

		// Token: 0x04000456 RID: 1110
		private uint? _maxAchievePoint;

		// Token: 0x04000457 RID: 1111
		private readonly List<AchieveBriefInfo> _dataList = new List<AchieveBriefInfo>();

		// Token: 0x04000458 RID: 1112
		private uint? _rewardId;

		// Token: 0x04000459 RID: 1113
		private IExtension extensionObject;
	}
}
