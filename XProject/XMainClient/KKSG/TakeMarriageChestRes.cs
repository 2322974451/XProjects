using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "TakeMarriageChestRes")]
	[Serializable]
	public class TakeMarriageChestRes : IExtensible
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

		[ProtoMember(2, Name = "itemid", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemid
		{
			get
			{
				return this._itemid;
			}
		}

		[ProtoMember(3, Name = "itemcount", DataFormat = DataFormat.TwosComplement)]
		public List<uint> itemcount
		{
			get
			{
				return this._itemcount;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "takedchest", DataFormat = DataFormat.TwosComplement)]
		public uint takedchest
		{
			get
			{
				return this._takedchest ?? 0U;
			}
			set
			{
				this._takedchest = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool takedchestSpecified
		{
			get
			{
				return this._takedchest != null;
			}
			set
			{
				bool flag = value == (this._takedchest == null);
				if (flag)
				{
					this._takedchest = (value ? new uint?(this.takedchest) : null);
				}
			}
		}

		private bool ShouldSerializetakedchest()
		{
			return this.takedchestSpecified;
		}

		private void Resettakedchest()
		{
			this.takedchestSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<uint> _itemid = new List<uint>();

		private readonly List<uint> _itemcount = new List<uint>();

		private uint? _takedchest;

		private IExtension extensionObject;
	}
}
