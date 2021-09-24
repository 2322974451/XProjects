using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "AdjustGuildArenaRolePosRes")]
	[Serializable]
	public class AdjustGuildArenaRolePosRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "errorCode", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode errorCode
		{
			get
			{
				return this._errorCode ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._errorCode = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorCodeSpecified
		{
			get
			{
				return this._errorCode != null;
			}
			set
			{
				bool flag = value == (this._errorCode == null);
				if (flag)
				{
					this._errorCode = (value ? new ErrorCode?(this.errorCode) : null);
				}
			}
		}

		private bool ShouldSerializeerrorCode()
		{
			return this.errorCodeSpecified;
		}

		private void ReseterrorCode()
		{
			this.errorCodeSpecified = false;
		}

		[ProtoMember(2, Name = "fightunits", DataFormat = DataFormat.Default)]
		public List<GuildDarenaUnit> fightunits
		{
			get
			{
				return this._fightunits;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _errorCode;

		private readonly List<GuildDarenaUnit> _fightunits = new List<GuildDarenaUnit>();

		private IExtension extensionObject;
	}
}
