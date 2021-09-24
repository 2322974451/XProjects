using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResumeItem")]
	[Serializable]
	public class ResumeItem : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dtime", DataFormat = DataFormat.TwosComplement)]
		public uint dtime
		{
			get
			{
				return this._dtime ?? 0U;
			}
			set
			{
				this._dtime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dtimeSpecified
		{
			get
			{
				return this._dtime != null;
			}
			set
			{
				bool flag = value == (this._dtime == null);
				if (flag)
				{
					this._dtime = (value ? new uint?(this.dtime) : null);
				}
			}
		}

		private bool ShouldSerializedtime()
		{
			return this.dtimeSpecified;
		}

		private void Resetdtime()
		{
			this.dtimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "equip", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public Item equip
		{
			get
			{
				return this._equip;
			}
			set
			{
				this._equip = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _dtime;

		private Item _equip = null;

		private IExtension extensionObject;
	}
}
