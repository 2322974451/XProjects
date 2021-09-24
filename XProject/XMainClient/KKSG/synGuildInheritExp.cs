using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "synGuildInheritExp")]
	[Serializable]
	public class synGuildInheritExp : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "roleOne", DataFormat = DataFormat.TwosComplement)]
		public ulong roleOne
		{
			get
			{
				return this._roleOne ?? 0UL;
			}
			set
			{
				this._roleOne = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleOneSpecified
		{
			get
			{
				return this._roleOne != null;
			}
			set
			{
				bool flag = value == (this._roleOne == null);
				if (flag)
				{
					this._roleOne = (value ? new ulong?(this.roleOne) : null);
				}
			}
		}

		private bool ShouldSerializeroleOne()
		{
			return this.roleOneSpecified;
		}

		private void ResetroleOne()
		{
			this.roleOneSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "expOne", DataFormat = DataFormat.TwosComplement)]
		public uint expOne
		{
			get
			{
				return this._expOne ?? 0U;
			}
			set
			{
				this._expOne = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expOneSpecified
		{
			get
			{
				return this._expOne != null;
			}
			set
			{
				bool flag = value == (this._expOne == null);
				if (flag)
				{
					this._expOne = (value ? new uint?(this.expOne) : null);
				}
			}
		}

		private bool ShouldSerializeexpOne()
		{
			return this.expOneSpecified;
		}

		private void ResetexpOne()
		{
			this.expOneSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "roleTwo", DataFormat = DataFormat.TwosComplement)]
		public ulong roleTwo
		{
			get
			{
				return this._roleTwo ?? 0UL;
			}
			set
			{
				this._roleTwo = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool roleTwoSpecified
		{
			get
			{
				return this._roleTwo != null;
			}
			set
			{
				bool flag = value == (this._roleTwo == null);
				if (flag)
				{
					this._roleTwo = (value ? new ulong?(this.roleTwo) : null);
				}
			}
		}

		private bool ShouldSerializeroleTwo()
		{
			return this.roleTwoSpecified;
		}

		private void ResetroleTwo()
		{
			this.roleTwoSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "expTwo", DataFormat = DataFormat.TwosComplement)]
		public uint expTwo
		{
			get
			{
				return this._expTwo ?? 0U;
			}
			set
			{
				this._expTwo = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool expTwoSpecified
		{
			get
			{
				return this._expTwo != null;
			}
			set
			{
				bool flag = value == (this._expTwo == null);
				if (flag)
				{
					this._expTwo = (value ? new uint?(this.expTwo) : null);
				}
			}
		}

		private bool ShouldSerializeexpTwo()
		{
			return this.expTwoSpecified;
		}

		private void ResetexpTwo()
		{
			this.expTwoSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "turn", DataFormat = DataFormat.TwosComplement)]
		public uint turn
		{
			get
			{
				return this._turn ?? 0U;
			}
			set
			{
				this._turn = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool turnSpecified
		{
			get
			{
				return this._turn != null;
			}
			set
			{
				bool flag = value == (this._turn == null);
				if (flag)
				{
					this._turn = (value ? new uint?(this.turn) : null);
				}
			}
		}

		private bool ShouldSerializeturn()
		{
			return this.turnSpecified;
		}

		private void Resetturn()
		{
			this.turnSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "islast", DataFormat = DataFormat.Default)]
		public bool islast
		{
			get
			{
				return this._islast ?? false;
			}
			set
			{
				this._islast = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool islastSpecified
		{
			get
			{
				return this._islast != null;
			}
			set
			{
				bool flag = value == (this._islast == null);
				if (flag)
				{
					this._islast = (value ? new bool?(this.islast) : null);
				}
			}
		}

		private bool ShouldSerializeislast()
		{
			return this.islastSpecified;
		}

		private void Resetislast()
		{
			this.islastSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "teacherId", DataFormat = DataFormat.TwosComplement)]
		public ulong teacherId
		{
			get
			{
				return this._teacherId ?? 0UL;
			}
			set
			{
				this._teacherId = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool teacherIdSpecified
		{
			get
			{
				return this._teacherId != null;
			}
			set
			{
				bool flag = value == (this._teacherId == null);
				if (flag)
				{
					this._teacherId = (value ? new ulong?(this.teacherId) : null);
				}
			}
		}

		private bool ShouldSerializeteacherId()
		{
			return this.teacherIdSpecified;
		}

		private void ResetteacherId()
		{
			this.teacherIdSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _roleOne;

		private uint? _expOne;

		private ulong? _roleTwo;

		private uint? _expTwo;

		private uint? _turn;

		private bool? _islast;

		private ulong? _teacherId;

		private IExtension extensionObject;
	}
}
