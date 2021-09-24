using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "KickAccountJkydMsg")]
	[Serializable]
	public class KickAccountJkydMsg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "msg", DataFormat = DataFormat.Default)]
		public string msg
		{
			get
			{
				return this._msg ?? "";
			}
			set
			{
				this._msg = value;
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool msgSpecified
		{
			get
			{
				return this._msg != null;
			}
			set
			{
				bool flag = value == (this._msg == null);
				if (flag)
				{
					this._msg = (value ? this.msg : null);
				}
			}
		}

		private bool ShouldSerializemsg()
		{
			return this.msgSpecified;
		}

		private void Resetmsg()
		{
			this.msgSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "kt", DataFormat = DataFormat.TwosComplement)]
		public KickType kt
		{
			get
			{
				return this._kt ?? KickType.KICK_NORMAL;
			}
			set
			{
				this._kt = new KickType?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ktSpecified
		{
			get
			{
				return this._kt != null;
			}
			set
			{
				bool flag = value == (this._kt == null);
				if (flag)
				{
					this._kt = (value ? new KickType?(this.kt) : null);
				}
			}
		}

		private bool ShouldSerializekt()
		{
			return this.ktSpecified;
		}

		private void Resetkt()
		{
			this.ktSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private string _msg;

		private KickType? _kt;

		private IExtension extensionObject;
	}
}
