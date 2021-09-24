using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChangeGuildSettingArg")]
	[Serializable]
	public class ChangeGuildSettingArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "Icon", DataFormat = DataFormat.TwosComplement)]
		public int Icon
		{
			get
			{
				return this._Icon ?? 0;
			}
			set
			{
				this._Icon = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool IconSpecified
		{
			get
			{
				return this._Icon != null;
			}
			set
			{
				bool flag = value == (this._Icon == null);
				if (flag)
				{
					this._Icon = (value ? new int?(this.Icon) : null);
				}
			}
		}

		private bool ShouldSerializeIcon()
		{
			return this.IconSpecified;
		}

		private void ResetIcon()
		{
			this.IconSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "powerpoint", DataFormat = DataFormat.TwosComplement)]
		public int powerpoint
		{
			get
			{
				return this._powerpoint ?? 0;
			}
			set
			{
				this._powerpoint = new int?(value);
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
					this._powerpoint = (value ? new int?(this.powerpoint) : null);
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

		[ProtoMember(3, IsRequired = false, Name = "needapproval", DataFormat = DataFormat.TwosComplement)]
		public int needapproval
		{
			get
			{
				return this._needapproval ?? 0;
			}
			set
			{
				this._needapproval = new int?(value);
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
					this._needapproval = (value ? new int?(this.needapproval) : null);
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

		[ProtoMember(4, IsRequired = false, Name = "annoucement", DataFormat = DataFormat.Default)]
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

		private int? _Icon;

		private int? _powerpoint;

		private int? _needapproval;

		private string _annoucement;

		private IExtension extensionObject;
	}
}
