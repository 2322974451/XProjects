using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpecialStageInfo")]
	[Serializable]
	public class SpecialStageInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "arenaup", DataFormat = DataFormat.TwosComplement)]
		public uint arenaup
		{
			get
			{
				return this._arenaup ?? 0U;
			}
			set
			{
				this._arenaup = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool arenaupSpecified
		{
			get
			{
				return this._arenaup != null;
			}
			set
			{
				bool flag = value == (this._arenaup == null);
				if (flag)
				{
					this._arenaup = (value ? new uint?(this.arenaup) : null);
				}
			}
		}

		private bool ShouldSerializearenaup()
		{
			return this.arenaupSpecified;
		}

		private void Resetarenaup()
		{
			this.arenaupSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "bossrushresult", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BossRushResult bossrushresult
		{
			get
			{
				return this._bossrushresult;
			}
			set
			{
				this._bossrushresult = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "arenamissed", DataFormat = DataFormat.Default)]
		public bool arenamissed
		{
			get
			{
				return this._arenamissed ?? false;
			}
			set
			{
				this._arenamissed = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool arenamissedSpecified
		{
			get
			{
				return this._arenamissed != null;
			}
			set
			{
				bool flag = value == (this._arenamissed == null);
				if (flag)
				{
					this._arenamissed = (value ? new bool?(this.arenamissed) : null);
				}
			}
		}

		private bool ShouldSerializearenamissed()
		{
			return this.arenamissedSpecified;
		}

		private void Resetarenamissed()
		{
			this.arenamissedSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _arenaup;

		private BossRushResult _bossrushresult = null;

		private bool? _arenamissed;

		private IExtension extensionObject;
	}
}
