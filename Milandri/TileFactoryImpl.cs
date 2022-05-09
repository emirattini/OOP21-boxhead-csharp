using System.Collections.Generic;

namespace boxhead.view.world.tile
{


	using Point2D = javafx.geometry.Point2D;
	using SnapshotParameters = javafx.scene.SnapshotParameters;
	using Image = javafx.scene.image.Image;
	using ImageView = javafx.scene.image.ImageView;
	using Color = javafx.scene.paint.Color;

	public class TileFactoryImpl : TileFactory
	{
		private double tileSize;
		private TileSet tiles;

		/// <summary>
		/// Constructor, URL of the image for TileSet, size of the tile in the image
		/// </summary>
		/// <param name="url"> </param>
		/// <param name="s"> </param>


		public TileFactoryImpl(double s)
		{
			this.tileSize = s;
			this.tiles = new TileSetImpl(this.tileSize);
		}


		public override double TileSize
		{
			set
			{
				tileSize = value;
			}
		}


		public override Tile createTile(int t, Point2D pos, double s)
		{

			return new TileAnonymousInnerClassHelper(this, t, pos, s);
		}

		private class TileAnonymousInnerClassHelper : Tile
		{
			private readonly TileFactoryImpl outerInstance;

			private int t;
			private Point2D pos;
			private double s;

			public TileAnonymousInnerClassHelper(TileFactoryImpl outerInstance, int t, Point2D pos, double s)
			{
				this.outerInstance = outerInstance;
				this.t = t;
				this.pos = pos;
				this.s = s;
				img = new ImageView();
				sP = new SnapshotParameters();
				p = pos;
				size = s;
				scale = 1.0;
			}


			private ImageView img;
			private SnapshotParameters sP;
			private Point2D p;
			private double size;
			private double scale;

			public override Image Tile
			{
				get
				{
					this.img.Image = outerInstance.tiles.getTile(t);
					return this.img.snapshot(sP, null);
				}
			}

			public override double Size
			{
				get
				{
					return this.size * scale;
				}
			}


			public override double RenderScale
			{
				set
				{
					this.scale = value;
					sP.Fill = Color.TRANSPARENT;
					this.img.FitHeight = s * value;
					this.img.FitWidth = s * value;
    
				}
				get
				{
					return this.scale;
				}
			}


			public override Point2D RelativePos
			{
				get
				{
					return this.p.multiply(Size);
				}
			}

			public override Point2D Pos
			{
				get
				{
					return this.p;
				}
			}

			public override double X
			{
				get
				{
					return this.p.X;
				}
			}

			public override double Y
			{
				get
				{
					return this.p.Y;
				}
			}

		}

		public override ISet<Tile> createTiles(IDictionary<Point2D, int?> tile, double s)
		{
			return tile.SetOfKeyValuePairs().stream(). <Tile> map(e => createTile(e.Value, e.Key, s)).collect(Collectors.toSet());
		}

	}
}

using System.Collections.Generic;
internal static class HashMapHelperClass
{
	internal static HashSet<KeyValuePair<TKey, TValue>> SetOfKeyValuePairs<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
	{
		HashSet<KeyValuePair<TKey, TValue>> entries = new HashSet<KeyValuePair<TKey, TValue>>();
		foreach (KeyValuePair<TKey, TValue> keyValuePair in dictionary)
		{
			entries.Add(keyValuePair);
		}
		return entries;
	}

	internal static TValue GetValueOrNull<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
	{
		TValue ret;
		dictionary.TryGetValue(key, out ret);
		return ret;
	}
}
