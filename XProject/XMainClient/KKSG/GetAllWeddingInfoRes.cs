using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetAllWeddingInfoRes")]
	[Serializable]
	public class GetAllWeddingInfoRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "result", DataFormat = DataFormat.TwosComplement)]
		public ErrorCode result
		{
			get
			{
				return this._result ?? ErrorCode.ERR_SUCCESS;
			}
			set
			{
				this._result = new ErrorCode?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool resultSpecified
		{
			get
			{
				return this._result != null;
			}
			set
			{
				bool flag = value == (this._result == null);
				if (flag)
				{
					this._result = (value ? new ErrorCode?(this.result) : null);
				}
			}
		}

		private bool ShouldSerializeresult()
		{
			return this.resultSpecified;
		}

		private void Resetresult()
		{
			this.resultSpecified = false;
		}

		[ProtoMember(2, Name = "can_enter", DataFormat = DataFormat.Default)]
		public List<WeddingBrief> can_enter
		{
			get
			{
				return this._can_enter;
			}
		}

		[ProtoMember(3, Name = "can_apply", DataFormat = DataFormat.Default)]
		public List<WeddingBrief> can_apply
		{
			get
			{
				return this._can_apply;
			}
		}

		[ProtoMember(4, Name = "is_apply", DataFormat = DataFormat.Default)]
		public List<bool> is_apply
		{
			get
			{
				return this._is_apply;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<WeddingBrief> _can_enter = new List<WeddingBrief>();

		private readonly List<WeddingBrief> _can_apply = new List<WeddingBrief>();

		private readonly List<bool> _is_apply = new List<bool>();

		private IExtension extensionObject;
	}
}
