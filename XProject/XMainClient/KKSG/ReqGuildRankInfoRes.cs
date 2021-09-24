using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ReqGuildRankInfoRes")]
	[Serializable]
	public class ReqGuildRankInfoRes : IExtensible
	{

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

		private bool ShouldSerializeendTime()
		{
			return this.endTimeSpecified;
		}

		private void ResetendTime()
		{
			this.endTimeSpecified = false;
		}

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

		private bool ShouldSerializerank()
		{
			return this.rankSpecified;
		}

		private void Resetrank()
		{
			this.rankSpecified = false;
		}

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

		private bool ShouldSerializekeepTime()
		{
			return this.keepTimeSpecified;
		}

		private void ResetkeepTime()
		{
			this.keepTimeSpecified = false;
		}

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

		private bool ShouldSerializenowTime()
		{
			return this.nowTimeSpecified;
		}

		private void ResetnowTime()
		{
			this.nowTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _endTime;

		private uint? _rank;

		private uint? _keepTime;

		private uint? _nowTime;

		private IExtension extensionObject;
	}
}
