using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PandoraDrop")]
	[Serializable]
	public class PandoraDrop : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "pandoraDropID", DataFormat = DataFormat.TwosComplement)]
		public uint pandoraDropID
		{
			get
			{
				return this._pandoraDropID ?? 0U;
			}
			set
			{
				this._pandoraDropID = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pandoraDropIDSpecified
		{
			get
			{
				return this._pandoraDropID != null;
			}
			set
			{
				bool flag = value == (this._pandoraDropID == null);
				if (flag)
				{
					this._pandoraDropID = (value ? new uint?(this.pandoraDropID) : null);
				}
			}
		}

		private bool ShouldSerializepandoraDropID()
		{
			return this.pandoraDropIDSpecified;
		}

		private void ResetpandoraDropID()
		{
			this.pandoraDropIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "betterDropTimes", DataFormat = DataFormat.TwosComplement)]
		public uint betterDropTimes
		{
			get
			{
				return this._betterDropTimes ?? 0U;
			}
			set
			{
				this._betterDropTimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool betterDropTimesSpecified
		{
			get
			{
				return this._betterDropTimes != null;
			}
			set
			{
				bool flag = value == (this._betterDropTimes == null);
				if (flag)
				{
					this._betterDropTimes = (value ? new uint?(this.betterDropTimes) : null);
				}
			}
		}

		private bool ShouldSerializebetterDropTimes()
		{
			return this.betterDropTimesSpecified;
		}

		private void ResetbetterDropTimes()
		{
			this.betterDropTimesSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "noUsedBestDropTimes", DataFormat = DataFormat.TwosComplement)]
		public uint noUsedBestDropTimes
		{
			get
			{
				return this._noUsedBestDropTimes ?? 0U;
			}
			set
			{
				this._noUsedBestDropTimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool noUsedBestDropTimesSpecified
		{
			get
			{
				return this._noUsedBestDropTimes != null;
			}
			set
			{
				bool flag = value == (this._noUsedBestDropTimes == null);
				if (flag)
				{
					this._noUsedBestDropTimes = (value ? new uint?(this.noUsedBestDropTimes) : null);
				}
			}
		}

		private bool ShouldSerializenoUsedBestDropTimes()
		{
			return this.noUsedBestDropTimesSpecified;
		}

		private void ResetnoUsedBestDropTimes()
		{
			this.noUsedBestDropTimesSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "nextBetterDropTimes", DataFormat = DataFormat.TwosComplement)]
		public uint nextBetterDropTimes
		{
			get
			{
				return this._nextBetterDropTimes ?? 0U;
			}
			set
			{
				this._nextBetterDropTimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nextBetterDropTimesSpecified
		{
			get
			{
				return this._nextBetterDropTimes != null;
			}
			set
			{
				bool flag = value == (this._nextBetterDropTimes == null);
				if (flag)
				{
					this._nextBetterDropTimes = (value ? new uint?(this.nextBetterDropTimes) : null);
				}
			}
		}

		private bool ShouldSerializenextBetterDropTimes()
		{
			return this.nextBetterDropTimesSpecified;
		}

		private void ResetnextBetterDropTimes()
		{
			this.nextBetterDropTimesSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "noUsedNextBestDropTimes", DataFormat = DataFormat.TwosComplement)]
		public uint noUsedNextBestDropTimes
		{
			get
			{
				return this._noUsedNextBestDropTimes ?? 0U;
			}
			set
			{
				this._noUsedNextBestDropTimes = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool noUsedNextBestDropTimesSpecified
		{
			get
			{
				return this._noUsedNextBestDropTimes != null;
			}
			set
			{
				bool flag = value == (this._noUsedNextBestDropTimes == null);
				if (flag)
				{
					this._noUsedNextBestDropTimes = (value ? new uint?(this.noUsedNextBestDropTimes) : null);
				}
			}
		}

		private bool ShouldSerializenoUsedNextBestDropTimes()
		{
			return this.noUsedNextBestDropTimesSpecified;
		}

		private void ResetnoUsedNextBestDropTimes()
		{
			this.noUsedNextBestDropTimesSpecified = false;
		}

		[ProtoMember(6, Name = "bestDropTimes", DataFormat = DataFormat.TwosComplement)]
		public List<uint> bestDropTimes
		{
			get
			{
				return this._bestDropTimes;
			}
		}

		[ProtoMember(7, Name = "nextBestDropTimes", DataFormat = DataFormat.TwosComplement)]
		public List<uint> nextBestDropTimes
		{
			get
			{
				return this._nextBestDropTimes;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _pandoraDropID;

		private uint? _betterDropTimes;

		private uint? _noUsedBestDropTimes;

		private uint? _nextBetterDropTimes;

		private uint? _noUsedNextBestDropTimes;

		private readonly List<uint> _bestDropTimes = new List<uint>();

		private readonly List<uint> _nextBestDropTimes = new List<uint>();

		private IExtension extensionObject;
	}
}
