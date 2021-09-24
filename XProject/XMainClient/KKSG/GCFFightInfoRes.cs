using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "GCFFightInfoRes")]
	[Serializable]
	public class GCFFightInfoRes : IExtensible
	{

		[ProtoMember(1, Name = "guilds", DataFormat = DataFormat.Default)]
		public List<GCFGuildBrief> guilds
		{
			get
			{
				return this._guilds;
			}
		}

		[ProtoMember(2, Name = "JvDians", DataFormat = DataFormat.Default)]
		public List<GCFJvDianInfo> JvDians
		{
			get
			{
				return this._JvDians;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "lefttime", DataFormat = DataFormat.TwosComplement)]
		public uint lefttime
		{
			get
			{
				return this._lefttime ?? 0U;
			}
			set
			{
				this._lefttime = new uint?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool lefttimeSpecified
		{
			get
			{
				return this._lefttime != null;
			}
			set
			{
				bool flag = value == (this._lefttime == null);
				if (flag)
				{
					this._lefttime = (value ? new uint?(this.lefttime) : null);
				}
			}
		}

		private bool ShouldSerializelefttime()
		{
			return this.lefttimeSpecified;
		}

		private void Resetlefttime()
		{
			this.lefttimeSpecified = false;
		}

		[ProtoMember(4, IsRequired = false, Name = "mygroup", DataFormat = DataFormat.TwosComplement)]
		public int mygroup
		{
			get
			{
				return this._mygroup ?? 0;
			}
			set
			{
				this._mygroup = new int?(value);
			}
		}

		[XmlIgnore]
		[Browsable(false)]
		public bool mygroupSpecified
		{
			get
			{
				return this._mygroup != null;
			}
			set
			{
				bool flag = value == (this._mygroup == null);
				if (flag)
				{
					this._mygroup = (value ? new int?(this.mygroup) : null);
				}
			}
		}

		private bool ShouldSerializemygroup()
		{
			return this.mygroupSpecified;
		}

		private void Resetmygroup()
		{
			this.mygroupSpecified = false;
		}

		[ProtoMember(5, IsRequired = false, Name = "myinfo", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public GCFRoleBrief myinfo
		{
			get
			{
				return this._myinfo;
			}
			set
			{
				this._myinfo = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private readonly List<GCFGuildBrief> _guilds = new List<GCFGuildBrief>();

		private readonly List<GCFJvDianInfo> _JvDians = new List<GCFJvDianInfo>();

		private uint? _lefttime;

		private int? _mygroup;

		private GCFRoleBrief _myinfo = null;

		private IExtension extensionObject;
	}
}
