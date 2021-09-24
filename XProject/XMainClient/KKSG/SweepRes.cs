using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SweepRes")]
	[Serializable]
	public class SweepRes : IExtensible
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

		[ProtoMember(2, Name = "rewards", DataFormat = DataFormat.Default)]
		public List<SweepResult> rewards
		{
			get
			{
				return this._rewards;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "abyssleftcount", DataFormat = DataFormat.TwosComplement)]
		public int abyssleftcount
		{
			get
			{
				return this._abyssleftcount ?? 0;
			}
			set
			{
				this._abyssleftcount = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool abyssleftcountSpecified
		{
			get
			{
				return this._abyssleftcount != null;
			}
			set
			{
				bool flag = value == (this._abyssleftcount == null);
				if (flag)
				{
					this._abyssleftcount = (value ? new int?(this.abyssleftcount) : null);
				}
			}
		}

		private bool ShouldSerializeabyssleftcount()
		{
			return this.abyssleftcountSpecified;
		}

		private void Resetabyssleftcount()
		{
			this.abyssleftcountSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "isexpseal", DataFormat = DataFormat.Default)]
		public bool isexpseal
		{
			get
			{
				return this._isexpseal ?? false;
			}
			set
			{
				this._isexpseal = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isexpsealSpecified
		{
			get
			{
				return this._isexpseal != null;
			}
			set
			{
				bool flag = value == (this._isexpseal == null);
				if (flag)
				{
					this._isexpseal = (value ? new bool?(this.isexpseal) : null);
				}
			}
		}

		private bool ShouldSerializeisexpseal()
		{
			return this.isexpsealSpecified;
		}

		private void Resetisexpseal()
		{
			this.isexpsealSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ErrorCode? _result;

		private readonly List<SweepResult> _rewards = new List<SweepResult>();

		private int? _abyssleftcount;

		private bool? _isexpseal;

		private IExtension extensionObject;
	}
}
