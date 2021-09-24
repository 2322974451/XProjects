using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GuildHallUpdatePoint")]
	[Serializable]
	public class GuildHallUpdatePoint : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "schoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint schoolpoint
		{
			get
			{
				return this._schoolpoint ?? 0U;
			}
			set
			{
				this._schoolpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool schoolpointSpecified
		{
			get
			{
				return this._schoolpoint != null;
			}
			set
			{
				bool flag = value == (this._schoolpoint == null);
				if (flag)
				{
					this._schoolpoint = (value ? new uint?(this.schoolpoint) : null);
				}
			}
		}

		private bool ShouldSerializeschoolpoint()
		{
			return this.schoolpointSpecified;
		}

		private void Resetschoolpoint()
		{
			this.schoolpointSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "hallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint hallpoint
		{
			get
			{
				return this._hallpoint ?? 0U;
			}
			set
			{
				this._hallpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool hallpointSpecified
		{
			get
			{
				return this._hallpoint != null;
			}
			set
			{
				bool flag = value == (this._hallpoint == null);
				if (flag)
				{
					this._hallpoint = (value ? new uint?(this.hallpoint) : null);
				}
			}
		}

		private bool ShouldSerializehallpoint()
		{
			return this.hallpointSpecified;
		}

		private void Resethallpoint()
		{
			this.hallpointSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "roleid", DataFormat = DataFormat.TwosComplement)]
		public ulong roleid
		{
			get
			{
				return this._roleid ?? 0UL;
			}
			set
			{
				this._roleid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleidSpecified
		{
			get
			{
				return this._roleid != null;
			}
			set
			{
				bool flag = value == (this._roleid == null);
				if (flag)
				{
					this._roleid = (value ? new ulong?(this.roleid) : null);
				}
			}
		}

		private bool ShouldSerializeroleid()
		{
			return this.roleidSpecified;
		}

		private void Resetroleid()
		{
			this.roleidSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "deltaschoolpoint", DataFormat = DataFormat.TwosComplement)]
		public uint deltaschoolpoint
		{
			get
			{
				return this._deltaschoolpoint ?? 0U;
			}
			set
			{
				this._deltaschoolpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deltaschoolpointSpecified
		{
			get
			{
				return this._deltaschoolpoint != null;
			}
			set
			{
				bool flag = value == (this._deltaschoolpoint == null);
				if (flag)
				{
					this._deltaschoolpoint = (value ? new uint?(this.deltaschoolpoint) : null);
				}
			}
		}

		private bool ShouldSerializedeltaschoolpoint()
		{
			return this.deltaschoolpointSpecified;
		}

		private void Resetdeltaschoolpoint()
		{
			this.deltaschoolpointSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "deltahallpoint", DataFormat = DataFormat.TwosComplement)]
		public uint deltahallpoint
		{
			get
			{
				return this._deltahallpoint ?? 0U;
			}
			set
			{
				this._deltahallpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deltahallpointSpecified
		{
			get
			{
				return this._deltahallpoint != null;
			}
			set
			{
				bool flag = value == (this._deltahallpoint == null);
				if (flag)
				{
					this._deltahallpoint = (value ? new uint?(this.deltahallpoint) : null);
				}
			}
		}

		private bool ShouldSerializedeltahallpoint()
		{
			return this.deltahallpointSpecified;
		}

		private void Resetdeltahallpoint()
		{
			this.deltahallpointSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _schoolpoint;

		private uint? _hallpoint;

		private ulong? _roleid;

		private uint? _deltaschoolpoint;

		private uint? _deltahallpoint;

		private IExtension extensionObject;
	}
}
