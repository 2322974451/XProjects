using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetSkyCraftRecordRes")]
	[Serializable]
	public class GetSkyCraftRecordRes : IExtensible
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

		[ProtoMember(2, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "losenum", DataFormat = DataFormat.TwosComplement)]
		public uint losenum
		{
			get
			{
				return this._losenum ?? 0U;
			}
			set
			{
				this._losenum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool losenumSpecified
		{
			get
			{
				return this._losenum != null;
			}
			set
			{
				bool flag = value == (this._losenum == null);
				if (flag)
				{
					this._losenum = (value ? new uint?(this.losenum) : null);
				}
			}
		}

		private bool ShouldSerializelosenum()
		{
			return this.losenumSpecified;
		}

		private void Resetlosenum()
		{
			this.losenumSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
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

		[ProtoMember(5, IsRequired = false, Name = "max_continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint max_continuewin
		{
			get
			{
				return this._max_continuewin ?? 0U;
			}
			set
			{
				this._max_continuewin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool max_continuewinSpecified
		{
			get
			{
				return this._max_continuewin != null;
			}
			set
			{
				bool flag = value == (this._max_continuewin == null);
				if (flag)
				{
					this._max_continuewin = (value ? new uint?(this.max_continuewin) : null);
				}
			}
		}

		private bool ShouldSerializemax_continuewin()
		{
			return this.max_continuewinSpecified;
		}

		private void Resetmax_continuewin()
		{
			this.max_continuewinSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "max_continuelose", DataFormat = DataFormat.TwosComplement)]
		public uint max_continuelose
		{
			get
			{
				return this._max_continuelose ?? 0U;
			}
			set
			{
				this._max_continuelose = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool max_continueloseSpecified
		{
			get
			{
				return this._max_continuelose != null;
			}
			set
			{
				bool flag = value == (this._max_continuelose == null);
				if (flag)
				{
					this._max_continuelose = (value ? new uint?(this.max_continuelose) : null);
				}
			}
		}

		private bool ShouldSerializemax_continuelose()
		{
			return this.max_continueloseSpecified;
		}

		private void Resetmax_continuelose()
		{
			this.max_continueloseSpecified = false;
		}

		[ProtoMember(7, Name = "records", DataFormat = DataFormat.Default)]
		public List<SkyCraftBattleRecord> records
		{
			get
			{
				return this._records;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private uint? _winnum;

		private uint? _losenum;

		private float? _winrate;

		private uint? _max_continuewin;

		private uint? _max_continuelose;

		private readonly List<SkyCraftBattleRecord> _records = new List<SkyCraftBattleRecord>();

		private IExtension extensionObject;
	}
}
