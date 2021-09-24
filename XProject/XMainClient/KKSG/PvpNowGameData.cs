using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PvpNowGameData")]
	[Serializable]
	public class PvpNowGameData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "group1WinCount", DataFormat = DataFormat.TwosComplement)]
		public int group1WinCount
		{
			get
			{
				return this._group1WinCount ?? 0;
			}
			set
			{
				this._group1WinCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool group1WinCountSpecified
		{
			get
			{
				return this._group1WinCount != null;
			}
			set
			{
				bool flag = value == (this._group1WinCount == null);
				if (flag)
				{
					this._group1WinCount = (value ? new int?(this.group1WinCount) : null);
				}
			}
		}

		private bool ShouldSerializegroup1WinCount()
		{
			return this.group1WinCountSpecified;
		}

		private void Resetgroup1WinCount()
		{
			this.group1WinCountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "group2WinCount", DataFormat = DataFormat.TwosComplement)]
		public int group2WinCount
		{
			get
			{
				return this._group2WinCount ?? 0;
			}
			set
			{
				this._group2WinCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool group2WinCountSpecified
		{
			get
			{
				return this._group2WinCount != null;
			}
			set
			{
				bool flag = value == (this._group2WinCount == null);
				if (flag)
				{
					this._group2WinCount = (value ? new int?(this.group2WinCount) : null);
				}
			}
		}

		private bool ShouldSerializegroup2WinCount()
		{
			return this.group2WinCountSpecified;
		}

		private void Resetgroup2WinCount()
		{
			this.group2WinCountSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "drawWinCount", DataFormat = DataFormat.TwosComplement)]
		public int drawWinCount
		{
			get
			{
				return this._drawWinCount ?? 0;
			}
			set
			{
				this._drawWinCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool drawWinCountSpecified
		{
			get
			{
				return this._drawWinCount != null;
			}
			set
			{
				bool flag = value == (this._drawWinCount == null);
				if (flag)
				{
					this._drawWinCount = (value ? new int?(this.drawWinCount) : null);
				}
			}
		}

		private bool ShouldSerializedrawWinCount()
		{
			return this.drawWinCountSpecified;
		}

		private void ResetdrawWinCount()
		{
			this.drawWinCountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "LeftTime", DataFormat = DataFormat.TwosComplement)]
		public uint LeftTime
		{
			get
			{
				return this._LeftTime ?? 0U;
			}
			set
			{
				this._LeftTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool LeftTimeSpecified
		{
			get
			{
				return this._LeftTime != null;
			}
			set
			{
				bool flag = value == (this._LeftTime == null);
				if (flag)
				{
					this._LeftTime = (value ? new uint?(this.LeftTime) : null);
				}
			}
		}

		private bool ShouldSerializeLeftTime()
		{
			return this.LeftTimeSpecified;
		}

		private void ResetLeftTime()
		{
			this.LeftTimeSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "isAllEnd", DataFormat = DataFormat.Default)]
		public bool isAllEnd
		{
			get
			{
				return this._isAllEnd ?? false;
			}
			set
			{
				this._isAllEnd = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isAllEndSpecified
		{
			get
			{
				return this._isAllEnd != null;
			}
			set
			{
				bool flag = value == (this._isAllEnd == null);
				if (flag)
				{
					this._isAllEnd = (value ? new bool?(this.isAllEnd) : null);
				}
			}
		}

		private bool ShouldSerializeisAllEnd()
		{
			return this.isAllEndSpecified;
		}

		private void ResetisAllEnd()
		{
			this.isAllEndSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "group1Leader", DataFormat = DataFormat.TwosComplement)]
		public ulong group1Leader
		{
			get
			{
				return this._group1Leader ?? 0UL;
			}
			set
			{
				this._group1Leader = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool group1LeaderSpecified
		{
			get
			{
				return this._group1Leader != null;
			}
			set
			{
				bool flag = value == (this._group1Leader == null);
				if (flag)
				{
					this._group1Leader = (value ? new ulong?(this.group1Leader) : null);
				}
			}
		}

		private bool ShouldSerializegroup1Leader()
		{
			return this.group1LeaderSpecified;
		}

		private void Resetgroup1Leader()
		{
			this.group1LeaderSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "group2Leader", DataFormat = DataFormat.TwosComplement)]
		public ulong group2Leader
		{
			get
			{
				return this._group2Leader ?? 0UL;
			}
			set
			{
				this._group2Leader = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool group2LeaderSpecified
		{
			get
			{
				return this._group2Leader != null;
			}
			set
			{
				bool flag = value == (this._group2Leader == null);
				if (flag)
				{
					this._group2Leader = (value ? new ulong?(this.group2Leader) : null);
				}
			}
		}

		private bool ShouldSerializegroup2Leader()
		{
			return this.group2LeaderSpecified;
		}

		private void Resetgroup2Leader()
		{
			this.group2LeaderSpecified = false;
		}

		[ProtoMember(8, Name = "nowUnitdData", DataFormat = DataFormat.Default)]
		public List<PvpNowUnitData> nowUnitdData
		{
			get
			{
				return this._nowUnitdData;
			}
		}

		[ProtoMember(9, IsRequired = false, Name = "errcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errcode
		{
			get
			{
				return this._errcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errcodeSpecified
		{
			get
			{
				return this._errcode != null;
			}
			set
			{
				bool flag = value == (this._errcode == null);
				if (flag)
				{
					this._errcode = (value ? new ErrorCode?(this.errcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrcode()
		{
			return this.errcodeSpecified;
		}

		private void Reseterrcode()
		{
			this.errcodeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _group1WinCount;

		private int? _group2WinCount;

		private int? _drawWinCount;

		private uint? _LeftTime;

		private bool? _isAllEnd;

		private ulong? _group1Leader;

		private ulong? _group2Leader;

		private readonly List<PvpNowUnitData> _nowUnitdData = new List<PvpNowUnitData>();

		private ErrorCode? _errcode;

		private IExtension extensionObject;
	}
}
