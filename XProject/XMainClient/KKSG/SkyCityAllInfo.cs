using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityAllInfo")]
	[Serializable]
	public class SkyCityAllInfo : IExtensible
	{

		[ProtoMember(1, Name = "groupdata", DataFormat = DataFormat.Default)]
		public List<SkyCityGroupData> groupdata
		{
			get
			{
				return this._groupdata;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "timetype", DataFormat = DataFormat.TwosComplement)]
		public SkyCityTimeType timetype
		{
			get
			{
				return this._timetype ?? SkyCityTimeType.Waiting;
			}
			set
			{
				this._timetype = new SkyCityTimeType?(value);
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
					this._timetype = (value ? new SkyCityTimeType?(this.timetype) : null);
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

		private readonly List<SkyCityGroupData> _groupdata = new List<SkyCityGroupData>();

		private SkyCityTimeType? _timetype;

		private uint? _lefttime;

		private IExtension extensionObject;
	}
}
