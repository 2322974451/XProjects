using System;
using System.Collections.Generic;
using XUtliPoolLib;

namespace XMainClient
{

	internal class XBulletMgr : XSingleton<XBulletMgr>
	{

		public override bool Init()
		{
			this.m_BufferPool.Init(this.blockInit, 4);
			return true;
		}

		public void GetSmallBuffer(ref SmallBuffer<XBullet.XBulletTarget> sb, int size)
		{
			this.m_BufferPool.GetBlock(ref sb, size, 0);
		}

		public void ReturnSmallBuffer(ref SmallBuffer<XBullet.XBulletTarget> sb)
		{
			this.m_BufferPool.ReturnBlock(ref sb);
		}

		public XBullet GetBullet(XBulletMgr.KeyOfBullet id)
		{
			XBullet result = null;
			this._bullets_maps.TryGetValue(id, out result);
			return result;
		}

		public void Cache(XBulletMgr.KeyOfBullet id)
		{
			this._server_temp_bullets.Add(id);
		}

		public void ShootBullet(XBullet bullet)
		{
			XBulletMgr.KeyOfBullet keyOfBullet = new XBulletMgr.KeyOfBullet(bullet.BulletCore.FirerID, bullet.ID, bullet.ExtraID);
			bool flag = !this._bullets_maps.ContainsKey(keyOfBullet);
			if (flag)
			{
				this._bullets_maps.Add(keyOfBullet, bullet);
				this._bullets.Add(bullet);
				bool flag2 = this._server_temp_bullets.Contains(keyOfBullet);
				if (flag2)
				{
					bullet.OnResult(null);
				}
			}
			else
			{
				XSingleton<XDebug>.singleton.AddErrorLog("Duplicated Bullet id ", bullet.ID.ToString(), null, null, null, null);
			}
		}

		public void LogEndFx(XFx bullet)
		{
			this._bullets_end_fx.Add(bullet);
			bullet.callback = new OnFxDestroyed(this.UnLogEndFx);
		}

		public void Update(float fDeltaT)
		{
			int count = this._bullets.Count;
			for (int i = count - 1; i >= 0; i--)
			{
				XBullet xbullet = this._bullets[i] as XBullet;
				xbullet.Update(fDeltaT);
				bool flag = xbullet.IsExpired();
				if (flag)
				{
					XBulletMgr.KeyOfBullet keyOfBullet = new XBulletMgr.KeyOfBullet(xbullet.BulletCore.FirerID, xbullet.ID, xbullet.ExtraID);
					xbullet.Destroy(false);
					this._server_temp_bullets.Remove(keyOfBullet);
					this._bullets_maps.Remove(keyOfBullet);
					this._bullets.RemoveAt(i);
					bool flag2 = false;
					int j = 0;
					int count2 = this._bulletsCache.Count;
					while (j < count2)
					{
						bool flag3 = this._bulletsCache[j] == null;
						if (flag3)
						{
							this._bulletsCache[j] = xbullet;
							flag2 = true;
							break;
						}
						j++;
					}
					bool flag4 = !flag2;
					if (flag4)
					{
						this._bulletsCache.Add(xbullet);
					}
				}
			}
		}

		public XBullet CreateBullet(ulong bulletid, long token, XEntity firer, XEntity target, XSkillCore core, XResultData data, uint id, int diviation, bool demonstration, int wid)
		{
			int i = 0;
			int count = this._bulletsCache.Count;
			while (i < count)
			{
				XBullet xbullet = this._bulletsCache[i] as XBullet;
				bool flag = xbullet != null;
				if (flag)
				{
					xbullet.Init(bulletid, new XBulletCore(token, firer, target, core, data, id, diviation, demonstration, wid));
					this._bulletsCache[i] = null;
					return xbullet;
				}
				i++;
			}
			return new XBullet(bulletid, new XBulletCore(token, firer, target, core, data, id, diviation, demonstration, wid));
		}

		public void OnEnterScene()
		{
			this._bullets_end_fx.debugName = "XBulletMgr._bullets_end_fx";
			this._bullets.debugName = "XBulletMgr._bullets";
			this._bulletsCache.debugName = "XBulletMgr._bulletsCache";
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._bullets_end_fx, 256, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._bullets, 16, 0);
			XSingleton<BufferPoolMgr>.singleton.GetSmallBuffer(ref this._bulletsCache, 16, 0);
		}

		public void OnLeaveScene()
		{
			this.ClearBullets();
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._bullets_end_fx);
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._bullets);
			XSingleton<BufferPoolMgr>.singleton.ReturnSmallBuffer(ref this._bulletsCache);
		}

		public void OnLeaveStage()
		{
			this.ClearBullets();
		}

		public void ClearBullets(ulong hostid)
		{
			for (int i = this._bullets.Count - 1; i >= 0; i--)
			{
				XBullet xbullet = this._bullets[i] as XBullet;
				bool flag = xbullet != null && xbullet.BulletCore.FirerID == hostid;
				if (flag)
				{
					xbullet.Expire();
					xbullet.Deny();
				}
			}
		}

		public void ClearBullets()
		{
			for (int i = this._bullets.Count - 1; i >= 0; i--)
			{
				XBullet xbullet = this._bullets[i] as XBullet;
				xbullet.Destroy(true);
			}
			this._bullets.Clear();
			this._bullets_maps.Clear();
			this._server_temp_bullets.Clear();
			for (int j = this._bullets_end_fx.Count - 1; j >= 0; j--)
			{
				XFx fx = this._bullets_end_fx[j] as XFx;
				XSingleton<XFxMgr>.singleton.DestroyFx(fx, true);
			}
			this._bullets_end_fx.Clear();
		}

		public void UnLogEndFx(XFx fx)
		{
			this._bullets_end_fx.Remove(fx);
		}

		private SmallBufferPool<XBullet.XBulletTarget> m_BufferPool = new SmallBufferPool<XBullet.XBulletTarget>();

		public BlockInfo[] blockInit = new BlockInfo[]
		{
			new BlockInfo(4, 128),
			new BlockInfo(8, 512)
		};

		private HashSet<XBulletMgr.KeyOfBullet> _server_temp_bullets = new HashSet<XBulletMgr.KeyOfBullet>();

		private SmallBuffer<object> _bullets;

		private SmallBuffer<object> _bulletsCache;

		private Dictionary<XBulletMgr.KeyOfBullet, XBullet> _bullets_maps = new Dictionary<XBulletMgr.KeyOfBullet, XBullet>();

		private SmallBuffer<object> _bullets_end_fx;

		internal struct KeyOfBullet : IEqualityComparer<XBulletMgr.KeyOfBullet>
		{

			public KeyOfBullet(ulong h, ulong s, ulong t)
			{
				this.host = h;
				this.self = s;
				this.target = t;
			}

			public bool Equals(XBulletMgr.KeyOfBullet x, XBulletMgr.KeyOfBullet y)
			{
				return x.host == y.host && x.self == y.self && x.target == y.target;
			}

			public int GetHashCode(XBulletMgr.KeyOfBullet obj)
			{
				return (int)obj.host | (int)obj.self << 24;
			}

			public ulong self;

			public ulong host;

			public ulong target;
		}
	}
}
