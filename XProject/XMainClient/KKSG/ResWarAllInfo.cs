using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ResWarAllInfo")]
	[Serializable]
	public class ResWarAllInfo : IExtensible
	{

		[ProtoMember(1, Name = "groupdata", DataFormat = DataFormat.Default)]
		public List<ResWarGroupData> groupdata
		{
			get
			{
				return this._groupdata;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "timetype", DataFormat = DataFormat.TwosComplement)]
		public ResWarTimeType timetype
		{
			get
			{
				return this._timetype ?? ResWarTimeType.RealyTime;
			}
			set
			{
				this._timetype = new ResWarTimeType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timetypeSpecified
		{
			get
			{
				return this._timetype != null;
			}
			set
			{
				bool flag = value == (this._timetype == null);
				if (flag)
				{
					this._timetype = (value ? new ResWarTimeType?(this.timetype) : null);
				}
			}
		}

		private bool ShouldSerializetimetype()
		{
			return this.timetypeSpecified;
		}

		private void Resettimetype()
		{
			this.timetypeSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<ResWarGroupData> _groupdata = new List<ResWarGroupData>();

		private ResWarTimeType? _timetype;

		private uint? _lefttime;

		private IExtension extensionObject;
	}
}
