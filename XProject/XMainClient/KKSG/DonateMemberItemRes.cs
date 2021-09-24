using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "DonateMemberItemRes")]
	[Serializable]
	public class DonateMemberItemRes : IExtensible
	{

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

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "dailycount", DataFormat = DataFormat.TwosComplement)]
		public uint dailycount
		{
			get
			{
				return this._dailycount ?? 0U;
			}
			set
			{
				this._dailycount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dailycountSpecified
		{
			get
			{
				return this._dailycount != null;
			}
			set
			{
				bool flag = value == (this._dailycount == null);
				if (flag)
				{
					this._dailycount = (value ? new uint?(this.dailycount) : null);
				}
			}
		}

		private bool ShouldSerializedailycount()
		{
			return this.dailycountSpecified;
		}

		private void Resetdailycount()
		{
			this.dailycountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "totalcount", DataFormat = DataFormat.TwosComplement)]
		public uint totalcount
		{
			get
			{
				return this._totalcount ?? 0U;
			}
			set
			{
				this._totalcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalcountSpecified
		{
			get
			{
				return this._totalcount != null;
			}
			set
			{
				bool flag = value == (this._totalcount == null);
				if (flag)
				{
					this._totalcount = (value ? new uint?(this.totalcount) : null);
				}
			}
		}

		private bool ShouldSerializetotalcount()
		{
			return this.totalcountSpecified;
		}

		private void Resettotalcount()
		{
			this.totalcountSpecified = false;
		}

		[ProtoMember(4, Name = "rankitem", DataFormat = DataFormat.Default)]
		public List<GuildMemberDonateRankItem> rankitem
		{
			get
			{
				return this._rankitem;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "getcount", DataFormat = DataFormat.TwosComplement)]
		public uint getcount
		{
			get
			{
				return this._getcount ?? 0U;
			}
			set
			{
				this._getcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool getcountSpecified
		{
			get
			{
				return this._getcount != null;
			}
			set
			{
				bool flag = value == (this._getcount == null);
				if (flag)
				{
					this._getcount = (value ? new uint?(this.getcount) : null);
				}
			}
		}

		private bool ShouldSerializegetcount()
		{
			return this.getcountSpecified;
		}

		private void Resetgetcount()
		{
			this.getcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _dailycount;

		private uint? _totalcount;

		private readonly List<GuildMemberDonateRankItem> _rankitem = new List<GuildMemberDonateRankItem>();

		private uint? _getcount;

		private IExtension extensionObject;
	}
}
