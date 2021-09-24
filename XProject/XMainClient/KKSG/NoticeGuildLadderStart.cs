using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NoticeGuildLadderStart")]
	[Serializable]
	public class NoticeGuildLadderStart : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isstart", DataFormat = DataFormat.Default)]
		public bool isstart
		{
			get
			{
				return this._isstart ?? false;
			}
			set
			{
				this._isstart = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isstartSpecified
		{
			get
			{
				return this._isstart != null;
			}
			set
			{
				bool flag = value == (this._isstart == null);
				if (flag)
				{
					this._isstart = (value ? new bool?(this.isstart) : null);
				}
			}
		}

		private bool ShouldSerializeisstart()
		{
			return this.isstartSpecified;
		}

		private void Resetisstart()
		{
			this.isstartSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isstart;

		private IExtension extensionObject;
	}
}
