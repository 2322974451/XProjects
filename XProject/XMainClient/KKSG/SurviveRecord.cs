using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SurviveRecord")]
	[Serializable]
	public class SurviveRecord : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "lastweekuptime", DataFormat = DataFormat.TwosComplement)]
		public uint lastweekuptime
		{
			get
			{
				return this._lastweekuptime ?? 0U;
			}
			set
			{
				this._lastweekuptime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lastweekuptimeSpecified
		{
			get
			{
				return this._lastweekuptime != null;
			}
			set
			{
				bool flag = value == (this._lastweekuptime == null);
				if (flag)
				{
					this._lastweekuptime = (value ? new uint?(this.lastweekuptime) : null);
				}
			}
		}

		private bool ShouldSerializelastweekuptime()
		{
			return this.lastweekuptimeSpecified;
		}

		private void Resetlastweekuptime()
		{
			this.lastweekuptimeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "point", DataFormat = DataFormat.TwosComplement)]
		public uint point
		{
			get
			{
				return this._point ?? 0U;
			}
			set
			{
				this._point = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool pointSpecified
		{
			get
			{
				return this._point != null;
			}
			set
			{
				bool flag = value == (this._point == null);
				if (flag)
				{
					this._point = (value ? new uint?(this.point) : null);
				}
			}
		}

		private bool ShouldSerializepoint()
		{
			return this.pointSpecified;
		}

		private void Resetpoint()
		{
			this.pointSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "topcount", DataFormat = DataFormat.TwosComplement)]
		public uint topcount
		{
			get
			{
				return this._topcount ?? 0U;
			}
			set
			{
				this._topcount = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool topcountSpecified
		{
			get
			{
				return this._topcount != null;
			}
			set
			{
				bool flag = value == (this._topcount == null);
				if (flag)
				{
					this._topcount = (value ? new uint?(this.topcount) : null);
				}
			}
		}

		private bool ShouldSerializetopcount()
		{
			return this.topcountSpecified;
		}

		private void Resettopcount()
		{
			this.topcountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "givereward", DataFormat = DataFormat.Default)]
		public bool givereward
		{
			get
			{
				return this._givereward ?? false;
			}
			set
			{
				this._givereward = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool giverewardSpecified
		{
			get
			{
				return this._givereward != null;
			}
			set
			{
				bool flag = value == (this._givereward == null);
				if (flag)
				{
					this._givereward = (value ? new bool?(this.givereward) : null);
				}
			}
		}

		private bool ShouldSerializegivereward()
		{
			return this.giverewardSpecified;
		}

		private void Resetgivereward()
		{
			this.giverewardSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _lastweekuptime;

		private uint? _point;

		private uint? _topcount;

		private bool? _givereward;

		private IExtension extensionObject;
	}
}
