using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GoalAwardsValue")]
	[Serializable]
	public class GoalAwardsValue : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "gkid", DataFormat = DataFormat.TwosComplement)]
		public uint gkid
		{
			get
			{
				return this._gkid ?? 0U;
			}
			set
			{
				this._gkid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gkidSpecified
		{
			get
			{
				return this._gkid != null;
			}
			set
			{
				bool flag = value == (this._gkid == null);
				if (flag)
				{
					this._gkid = (value ? new uint?(this.gkid) : null);
				}
			}
		}

		private bool ShouldSerializegkid()
		{
			return this.gkidSpecified;
		}

		private void Resetgkid()
		{
			this.gkidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "gkvalue", DataFormat = DataFormat.TwosComplement)]
		public double gkvalue
		{
			get
			{
				return this._gkvalue ?? 0.0;
			}
			set
			{
				this._gkvalue = new double?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool gkvalueSpecified
		{
			get
			{
				return this._gkvalue != null;
			}
			set
			{
				bool flag = value == (this._gkvalue == null);
				if (flag)
				{
					this._gkvalue = (value ? new double?(this.gkvalue) : null);
				}
			}
		}

		private bool ShouldSerializegkvalue()
		{
			return this.gkvalueSpecified;
		}

		private void Resetgkvalue()
		{
			this.gkvalueSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _gkid;

		private double? _gkvalue;

		private IExtension extensionObject;
	}
}
