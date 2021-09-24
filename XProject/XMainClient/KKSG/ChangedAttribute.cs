using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChangedAttribute")]
	[Serializable]
	public class ChangedAttribute : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "time", DataFormat = DataFormat.TwosComplement)]
		public ulong time
		{
			get
			{
				return this._time ?? 0UL;
			}
			set
			{
				this._time = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool timeSpecified
		{
			get
			{
				return this._time != null;
			}
			set
			{
				bool flag = value == (this._time == null);
				if (flag)
				{
					this._time = (value ? new ulong?(this.time) : null);
				}
			}
		}

		private bool ShouldSerializetime()
		{
			return this.timeSpecified;
		}

		private void Resettime()
		{
			this.timeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "uID", DataFormat = DataFormat.TwosComplement)]
		public ulong uID
		{
			get
			{
				return this._uID ?? 0UL;
			}
			set
			{
				this._uID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uIDSpecified
		{
			get
			{
				return this._uID != null;
			}
			set
			{
				bool flag = value == (this._uID == null);
				if (flag)
				{
					this._uID = (value ? new ulong?(this.uID) : null);
				}
			}
		}

		private bool ShouldSerializeuID()
		{
			return this.uIDSpecified;
		}

		private void ResetuID()
		{
			this.uIDSpecified = false;
		}

		[ProtoMember(3, Name = "AttrID", DataFormat = DataFormat.TwosComplement)]
		public List<int> AttrID
		{
			get
			{
				return this._AttrID;
			}
		}

		[ProtoMember(4, Name = "AttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<double> AttrValue
		{
			get
			{
				return this._AttrValue;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "showHUD", DataFormat = DataFormat.Default)]
		public bool showHUD
		{
			get
			{
				return this._showHUD ?? false;
			}
			set
			{
				this._showHUD = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool showHUDSpecified
		{
			get
			{
				return this._showHUD != null;
			}
			set
			{
				bool flag = value == (this._showHUD == null);
				if (flag)
				{
					this._showHUD = (value ? new bool?(this.showHUD) : null);
				}
			}
		}

		private bool ShouldSerializeshowHUD()
		{
			return this.showHUDSpecified;
		}

		private void ResetshowHUD()
		{
			this.showHUDSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "needHUD", DataFormat = DataFormat.Default)]
		public bool needHUD
		{
			get
			{
				return this._needHUD ?? false;
			}
			set
			{
				this._needHUD = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool needHUDSpecified
		{
			get
			{
				return this._needHUD != null;
			}
			set
			{
				bool flag = value == (this._needHUD == null);
				if (flag)
				{
					this._needHUD = (value ? new bool?(this.needHUD) : null);
				}
			}
		}

		private bool ShouldSerializeneedHUD()
		{
			return this.needHUDSpecified;
		}

		private void ResetneedHUD()
		{
			this.needHUDSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "CasterID", DataFormat = DataFormat.TwosComplement)]
		public ulong CasterID
		{
			get
			{
				return this._CasterID ?? 0UL;
			}
			set
			{
				this._CasterID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool CasterIDSpecified
		{
			get
			{
				return this._CasterID != null;
			}
			set
			{
				bool flag = value == (this._CasterID == null);
				if (flag)
				{
					this._CasterID = (value ? new ulong?(this.CasterID) : null);
				}
			}
		}

		private bool ShouldSerializeCasterID()
		{
			return this.CasterIDSpecified;
		}

		private void ResetCasterID()
		{
			this.CasterIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _time;

		private ulong? _uID;

		private readonly List<int> _AttrID = new List<int>();

		private readonly List<double> _AttrValue = new List<double>();

		private bool? _showHUD;

		private bool? _needHUD;

		private ulong? _CasterID;

		private IExtension extensionObject;
	}
}
