using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "NewGuildBonusData")]
	[Serializable]
	public class NewGuildBonusData : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "showIconInScreen", DataFormat = DataFormat.Default)]
		public bool showIconInScreen
		{
			get
			{
				return this._showIconInScreen ?? false;
			}
			set
			{
				this._showIconInScreen = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool showIconInScreenSpecified
		{
			get
			{
				return this._showIconInScreen != null;
			}
			set
			{
				bool flag = value == (this._showIconInScreen == null);
				if (flag)
				{
					this._showIconInScreen = (value ? new bool?(this.showIconInScreen) : null);
				}
			}
		}

		private bool ShouldSerializeshowIconInScreen()
		{
			return this.showIconInScreenSpecified;
		}

		private void ResetshowIconInScreen()
		{
			this.showIconInScreenSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private bool? _showIconInScreen;

		private IExtension extensionObject;
	}
}
