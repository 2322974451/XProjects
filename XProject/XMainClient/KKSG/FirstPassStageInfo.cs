using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200062B RID: 1579
	[ProtoContract(Name = "FirstPassStageInfo")]
	[Serializable]
	public class FirstPassStageInfo : IExtensible
	{
		// Token: 0x17001E78 RID: 7800
		// (get) Token: 0x060060DC RID: 24796 RVA: 0x000B8C14 File Offset: 0x000B6E14
		// (set) Token: 0x060060DD RID: 24797 RVA: 0x000B8C40 File Offset: 0x000B6E40
		[ProtoMember(1, IsRequired = false, Name = "firstPassID", DataFormat = DataFormat.TwosComplement)]
		public int firstPassID
		{
			get
			{
				return this._firstPassID ?? 0;
			}
			set
			{
				this._firstPassID = new int?(value);
			}
		}

		// Token: 0x17001E79 RID: 7801
		// (get) Token: 0x060060DE RID: 24798 RVA: 0x000B8C50 File Offset: 0x000B6E50
		// (set) Token: 0x060060DF RID: 24799 RVA: 0x000B8C70 File Offset: 0x000B6E70
		[XmlIgnore]
		[Browsable(false)]
		public bool firstPassIDSpecified
		{
			get
			{
				return this._firstPassID != null;
			}
			set
			{
				bool flag = value == (this._firstPassID == null);
				if (flag)
				{
					this._firstPassID = (value ? new int?(this.firstPassID) : null);
				}
			}
		}

		// Token: 0x060060E0 RID: 24800 RVA: 0x000B8CB4 File Offset: 0x000B6EB4
		private bool ShouldSerializefirstPassID()
		{
			return this.firstPassIDSpecified;
		}

		// Token: 0x060060E1 RID: 24801 RVA: 0x000B8CCC File Offset: 0x000B6ECC
		private void ResetfirstPassID()
		{
			this.firstPassIDSpecified = false;
		}

		// Token: 0x17001E7A RID: 7802
		// (get) Token: 0x060060E2 RID: 24802 RVA: 0x000B8CD8 File Offset: 0x000B6ED8
		// (set) Token: 0x060060E3 RID: 24803 RVA: 0x000B8D04 File Offset: 0x000B6F04
		[ProtoMember(2, IsRequired = false, Name = "isGetReward", DataFormat = DataFormat.Default)]
		public bool isGetReward
		{
			get
			{
				return this._isGetReward ?? false;
			}
			set
			{
				this._isGetReward = new bool?(value);
			}
		}

		// Token: 0x17001E7B RID: 7803
		// (get) Token: 0x060060E4 RID: 24804 RVA: 0x000B8D14 File Offset: 0x000B6F14
		// (set) Token: 0x060060E5 RID: 24805 RVA: 0x000B8D34 File Offset: 0x000B6F34
		[XmlIgnore]
		[Browsable(false)]
		public bool isGetRewardSpecified
		{
			get
			{
				return this._isGetReward != null;
			}
			set
			{
				bool flag = value == (this._isGetReward == null);
				if (flag)
				{
					this._isGetReward = (value ? new bool?(this.isGetReward) : null);
				}
			}
		}

		// Token: 0x060060E6 RID: 24806 RVA: 0x000B8D78 File Offset: 0x000B6F78
		private bool ShouldSerializeisGetReward()
		{
			return this.isGetRewardSpecified;
		}

		// Token: 0x060060E7 RID: 24807 RVA: 0x000B8D90 File Offset: 0x000B6F90
		private void ResetisGetReward()
		{
			this.isGetRewardSpecified = false;
		}

		// Token: 0x17001E7C RID: 7804
		// (get) Token: 0x060060E8 RID: 24808 RVA: 0x000B8D9C File Offset: 0x000B6F9C
		// (set) Token: 0x060060E9 RID: 24809 RVA: 0x000B8DC8 File Offset: 0x000B6FC8
		[ProtoMember(3, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
		public int rank
		{
			get
			{
				return this._rank ?? 0;
			}
			set
			{
				this._rank = new int?(value);
			}
		}

		// Token: 0x17001E7D RID: 7805
		// (get) Token: 0x060060EA RID: 24810 RVA: 0x000B8DD8 File Offset: 0x000B6FD8
		// (set) Token: 0x060060EB RID: 24811 RVA: 0x000B8DF8 File Offset: 0x000B6FF8
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
					this._rank = (value ? new int?(this.rank) : null);
				}
			}
		}

		// Token: 0x060060EC RID: 24812 RVA: 0x000B8E3C File Offset: 0x000B703C
		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		// Token: 0x060060ED RID: 24813 RVA: 0x000B8E54 File Offset: 0x000B7054
		private void Resetrank()
		{
			this.rankSpecified = false;
		}

		// Token: 0x17001E7E RID: 7806
		// (get) Token: 0x060060EE RID: 24814 RVA: 0x000B8E60 File Offset: 0x000B7060
		// (set) Token: 0x060060EF RID: 24815 RVA: 0x000B8E8C File Offset: 0x000B708C
		[ProtoMember(4, IsRequired = false, Name = "hasCommended", DataFormat = DataFormat.Default)]
		public bool hasCommended
		{
			get
			{
				return this._hasCommended ?? false;
			}
			set
			{
				this._hasCommended = new bool?(value);
			}
		}

		// Token: 0x17001E7F RID: 7807
		// (get) Token: 0x060060F0 RID: 24816 RVA: 0x000B8E9C File Offset: 0x000B709C
		// (set) Token: 0x060060F1 RID: 24817 RVA: 0x000B8EBC File Offset: 0x000B70BC
		[XmlIgnore]
		[Browsable(false)]
		public bool hasCommendedSpecified
		{
			get
			{
				return this._hasCommended != null;
			}
			set
			{
				bool flag = value == (this._hasCommended == null);
				if (flag)
				{
					this._hasCommended = (value ? new bool?(this.hasCommended) : null);
				}
			}
		}

		// Token: 0x060060F2 RID: 24818 RVA: 0x000B8F00 File Offset: 0x000B7100
		private bool ShouldSerializehasCommended()
		{
			return this.hasCommendedSpecified;
		}

		// Token: 0x060060F3 RID: 24819 RVA: 0x000B8F18 File Offset: 0x000B7118
		private void ResethasCommended()
		{
			this.hasCommendedSpecified = false;
		}

		// Token: 0x17001E80 RID: 7808
		// (get) Token: 0x060060F4 RID: 24820 RVA: 0x000B8F24 File Offset: 0x000B7124
		// (set) Token: 0x060060F5 RID: 24821 RVA: 0x000B8F50 File Offset: 0x000B7150
		[ProtoMember(5, IsRequired = false, Name = "totalRank", DataFormat = DataFormat.TwosComplement)]
		public int totalRank
		{
			get
			{
				return this._totalRank ?? 0;
			}
			set
			{
				this._totalRank = new int?(value);
			}
		}

		// Token: 0x17001E81 RID: 7809
		// (get) Token: 0x060060F6 RID: 24822 RVA: 0x000B8F60 File Offset: 0x000B7160
		// (set) Token: 0x060060F7 RID: 24823 RVA: 0x000B8F80 File Offset: 0x000B7180
		[XmlIgnore]
		[Browsable(false)]
		public bool totalRankSpecified
		{
			get
			{
				return this._totalRank != null;
			}
			set
			{
				bool flag = value == (this._totalRank == null);
				if (flag)
				{
					this._totalRank = (value ? new int?(this.totalRank) : null);
				}
			}
		}

		// Token: 0x060060F8 RID: 24824 RVA: 0x000B8FC4 File Offset: 0x000B71C4
		private bool ShouldSerializetotalRank()
		{
			return this.totalRankSpecified;
		}

		// Token: 0x060060F9 RID: 24825 RVA: 0x000B8FDC File Offset: 0x000B71DC
		private void ResettotalRank()
		{
			this.totalRankSpecified = false;
		}

		// Token: 0x17001E82 RID: 7810
		// (get) Token: 0x060060FA RID: 24826 RVA: 0x000B8FE8 File Offset: 0x000B71E8
		[ProtoMember(6, Name = "commendedStarLevels", DataFormat = DataFormat.TwosComplement)]
		public List<uint> commendedStarLevels
		{
			get
			{
				return this._commendedStarLevels;
			}
		}

		// Token: 0x060060FB RID: 24827 RVA: 0x000B9000 File Offset: 0x000B7200
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001781 RID: 6017
		private int? _firstPassID;

		// Token: 0x04001782 RID: 6018
		private bool? _isGetReward;

		// Token: 0x04001783 RID: 6019
		private int? _rank;

		// Token: 0x04001784 RID: 6020
		private bool? _hasCommended;

		// Token: 0x04001785 RID: 6021
		private int? _totalRank;

		// Token: 0x04001786 RID: 6022
		private readonly List<uint> _commendedStarLevels = new List<uint>();

		// Token: 0x04001787 RID: 6023
		private IExtension extensionObject;
	}
}
