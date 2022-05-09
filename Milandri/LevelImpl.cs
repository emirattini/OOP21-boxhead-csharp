using System.Collections.Generic;

namespace boxhead.model.level
{
	using Point2D = javafx.geometry.Point2D;
	using Wall = boxhead.model.entities.Wall;
	/// <summary>
	/// Implementation of <seealso cref="Level"/>
	/// </summary>
	public class LevelImpl : Level
	{
		private readonly IDictionary<Point2D, int?> blocks;
		private readonly IList<Wall> walls;
		private readonly ISet<Point2D> ammoSpawns;
		private readonly ISet<Point2D> zombieSpawns;
		private readonly double width;
		private readonly double height;
		private readonly double tileSize;
		/// <summary>
		/// Constructor of the level.
		/// </summary>
		/// <param name="blocks"> </param>
		/// <param name="width"> </param>
		/// <param name="height"> </param>
		/// <param name="tileSize"> </param>

		public LevelImpl(IDictionary<Point2D, int?> blocks, double width, double height, double tileSize)
		{
			this.blocks = blocks;
			this.walls = new LinkedList<>();
			this.ammoSpawns = new HashSet<>();
			this.zombieSpawns = new HashSet<>();
			this.width = width;
			this.height = height;
			this.tileSize = tileSize;
			loadObjects();
		}
		/// <summary>
		/// Internal method to load all the objects.
		/// </summary>
		private void loadObjects()
		{
			blocks.forEach((point, id) =>
			{
				switch (id)
				{
					case 2:
						this.walls.Add(new Wall(new Point2D(point.X * tileSize, point.Y * tileSize)));
						break;
					case 3:
						this.zombieSpawns.Add(new Point2D(point.X * tileSize, point.Y * tileSize));
						break;
					case 4:
						this.ammoSpawns.Add(new Point2D(point.X * tileSize, point.Y * tileSize));
						break;
					case 1:
						break;
				}
			});
		}
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override IDictionary<Point2D, int?> Blocks
		{
			get
			{
				return blocks;
			}
		}
		/// <summary>
		/// {@inheritDoc}
		/// </summary>
		public override IList<Wall> Walls
		{
			get
			{
				return this.walls;
			}
		}
        public override ISet<Point2D> AmmoSpawnPoints
	{
		get
		{
			return this.ammoSpawns;
		}
	}
	/// <summary>
	/// {@inheritDoc}
	/// </summary>
	public override ISet<Point2D> ZombieSpawnPoints
	{
		get
		{
			return this.zombieSpawns;
		}
	}
	/// <summary>
	/// {@inheritDoc}
	/// </summary>
	public override double Width
	{
		get
		{
			return width;
		}
	}
	/// <summary>
	/// {@inheritDoc}
	/// </summary>
	public override double Height
	{
		get
		{
			return height;
		}
	}
	/// <summary>
	/// {@inheritDoc}
	/// </summary>
	public override double TileSize
    {
		get
		{
			return tileSize;
		}
	}
}


