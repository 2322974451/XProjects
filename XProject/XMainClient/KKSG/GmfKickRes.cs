using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GmfKickRes")]
	[Serializable]
	public class GmfKickRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "cooldowntime", DataFormat = DataFormat.TwosComplement)]
		public uint cooldowntime
		{
			get
			{
				return this._cooldowntime ?? 0U;
			}
			set
			{
				this._cooldowntime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool cooldowntimeSpecified
		{
			get
			{
				return this._cooldowntime != null;
			}
			set
			{
				bool flag = value == (this._cooldowntime == null);
				if (flag)
				{
					this._cooldowntime = (value ? new uint?(this.cooldowntime) : null);
				}
			}
		}

		private bool ShouldSerializecooldowntime()
		{
			return this.cooldowntimeSpecified;
		}

		private void Resetcooldowntime()
		{
			this.cooldowntimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "leaderkick", DataFormat = DataFormat.TwosComplement)]
		public int leaderkick
		{
			get
			{
				return this._leaderkick ?? 0;
			}
			set
			{
				this._leaderkick = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leaderkickSpecified
		{
			get
			{
				return this._leaderkick != null;
			}
			set
			{
				bool flag = value == (this._leaderkick == null);
				if (flag)
				{
					this._leaderkick = (value ? new int?(this.leaderkick) : null);
				}
			}
		}

		private bool ShouldSerializeleaderkick()
		{
			return this.leaderkickSpecified;
		}

		private void Resetleaderkick()
		{
			this.leaderkickSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "kickname", DataFormat = DataFormat.Default)]
		public string kickname
		{
			get
			{
				return this._kickname ?? "";
			}
			set
			{
				this._kickname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool kicknameSpecified
		{
			get
			{
				return this._kickname != null;
			}
			set
			{
				bool flag = value == (this._kickname == null);
				if (flag)
				{
					this._kickname = (value ? this.kickname : null);
				}
			}
		}

		private bool ShouldSerializekickname()
		{
			return this.kicknameSpecified;
		}

		private void Resetkickname()
		{
			this.kicknameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _cooldowntime;

		private int? _leaderkick;

		private string _kickname;

		private IExtension extensionObject;
	}
}
