using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "QuitRoom")]
	[Serializable]
	public class QuitRoom : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roomID", DataFormat = DataFormat.TwosComplement)]
		public long roomID
		{
			get
			{
				return this._roomID ?? 0L;
			}
			set
			{
				this._roomID = new long?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roomIDSpecified
		{
			get
			{
				return this._roomID != null;
			}
			set
			{
				bool flag = value == (this._roomID == null);
				if (flag)
				{
					this._roomID = (value ? new long?(this.roomID) : null);
				}
			}
		}

		private bool ShouldSerializeroomID()
		{
			return this.roomIDSpecified;
		}

		private void ResetroomID()
		{
			this.roomIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "memberID", DataFormat = DataFormat.TwosComplement)]
		public int memberID
		{
			get
			{
				return this._memberID ?? 0;
			}
			set
			{
				this._memberID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool memberIDSpecified
		{
			get
			{
				return this._memberID != null;
			}
			set
			{
				bool flag = value == (this._memberID == null);
				if (flag)
				{
					this._memberID = (value ? new int?(this.memberID) : null);
				}
			}
		}

		private bool ShouldSerializememberID()
		{
			return this.memberIDSpecified;
		}

		private void ResetmemberID()
		{
			this.memberIDSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private long? _roomID;

		private int? _memberID;

		private IExtension extensionObject;
	}
}
