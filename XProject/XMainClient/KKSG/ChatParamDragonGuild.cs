using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatParamDragonGuild")]
	[Serializable]
	public class ChatParamDragonGuild : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "dragonguildId", DataFormat = DataFormat.TwosComplement)]
		public ulong dragonguildId
		{
			get
			{
				return this._dragonguildId ?? 0UL;
			}
			set
			{
				this._dragonguildId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonguildIdSpecified
		{
			get
			{
				return this._dragonguildId != null;
			}
			set
			{
				bool flag = value == (this._dragonguildId == null);
				if (flag)
				{
					this._dragonguildId = (value ? new ulong?(this.dragonguildId) : null);
				}
			}
		}

		private bool ShouldSerializedragonguildId()
		{
			return this.dragonguildIdSpecified;
		}

		private void ResetdragonguildId()
		{
			this.dragonguildIdSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "dragonguildname", DataFormat = DataFormat.Default)]
		public string dragonguildname
		{
			get
			{
				return this._dragonguildname ?? "";
			}
			set
			{
				this._dragonguildname = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool dragonguildnameSpecified
		{
			get
			{
				return this._dragonguildname != null;
			}
			set
			{
				bool flag = value == (this._dragonguildname == null);
				if (flag)
				{
					this._dragonguildname = (value ? this.dragonguildname : null);
				}
			}
		}

		private bool ShouldSerializedragonguildname()
		{
			return this.dragonguildnameSpecified;
		}

		private void Resetdragonguildname()
		{
			this.dragonguildnameSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _dragonguildId;

		private string _dragonguildname;

		private IExtension extensionObject;
	}
}
