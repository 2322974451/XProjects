using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChooseRollReqArg")]
	[Serializable]
	public class ChooseRollReqArg : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "chooseType", DataFormat = DataFormat.TwosComplement)]
		public int chooseType
		{
			get
			{
				return this._chooseType ?? 0;
			}
			set
			{
				this._chooseType = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool chooseTypeSpecified
		{
			get
			{
				return this._chooseType != null;
			}
			set
			{
				bool flag = value == (this._chooseType == null);
				if (flag)
				{
					this._chooseType = (value ? new int?(this.chooseType) : null);
				}
			}
		}

		private bool ShouldSerializechooseType()
		{
			return this.chooseTypeSpecified;
		}

		private void ResetchooseType()
		{
			this.chooseTypeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "info", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public EnemyDoodadInfo info
		{
			get
			{
				return this._info;
			}
			set
			{
				this._info = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private int? _chooseType;

		private EnemyDoodadInfo _info = null;

		private IExtension extensionObject;
	}
}
