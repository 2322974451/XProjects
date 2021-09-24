using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "roArg")]
	[Serializable]
	public class roArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "bNoShowLog", DataFormat = DataFormat.Default)]
		public bool bNoShowLog
		{
			get
			{
				return this._bNoShowLog ?? false;
			}
			set
			{
				this._bNoShowLog = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool bNoShowLogSpecified
		{
			get
			{
				return this._bNoShowLog != null;
			}
			set
			{
				bool flag = value == (this._bNoShowLog == null);
				if (flag)
				{
					this._bNoShowLog = (value ? new bool?(this.bNoShowLog) : null);
				}
			}
		}

		private bool ShouldSerializebNoShowLog()
		{
			return this.bNoShowLogSpecified;
		}

		private void ResetbNoShowLog()
		{
			this.bNoShowLogSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _bNoShowLog;

		private IExtension extensionObject;
	}
}
