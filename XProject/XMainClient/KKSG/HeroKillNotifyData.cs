using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "HeroKillNotifyData")]
	[Serializable]
	public class HeroKillNotifyData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "killer", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HeroKillUnit killer
		{
			get
			{
				return this._killer;
			}
			set
			{
				this._killer = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "dead", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public HeroKillUnit dead
		{
			get
			{
				return this._dead;
			}
			set
			{
				this._dead = value;
			}
		}

		[ProtoMember(3, Name = "assists", DataFormat = DataFormat.Default)]
		public List<HeroKillUnit> assists
		{
			get
			{
				return this._assists;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "multiKill", DataFormat = DataFormat.TwosComplement)]
		public uint multiKill
		{
			get
			{
				return this._multiKill ?? 0U;
			}
			set
			{
				this._multiKill = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool multiKillSpecified
		{
			get
			{
				return this._multiKill != null;
			}
			set
			{
				bool flag = value == (this._multiKill == null);
				if (flag)
				{
					this._multiKill = (value ? new uint?(this.multiKill) : null);
				}
			}
		}

		private bool ShouldSerializemultiKill()
		{
			return this.multiKillSpecified;
		}

		private void ResetmultiKill()
		{
			this.multiKillSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "isFirstBlood", DataFormat = DataFormat.Default)]
		public bool isFirstBlood
		{
			get
			{
				return this._isFirstBlood ?? false;
			}
			set
			{
				this._isFirstBlood = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isFirstBloodSpecified
		{
			get
			{
				return this._isFirstBlood != null;
			}
			set
			{
				bool flag = value == (this._isFirstBlood == null);
				if (flag)
				{
					this._isFirstBlood = (value ? new bool?(this.isFirstBlood) : null);
				}
			}
		}

		private bool ShouldSerializeisFirstBlood()
		{
			return this.isFirstBloodSpecified;
		}

		private void ResetisFirstBlood()
		{
			this.isFirstBloodSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private HeroKillUnit _killer = null;

		private HeroKillUnit _dead = null;

		private readonly List<HeroKillUnit> _assists = new List<HeroKillUnit>();

		private uint? _multiKill;

		private bool? _isFirstBlood;

		private IExtension extensionObject;
	}
}
