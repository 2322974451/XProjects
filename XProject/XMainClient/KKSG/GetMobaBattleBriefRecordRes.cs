using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GetMobaBattleBriefRecordRes")]
	[Serializable]
	public class GetMobaBattleBriefRecordRes : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "totalnum", DataFormat = DataFormat.TwosComplement)]
		public uint totalnum
		{
			get
			{
				return this._totalnum ?? 0U;
			}
			set
			{
				this._totalnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool totalnumSpecified
		{
			get
			{
				return this._totalnum != null;
			}
			set
			{
				bool flag = value == (this._totalnum == null);
				if (flag)
				{
					this._totalnum = (value ? new uint?(this.totalnum) : null);
				}
			}
		}

		private bool ShouldSerializetotalnum()
		{
			return this.totalnumSpecified;
		}

		private void Resettotalnum()
		{
			this.totalnumSpecified = false;
		}

		[ProtoMember(2, IsRequired = false, Name = "winnum", DataFormat = DataFormat.TwosComplement)]
		public uint winnum
		{
			get
			{
				return this._winnum ?? 0U;
			}
			set
			{
				this._winnum = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool winnumSpecified
		{
			get
			{
				return this._winnum != null;
			}
			set
			{
				bool flag = value == (this._winnum == null);
				if (flag)
				{
					this._winnum = (value ? new uint?(this.winnum) : null);
				}
			}
		}

		private bool ShouldSerializewinnum()
		{
			return this.winnumSpecified;
		}

		private void Resetwinnum()
		{
			this.winnumSpecified = false;
		}

		[ProtoMember(3, Name = "brief", DataFormat = DataFormat.Default)]
		public List<MobaBattleOneGameBrief> brief
		{
			get
			{
				return this._brief;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private uint? _totalnum;

		private uint? _winnum;

		private readonly List<MobaBattleOneGameBrief> _brief = new List<MobaBattleOneGameBrief>();

		private IExtension extensionObject;
	}
}
