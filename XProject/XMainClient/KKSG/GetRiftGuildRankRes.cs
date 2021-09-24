using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetRiftGuildRankRes")]
	[Serializable]
	public class GetRiftGuildRankRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "error", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode error
		{
			get
			{
				return this._error ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._error = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool errorSpecified
		{
			get
			{
				return this._error != null;
			}
			set
			{
				bool flag = value == (this._error == null);
				if (flag)
				{
					this._error = (value ? new ErrorCode?(this.error) : null);
				}
			}
		}

		private bool ShouldSerializeerror()
		{
			return this.errorSpecified;
		}

		private void Reseterror()
		{
			this.errorSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "curRiftID", DataFormat = DataFormat.TwosComplement)]
		public int curRiftID
		{
			get
			{
				return this._curRiftID ?? 0;
			}
			set
			{
				this._curRiftID = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool curRiftIDSpecified
		{
			get
			{
				return this._curRiftID != null;
			}
			set
			{
				bool flag = value == (this._curRiftID == null);
				if (flag)
				{
					this._curRiftID = (value ? new int?(this.curRiftID) : null);
				}
			}
		}

		private bool ShouldSerializecurRiftID()
		{
			return this.curRiftIDSpecified;
		}

		private void ResetcurRiftID()
		{
			this.curRiftIDSpecified = false;
		}

		[ProtoMember(3, Name = "buffIDs", DataFormat = DataFormat.Default)]
		public List<Buff> buffIDs
		{
			get
			{
				return this._buffIDs;
			}
		}

		[ProtoMember(4, Name = "infos", DataFormat = DataFormat.Default)]
		public List<RiftGuildRankInfo> infos
		{
			get
			{
				return this._infos;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private int? _curRiftID;

		private readonly List<Buff> _buffIDs = new List<Buff>();

		private readonly List<RiftGuildRankInfo> _infos = new List<RiftGuildRankInfo>();

		private IExtension extensionObject;
	}
}
