using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x02000609 RID: 1545
	[ProtoContract(Name = "TShowVoteRecord")]
	[Serializable]
	public class TShowVoteRecord : IExtensible
	{
		// Token: 0x17001D2F RID: 7471
		// (get) Token: 0x06005D18 RID: 23832 RVA: 0x000B1648 File Offset: 0x000AF848
		// (set) Token: 0x06005D19 RID: 23833 RVA: 0x000B1674 File Offset: 0x000AF874
		[ProtoMember(1, IsRequired = false, Name = "updateTime", DataFormat = DataFormat.TwosComplement)]
		public int updateTime
		{
			get
			{
				return this._updateTime ?? 0;
			}
			set
			{
				this._updateTime = new int?(value);
			}
		}

		// Token: 0x17001D30 RID: 7472
		// (get) Token: 0x06005D1A RID: 23834 RVA: 0x000B1684 File Offset: 0x000AF884
		// (set) Token: 0x06005D1B RID: 23835 RVA: 0x000B16A4 File Offset: 0x000AF8A4
		[XmlIgnore]
		[Browsable(false)]
		public bool updateTimeSpecified
		{
			get
			{
				return this._updateTime != null;
			}
			set
			{
				bool flag = value == (this._updateTime == null);
				if (flag)
				{
					this._updateTime = (value ? new int?(this.updateTime) : null);
				}
			}
		}

		// Token: 0x06005D1C RID: 23836 RVA: 0x000B16E8 File Offset: 0x000AF8E8
		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		// Token: 0x06005D1D RID: 23837 RVA: 0x000B1700 File Offset: 0x000AF900
		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		// Token: 0x17001D31 RID: 7473
		// (get) Token: 0x06005D1E RID: 23838 RVA: 0x000B170C File Offset: 0x000AF90C
		[ProtoMember(2, Name = "voteData", DataFormat = DataFormat.Default)]
		public List<TShowRoleDailyVoteData> voteData
		{
			get
			{
				return this._voteData;
			}
		}

		// Token: 0x17001D32 RID: 7474
		// (get) Token: 0x06005D1F RID: 23839 RVA: 0x000B1724 File Offset: 0x000AF924
		// (set) Token: 0x06005D20 RID: 23840 RVA: 0x000B1750 File Offset: 0x000AF950
		[ProtoMember(3, IsRequired = false, Name = "haveSendRank", DataFormat = DataFormat.Default)]
		public bool haveSendRank
		{
			get
			{
				return this._haveSendRank ?? false;
			}
			set
			{
				this._haveSendRank = new bool?(value);
			}
		}

		// Token: 0x17001D33 RID: 7475
		// (get) Token: 0x06005D21 RID: 23841 RVA: 0x000B1760 File Offset: 0x000AF960
		// (set) Token: 0x06005D22 RID: 23842 RVA: 0x000B1780 File Offset: 0x000AF980
		[XmlIgnore]
		[Browsable(false)]
		public bool haveSendRankSpecified
		{
			get
			{
				return this._haveSendRank != null;
			}
			set
			{
				bool flag = value == (this._haveSendRank == null);
				if (flag)
				{
					this._haveSendRank = (value ? new bool?(this.haveSendRank) : null);
				}
			}
		}

		// Token: 0x06005D23 RID: 23843 RVA: 0x000B17C4 File Offset: 0x000AF9C4
		private bool ShouldSerializehaveSendRank()
		{
			return this.haveSendRankSpecified;
		}

		// Token: 0x06005D24 RID: 23844 RVA: 0x000B17DC File Offset: 0x000AF9DC
		private void ResethaveSendRank()
		{
			this.haveSendRankSpecified = false;
		}

		// Token: 0x06005D25 RID: 23845 RVA: 0x000B17E8 File Offset: 0x000AF9E8
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x040016A1 RID: 5793
		private int? _updateTime;

		// Token: 0x040016A2 RID: 5794
		private readonly List<TShowRoleDailyVoteData> _voteData = new List<TShowRoleDailyVoteData>();

		// Token: 0x040016A3 RID: 5795
		private bool? _haveSendRank;

		// Token: 0x040016A4 RID: 5796
		private IExtension extensionObject;
	}
}
