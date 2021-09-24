using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChangeDragonGuildSettingArg")]
	[Serializable]
	public class ChangeDragonGuildSettingArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public uint powerpoint
		{
			get
			{
				return this._powerpoint ?? 0U;
			}
			set
			{
				this._powerpoint = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool powerpointSpecified
		{
			get
			{
				return this._powerpoint != null;
			}
			set
			{
				bool flag = value == (this._powerpoint == null);
				if (flag)
				{
					this._powerpoint = (value ? new uint?(this.powerpoint) : null);
				}
			}
		}

		private bool ShouldSerializepowerpoint()
		{
			return this.powerpointSpecified;
		}

		private void Resetpowerpoint()
		{
			this.powerpointSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "needapproval", DataFormat = DataFormat.TwosComplement)]
		public uint needapproval
		{
			get
			{
				return this._needapproval ?? 0U;
			}
			set
			{
				this._needapproval = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needapprovalSpecified
		{
			get
			{
				return this._needapproval != null;
			}
			set
			{
				bool flag = value == (this._needapproval == null);
				if (flag)
				{
					this._needapproval = (value ? new uint?(this.needapproval) : null);
				}
			}
		}

		private bool ShouldSerializeneedapproval()
		{
			return this.needapprovalSpecified;
		}

		private void Resetneedapproval()
		{
			this.needapprovalSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
		public string annoucement
		{
			get
			{
				return this._annoucement ?? "";
			}
			set
			{
				this._annoucement = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool annoucementSpecified
		{
			get
			{
				return this._annoucement != null;
			}
			set
			{
				bool flag = value == (this._annoucement == null);
				if (flag)
				{
					this._annoucement = (value ? this.annoucement : null);
				}
			}
		}

		private bool ShouldSerializeannoucement()
		{
			return this.annoucementSpecified;
		}

		private void Resetannoucement()
		{
			this.annoucementSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _powerpoint;

		private uint? _needapproval;

		private string _annoucement;

		private IExtension extensionObject;
	}
}
