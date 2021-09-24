using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetSkyCraftInfoRes")]
	[Serializable]
	public class GetSkyCraftInfoRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "stid", DataFormat = DataFormat.TwosComplement)]
		public ulong stid
		{
			get
			{
				return this._stid ?? 0UL;
			}
			set
			{
				this._stid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool stidSpecified
		{
			get
			{
				return this._stid != null;
			}
			set
			{
				bool flag = value == (this._stid == null);
				if (flag)
				{
					this._stid = (value ? new ulong?(this.stid) : null);
				}
			}
		}

		private bool ShouldSerializestid()
		{
			return this.stidSpecified;
		}

		private void Resetstid()
		{
			this.stidSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "total_num", DataFormat = DataFormat.TwosComplement)]
		public uint total_num
		{
			get
			{
				return this._total_num ?? 0U;
			}
			set
			{
				this._total_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool total_numSpecified
		{
			get
			{
				return this._total_num != null;
			}
			set
			{
				bool flag = value == (this._total_num == null);
				if (flag)
				{
					this._total_num = (value ? new uint?(this.total_num) : null);
				}
			}
		}

		private bool ShouldSerializetotal_num()
		{
			return this.total_numSpecified;
		}

		private void Resettotal_num()
		{
			this.total_numSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
		public float winrate
		{
			get
			{
				return this._winrate ?? 0f;
			}
			set
			{
				this._winrate = new float?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winrateSpecified
		{
			get
			{
				return this._winrate != null;
			}
			set
			{
				bool flag = value == (this._winrate == null);
				if (flag)
				{
					this._winrate = (value ? new float?(this.winrate) : null);
				}
			}
		}

		private bool ShouldSerializewinrate()
		{
			return this.winrateSpecified;
		}

		private void Resetwinrate()
		{
			this.winrateSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "rank", DataFormat = DataFormat.TwosComplement)]
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

		[ProtoMember(7, Name = "members", DataFormat = DataFormat.Default)]
		public List<SkyTeamMemberInfo> members
		{
			get
			{
				return this._members;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "today_num", DataFormat = DataFormat.TwosComplement)]
		public uint today_num
		{
			get
			{
				return this._today_num ?? 0U;
			}
			set
			{
				this._today_num = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool today_numSpecified
		{
			get
			{
				return this._today_num != null;
			}
			set
			{
				bool flag = value == (this._today_num == null);
				if (flag)
				{
					this._today_num = (value ? new uint?(this.today_num) : null);
				}
			}
		}

		private bool ShouldSerializetoday_num()
		{
			return this.today_numSpecified;
		}

		private void Resettoday_num()
		{
			this.today_numSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private ulong? _stid;

		private string _name;

		private uint? _total_num;

		private float? _winrate;

		private uint? _rank;

		private readonly List<SkyTeamMemberInfo> _members = new List<SkyTeamMemberInfo>();

		private uint? _today_num;

		private IExtension extensionObject;
	}
}
