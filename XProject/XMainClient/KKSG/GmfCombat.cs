using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfCombat")]
	[Serializable]
	public class GmfCombat : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "killcount", DataFormat = DataFormat.TwosComplement)]
		public uint killcount
		{
			get
			{
				return this._killcount ?? 0U;
			}
			set
			{
				this._killcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killcountSpecified
		{
			get
			{
				return this._killcount != null;
			}
			set
			{
				bool flag = value == (this._killcount == null);
				if (flag)
				{
					this._killcount = (value ? new uint?(this.killcount) : null);
				}
			}
		}

		private bool ShouldSerializekillcount()
		{
			return this.killcountSpecified;
		}

		private void Resetkillcount()
		{
			this.killcountSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "damage", DataFormat = DataFormat.TwosComplement)]
		public double damage
		{
			get
			{
				return this._damage ?? 0.0;
			}
			set
			{
				this._damage = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool damageSpecified
		{
			get
			{
				return this._damage != null;
			}
			set
			{
				bool flag = value == (this._damage == null);
				if (flag)
				{
					this._damage = (value ? new double?(this.damage) : null);
				}
			}
		}

		private bool ShouldSerializedamage()
		{
			return this.damageSpecified;
		}

		private void Resetdamage()
		{
			this.damageSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "deadcount", DataFormat = DataFormat.TwosComplement)]
		public uint deadcount
		{
			get
			{
				return this._deadcount ?? 0U;
			}
			set
			{
				this._deadcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deadcountSpecified
		{
			get
			{
				return this._deadcount != null;
			}
			set
			{
				bool flag = value == (this._deadcount == null);
				if (flag)
				{
					this._deadcount = (value ? new uint?(this.deadcount) : null);
				}
			}
		}

		private bool ShouldSerializedeadcount()
		{
			return this.deadcountSpecified;
		}

		private void Resetdeadcount()
		{
			this.deadcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _killcount;

		private double? _damage;

		private uint? _deadcount;

		private IExtension extensionObject;
	}
}
