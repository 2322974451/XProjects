using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SpriteOperationRes")]
	[Serializable]
	public class SpriteOperationRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "ErrorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode ErrorCode
		{
			get
			{
				return this._ErrorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._ErrorCode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ErrorCodeSpecified
		{
			get
			{
				return this._ErrorCode != null;
			}
			set
			{
				bool flag = value == (this._ErrorCode == null);
				if (flag)
				{
					this._ErrorCode = (value ? new ErrorCode?(this.ErrorCode) : null);
				}
			}
		}

		private bool ShouldSerializeErrorCode()
		{
			return this.ErrorCodeSpecified;
		}

		private void ResetErrorCode()
		{
			this.ErrorCodeSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "Exp", DataFormat = DataFormat.TwosComplement)]
		public uint Exp
		{
			get
			{
				return this._Exp ?? 0U;
			}
			set
			{
				this._Exp = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ExpSpecified
		{
			get
			{
				return this._Exp != null;
			}
			set
			{
				bool flag = value == (this._Exp == null);
				if (flag)
				{
					this._Exp = (value ? new uint?(this.Exp) : null);
				}
			}
		}

		private bool ShouldSerializeExp()
		{
			return this.ExpSpecified;
		}

		private void ResetExp()
		{
			this.ExpSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "AwakeSpriteBefore", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SpriteInfo AwakeSpriteBefore
		{
			get
			{
				return this._AwakeSpriteBefore;
			}
			set
			{
				this._AwakeSpriteBefore = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "AwakeSprite", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public SpriteInfo AwakeSprite
		{
			get
			{
				return this._AwakeSprite;
			}
			set
			{
				this._AwakeSprite = value;
			}
		}

		[ProtoMember(5, Name = "InFight", DataFormat = DataFormat.TwosComplement)]
		public List<ulong> InFight
		{
			get
			{
				return this._InFight;
			}
		}

		[ProtoMember(6, Name = "LastTrainAttrID", DataFormat = DataFormat.TwosComplement)]
		public List<uint> LastTrainAttrID
		{
			get
			{
				return this._LastTrainAttrID;
			}
		}

		[ProtoMember(7, Name = "LastTrainAttrValue", DataFormat = DataFormat.TwosComplement)]
		public List<uint> LastTrainAttrValue
		{
			get
			{
				return this._LastTrainAttrValue;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _ErrorCode;

		private uint? _Exp;

		private SpriteInfo _AwakeSpriteBefore = null;

		private SpriteInfo _AwakeSprite = null;

		private readonly List<ulong> _InFight = new List<ulong>();

		private readonly List<uint> _LastTrainAttrID = new List<uint>();

		private readonly List<uint> _LastTrainAttrValue = new List<uint>();

		private IExtension extensionObject;
	}
}
