using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "atlasdata")]
	[Serializable]
	public class atlasdata : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "groupid", DataFormat = DataFormat.TwosComplement)]
		public uint groupid
		{
			get
			{
				return this._groupid ?? 0U;
			}
			set
			{
				this._groupid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool groupidSpecified
		{
			get
			{
				return this._groupid != null;
			}
			set
			{
				bool flag = value == (this._groupid == null);
				if (flag)
				{
					this._groupid = (value ? new uint?(this.groupid) : null);
				}
			}
		}

		private bool ShouldSerializegroupid()
		{
			return this.groupidSpecified;
		}

		private void Resetgroupid()
		{
			this.groupidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "finishid", DataFormat = DataFormat.TwosComplement)]
		public uint finishid
		{
			get
			{
				return this._finishid ?? 0U;
			}
			set
			{
				this._finishid = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool finishidSpecified
		{
			get
			{
				return this._finishid != null;
			}
			set
			{
				bool flag = value == (this._finishid == null);
				if (flag)
				{
					this._finishid = (value ? new uint?(this.finishid) : null);
				}
			}
		}

		private bool ShouldSerializefinishid()
		{
			return this.finishidSpecified;
		}

		private void Resetfinishid()
		{
			this.finishidSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _groupid;

		private uint? _finishid;

		private IExtension extensionObject;
	}
}
