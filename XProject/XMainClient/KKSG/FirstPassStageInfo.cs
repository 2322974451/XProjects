using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "FirstPassStageInfo")]
	[Serializable]
	public class FirstPassStageInfo : IExtensible
	{

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

		private bool ShouldSerializefirstPassID()
		{
			return this.firstPassIDSpecified;
		}

		private void ResetfirstPassID()
		{
			this.firstPassIDSpecified = false;
		}

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

		private bool ShouldSerializeisGetReward()
		{
			return this.isGetRewardSpecified;
		}

		private void ResetisGetReward()
		{
			this.isGetRewardSpecified = false;
		}

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

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

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

		private bool ShouldSerializehasCommended()
		{
			return this.hasCommendedSpecified;
		}

		private void ResethasCommended()
		{
			this.hasCommendedSpecified = false;
		}

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

		private bool ShouldSerializetotalRank()
		{
			return this.totalRankSpecified;
		}

		private void ResettotalRank()
		{
			this.totalRankSpecified = false;
		}

		[ProtoMember(6, Name = "commendedStarLevels", DataFormat = DataFormat.TwosComplement)]
		public List<uint> commendedStarLevels
		{
			get
			{
				return this._commendedStarLevels;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _firstPassID;

		private bool? _isGetReward;

		private int? _rank;

		private bool? _hasCommended;

		private int? _totalRank;

		private readonly List<uint> _commendedStarLevels = new List<uint>();

		private IExtension extensionObject;
	}
}
