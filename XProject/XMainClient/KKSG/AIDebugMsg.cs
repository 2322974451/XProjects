using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AIDebugMsg")]
	[Serializable]
	public class AIDebugMsg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "level", DataFormat = DataFormat.TwosComplement)]
		public int level
		{
			get
			{
				return this._level ?? 0;
			}
			set
			{
				this._level = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool levelSpecified
		{
			get
			{
				return this._level != null;
			}
			set
			{
				bool flag = value == (this._level == null);
				if (flag)
				{
					this._level = (value ? new int?(this.level) : null);
				}
			}
		}

		private bool ShouldSerializelevel()
		{
			return this.levelSpecified;
		}

		private void Resetlevel()
		{
			this.levelSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "msg", DataFormat = DataFormat.Default)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _level;

		private string _msg;

		private IExtension extensionObject;
	}
}
