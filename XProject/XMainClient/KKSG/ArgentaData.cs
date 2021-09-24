using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ArgentaData")]
	[Serializable]
	public class ArgentaData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "argentaStartTime", DataFormat = DataFormat.TwosComplement)]
		public uint argentaStartTime
		{
			get
			{
				return this._argentaStartTime ?? 0U;
			}
			set
			{
				this._argentaStartTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool argentaStartTimeSpecified
		{
			get
			{
				return this._argentaStartTime != null;
			}
			set
			{
				bool flag = value == (this._argentaStartTime == null);
				if (flag)
				{
					this._argentaStartTime = (value ? new uint?(this.argentaStartTime) : null);
				}
			}
		}

		private bool ShouldSerializeargentaStartTime()
		{
			return this.argentaStartTimeSpecified;
		}

		private void ResetargentaStartTime()
		{
			this.argentaStartTimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public uint level
		{
			get
			{
				return this._level ?? 0U;
			}
			set
			{
				this._level = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new uint?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lastUpdateTime", DataFormat = DataFormat.TwosComplement)]
		public uint lastUpdateTime
		{
			get
			{
				return this._lastUpdateTime ?? 0U;
			}
			set
			{
				this._lastUpdateTime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastUpdateTimeSpecified
		{
			get
			{
				return this._lastUpdateTime != null;
			}
			set
			{
				bool flag = value == (this._lastUpdateTime == null);
				if (flag)
				{
					this._lastUpdateTime = (value ? new uint?(this.lastUpdateTime) : null);
				}
			}
		}

		private bool ShouldSerializelastUpdateTime()
		{
			return this.lastUpdateTimeSpecified;
		}

		private void ResetlastUpdateTime()
		{
			this.lastUpdateTimeSpecified = false;
		}

		[ProtoMember(4, Name = "getDailyRewards", DataFormat = DataFormat.TwosComplement)]
		public List<uint> getDailyRewards
		{
			get
			{
				return this._getDailyRewards;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _argentaStartTime;

		private uint? _level;

		private uint? _lastUpdateTime;

		private readonly List<uint> _getDailyRewards = new List<uint>();

		private IExtension extensionObject;
	}
}
