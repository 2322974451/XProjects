using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "MarriageApplyInfo")]
	[Serializable]
	public class MarriageApplyInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "applyRoleID", DataFormat = DataFormat.TwosComplement)]
		public ulong applyRoleID
		{
			get
			{
				return this._applyRoleID ?? 0UL;
			}
			set
			{
				this._applyRoleID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool applyRoleIDSpecified
		{
			get
			{
				return this._applyRoleID != null;
			}
			set
			{
				bool flag = value == (this._applyRoleID == null);
				if (flag)
				{
					this._applyRoleID = (value ? new ulong?(this.applyRoleID) : null);
				}
			}
		}

		private bool ShouldSerializeapplyRoleID()
		{
			return this.applyRoleIDSpecified;
		}

		private void ResetapplyRoleID()
		{
			this.applyRoleIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "applyName", DataFormat = DataFormat.Default)]
		public string applyName
		{
			get
			{
				return this._applyName ?? "";
			}
			set
			{
				this._applyName = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool applyNameSpecified
		{
			get
			{
				return this._applyName != null;
			}
			set
			{
				bool flag = value == (this._applyName == null);
				if (flag)
				{
					this._applyName = (value ? this.applyName : null);
				}
			}
		}

		private bool ShouldSerializeapplyName()
		{
			return this.applyNameSpecified;
		}

		private void ResetapplyName()
		{
			this.applyNameSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "type", DataFormat = DataFormat.TwosComplement)]
		public WeddingType type
		{
			get
			{
				return this._type ?? WeddingType.WeddingType_Normal;
			}
			set
			{
				this._type = new WeddingType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool typeSpecified
		{
			get
			{
				return this._type != null;
			}
			set
			{
				bool flag = value == (this._type == null);
				if (flag)
				{
					this._type = (value ? new WeddingType?(this.type) : null);
				}
			}
		}

		private bool ShouldSerializetype()
		{
			return this.typeSpecified;
		}

		private void Resettype()
		{
			this.typeSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _applyRoleID;

		private string _applyName;

		private WeddingType? _type;

		private IExtension extensionObject;
	}
}
