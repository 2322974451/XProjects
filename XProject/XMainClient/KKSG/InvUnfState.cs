using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvUnfState")]
	[Serializable]
	public class InvUnfState : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "inviteID", DataFormat = DataFormat.TwosComplement)]
		public int inviteID
		{
			get
			{
				return this._inviteID ?? 0;
			}
			set
			{
				this._inviteID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool inviteIDSpecified
		{
			get
			{
				return this._inviteID != null;
			}
			set
			{
				bool flag = value == (this._inviteID == null);
				if (flag)
				{
					this._inviteID = (value ? new int?(this.inviteID) : null);
				}
			}
		}

		private bool ShouldSerializeinviteID()
		{
			return this.inviteIDSpecified;
		}

		private void ResetinviteID()
		{
			this.inviteIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "isdeleted", DataFormat = DataFormat.Default)]
		public bool isdeleted
		{
			get
			{
				return this._isdeleted ?? false;
			}
			set
			{
				this._isdeleted = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isdeletedSpecified
		{
			get
			{
				return this._isdeleted != null;
			}
			set
			{
				bool flag = value == (this._isdeleted == null);
				if (flag)
				{
					this._isdeleted = (value ? new bool?(this.isdeleted) : null);
				}
			}
		}

		private bool ShouldSerializeisdeleted()
		{
			return this.isdeletedSpecified;
		}

		private void Resetisdeleted()
		{
			this.isdeletedSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _inviteID;

		private bool? _isdeleted;

		private IExtension extensionObject;
	}
}
