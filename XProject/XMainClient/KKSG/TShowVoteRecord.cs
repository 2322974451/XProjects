using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TShowVoteRecord")]
	[Serializable]
	public class TShowVoteRecord : IExtensible
	{

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

		private bool ShouldSerializeupdateTime()
		{
			return this.updateTimeSpecified;
		}

		private void ResetupdateTime()
		{
			this.updateTimeSpecified = false;
		}

		[ProtoMember(2, Name = "voteData", DataFormat = DataFormat.Default)]
		public List<TShowRoleDailyVoteData> voteData
		{
			get
			{
				return this._voteData;
			}
		}

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

		private bool ShouldSerializehaveSendRank()
		{
			return this.haveSendRankSpecified;
		}

		private void ResethaveSendRank()
		{
			this.haveSendRankSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _updateTime;

		private readonly List<TShowRoleDailyVoteData> _voteData = new List<TShowRoleDailyVoteData>();

		private bool? _haveSendRank;

		private IExtension extensionObject;
	}
}
