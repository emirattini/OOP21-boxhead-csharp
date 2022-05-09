using System.Collections.Generic;

namespace boxhead.controller.entities
{


	using Ammo = boxhead.model.entities.gun.Ammo;
	using AmmoSpawn = boxhead.model.entities.gun.AmmoSpawn;
	using AmmoSpawnImpl = boxhead.model.entities.gun.AmmoSpawnImpl;
	using AmmoView = boxhead.view.entities.AmmoView;
	using BoundingBox = javafx.geometry.BoundingBox;
	using Point2D = javafx.geometry.Point2D;

	/// <summary>
	/// Implementation of <seealso cref="AmmoController"/>.
	/// </summary>
	public class AmmoControllerImpl : AmmoController
	{

		private readonly AmmoSpawn spawn;
		private readonly IDictionary<Ammo, AmmoView> ammoActive;

		/// <summary>
		/// Constructor that takes all the ammoSpawnPoints. </summary>
		/// <param name="ammoSpawnPoints"> </param>
		public AmmoControllerImpl(ISet<Point2D> ammoSpawnPoints)
		{
			this.spawn = new AmmoSpawnImpl();
			this.spawn.AmmoSpawnPoints = ammoSpawnPoints;
			this.ammoActive = new Dictionary<>();
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override ISet<BoundingBox> Ammos
		{
			get
			{
				return this.ammoActive.Keys.stream().map(a => a.BoundingBox).collect(Collectors.toSet());
			}
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>

		public override void removeAmmo(BoundingBox ammoBB)
		{
			Ammo ammo = this.ammoActive.Keys.stream().filter(a => a.BoundingBox.Equals(ammoBB)).findFirst().get();
			this.ammoActive.Remove(ammo, this.ammoActive[ammo]);
			this.spawn.removeAmmo(ammo);
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override void update()
		{
			this.spawn.update();
			this.spawn.AmmoActive.forEach(a =>
			{
				if (!(this.ammoActive.ContainsKey(a)))
				{
					this.ammoActive[a] = new AmmoView();
				}
			});
		}

		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override IDictionary<Ammo, AmmoView> AmmoView
		{
			get
			{
				return this.ammoActive;
			}
		}

	}
}
