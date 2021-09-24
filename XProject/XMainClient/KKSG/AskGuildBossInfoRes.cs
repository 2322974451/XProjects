using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AskGuildBossInfoRes")]
	[Serializable]
	public class AskGuildBossInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorcode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorcode
		{
			get
			{
				return this._errorcode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorcode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorcodeSpecified
		{
			get
			{
				return this._errorcode != null;
			}
			set
			{
				bool flag = value == (this._errorcode == null);
				if (flag)
				{
					this._errorcode = (value ? new ErrorCode?(this.errorcode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorcode()
		{
			return this.errorcodeSpecified;
		}

		private void Reseterrorcode()
		{
			this.errorcodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "bossId", DataFormat = DataFormat.TwosComplement)]
		public uint bossId
		{
			get
			{
				return this._bossId ?? 0U;
			}
			set
			{
				this._bossId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bossIdSpecified
		{
			get
			{
				return this._bossId != null;
			}
			set
			{
				bool flag = value == (this._bossId == null);
				if (flag)
				{
					this._bossId = (value ? new uint?(this.bossId) : null);
				}
			}
		}

		private bool ShouldSerializebossId()
		{
			return this.bossIdSpecified;
		}

		private void ResetbossId()
		{
			this.bossIdSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "needKillBossId", DataFormat = DataFormat.TwosComplement)]
		public uint needKillBossId
		{
			get
			{
				return this._needKillBossId ?? 0U;
			}
			set
			{
				this._needKillBossId = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needKillBossIdSpecified
		{
			get
			{
				return this._needKillBossId != null;
			}
			set
			{
				bool flag = value == (this._needKillBossId == null);
				if (flag)
				{
					this._needKillBossId = (value ? new uint?(this.needKillBossId) : null);
				}
			}
		}

		private bool ShouldSerializeneedKillBossId()
		{
			return this.needKillBossIdSpecified;
		}

		private void ResetneedKillBossId()
		{
			this.needKillBossIdSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isFirstKill", DataFormat = DataFormat.Default)]
		public bool isFirstKill
		{
			get
			{
				return this._isFirstKill ?? false;
			}
			set
			{
				this._isFirstKill = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isFirstKillSpecified
		{
			get
			{
				return this._isFirstKill != null;
			}
			set
			{
				bool flag = value == (this._isFirstKill == null);
				if (flag)
				{
					this._isFirstKill = (value ? new bool?(this.isFirstKill) : null);
				}
			}
		}

		private bool ShouldSerializeisFirstKill()
		{
			return this.isFirstKillSpecified;
		}

		private void ResetisFirstKill()
		{
			this.isFirstKillSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "isLeader", DataFormat = DataFormat.Default)]
		public bool isLeader
		{
			get
			{
				return this._isLeader ?? false;
			}
			set
			{
				this._isLeader = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isLeaderSpecified
		{
			get
			{
				return this._isLeader != null;
			}
			set
			{
				bool flag = value == (this._isLeader == null);
				if (flag)
				{
					this._isLeader = (value ? new bool?(this.isLeader) : null);
				}
			}
		}

		private bool ShouldSerializeisLeader()
		{
			return this.isLeaderSpecified;
		}

		private void ResetisLeader()
		{
			this.isLeaderSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "needguildlvl", DataFormat = DataFormat.TwosComplement)]
		public uint needguildlvl
		{
			get
			{
				return this._needguildlvl ?? 0U;
			}
			set
			{
				this._needguildlvl = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needguildlvlSpecified
		{
			get
			{
				return this._needguildlvl != null;
			}
			set
			{
				bool flag = value == (this._needguildlvl == null);
				if (flag)
				{
					this._needguildlvl = (value ? new uint?(this.needguildlvl) : null);
				}
			}
		}

		private bool ShouldSerializeneedguildlvl()
		{
			return this.needguildlvlSpecified;
		}

		private void Resetneedguildlvl()
		{
			this.needguildlvlSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorcode;

		private uint? _bossId;

		private uint? _needKillBossId;

		private bool? _isFirstKill;

		private bool? _isLeader;

		private uint? _needguildlvl;

		private IExtension extensionObject;
	}
}
