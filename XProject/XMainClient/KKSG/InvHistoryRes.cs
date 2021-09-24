using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "InvHistoryRes")]
	[Serializable]
	public class InvHistoryRes : IExtensible
	{

		[ProtoMember(1, Name = "invUnfH", DataFormat = DataFormat.Default)]
		public List<TeamInvite> invUnfH
		{
			get
			{
				return this._invUnfH;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "ret", DataFormat = DataFormat.TwosComplement)]
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

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<TeamInvite> _invUnfH = new List<TeamInvite>();

		private ErrorCode? _ret;

		private IExtension extensionObject;
	}
}
