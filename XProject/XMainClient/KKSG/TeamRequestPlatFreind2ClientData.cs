using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TeamRequestPlatFreind2ClientData")]
	[Serializable]
	public class TeamRequestPlatFreind2ClientData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "userOffline", DataFormat = DataFormat.Default)]
		public bool userOffline
		{
			get
			{
				return this._userOffline ?? false;
			}
			set
			{
				this._userOffline = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool userOfflineSpecified
		{
			get
			{
				return this._userOffline != null;
			}
			set
			{
				bool flag = value == (this._userOffline == null);
				if (flag)
				{
					this._userOffline = (value ? new bool?(this.userOffline) : null);
				}
			}
		}

		private bool ShouldSerializeuserOffline()
		{
			return this.userOfflineSpecified;
		}

		private void ResetuserOffline()
		{
			this.userOfflineSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "openID", DataFormat = DataFormat.Default)]
		public string openID
		{
			get
			{
				return this._openID ?? "";
			}
			set
			{
				this._openID = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool openIDSpecified
		{
			get
			{
				return this._openID != null;
			}
			set
			{
				bool flag = value == (this._openID == null);
				if (flag)
				{
					this._openID = (value ? this.openID : null);
				}
			}
		}

		private bool ShouldSerializeopenID()
		{
			return this.openIDSpecified;
		}

		private void ResetopenID()
		{
			this.openIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _userOffline;

		private string _openID;

		private IExtension extensionObject;
	}
}
