using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "BossRushRes")]
	[Serializable]
	public class BossRushRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ret
		{
			get
			{
				return this._ret ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ret = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool retSpecified
		{
			get
			{
				return this._ret != null;
			}
			set
			{
				bool flag = value == (this._ret == null);
				if (flag)
				{
					this._ret = (value ? new ErrorCode?(this.ret) : null);
				}
			}
		}

		private bool ShouldSerializeret()
		{
			return this.retSpecified;
		}

		private void Resetret()
		{
			this.retSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "data", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public BossRushData data
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "bossApp", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public UnitAppearance bossApp
		{
			get
			{
				return this._bossApp;
			}
			set
			{
				this._bossApp = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "leftcount", DataFormat = DataFormat.TwosComplement)]
		public int leftcount
		{
			get
			{
				return this._leftcount ?? 0;
			}
			set
			{
				this._leftcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftcountSpecified
		{
			get
			{
				return this._leftcount != null;
			}
			set
			{
				bool flag = value == (this._leftcount == null);
				if (flag)
				{
					this._leftcount = (value ? new int?(this.leftcount) : null);
				}
			}
		}

		private bool ShouldSerializeleftcount()
		{
			return this.leftcountSpecified;
		}

		private void Resetleftcount()
		{
			this.leftcountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _ret;

		private BossRushData _data = null;

		private UnitAppearance _bossApp = null;

		private int? _leftcount;

		private IExtension extensionObject;
	}
}
