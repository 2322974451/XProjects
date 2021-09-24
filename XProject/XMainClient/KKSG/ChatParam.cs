using System;
using System.ComponentModel;
using ProtoBuf;

namespace KKSG
{

	[ProtoContract(Name = "ChatParam")]
	[Serializable]
	public class ChatParam : IExtensible
	{

		[ProtoMember(1, IsRequired = false, Name = "role", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamRole role
		{
			get
			{
				return this._role;
			}
			set
			{
				this._role = value;
			}
		}

		[ProtoMember(2, IsRequired = false, Name = "item", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamItem item
		{
			get
			{
				return this._item;
			}
			set
			{
				this._item = value;
			}
		}

		[ProtoMember(3, IsRequired = false, Name = "num", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamNum num
		{
			get
			{
				return this._num;
			}
			set
			{
				this._num = value;
			}
		}

		[ProtoMember(4, IsRequired = false, Name = "guild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamGuild guild
		{
			get
			{
				return this._guild;
			}
			set
			{
				this._guild = value;
			}
		}

		[ProtoMember(5, IsRequired = false, Name = "team", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamTeam team
		{
			get
			{
				return this._team;
			}
			set
			{
				this._team = value;
			}
		}

		[ProtoMember(6, IsRequired = false, Name = "link", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamLink link
		{
			get
			{
				return this._link;
			}
			set
			{
				this._link = value;
			}
		}

		[ProtoMember(7, IsRequired = false, Name = "spectate", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamSpectate spectate
		{
			get
			{
				return this._spectate;
			}
			set
			{
				this._spectate = value;
			}
		}

		[ProtoMember(8, IsRequired = false, Name = "dragonguild", DataFormat = DataFormat.Default)]
		[DefaultValue(null)]
		public ChatParamDragonGuild dragonguild
		{
			get
			{
				return this._dragonguild;
			}
			set
			{
				this._dragonguild = value;
			}
		}

		IExtension IExtensible.GetExtensionObject(bool createIfMissing)
		{
			return Extensible.GetExtensionObject(ref this.extensionObject, createIfMissing);
		}

		private ChatParamRole _role = null;

		private ChatParamItem _item = null;

		private ChatParamNum _num = null;

		private ChatParamGuild _guild = null;

		private ChatParamTeam _team = null;

		private ChatParamLink _link = null;

		private ChatParamSpectate _spectate = null;

		private ChatParamDragonGuild _dragonguild = null;

		private IExtension extensionObject;
	}
}
