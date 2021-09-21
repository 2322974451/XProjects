using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{
	// Token: 0x0200069F RID: 1695
	[ProtoContract(Name = "FirstPassStageInfo2Client")]
	[Serializable]
	public class FirstPassStageInfo2Client : IExtensible
	{
		// Token: 0x170022E6 RID: 8934
		// (get) Token: 0x06006E46 RID: 28230 RVA: 0x000D3004 File Offset: 0x000D1204
		// (set) Token: 0x06006E47 RID: 28231 RVA: 0x000D3030 File Offset: 0x000D1230
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

		// Token: 0x170022E7 RID: 8935
		// (get) Token: 0x06006E48 RID: 28232 RVA: 0x000D3040 File Offset: 0x000D1240
		// (set) Token: 0x06006E49 RID: 28233 RVA: 0x000D3060 File Offset: 0x000D1260
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

		// Token: 0x06006E4A RID: 28234 RVA: 0x000D30A4 File Offset: 0x000D12A4
		private bool ShouldSerializefirstPassID()
		{
			return this.firstPassIDSpecified;
		}

		// Token: 0x06006E4B RID: 28235 RVA: 0x000D30BC File Offset: 0x000D12BC
		private void ResetfirstPassID()
		{
			this.firstPassIDSpecified = false;
		}

		// Token: 0x170022E8 RID: 8936
		// (get) Token: 0x06006E4C RID: 28236 RVA: 0x000D30C8 File Offset: 0x000D12C8
		// (set) Token: 0x06006E4D RID: 28237 RVA: 0x000D30F4 File Offset: 0x000D12F4
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

		// Token: 0x170022E9 RID: 8937
		// (get) Token: 0x06006E4E RID: 28238 RVA: 0x000D3104 File Offset: 0x000D1304
		// (set) Token: 0x06006E4F RID: 28239 RVA: 0x000D3124 File Offset: 0x000D1324
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

		// Token: 0x06006E50 RID: 28240 RVA: 0x000D3168 File Offset: 0x000D1368
		private bool ShouldSerializeisGetReward()
		{
			return this.isGetRewardSpecified;
		}

		// Token: 0x06006E51 RID: 28241 RVA: 0x000D3180 File Offset: 0x000D1380
		private void ResetisGetReward()
		{
			this.isGetRewardSpecified = false;
		}

		// Token: 0x170022EA RID: 8938
		// (get) Token: 0x06006E52 RID: 28242 RVA: 0x000D318C File Offset: 0x000D138C
		// (set) Token: 0x06006E53 RID: 28243 RVA: 0x000D31B8 File Offset: 0x000D13B8
		[ProtoMember(3, IsRequired = false, Name = "myRank", DataFormat = DataFormat.TwosComplement)]
		public int myRank
		{
			get
			{
				return this._myRank ?? 0;
			}
			set
			{
				this._myRank = new int?(value);
			}
		}

		// Token: 0x170022EB RID: 8939
		// (get) Token: 0x06006E54 RID: 28244 RVA: 0x000D31C8 File Offset: 0x000D13C8
		// (set) Token: 0x06006E55 RID: 28245 RVA: 0x000D31E8 File Offset: 0x000D13E8
		[XmlIgnore]
		[Browsable(false)]
		public bool myRankSpecified
		{
			get
			{
				return this._myRank != null;
			}
			set
			{
				bool flag = value == (this._myRank == null);
				if (flag)
				{
					this._myRank = (value ? new int?(this.myRank) : null);
				}
			}
		}

		// Token: 0x06006E56 RID: 28246 RVA: 0x000D322C File Offset: 0x000D142C
		private bool ShouldSerializemyRank()
		{
			return this.myRankSpecified;
		}

		// Token: 0x06006E57 RID: 28247 RVA: 0x000D3244 File Offset: 0x000D1444
		private void ResetmyRank()
		{
			this.myRankSpecified = false;
		}

		// Token: 0x170022EC RID: 8940
		// (get) Token: 0x06006E58 RID: 28248 RVA: 0x000D3250 File Offset: 0x000D1450
		// (set) Token: 0x06006E59 RID: 28249 RVA: 0x000D3268 File Offset: 0x000D1468
		[ProtoMember(4, IsRequired = true, Name = "totalRank", DataFormat = DataFormat.TwosComplement)]
		public int totalRank
		{
			get
			{
				return this._totalRank;
			}
			set
			{
				this._totalRank = value;
			}
		}

		// Token: 0x170022ED RID: 8941
		// (get) Token: 0x06006E5A RID: 28250 RVA: 0x000D3274 File Offset: 0x000D1474
		// (set) Token: 0x06006E5B RID: 28251 RVA: 0x000D32A0 File Offset: 0x000D14A0
		[ProtoMember(5, IsRequired = false, Name = "hasCommended", DataFormat = DataFormat.Default)]
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

		// Token: 0x170022EE RID: 8942
		// (get) Token: 0x06006E5C RID: 28252 RVA: 0x000D32B0 File Offset: 0x000D14B0
		// (set) Token: 0x06006E5D RID: 28253 RVA: 0x000D32D0 File Offset: 0x000D14D0
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

		// Token: 0x06006E5E RID: 28254 RVA: 0x000D3314 File Offset: 0x000D1514
		private bool ShouldSerializehasCommended()
		{
			return this.hasCommendedSpecified;
		}

		// Token: 0x06006E5F RID: 28255 RVA: 0x000D332C File Offset: 0x000D152C
		private void ResethasCommended()
		{
			this.hasCommendedSpecified = false;
		}

		// Token: 0x06006E60 RID: 28256 RVA: 0x000D3338 File Offset: 0x000D1538
		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		// Token: 0x04001A66 RID: 6758
		private int? _firstPassID;

		// Token: 0x04001A67 RID: 6759
		private bool? _isGetReward;

		// Token: 0x04001A68 RID: 6760
		private int? _myRank;

		// Token: 0x04001A69 RID: 6761
		private int _totalRank;

		// Token: 0x04001A6A RID: 6762
		private bool? _hasCommended;

		// Token: 0x04001A6B RID: 6763
		private IExtension extensionObject;
	}
}
