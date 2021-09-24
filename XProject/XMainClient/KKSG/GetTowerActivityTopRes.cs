using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetTowerActivityTopRes")]
	[Serializable]
	public class GetTowerActivityTopRes : IExtensible
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

		[ProtoMember(2, Name = "infos", DataFormat = DataFormat.Default)]
		public List<TowerRecord> infos
		{
			get
			{
				return this._infos;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "leftResetCount", DataFormat = DataFormat.TwosComplement)]
		public int leftResetCount
		{
			get
			{
				return this._leftResetCount ?? 0;
			}
			set
			{
				this._leftResetCount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool leftResetCountSpecified
		{
			get
			{
				return this._leftResetCount != null;
			}
			set
			{
				bool flag = value == (this._leftResetCount == null);
				if (flag)
				{
					this._leftResetCount = (value ? new int?(this.leftResetCount) : null);
				}
			}
		}

		private bool ShouldSerializeleftResetCount()
		{
			return this.leftResetCountSpecified;
		}

		private void ResetleftResetCount()
		{
			this.leftResetCountSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _error;

		private readonly List<TowerRecord> _infos = new List<TowerRecord>();

		private int? _leftResetCount;

		private IExtension extensionObject;
	}
}
