using System;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "SkyCityFinalBaseInfo")]
	[Serializable]
	public class SkyCityFinalBaseInfo : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "uuid", DataFormat = DataFormat.TwosComplement)]
		public ulong uuid
		{
			get
			{
				return this._uuid ?? 0UL;
			}
			set
			{
				this._uuid = new ulong?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool uuidSpecified
		{
			get
			{
				return this._uuid != null;
			}
			set
			{
				bool flag = value == (this._uuid == null);
				if (flag)
				{
					this._uuid = (value ? new ulong?(this.uuid) : null);
				}
			}
		}

		private bool ShouldSerializeuuid()
		{
			return this.uuidSpecified;
		}

		private void Resetuuid()
		{
			this.uuidSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "job", DataFormat = DataFormat.TwosComplement)]
		public uint job
		{
			get
			{
				return this._job ?? 0U;
			}
			set
			{
				this._job = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool jobSpecified
		{
			get
			{
				return this._job != null;
			}
			set
			{
				bool flag = value == (this._job == null);
				if (flag)
				{
					this._job = (value ? new uint?(this.job) : null);
				}
			}
		}

		private bool ShouldSerializejob()
		{
			return this.jobSpecified;
		}

		private void Resetjob()
		{
			this.jobSpecified = false;
		}

		[ProtoMember(3, IsRequired = false, Name = "killer", DataFormat = DataFormat.TwosComplement)]
		public uint killer
		{
			get
			{
				return this._killer ?? 0U;
			}
			set
			{
				this._killer = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool killerSpecified
		{
			get
			{
				return this._killer != null;
			}
			set
			{
				bool flag = value == (this._killer == null);
				if (flag)
				{
					this._killer = (value ? new uint?(this.killer) : null);
				}
			}
		}

		private bool ShouldSerializekiller()
		{
			return this.killerSpecified;
		}

		private void Resetkiller()
		{
			this.killerSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "dead", DataFormat = DataFormat.TwosComplement)]
		public uint dead
		{
			get
			{
				return this._dead ?? 0U;
			}
			set
			{
				this._dead = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool deadSpecified
		{
			get
			{
				return this._dead != null;
			}
			set
			{
				bool flag = value == (this._dead == null);
				if (flag)
				{
					this._dead = (value ? new uint?(this.dead) : null);
				}
			}
		}

		private bool ShouldSerializedead()
		{
			return this.deadSpecified;
		}

		private void Resetdead()
		{
			this.deadSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "intimategree", DataFormat = DataFormat.TwosComplement)]
		public uint intimategree
		{
			get
			{
				return this._intimategree ?? 0U;
			}
			set
			{
				this._intimategree = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool intimategreeSpecified
		{
			get
			{
				return this._intimategree != null;
			}
			set
			{
				bool flag = value == (this._intimategree == null);
				if (flag)
				{
					this._intimategree = (value ? new uint?(this.intimategree) : null);
				}
			}
		}

		private bool ShouldSerializeintimategree()
		{
			return this.intimategreeSpecified;
		}

		private void Resetintimategree()
		{
			this.intimategreeSpecified = false;
		}

		[ProtoMember(6, IsRequired = false, Name = "ismvp", DataFormat = DataFormat.Default)]
		public bool ismvp
		{
			get
			{
				return this._ismvp ?? false;
			}
			set
			{
				this._ismvp = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool ismvpSpecified
		{
			get
			{
				return this._ismvp != null;
			}
			set
			{
				bool flag = value == (this._ismvp == null);
				if (flag)
				{
					this._ismvp = (value ? new bool?(this.ismvp) : null);
				}
			}
		}

		private bool ShouldSerializeismvp()
		{
			return this.ismvpSpecified;
		}

		private void Resetismvp()
		{
			this.ismvpSpecified = false;
		}

		[ProtoMember(7, IsRequired = false, Name = "isfriend", DataFormat = DataFormat.Default)]
		public bool isfriend
		{
			get
			{
				return this._isfriend ?? false;
			}
			set
			{
				this._isfriend = new bool?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool isfriendSpecified
		{
			get
			{
				return this._isfriend != null;
			}
			set
			{
				bool flag = value == (this._isfriend == null);
				if (flag)
				{
					this._isfriend = (value ? new bool?(this.isfriend) : null);
				}
			}
		}

		private bool ShouldSerializeisfriend()
		{
			return this.isfriendSpecified;
		}

		private void Resetisfriend()
		{
			this.isfriendSpecified = false;
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ulong? _uuid;

		private uint? _job;

		private uint? _killer;

		private uint? _dead;

		private uint? _intimategree;

		private bool? _ismvp;

		private bool? _isfriend;

		private IExtension extensionObject;
	}
}
