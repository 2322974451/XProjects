using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildCampInfoRes")]
	[Serializable]
	public class GuildCampInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, Name = "rankInfos", DataFormat = DataFormat.Default)]
		public List<GuildCampRankInfo> rankInfos
		{
			get
			{
				return this._rankInfos;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "curCampID", DataFormat = DataFormat.TwosComplement)]
		public int curCampID
		{
			get
			{
				return this._curCampID ?? 0;
			}
			set
			{
				this._curCampID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curCampIDSpecified
		{
			get
			{
				return this._curCampID != null;
			}
			set
			{
				bool flag = value == (this._curCampID == null);
				if (flag)
				{
					this._curCampID = (value ? new int?(this.curCampID) : null);
				}
			}
		}

		private bool ShouldSerializecurCampID()
		{
			return this.curCampIDSpecified;
		}

		private void ResetcurCampID()
		{
			this.curCampIDSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "nextCampID", DataFormat = DataFormat.TwosComplement)]
		public int nextCampID
		{
			get
			{
				return this._nextCampID ?? 0;
			}
			set
			{
				this._nextCampID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nextCampIDSpecified
		{
			get
			{
				return this._nextCampID != null;
			}
			set
			{
				bool flag = value == (this._nextCampID == null);
				if (flag)
				{
					this._nextCampID = (value ? new int?(this.nextCampID) : null);
				}
			}
		}

		private bool ShouldSerializenextCampID()
		{
			return this.nextCampIDSpecified;
		}

		private void ResetnextCampID()
		{
			this.nextCampIDSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "leftCount", DataFormat = DataFormat.TwosComplement)]
		public int leftCount
		{
			get
			{
				return this._leftCount ?? 0;
			}
			set
			{
				this._leftCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftCountSpecified
		{
			get
			{
				return this._leftCount != null;
			}
			set
			{
				bool flag = value == (this._leftCount == null);
				if (flag)
				{
					this._leftCount = (value ? new int?(this.leftCount) : null);
				}
			}
		}

		private bool ShouldSerializeleftCount()
		{
			return this.leftCountSpecified;
		}

		private void ResetleftCount()
		{
			this.leftCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private readonly List<GuildCampRankInfo> _rankInfos = new List<GuildCampRankInfo>();

		private int? _curCampID;

		private int? _nextCampID;

		private int? _leftCount;

		private IExtension extensionObject;
	}
}
