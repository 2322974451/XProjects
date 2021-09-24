using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "PkRankExtraData")]
	[Serializable]
	public class PkRankExtraData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "joincount", DataFormat = DataFormat.TwosComplement)]
		public uint joincount
		{
			get
			{
				return this._joincount ?? 0U;
			}
			set
			{
				this._joincount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool joincountSpecified
		{
			get
			{
				return this._joincount != null;
			}
			set
			{
				bool flag = value == (this._joincount == null);
				if (flag)
				{
					this._joincount = (value ? new uint?(this.joincount) : null);
				}
			}
		}

		private bool ShouldSerializejoincount()
		{
			return this.joincountSpecified;
		}

		private void Resetjoincount()
		{
			this.joincountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "winrate", DataFormat = DataFormat.FixedSize)]
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

		[ProtoMember(3, IsRequired = false, Name = "continuewin", DataFormat = DataFormat.TwosComplement)]
		public uint continuewin
		{
			get
			{
				return this._continuewin ?? 0U;
			}
			set
			{
				this._continuewin = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool continuewinSpecified
		{
			get
			{
				return this._continuewin != null;
			}
			set
			{
				bool flag = value == (this._continuewin == null);
				if (flag)
				{
					this._continuewin = (value ? new uint?(this.continuewin) : null);
				}
			}
		}

		private bool ShouldSerializecontinuewin()
		{
			return this.continuewinSpecified;
		}

		private void Resetcontinuewin()
		{
			this.continuewinSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _joincount;

		private float? _winrate;

		private uint? _continuewin;

		private IExtension extensionObject;
	}
}
