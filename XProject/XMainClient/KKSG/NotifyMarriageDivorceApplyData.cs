using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NotifyMarriageDivorceApplyData")]
	[Serializable]
	public class NotifyMarriageDivorceApplyData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isApplyCancel", DataFormat = DataFormat.Default)]
		public bool isApplyCancel
		{
			get
			{
				return this._isApplyCancel ?? false;
			}
			set
			{
				this._isApplyCancel = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isApplyCancelSpecified
		{
			get
			{
				return this._isApplyCancel != null;
			}
			set
			{
				bool flag = value == (this._isApplyCancel == null);
				if (flag)
				{
					this._isApplyCancel = (value ? new bool?(this.isApplyCancel) : null);
				}
			}
		}

		private bool ShouldSerializeisApplyCancel()
		{
			return this.isApplyCancelSpecified;
		}

		private void ResetisApplyCancel()
		{
			this.isApplyCancelSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "roleID", DataFormat = DataFormat.TwosComplement)]
		public ulong roleID
		{
			get
			{
				return this._roleID ?? 0UL;
			}
			set
			{
				this._roleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleIDSpecified
		{
			get
			{
				return this._roleID != null;
			}
			set
			{
				bool flag = value == (this._roleID == null);
				if (flag)
				{
					this._roleID = (value ? new ulong?(this.roleID) : null);
				}
			}
		}

		private bool ShouldSerializeroleID()
		{
			return this.roleIDSpecified;
		}

		private void ResetroleID()
		{
			this.roleIDSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "name", DataFormat = DataFormat.Default)]
		public string name
		{
			get
			{
				return this._name ?? "";
			}
			set
			{
				this._name = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool nameSpecified
		{
			get
			{
				return this._name != null;
			}
			set
			{
				bool flag = value == (this._name == null);
				if (flag)
				{
					this._name = (value ? this.name : null);
				}
			}
		}

		private bool ShouldSerializename()
		{
			return this.nameSpecified;
		}

		private void Resetname()
		{
			this.nameSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "leftTime", DataFormat = DataFormat.TwosComplement)]
		public int leftTime
		{
			get
			{
				return this._leftTime ?? 0;
			}
			set
			{
				this._leftTime = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftTimeSpecified
		{
			get
			{
				return this._leftTime != null;
			}
			set
			{
				bool flag = value == (this._leftTime == null);
				if (flag)
				{
					this._leftTime = (value ? new int?(this.leftTime) : null);
				}
			}
		}

		private bool ShouldSerializeleftTime()
		{
			return this.leftTimeSpecified;
		}

		private void ResetleftTime()
		{
			this.leftTimeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isApplyCancel;

		private ulong? _roleID;

		private string _name;

		private int? _leftTime;

		private IExtension extensionObject;
	}
}
