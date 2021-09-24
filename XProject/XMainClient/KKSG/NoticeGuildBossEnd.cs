using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NoticeGuildBossEnd")]
	[Serializable]
	public class NoticeGuildBossEnd : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "isWin", DataFormat = DataFormat.Default)]
		public bool isWin
		{
			get
			{
				return this._isWin ?? false;
			}
			set
			{
				this._isWin = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isWinSpecified
		{
			get
			{
				return this._isWin != null;
			}
			set
			{
				bool flag = value == (this._isWin == null);
				if (flag)
				{
					this._isWin = (value ? new bool?(this.isWin) : null);
				}
			}
		}

		private bool ShouldSerializeisWin()
		{
			return this.isWinSpecified;
		}

		private void ResetisWin()
		{
			this.isWinSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _isWin;

		private IExtension extensionObject;
	}
}
