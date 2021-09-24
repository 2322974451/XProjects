using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "StartBattleFailedRes")]
	[Serializable]
	public class StartBattleFailedRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "proUserID", DataFormat = DataFormat.TwosComplement)]
		public ulong proUserID
		{
			get
			{
				return this._proUserID ?? 0UL;
			}
			set
			{
				this._proUserID = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool proUserIDSpecified
		{
			get
			{
				return this._proUserID != null;
			}
			set
			{
				bool flag = value == (this._proUserID == null);
				if (flag)
				{
					this._proUserID = (value ? new ulong?(this.proUserID) : null);
				}
			}
		}

		private bool ShouldSerializeproUserID()
		{
			return this.proUserIDSpecified;
		}

		private void ResetproUserID()
		{
			this.proUserIDSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "reason", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode reason
		{
			get
			{
				return this._reason ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._reason = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool reasonSpecified
		{
			get
			{
				return this._reason != null;
			}
			set
			{
				bool flag = value == (this._reason == null);
				if (flag)
				{
					this._reason = (value ? new ErrorCode?(this.reason) : null);
				}
			}
		}

		private bool ShouldSerializereason()
		{
			return this.reasonSpecified;
		}

		private void Resetreason()
		{
			this.reasonSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _proUserID;

		private ErrorCode? _reason;

		private IExtension extensionObject;
	}
}
